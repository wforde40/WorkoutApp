using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UiChallengeWorkoutApp.MobileAppService.Models;
using Dapper;
using System;
using System.Linq;
using System.Diagnostics;

namespace UiChallengeWorkoutApp.MobileAppService.Models
{
    public class WorkoutRepository : IWorkoutRepository
    {

        private readonly IConfiguration _config;

        public IDbConnection Connection
        {
            get => new SqlConnection(_config.GetConnectionString("WorkoutDb"));
        }

        public WorkoutRepository(IConfiguration configuration) =>
            (_config) = (configuration);

        public void Add(Workout add)
        {
            using (var conn = Connection)
            {
                var insertSql = "insert into Workout (Name, Description) values (@Name, @Description)";
                conn.Execute(insertSql, add);
            }
        }

        public void Update(Workout update)
        {
            using (var conn = Connection)
            {
                var updateSql = "Update Workout set Name = @Name, Description = @Description where id = @Id";
                conn.Execute(updateSql, update);
            }
        }

        public Workout Remove(int id)
        {
            using (var conn = Connection)
            {
                var removeSql = "Delete from workout output deleted.* where id = @id";
                return conn.QueryFirstOrDefault<Workout>(removeSql, new { id });
            }
        }

        public Workout Get(int id)
        {

            using (var conn = Connection)
            {
                var getWorkoutSql = "select * from Workout where Id = @id";
                var workout = conn.QueryFirstOrDefault<Workout>(getWorkoutSql, new { id });

                if (workout is null)
                    return default;

                var getExercisesSql = @"Select e.* from workouts w
                                            Join exercise e on w.ExerciseId = e.Id
                                            Where w.WorkoutID = @id";
                workout.Exercises = conn.Query<Exercise>(getExercisesSql, new { id });

                return workout;
            }

        }
        public IEnumerable<Workout> GetAll()
        {
            using (var conn = Connection)
            {
                var getAllSql = "Select * from workout";
                return conn.Query<Workout>(getAllSql);
            }
        }

        public Workout GetRandom(string category, string type)
        {

            try
            {
                var rand = new Random();

                var sql = @"select  w.id from Workout w 
	                        join WorkoutCategories wc on w.Id = wc.WorkoutID
	                        join Categories c on wc.CategoryID = c.Id 
	                        join WorkoutTypes wt on w.Id = wt.WorkoutID
	                        join WorkoutType t on wt.TypeID = t.id
                            where c.Name = @category and t.name = @type";

                using (var conn = Connection)
                {
                    var workoutIds = conn.Query<int>(sql, new { category, type });

                    if (workoutIds.Count() <= 0) { return null; }

                    var id = rand.Next(workoutIds.Min(), workoutIds.Max() + 1);


                    return Get(id);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            return null;
        }

        public IEnumerable<WorkoutCategory> GetCategories()
        {
            using (var conn = Connection)
            {
                var getCategoriesSql = "Select * from Categories";
                return conn.Query<WorkoutCategory>(getCategoriesSql);
            }
        }

        public IEnumerable<WorkoutType> GetTypes()
        {
            using (var conn = Connection)
            {
                var getTypesSql = "Select * from workoutType";
                return conn.Query<WorkoutType>(getTypesSql);
            }
        }

        public IEnumerable<CompletedWorkout> GetCompletedWorkouts(int id, DateTime startDate, DateTime endDate)
        {
            using (var conn = Connection)
            {
                var getCompletedWorkoutsSql = @" Select * from CompletedWorkouts where id in (
                                                Select max(id) From CompletedWorkouts 
                                                where userId = @id and dateCompleted between @startDate and @endDate
                                                group by cast(dateCompleted as Date))";
                return conn.Query<CompletedWorkout>(getCompletedWorkoutsSql, new { id, startDate, endDate});

                



            }
        }

        public CompletedWorkout AddCompletedWorkout(CompletedWorkout value)
        {
            using (var conn = Connection)
            {
                var insertCompletedWorkout = @"Insert into CompletedWorkouts
                                                (WorkoutID, UserID, DateCompleted)
                                                output inserted.* 
                                                values (@WorkoutID, @UserID, @DateCompleted)";
                return conn.Query<CompletedWorkout>(insertCompletedWorkout, 
                    new 
                    { 
                        value.WorkoutID,
                        value.UserID,
                        value.DateCompleted,
                    }).Single();
            }
        }
    }
}
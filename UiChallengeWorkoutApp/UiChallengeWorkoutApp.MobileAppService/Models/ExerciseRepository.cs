using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace UiChallengeWorkoutApp.MobileAppService.Models
{
    public class ExerciseRepository : IExerciseRepository
    {

        private readonly IConfiguration _config;

        public IDbConnection Connection
        {
            get => new SqlConnection(_config.GetConnectionString("WorkoutDb"));
        }

        public ExerciseRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void Add(Exercise exercise)
        {
            using(IDbConnection conn = Connection)
            {
                var sql = "Insert into Exercise (Name, Repetitions) Values (@Name, @Repetitions)";
                conn.Query(sql, exercise);
            }
        }

        public IEnumerable<Exercise> GetWorkout(int id)
        {
            using (IDbConnection conn = Connection)
            {
                var sql = "select * from Workouts where WorkoutID = @id";
                return conn.Query<Exercise>(sql, new { id });
            }
        }

        public Exercise Get(int id)
        {
            using(IDbConnection conn = Connection)
            { 

                var sql = "Select * from Exercise where ID = @id";
                return conn.Query<Exercise>(sql, new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Exercise> GetAll()
        {
            using(IDbConnection conn = Connection)
            {
                var sql = "Select * from Exercise";
                return conn.Query<Exercise>(sql);
            }
        }

        public Exercise Remove(int id)
        {
            using(IDbConnection connection = Connection)
            {
                var sql = "Delete from Exercises  Output deleted.* where ID = @id";
                return connection.Query<Exercise>(sql, new { id }).FirstOrDefault();
            }
        }

        public void Update(Exercise exercise)
        {
            using(IDbConnection connection = Connection)
            {
                var sql = "Update Exercise set Name = @Name, Repetitions = @Repetitions where ID = @id";
                connection.Query(sql, exercise);
            }
        }
    }
}

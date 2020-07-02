using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UiChallengeWorkoutApp.MobileAppService.Models;
using UiChallengeWorkoutApp.Models;
using Xamarin.Essentials;
using System.Text.Json;

namespace UiChallengeWorkoutApp.Services
{
    class ExerciseDatastore : IExerciseDataStore
    {
        private HttpClient client;
        private IEnumerable<Exercise> exercises;

        private bool IsConnected => Connectivity.NetworkAccess != NetworkAccess.Internet;

        public ExerciseDatastore()
        {
            var handler = GetInsecureHandler();
            client = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://10.0.2.2:5000"),
               
            };
        }

        public HttpClientHandler GetInsecureHandler()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        public async Task<bool> AddAsync(Exercise item)
        {
            if (item is null || !IsConnected)
                return false;

            var serializedExercise = JsonConvert.SerializeObject(item); 
            var message = await client.PostAsync("api/exercise/", new StringContent(serializedExercise, Encoding.UTF8, "application/json"));

            return message.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var message = await client.DeleteAsync($"api/exercise/{id}");
            return message.IsSuccessStatusCode;
        }

        public async Task<Workout> GetAsync(int id)
        {

            var json = await client.GetStringAsync($"api/workout/{id}");
            var workout = await Task.Run(() => JsonConvert.DeserializeObject<Workout>(json));
           

            return workout;
        }

        public async Task<Workout> GetRandomAsync(string category, string type)
        {

            try
            {
                var response = await client.GetAsync($"api/workout/random?category={category}&type={type}");
                var test = await response.Content.ReadAsStringAsync();

                var workout = await Task.Run(() => JsonConvert.DeserializeObject<Workout>(test));
                return workout;
            }
            catch(Exception ex)
            {
                return null;
            }           
        }

       
        public async Task<IEnumerable<Exercise>> GetAsync(bool forceRefresh = false)
        {
            var json = await client.GetStringAsync($"api/exercise");
            exercises = JsonConvert.DeserializeObject<IEnumerable<Exercise>>(json);
            return exercises;
        }

        public Exercise Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Exercise>> Get(bool forceRefresh = false)
        {

            var json = await client.GetStringAsync($"api/exercise");
            exercises = JsonConvert.DeserializeObject<IEnumerable<Exercise>>(json);
            return exercises;
        }

        public async Task<bool> UpdateAsync(Exercise item)
        {
            if (item is null || !IsConnected)
                return false;

            var serializedExercise = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedExercise);
            var bytes = new ByteArrayContent(buffer);

            var response =  await client.PutAsync("api/exercise", bytes);

            return response.IsSuccessStatusCode;
            

        }

        public async Task<IEnumerable<WorkoutCategory>> GetCategories()
        {
            try
            {

                var json = await client.GetStringAsync("api/workout/categories");
                var categories = JsonConvert.DeserializeObject<IEnumerable<WorkoutCategory>>(json);

                return categories;
            }
            catch(HttpRequestException ex)
            {
                //Logger gonna log
                return null;
            }
        }

        public async Task<IEnumerable<WorkoutType>> GetTypes()
        {
            try
            {
                var json = await client.GetStringAsync("api/workout/types");
                var results = JsonConvert.DeserializeObject<IEnumerable<WorkoutType>>(json);
                return results;
            }
            catch(HttpRequestException ex)
            {
                // Logger gonna log
                return null;
            }
        }

        public async Task<IEnumerable<WorkoutDayData>> GetCompletedWorkouts(CompletedWorkoutArgs args)
        {
            try
            {
                var json = await client.GetStringAsync($"api/Workout/Completed/{args.Id}");
                var results = JsonConvert.DeserializeObject<IEnumerable<WorkoutDayData>>(json);
               
                foreach (var result in results) 
                { 
                    result.Done = true; 
                } 

                return results;
            }
            catch(Exception ex)
            {
                // Logger gonna log
                return null;
            }
        }

        public async Task<WorkoutDayData> AddCompletedWorkout(WorkoutDayData data)
        {

            var jsonObject = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

            var results =  await client.PostAsync($"api/workout/completed/{data.UserID}/", content);

            if (results.IsSuccessStatusCode)
            {
                var resultString = await results.Content.ReadAsStringAsync();
                var resultData = JsonConvert.DeserializeObject<WorkoutDayData>(resultString);

                return resultData;
            }
            else
            {
                throw new Exception();
            }


        }
    }
}

using System;  
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;  
using System.Net.Http.Headers;  
  
namespace EventManagement.Models
{
    public class TaskDetailClient
    {
        private string Base_URL = "http://localhost:62963/api/";

        public IEnumerable<TaskDetails> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("TaskDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TaskDetails>>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else //web api sent error response 
                {
                    return Enumerable.Empty<TaskDetails>();
                }
            }
            catch
            {
                return null;
            }
        }
        public TaskDetails find(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("TaskDetails/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<TaskDetails>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Create(TaskDetails customer)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("TaskDetails", customer).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(TaskDetails taskDetails)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("TaskDetails/" + taskDetails.Task_ID, taskDetails).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("TaskDetails/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }

}
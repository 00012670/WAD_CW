using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using HabitTracker.Models;
using System.Threading.Tasks;
using System.Text;

namespace HabitTracker.Controllers
{
    public class HabitController : Controller
    {
        // The Definition of Base URL
        public const string baseUrl = "http://localhost:47547/";
        Uri ClientBaseAddress = new Uri(baseUrl);
        HttpClient clnt;

        // Constructor for initiating request to the given base URL publicly
        public HabitController()
        {
            clnt = new HttpClient();
            clnt.BaseAddress = ClientBaseAddress;
        }

        public void HeaderClearing()
        {
            // Clearing default headers
            clnt.DefaultRequestHeaders.Clear();

            // Define the request type of the data
            clnt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // GET: Habit
        public async Task<ActionResult> Index()
        {
            //// Creating the list of new Habits list
            List<Habit> HabitInfo = new List<Habit>();

            HeaderClearing();

            // Sending Request to the find web api Rest service resources using HTTPClient
            HttpResponseMessage httpResponseMessage = await clnt.GetAsync("api/Habit");

            // If the request is success
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                // storing the web api data into model that was predefined prior
                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;

                HabitInfo = JsonConvert.DeserializeObject<List<Habit>>(responseMessage);
            }
            return View(HabitInfo);
        }


        // POST: HabitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Habit habit)
        {
            habit.HabitProgress = new Progress { ID = habit.HabitId };
            if (ModelState.IsValid)
            {
                string createHabitInfo = JsonConvert.SerializeObject(habit);

                // creating string content to pass as Http content later
                StringContent stringContentInfo = new StringContent(createHabitInfo, Encoding.UTF8, "application/json");

                // Making a Post request
                HttpResponseMessage createHttpResponseMessage = clnt.PostAsync(clnt.BaseAddress + "api/Habit/", stringContentInfo).Result;
                if (createHttpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(habit);
        }

        // GET: Habit/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: HabitController/Details/5
        public ActionResult Details(int id)
        {
            //Creating a Get Request to get single Habit
            Habit habitDetails = new Habit();

            HeaderClearing();

            // Creating a get request after preparation of get URL and assignin the results

            HttpResponseMessage httpResponseMessageDetails = clnt.GetAsync(clnt.BaseAddress + "api/Habit/" + id).Result;

            // Checking for response state
            if (httpResponseMessageDetails.IsSuccessStatusCode)
            {
                // storing the response details received from web api 
                string detailsInfo = httpResponseMessageDetails.Content.ReadAsStringAsync().Result;

                // deserializing the response
                habitDetails = JsonConvert.DeserializeObject<Habit>(detailsInfo);
            }
            return View(habitDetails);
        }


        // GET: HabitController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //Creating a Get Request to get single Habit
            Habit habitDetails = new Habit();

            HeaderClearing();

            // Creating a get request after preparation of get URL and assignin the results

            HttpResponseMessage httpResponseMessageDetails = await clnt.GetAsync(clnt.BaseAddress + "api/Habit/" + id);

            // Checking for response state
            if (httpResponseMessageDetails.IsSuccessStatusCode)
            {
                // storing the response details received from web api 
                string detailsInfo = httpResponseMessageDetails.Content.ReadAsStringAsync().Result;

                // deserializing the response
                habitDetails = JsonConvert.DeserializeObject<Habit>(detailsInfo);
            }
            return View(habitDetails);
        }


        // POST: HabitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Habit habit)
        {
            habit.HabitProgress = new Progress { ID = habit.HabitId };
            if (ModelState.IsValid)
            {
                // serializing habit object into json format to send
                string editHabitInfo = JsonConvert.SerializeObject(habit);

                // creating string content to pass as Http content later
                StringContent stringContentInfo = new StringContent(editHabitInfo, Encoding.UTF8, "application/json");

                // Making a Put request
                HttpResponseMessage editHttpResponseMessage = await clnt.PutAsync(clnt.BaseAddress + "api/Habit/" + id, stringContentInfo);
                if (editHttpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(habit);
        }

        // GET: HabitController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //Creating a Get Request to get single Habit
            Habit habitDetails = new Habit();

            HeaderClearing();

            // Creating a get request after preparation of get URL and assignin the results

            HttpResponseMessage httpResponseMessageDetails = await clnt.GetAsync(clnt.BaseAddress + "api/Habit/" + id);

            // Checking for response state
            if (httpResponseMessageDetails.IsSuccessStatusCode)
            {
                // storing the response details received from web api 
                string detailsInfo = httpResponseMessageDetails.Content.ReadAsStringAsync().Result;

                // deserializing the response
                habitDetails = JsonConvert.DeserializeObject<Habit>(detailsInfo);
            }
            return View(habitDetails);
        }

        // POST: HabitController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage httpResponseMessage = await clnt.DeleteAsync(clnt.BaseAddress + "api/Habit/" + id);

            //Checking the response is successful or not which is sent using HttpClient  
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

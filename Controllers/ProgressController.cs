using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using HabitTracker.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;

namespace HabitTracker.Controllers
{
    public class ProgressController : Controller
    {
        // The Definition of Base URL
        public const string baseUrl = "http://localhost:47547/";
        Uri ClientBaseAddress = new Uri(baseUrl);
        HttpClient clnt;

        // Constructor for initiating request to the given base URL publicly
        public ProgressController()
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

        // GET: Progress
        public async Task<ActionResult> Index()
        {
            // Creating the list of new Progress list
            List<Progress> ProgressInfo = new List<Progress>();

            HeaderClearing();

            // Sending Request to the find web api Rest service resources using HTTPClient
            HttpResponseMessage httpResponseMessage = await clnt.GetAsync("api/Progress");

            // If the request is success
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                // storing the web api data into model that was predefined prior
                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;

                ProgressInfo = JsonConvert.DeserializeObject<List<Progress>>(responseMessage);
            }
            return View(ProgressInfo);
        }

        // POST: ProgressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Progress progress)
        {
            progress.Progresses = new Progress { ID = progress.ProgressId };
            if (ModelState.IsValid)
            {
                string createProgressInfo = JsonConvert.SerializeObject(progress);

                // creating string content to pass as Http content later
                StringContent stringContentInfo = new StringContent(createProgressInfo, Encoding.UTF8, "application/json");

                // Making a Post request
                HttpResponseMessage createHttpResponseMessage = clnt.PostAsync(clnt.BaseAddress + "api/Progress/", stringContentInfo).Result;
                if (createHttpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(progress);
        }

        // GET: Habit/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: ProgressController/Details/5
        public ActionResult Details(int id)
        {
            //Creating a Get Request to get single Progress
            Progress progressDetails = new Progress();

            HeaderClearing();

            // Creating a get request after preparation of get URL and assignin the results

            HttpResponseMessage httpResponseMessageDetails = clnt.GetAsync(clnt.BaseAddress + "api/Progress/" + id).Result;

            // Checking for response state
            if (httpResponseMessageDetails.IsSuccessStatusCode)
            {
                // storing the response details received from web api 
                string detailsInfo = httpResponseMessageDetails.Content.ReadAsStringAsync().Result;

                // deserializing the response
                progressDetails = JsonConvert.DeserializeObject<Progress>(detailsInfo);
            }
            return View(progressDetails);
        }

        // GET: ProgressController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //Creating a Get Request to get single Progress
            Progress progressDetails = new Progress();

            HeaderClearing();

            // Creating a get request after preparation of get URL and assignin the results

            HttpResponseMessage httpResponseMessageDetails = await clnt.GetAsync(clnt.BaseAddress + "api/Progress/" + id);

            // Checking for response state
            if (httpResponseMessageDetails.IsSuccessStatusCode)
            {
                // storing the response details received from web api 
                string detailsInfo = httpResponseMessageDetails.Content.ReadAsStringAsync().Result;

                // deserializing the response
                progressDetails = JsonConvert.DeserializeObject<Progress>(detailsInfo);
            }
            return View(progressDetails);
        }

        // POST: ProgressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Progress progress)
        {
            progress.Progresses = new Progress { ID = progress.ProgressId };
            if (ModelState.IsValid)
            {
                // serializing progress object into json format to send
                string editProgressInfo = JsonConvert.SerializeObject(progress);

                // creating string content to pass as Http content later
                StringContent stringContentInfo = new StringContent(editProgressInfo, Encoding.UTF8, "application/json");

                // Making a Put request
                HttpResponseMessage editHttpResponseMessage = await clnt.PutAsync(clnt.BaseAddress + "api/Progress/" + id, stringContentInfo);
                if (editHttpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(progress);
        }


        // GET: ProgressController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //Creating a Get Request to get single Progress
            Progress progressDetails = new Progress();

            HeaderClearing();

            // Creating a get request after preparation of get URL and assignin the results

            HttpResponseMessage httpResponseMessageDetails = await clnt.GetAsync(clnt.BaseAddress + "api/Progress/" + id);

            // Checking for response state
            if (httpResponseMessageDetails.IsSuccessStatusCode)
            {
                // storing the response details received from web api 
                string detailsInfo = httpResponseMessageDetails.Content.ReadAsStringAsync().Result;

                // deserializing the response
                progressDetails = JsonConvert.DeserializeObject<Progress>(detailsInfo);
            }
            return View(progressDetails);
        }

        // POST: ProgressController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage httpResponseMessage = await clnt.DeleteAsync(clnt.BaseAddress + "api/Progress/" + id);

            //Checking the response is successful or not which is sent using HttpClient  
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

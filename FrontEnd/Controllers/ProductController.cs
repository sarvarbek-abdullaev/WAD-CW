using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using Library.models;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class ProductController : Controller
    {
        // The Definition of Base URL
        public const string baseUrl = "http://localhost:13413/";
        Uri ClientBaseAddress = new Uri(baseUrl);
        HttpClient clnt;


        // Constructor for initiating request to the given base URL publicly
        public ProductController()
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


        // GET: Product
        public async Task<ActionResult> Index()
        {


            //// Creating the list of new Product list
            List<Product> ProductInfo = new List<Product>();


            HeaderClearing();

            // Sending Request to the find web api Rest service resources using HTTPClient
            HttpResponseMessage httpResponseMessage = await clnt.GetAsync("api/Product");

            // If the request is success
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                // storing the web api data into model that was predefined prior
                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;

                ProductInfo = JsonConvert.DeserializeObject<List<Product>>(responseMessage);
            }
            return View(ProductInfo);

        }



        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            //Creating a Get Request to get single Product
            Product productDetails = new Product();

            HeaderClearing();

            // Creating a get request after preparation of get URL and assignin the results

            HttpResponseMessage httpResponseMessageDetails = clnt.GetAsync(clnt.BaseAddress + "api/Product/" + id).Result;

            // Checking for response state
            if (httpResponseMessageDetails.IsSuccessStatusCode)
            {
                // storing the response details received from web api 
                string detailsInfo = httpResponseMessageDetails.Content.ReadAsStringAsync().Result;

                // deserializing the response
                productDetails = JsonConvert.DeserializeObject<Product>(detailsInfo);
            }
            return View(productDetails);
        }



        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            product.ProductCategory = new Category { ID = product.ProductCategoryId };
            if (ModelState.IsValid)
            {
                // serializing product object into json format to send
                /*string jsonObject = "{"+product."}"*/
                ;
                string createProductInfo = JsonConvert.SerializeObject(product);

                // creating string content to pass as Http content later
                StringContent stringContentInfo = new StringContent(createProductInfo, Encoding.UTF8, "application/json");

                // Making a Post request
                HttpResponseMessage createHttpResponseMessage = clnt.PostAsync(clnt.BaseAddress + "api/Product/", stringContentInfo).Result;
                if (createHttpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(product);

        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

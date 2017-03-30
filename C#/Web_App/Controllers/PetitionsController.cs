using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Text;
using Web_App.Models;

namespace Web_App.Controllers
{
    public class PetitionsController : Controller
    {
        public ActionResult Index()
        {
            Petition obj = new Petition();
            return View(obj);
        }

        //public ActionResult SendPetition(Petition petition)
        //{
        //    return View("PetitionResult", _SendPeticion(petition).Result);
        //}

        //private async Task<Guid> _SendPeticion(Petition petition)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://main-api.azurewebsites.net");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = await client.PostAsJsonAsync("/api/Peticiones/SetPeticion", petition);

        //    if (null != response && response.IsSuccessStatusCode)
        //    {
        //        return response.Content.ReadAsAsync<Guid>().Result;
        //    }

        //    return new Guid();
        //}


        public async Task SendPetition(Petition petition)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://main-api.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/Peticiones/SetPeticion", petition);
        }

        //public async Task GetGuidModel()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://main-api.azurewebsites.net");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    HttpResponseMessage response = null;

        //    try
        //    {
        //        response = await client.GetAsync(_isAlive);
        //    }

        //    catch (Exception ex)
        //    {
        //        item.isAlive = false;
        //    }

        //    if (null != response && response.IsSuccessStatusCode)
        //    {
        //        var respond = response.Content.ReadAsAsync<Guid>();
        //    }
        //}
    }
}

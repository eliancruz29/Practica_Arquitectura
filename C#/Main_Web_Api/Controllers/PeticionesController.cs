using Main_Web_Api.Models;
using Main_Web_Api.Secundary_Service;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Main_Web_Api.Controllers
{
    public class PeticionesController : ApiController
    {
        private ModelDbContext db = new ModelDbContext();

        //  protocol://domain:port/api/Peticiones/SetPeticion
        [HttpPost]
        [ActionName("SetPeticion")]
        public async Task<IHttpActionResult> SetPeticion(PeticionDTO model)
        {
            var _guid = Guid.NewGuid();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Task.Run(() => SendPeticion(_guid, model));

            return Ok(_guid);
        }

        //  protocol://domain:port/api/Peticiones/GetPeticion/{Guid}
        [HttpGet]
        [ResponseType(typeof(PeticionDetalleDTO))]
        [ActionName("GetPeticion")]
        public async Task<IHttpActionResult> GetPeticion(Guid Id)
        {
            try
            {
                if (null == Id)
                    return NotFound();

                var _peticion = await db.Peticiones.Select(p =>
                new PeticionDetalleDTO()
                {
                    Guid = p.Guid,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Telefono = p.Telefono,
                    Correo = p.Correo,
                    Cedula = p.Cedula,
                    Fecha = p.Fecha.ToString(),
                    Peticion = p.Peticion,
                    Procesada = true
                }).SingleOrDefaultAsync(p => p.Guid.Equals(Id));

                if (null == _peticion)
                {
                    _peticion = await db.PeticionesNoProcesadas.Select(p =>
                    new PeticionDetalleDTO()
                    {
                        Guid = p.Id,
                        Nombre = p.Nombre,
                        Apellido = p.Apellido,
                        Telefono = p.Telefono,
                        Correo = p.Correo,
                        Cedula = p.Cedula,
                        Fecha = p.Fecha.ToString(),
                        Peticion = p.Peticion,
                        Procesada = false
                    }).SingleOrDefaultAsync(p => p.Guid.Equals(Id));
                }

                if (null == _peticion)
                    return NotFound();

                return Ok(_peticion);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        private async Task SendPeticion(Guid _guid, PeticionDTO model)
        {
            Thread.Sleep(200);

            try
            {
                string _proccess = ConfigurationManager.AppSettings["Proccess_Url"].ToString();
                Who_Call whoCall = Who_Call.Instance;
                var uriSecApi = whoCall.GetUrl();

                if (string.IsNullOrWhiteSpace(uriSecApi.Result) || string.IsNullOrWhiteSpace(_proccess))
                    SavePeticionNoProcesada(_guid, model);
                else
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(uriSecApi.Result);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync(_proccess,
                        new PeticionDetalleDTO()
                        {
                            Guid = _guid,
                            Nombre = model.Nombre,
                            Apellido = model.Apellido,
                            Telefono = model.Telefono,
                            Correo = model.Correo,
                            Cedula = model.Cedula,
                            Fecha = DateTime.Now.ToLongDateString(),
                            Peticion = model.Peticion
                        });
                    
                    if (!response.IsSuccessStatusCode || !response.Content.ReadAsAsync<bool>().Result)
                        SavePeticionNoProcesada(_guid, model);
                }
            }
            catch (Exception ex)
            {
                SavePeticionNoProcesada(_guid, model);
            }
        }

        private void SavePeticionNoProcesada(Guid _guid, PeticionDTO model)
        {
            db.PeticionesNoProcesadas.Add(
                new PeticionesNoProcesada()
                {
                    Id = _guid,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Correo = model.Correo,
                    Telefono = model.Telefono,
                    Cedula = model.Cedula,
                    Fecha = DateTime.Now,
                    Peticion = model.Peticion
                });
            db.SaveChanges();
        }
    }
}

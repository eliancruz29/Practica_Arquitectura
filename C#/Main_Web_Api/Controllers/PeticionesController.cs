using Main_Web_Api.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Main_Web_Api.Controllers
{
    public class PeticionesController : ApiController
    {
        private ModelDbContext db = new ModelDbContext();

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
                    Peticion = p.Peticion
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
                        Peticion = p.Peticion
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

        private void SendPeticion(Guid _guid, PeticionDTO model)
        {
            Thread.Sleep(100);

            try
            {
                SavePeticionNoProcesada(_guid, model);
            }
            catch (Exception ex) { }
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

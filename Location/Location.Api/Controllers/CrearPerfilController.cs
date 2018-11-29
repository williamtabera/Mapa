using Location.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Location.Api.Controllers
{
    public class CrearPerfilController : ApiController
    {
        #region "Get"
        [HttpGet]
        public IEnumerable<tblLogin> Get()
        {
            using (var context = new PublicacionMig())
            {
                return context.Login.ToList();
            }
        }

        [HttpGet]
        public tblLogin Get(int id)
        {
            using (var context = new PublicacionMig())
            {
                return context.Login.FirstOrDefault(x => x.Id == id);
            }
        }

        #endregion

        #region "Post"
        [HttpPost]
        public IHttpActionResult Post(tblLogin Logins)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new PublicacionMig())
            {
                context.Login.Add(Logins);
                context.SaveChanges();
                return Ok(Logins);
            }
        }
        #endregion

        #region "Put"
        [HttpPut]
        public tblLogin Put(tblLogin Logins)
        {
            using (var context = new PublicacionMig())
            {
                var Loginact = context.Login.FirstOrDefault(x => x.Id == Logins.Id);
                Loginact.Nombres = Logins.Nombres;
                Loginact.Apellidos = Logins.Apellidos;
                Loginact.Celular = Logins.Celular;
                Loginact.Direccion = Logins.Direccion;
                Loginact.Estrato = Logins.Estrato;
                Loginact.FechaNacimiento = Logins.FechaNacimiento;
                Loginact.Correo = Logins.Correo;
                Loginact.Contraseña = Logins.Contraseña;
                context.SaveChanges();
                return Logins;
            }
        }
        #endregion

        #region "Delete"
        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new PublicacionMig())
            {
                var logindel = context.Login.FirstOrDefault(x => x.Id == id);
                context.Login.Remove(logindel);
                context.SaveChanges();
                return true;
            }
        }
        #endregion

    }
}

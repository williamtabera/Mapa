using Location.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Location.Api.Controllers
{
    public class localizacionController : ApiController
    {
        #region "Get"
        [HttpGet]
        public IEnumerable<tblLocalizacion> Get()
        {
            using (var context = new PublicacionMig())
            {
                return context.Localizacion.ToList();
            }
        }

        [HttpGet]
        public tblLocalizacion Get(int id)
        {
            using (var context = new PublicacionMig())
            {
                return context.Localizacion.FirstOrDefault(x => x.Id == id);
            }
        }

        #endregion

        #region "PostAdicionar"
        [HttpPost]
        public IHttpActionResult Post(tblLocalizacion localizacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new PublicacionMig())
            {
                context.Localizacion.Add(localizacion);
                context.SaveChanges();
                return Ok(localizacion);
            }
        }
        #endregion

        #region "Put"
        [HttpPut]
        public tblLocalizacion Put(tblLocalizacion localizacion)
        {
            using (var context = new PublicacionMig())
            {
                var Loginact = context.Localizacion.FirstOrDefault(x => x.Id == localizacion.Id);
                Loginact.LocalDateTime = localizacion.LocalDateTime;
                Loginact.Latitude = localizacion.Latitude;
                Loginact.Longitude = localizacion.Longitude;
                Loginact.Altitude = localizacion.Altitude;
                Loginact.AltitudeAccuracy = localizacion.AltitudeAccuracy;
                Loginact.Accuracy = localizacion.Accuracy;
                Loginact.Heading = localizacion.Heading;
                Loginact.Speed = localizacion.Speed;
                context.SaveChanges();
                return localizacion;
            }
        }
        #endregion

        #region "Delete"
        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new PublicacionMig())
            {
                var localizaciondel = context.Localizacion.FirstOrDefault(x => x.Id == id);
                context.Localizacion.Remove(localizaciondel);
                context.SaveChanges();
                return true;
            }
        }
        #endregion

    }
}

using Location.Api.Autenticación;
using Location.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Location.Api.Controllers
{
    public class LoginController : ApiController
    {
        #region "PostAutenticación"
        [HttpPost]
        public IHttpActionResult autenticacion(clsAutenticacion Logins)
        {
            using (var context = new PublicacionMig())
            {
                var autenticacion = context.Login.Any(x => x.Correo == Logins.correo && x.Contraseña == Logins.contraseña);
                clsValidacion validacion = new clsValidacion();
                if (autenticacion == false)
                {                    
                    return Ok(validacion.Denegado);
                }
                else
                {                    
                    return Ok(validacion.Espermitido);
                }
                
            }
        }
        #endregion
    }
}

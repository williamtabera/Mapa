using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Location.ClassMaster
{
    class Conexion
    {
        static void Main(string[] args)
        { 
        HttpClient publicaciones = new HttpClient();
        publicaciones.BaseAddress = new Uri("http://192.168.137.1");
        }
    }
}

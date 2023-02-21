using Microsoft.AspNetCore.Mvc;
using NetCoreEjemplo.Models;

namespace NetCoreEjemplo.Controllers
{   [ApiController]
    [Route("cliente")]
    public class CikenteController : ControllerBase
    {
        //Crear una WEB API REST en C# | .NET CORE 6 | (GET, POST, ETC) | HEADERS   para buscarlo
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id="1",
                    edad="22",
                    correo="nh@gmail.com",
                    nombre="Juan"
                },
                new Cliente
                {
                    id="2",
                    edad="23",
                    correo="guambito@gmail.com",
                    nombre="Pedro"
                },
                new Cliente
                {
                    id="3",
                    edad="22",
                    correo="coreall@gmail.com",
                    nombre="Gabriel"
                }
            };
            return clientes;
        }

        [HttpGet]
        [Route("listarByid")]
        public dynamic listarById(int codigo)
        {
            //obtenemos el cliente de la base de datos
            return new Cliente
            {
                id = codigo.ToString(),
                edad="23",
                nombre="pedro pascal",
                correo="pedpass@hotmail.com"
                
            };
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.id = "4";

            return new
            {
                success = true,
                message = "cliente creado",
                result = cliente
            };
        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token =Request.Headers.Where(x => x.Key == "Autorization").FirstOrDefault().Value;

            if(token != "marco123.")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                };

            }
            return new
            {
                success = true,
                message = "cliente eliminado",
                result = cliente
            };
        }
    }
}

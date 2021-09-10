using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace api_gestion_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Get()
        {
            string query = @"
                select usuario_id,usuario_nombre,usuario_apellido,username,usuario_email,usuario_celular,
                usuario_imagen,gaula.gaula_nombre,rol.rol_nombre,usuario.fecha_actualizacion,usuario_identificacion,password
                from usuario
                join rol
                on usuario.rol_id=rol.rol_id
                join gaula
                on usuario.gaula_id=gaula.gaula_id
                where usuario.estado_id = 1 
            ";

            string sqlDataSource = _configuration.GetConnectionString("Conexion");
            DataTable table = new DataTable();
            NpgsqlDataReader myReader;

            try
            {
                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                return Ok("Error: " + ex);
            }

            return new JsonResult(table);
        }
    }
}

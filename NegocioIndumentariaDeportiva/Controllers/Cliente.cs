using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
namespace NegocioIndumentariaDeportiva.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<Models.Cliente> clientes = new List<Models.Cliente>();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SistemaConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Clientes";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Models.Cliente cliente = new Models.Cliente();
                            cliente.Id = (int)reader["ID_Cliente"];
                            cliente.Nombre = (string)reader["Nombre_Cliente"];
                            cliente.Telefono = (string)reader["Telefono"];
                            clientes.Add(cliente);
                        }
                    }
                }
                connection.Close();
            }
            return View(clientes);
        }


    }
}
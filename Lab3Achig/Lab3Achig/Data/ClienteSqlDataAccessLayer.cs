using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Lab3Achig.Models;

namespace Lab3Achig.Data
{
    public class ClienteSqlDataAccessLayer
    {
        // Cadena de conexión a la base de datos MySQL
        string connectionString = "Server=localhost;Database=dbproductos;User ID=root;Password=1234;";

        public IEnumerable<ClienteSql> GetAllClientes()
        {
            List<ClienteSql> lst = new List<ClienteSql>();
            string query = "SELECT * FROM Cliente";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                ClienteSql cliente = new ClienteSql
                                {
                                    Codigo = rdr["codigo"] != DBNull.Value ? Convert.ToInt32(rdr["codigo"]) : 0,
                                    Cedula = rdr["cedula"] != DBNull.Value ? rdr["cedula"].ToString() : string.Empty,
                                    Apellidos = rdr["apellidos"] != DBNull.Value ? rdr["apellidos"].ToString() : string.Empty,
                                    Nombres = rdr["nombres"] != DBNull.Value ? rdr["nombres"].ToString() : string.Empty,
                                    FechaNacimiento = rdr["fechanacimiento"] != DBNull.Value ? Convert.ToDateTime(rdr["fechanacimiento"]) : default(DateTime),
                                    Mail = rdr["mail"] != DBNull.Value ? rdr["mail"].ToString() : string.Empty,
                                    Telefono = rdr["telefono"] != DBNull.Value ? rdr["telefono"].ToString() : string.Empty,
                                    Direccion = rdr["direccion"] != DBNull.Value ? rdr["direccion"].ToString() : string.Empty,
                                    Estado = rdr["estado"] != DBNull.Value ? Convert.ToBoolean(rdr["estado"]) : false
                                };

                                lst.Add(cliente);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Maneja el error aquí
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return lst;
        }

        public void AddCliente(ClienteSql cliente)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Cliente (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado) " +
                               "VALUES (@cedula, @apellidos, @nombres, @fechaNacimiento, @mail, @telefono, @direccion, @estado)";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
                    cmd.Parameters.AddWithValue("@apellidos", cliente.Apellidos);
                    cmd.Parameters.AddWithValue("@nombres", cliente.Nombres);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@mail", cliente.Mail);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@estado", cliente.Estado);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCliente(ClienteSql cliente)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Cliente SET Cedula = @cedula, Apellidos = @apellidos, Nombres = @nombres, " +
                               "FechaNacimiento = @fechaNacimiento, Mail = @mail, Telefono = @telefono, Direccion = @direccion, " +
                               "Estado = @estado WHERE Codigo = @codigo";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", cliente.Codigo);
                    cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
                    cmd.Parameters.AddWithValue("@apellidos", cliente.Apellidos);
                    cmd.Parameters.AddWithValue("@nombres", cliente.Nombres);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@mail", cliente.Mail);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@estado", cliente.Estado);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteSql GetClienteData(int? codigo)
        {
            ClienteSql cliente = new ClienteSql();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cliente WHERE Codigo = @codigo";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            cliente.Codigo = Convert.ToInt32(rdr["Codigo"]);
                            cliente.Cedula = rdr["Cedula"].ToString();
                            cliente.Apellidos = rdr["Apellidos"].ToString();
                            cliente.Nombres = rdr["Nombres"].ToString();
                            cliente.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                            cliente.Mail = rdr["Mail"].ToString();
                            cliente.Telefono = rdr["Telefono"].ToString();
                            cliente.Direccion = rdr["Direccion"].ToString();
                            cliente.Estado = Convert.ToBoolean(rdr["Estado"]);
                        }
                    }
                }
            }

            return cliente;
        }

        public void DeleteCliente(int? codigo)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Cliente WHERE Codigo = @codigo";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

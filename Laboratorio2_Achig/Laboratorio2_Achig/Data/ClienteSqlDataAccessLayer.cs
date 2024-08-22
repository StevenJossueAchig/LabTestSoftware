using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;  
using System.Data;
using Laboratorio2_Achig.Models;
using Npgsql; // PostgreSQL .NET provider

namespace Laboratorio2_Achig.Data
{
    public class ClienteSqlDataAccessLayer
    {
        // Realizar la conexión hacia la BDD, es decir el connection String
        // <summary>
        // Cadena de conexión a la base de datos PostgreSQL
        // </summary>
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dbproductos";

        public IEnumerable<ClienteSql> GetAllClientes()
        {
            List<ClienteSql> lst = new List<ClienteSql>();
            // Crear el comando con una consulta SQL directa
            string query = "SELECT * FROM Cliente";

            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    // No es necesario configurar CommandType para una consulta directa.
                    try
                    {
                        con.Open();
                        using (NpgsqlDataReader rdr = cmd.ExecuteReader())
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
                                    Estado = rdr["estado"] != DBNull.Value ? Convert.ToBoolean(rdr["estado"]) : false,
                                    Saldo = rdr["saldo"] != DBNull.Value ? Convert.ToDecimal(rdr["saldo"]) : 0m,  // o Convert.ToDecimal si usas decimal en la base de datos
                                    Provincia = rdr["provincia"] != DBNull.Value ? rdr["provincia"].ToString() : string.Empty
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


        // Para agregar un nuevo registro de Cliente
        public void AddCliente(ClienteSql cliente)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
                {
                    string query = "INSERT INTO Cliente (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado, Provincia, Saldo) " +
                                   "VALUES (@cedula, @apellidos, @nombres, @fechaNacimiento, @mail, @telefono, @direccion, @estado, @provincia, @saldo)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@provincia", cliente.Provincia);
                        cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
                        cmd.Parameters.AddWithValue("@apellidos", cliente.Apellidos);
                        cmd.Parameters.AddWithValue("@nombres", cliente.Nombres);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@mail", cliente.Mail);
                        cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                        cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                        cmd.Parameters.AddWithValue("@estado", cliente.Estado);
                        cmd.Parameters.AddWithValue("@saldo", cliente.Saldo);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: registrar el error, mostrar un mensaje al usuario, etc.
                Console.WriteLine($"Error al agregar cliente: {ex.Message}");
                // Dependiendo de la aplicación, podrías lanzar una excepción o manejar el error de otra forma
                throw;
            }
        }



        // Para actualizar un registro en particular de un Cliente
        public void UpdateCliente(ClienteSql cliente)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "UPDATE Cliente SET Cedula = @cedula, Apellidos = @apellidos, Nombres = @nombres, " +
               "FechaNacimiento = @fechaNacimiento, Mail = @mail, Telefono = @telefono, Direccion = @direccion, " +
               "Estado = @estado, Provincia = @provincia, Saldo = @saldo WHERE Codigo = @codigo";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
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
                    cmd.Parameters.AddWithValue("@provincia", cliente.Provincia); // Nueva línea para Provincia
                    cmd.Parameters.AddWithValue("@saldo", cliente.Saldo);       // Nueva línea para Saldo

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // Obtener los detalles de un cliente
        public ClienteSql GetClienteData(int? codigo)
        {
            ClienteSql cliente = new ClienteSql();

            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cliente WHERE Codigo = @codigo";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    con.Open();
                    using (NpgsqlDataReader rdr = cmd.ExecuteReader())
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
                            cliente.Saldo = Convert.ToDecimal(rdr["Saldo"]);
                            cliente.Provincia = rdr["Provincia"].ToString();
                            cliente.Estado = Convert.ToBoolean(rdr["Estado"]);
                        }
                    }
                }
            }

            return cliente;
        }


        // Eliminar el registro de un cliente específico
        public void DeleteCliente(int? codigo)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "DELETE FROM Cliente WHERE Codigo = @codigo";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}

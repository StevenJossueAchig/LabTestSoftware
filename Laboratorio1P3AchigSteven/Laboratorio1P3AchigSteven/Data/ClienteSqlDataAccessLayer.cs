using System.Data.SqlClient;
using Laboratorio1P3AchigSteven.Models;
using System.Data;

namespace Laboratorio1P3AchigSteven.Data
{
    public class ClienteSqlDataAccessLayer
    {
        // Realizar la conexion hacia la BDD, es decir el connection String
        //string connectionString = "Data Source=DESKTOP-Q9ULUU8;Initial Catalog=dbproductos; user ID=sa; Password=sa";
        string connectionString = "Data Source=DESKTOP-Q9ULUU8;Initial Catalog=dbproductos;Integrated Security=True";

        #region GetAllClientes
        public IEnumerable<ClienteSql> GetAllClientes()
        {
            List<ClienteSql> lst = new List<ClienteSql>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Se puede escribir directamente la consulta en el comando
                // SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente", con);
                SqlCommand cmd = new SqlCommand("cliente_SelectAll", con);
                // Saber que es lo que se va traer
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClienteSql cliente = new ClienteSql();
                    cliente.Codigo = Convert.ToInt32(reader["Codigo"]);
                    cliente.Cedula = reader["Cedula"].ToString();
                    cliente.Apellidos = reader["Apellidos"].ToString();
                    cliente.Nombres = reader["Nombres"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    cliente.Mail = reader["Mail"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();
                    cliente.Direccion = reader["Direccion"].ToString();
                    cliente.Estado = Convert.ToBoolean(reader["Estado"]);

                    lst.Add(cliente);
                }
                con.Close();
            }
            return lst;
        }
        #endregion

        #region InsertCliente
        public void InsertCliente(ClienteSql cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Cliente (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado) " +
                               "VALUES (@cedula, @apellidos, @nombres, @fechaNacimiento, @mail, @telefono, @direccion, @estado)";

                //SqlCommand cmd = new SqlCommand("cliente_Insert", con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        #endregion

        #region UpdateCliente
        public void UpdateCliente(ClienteSql cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        #endregion

        #region DeleteCliente
        public void DeleteCliente(int codigo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", codigo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        #endregion

        #region GetClienteById
        public ClienteSql GetClienteById(int codigo)
        {
            ClienteSql cliente = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_SelectById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", codigo);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cliente = new ClienteSql
                    {
                        Codigo = Convert.ToInt32(reader["Codigo"]),
                        Cedula = reader["Cedula"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Nombres = reader["Nombres"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                        Mail = reader["Mail"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    };
                }

                con.Close();
            }
            return cliente;
        }
        #endregion

    }
}

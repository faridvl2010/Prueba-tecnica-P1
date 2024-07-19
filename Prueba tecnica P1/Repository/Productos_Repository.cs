using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Prueba_tecnica_P1.Repository
{
    public class Productos_Repository
    {
        private String conectionString { get; set; }
        public Productos_Repository(String conectionString)
        {
            this.conectionString = conectionString;
        }
        public DataTable GetProductos()
        {
            DataTable dtProductos = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlCommand cmd = new SqlCommand())
            {
                using (SqlConnection cn = new SqlConnection(this.conectionString))
                {
                    try
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.CommandText = "procProductosSelect";
                        adapter.SelectCommand = cmd;
                        adapter.Fill(dtProductos);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo completar la consulta en la base de datos", ex);
                    }
                }
            }
            return dtProductos;
        }
    }
}

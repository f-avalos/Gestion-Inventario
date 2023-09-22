using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.AccessControl;

namespace Sol_Almacen.Presentacion
{
    public class D_Articulos
    {
        public DataTable Listado_Ar(string cTexto)
        {   
            //Variables
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                //Llama a método de conexion a bbdd
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "select a.codigo_ar,a.descripcion_ar,a.marca_ar,b.descripcion_um,c.descripcion_ca,a.stock_actual,a.codigo_um,a.codigo_ca from tb_articulos a inner join tb_unidades_medidas b on a.codigo_um = b.codigo_um inner join tb_categorias c on a.codigo_ca = c.codigo_ca where a.descripcion_ar like '" + cTexto + "' order by a.codigo_ar;";
                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);
                Comando.CommandTimeout = 60;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();

                //Toma resultado de consulta y la inserta a DataTable
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Termina la consulta y cierra la conexión
                if(SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public string Guardar_ar(int nOpcion, P_Articulos oAr)
        {
            //Variables
            string Rpta = "";
            string Sqltarea = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                if (nOpcion == 1) //registro
                {
                    Sqltarea = "insert into tb_articulos values ('"+oAr.Codigo_ar+"', '" + oAr.Descripcion_ar + "', '" + oAr.Marca_ar + "', '" + oAr.Codigo_um + "', '" + oAr.Codigo_ca + "', '" + oAr.Stock_actual + "', '" + oAr.Fecha_crea + "', '" + oAr.Fecha_modifica + "')";
                    /*Sqltarea = "insert into tb_articulos(descripcion_ar, marca_ar, codigo_um, codigo_ca, stock_actual, fecha_crea, fecha_modifica) values('"+ 
                        oAr.Descripcion_ar+"', "+
                        oAr.Marca_ar + "', " +
                        oAr.Codigo_um + "', " +
                        oAr.Codigo_ca + "', " +
                        oAr.Stock_actual + "', " +
                        oAr.Fecha_crea + "', " +
                        oAr.Fecha_modifica + "', ";*/

                }
                else //actualización
                {
                    Sqltarea = "update tb_articulos set descripcion_ar = '"+oAr.Descripcion_ar+"', "+
                        "marca_ar = '"+oAr.Marca_ar+"', "+
                        "codigo_um = '"+oAr.Codigo_um + "', " +
                        "codigo_ca = '"+oAr.Codigo_ca + "', " +
                        "stock_actual = '"+oAr.Stock_actual + "', " +
                        "fecha_modifica = '"+oAr.Fecha_modifica + "'"+
                        "where codigo_ar = '"+oAr.Codigo_ar+"'";
                }
                MySqlCommand Comando = new MySqlCommand(Sqltarea, SqlCon);
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery()>=1 ? "Ok" : "No se pudo ingresar el registro";
                
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                //Termina la consulta y cierra la conexión
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Rpta;
        }

        public string Eliminar_ar(int nCodigo_ar)
        {
            //Variables
            string Rpta = "";
            string Sqltarea = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                Sqltarea = "delete from tb_articulos where codigo_ar = '"+nCodigo_ar+"'";
                
                MySqlCommand Comando = new MySqlCommand(Sqltarea, SqlCon);
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "Ok" : "No se pudo eliminar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                //Termina la consulta y cierra la conexión
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Rpta;
        }
    }
}

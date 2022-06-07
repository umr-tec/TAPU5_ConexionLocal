using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace TAPU5_Ejemplo1
{
    class Conexion
    {
        //agregar elementos necesarios
        #region VariablesGlobales
        private string connection = string.Empty;
        private SqlConnection connect;
        private SqlCommand command;
        private SqlDataReader reader;
        #endregion

        //conectarme
        public Conexion() {
            connect = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //metodo paraq conectarnos
        private SqlConnection Conectar() {
            connect.ConnectionString = connection;
            connect.Open();

            return connect;
        }

        private void CerrarConexion() {
            connect.Close();
        }

        public bool GuardarAlumno(string matricula, string nombre, string primerApellido, string segundoApellido, string fecha)
        {

            bool res;
            try
            {
                Conectar();
                command = new SqlCommand("INSERT INTO Alumnos VALUES(' " + matricula + " ',' " + nombre + " ','"+primerApellido+"','"+segundoApellido+"','Sistemas','"+fecha+"')", connect);
                command.ExecuteNonQuery();
                res = true;
                MessageBox.Show("Datos guardados con éxito");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("Error al guardar");
                res = false;
            }
            finally {
                CerrarConexion();
            }
            return res;
        }
    }
}

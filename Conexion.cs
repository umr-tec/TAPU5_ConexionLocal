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
        private SqlDataAdapter dataAdapter;
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

        //Traer inforacion de la BD
        public DataSet MostrarDatos()
        {
            DataSet dataSet = new DataSet();            
            try
            {
                Conectar();
                command = new SqlCommand("SELECT UPPER( matricula) AS 'Matricula', UPPER(nombre) AS 'Nombre del Alumno', UPPER(prinmerApellido) + ' ' + UPPER(segundoApellido) AS 'Apellidos del Alumno',UPPER(carrera) AS 'Carrera', fechaNacimiento as 'Fecha de Nacimiento' FROM Alumnos", connect);
                command.ExecuteScalar();
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                dataSet = null;
                MessageBox.Show(ex.Message.ToString());
            }
            finally {
                CerrarConexion();
            }
            return dataSet;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAPU5_Ejemplo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();
            conexion.GuardarAlumno(txtMatricula.Text ,txtNombre.Text,txtprimerApellido.Text,txtSegundoApellido.Text, dateTimePicker1.Value.ToShortDateString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();
            DataTable dt = new DataTable();

            dt = conexion.MostrarDatos().Tables[0];
            dataGridView1.DataSource = dt;

            /*
               DataTable dt1 = new DataTable();

            dt = conexion.MostrarDatos().Tables[1];
            dataGridView2.DataSource = dt1;
             */

        }
    }
}

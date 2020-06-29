using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        conex objConexion = new conex();
        int posicion = 0;
        string accion = "nuevo";
        DataTable tbl = new DataTable();


        public Form1()
        {
            InitializeComponent();
        }

        conex sql = new conex();




        private void Form1_Load(object sender, EventArgs e)
        {
            dtgv.DataSource = sql.Mostrar_Datos();
            // TODO: esta línea de código carga datos en la tabla 'db_parque_vehicular_Orellana_RosaDataSet.tbl_vehiculos' Puede moverla o quitarla según sea necesario.
            this.tbl_vehiculosTableAdapter.Fill(this.db_parque_vehicular_Orellana_RosaDataSet.tbl_vehiculos);
        }

        private void dgvw(object sender, DataGridViewCellEventArgs e)
        {


            DataGridViewRow fila = dtgv.Rows[e.RowIndex];
            txtid.Text = Convert.ToString(fila.Cells[0].Value);
            txtmarca.Text = Convert.ToString(fila.Cells[1].Value);
            txtmodelo.Text = Convert.ToString(fila.Cells[2].Value);
            txtyear.Text = Convert.ToString(fila.Cells[3].Value);


        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            txtid.Text = dtgv.Rows.Count.ToString();
            if (txtid.Text == "" | txtmarca.Text == "" | txtmodelo.Text == "" | txtyear.Text == "")
            {
                MessageBox.Show("Falta llenar algún campo :c");
            }
            else
            {
                if (sql.Insertar(txtid.Text, txtmarca.Text, txtmodelo.Text, txtyear.Text))
                {
                    MessageBox.Show("Datos Ingresados :D");
                    dtgv.DataSource = sql.Mostrar_Datos();
                }
                else MessageBox.Show("Error al Insertar los Datos :c");
            }
            txtid.Text = "";
            txtmodelo.Text = "";
            txtmarca.Text = "";
            txtyear.Text = "";
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" | txtmarca.Text == "" | txtmodelo.Text == "" | txtyear.Text == "")
            {
                MessageBox.Show("Falta llenar algún campo :c");
            }
            else
            {
                if (sql.Eliminar(txtid.Text))
                {
                    MessageBox.Show("Datos Eliminados :D");
                    dtgv.DataSource = sql.Mostrar_Datos();
                }
                else MessageBox.Show("Error al Eliminar los Datos :c");
            }
            txtid.Text = "";
            txtmodelo.Text = "";
            txtmarca.Text = "";
            txtyear.Text = "";
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" | txtmarca.Text == "" | txtmodelo.Text == "" | txtyear.Text == "")
            {
                MessageBox.Show("Falta llenar algún campo :c");
            }
            else
            {
                if (sql.Actualizar(txtid.Text, txtmarca.Text, txtmodelo.Text, txtyear.Text))
                {
                    MessageBox.Show("Datos Actualizados :D");
                    dtgv.DataSource = sql.Mostrar_Datos();
                }
                else MessageBox.Show("Error al Actualizar los Datos :c");
            }
            txtid.Text = "";
            txtmodelo.Text = "";
            txtmarca.Text = "";
            txtyear.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                dtgv.DataSource = sql.Buscar(txtbuscar.Text);
            }
            else
            {
                dtgv.DataSource = sql.Mostrar_Datos();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }  
            
}
    

       
        
    

       
   


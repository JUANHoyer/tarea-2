using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;
using Capa_return;
using System.Drawing.Imaging;
using System.Configuration;

namespace DirectoriaTel
{
    public partial class Form1 : Form
    {
        ClaseEntidad objent = new ClaseEntidad();
        clasereturn objet = new clasereturn();

        public Form1()
        {
            InitializeComponent();
        }

        void mantenimiento(string Accion) 
        {

            objent.CC = Convert.ToInt32(Documento.Text);
            objent.NombreC = Nombres.Text;
            objent.NuEmpresarial = Convert.ToInt32(NEmpresarial.Text);
            objent.NuOficina = Convert.ToInt32(NOficina.Text);
            objent.Cargo = Carg.Text;
            objent.Accion = Accion;
            string men = objet.Mantenimiento_Empleado(objent);
            MessageBox.Show(men,"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void limpiar() 
        {
            Documento.Text = "";
            Nombres.Text = "";
            NEmpresarial.Text = "";
            NOficina.Text = "";
            Carg.Text = "";
            textBuscar.Text = "";
            dataGridView1.DataSource = objet.listar_Empleados();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objet.listar_Empleados();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (MessageBox.Show("¿Deseas registrar a " + Nombres.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes) 
                {  
                mantenimiento("1");
                    
                    limpiar();
                } 
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Documento.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + Documento.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Documento.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + Nombres.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            if (textBuscar.Text != "") 
            {
                objent.NombreC = textBuscar.Text;
                DataTable dt = new DataTable();
                dt = objet.Buscar_Empleados(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objet.listar_Empleados();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            Documento.Text = dataGridView1[0,fila].Value.ToString();
            Nombres.Text = dataGridView1[1, fila].Value.ToString();
            NEmpresarial.Text = dataGridView1[2, fila].Value.ToString();
            NOficina.Text = dataGridView1[3, fila].Value.ToString();
            Carg.Text = dataGridView1[4, fila].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo= new OpenFileDialog();
            DialogResult rs = fo.ShowDialog();
            if (rs == DialogResult.OK)
            { 
                  imgFoto.Image = Image.FromFile( fo.FileName );

            }
        }
    }
}

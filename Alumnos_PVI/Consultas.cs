using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVI_Final
{
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'pVI_Alumnos2DataSet.Alumnos1' Puede moverla o quitarla según sea necesario.
            this.alumnos1TableAdapter.Fill(this.pVI_Alumnos2DataSet.Alumnos1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Xml;

namespace PVI_Final
{
    public partial class Form1 : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
        private DataSet table = new DataSet();
        private string llamar = "Select * from Alumnos";
        private int examenes = 1;
        private int tareas = 0;
        private int asistencia = 0;
        private int porcExamen = 0;
        private int porcTareas = 0;
        private int porcAsist = 0;
        public Form1()
        {
            InitializeComponent();
            //alterTable("alter table alumnos drop column examen_1");
            GetData(llamar);
            label11.Text = porcExamen + "%";
            label12.Text = porcTareas + "%";
            label13.Text = porcAsist + "%";
        }
        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                //System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Otros\Documents\PVI_Alumnos2.accdb");
                String conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Otros\\Documents\\PVI_Alumnos2.accdb";
                // Create a new data adapter based on the specified query.
                dataAdapter = new OleDbDataAdapter(selectCommand, conn);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                table = new DataSet("Alumnos");
                //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table.Tables[0];
                //bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
        private void alterTable(string command)
        {
            String myConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Otros\\Documents\\PVI_Alumnos2.accdb";
            OleDbConnection myConnection = new OleDbConnection(myConn);
            string myInsert = command;
            OleDbCommand myCom = new OleDbCommand(myInsert);
            myCom.Connection = myConnection;

            myConnection.Open();
            try
            {
                myCom.ExecuteNonQuery();
                GetData(llamar);
            }catch (Exception ex){
                MessageBox.Show(ex.Message.ToString());
            }
            myConnection.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            Consultas form4 = new Consultas();
            form4.ShowDialog();
            string consulta; //= form4.comboBox1.Text;
            string orderBy = form4.comboBox2.Text;
            string columnas = "*";//compararConsulta(consulta);
            string orden = ordenarConsulta(orderBy);
            
            
            dataGridView1.DataSource = bindingSource1;
            consulta = "select " + columnas + " from Alumnos" + orden;

            GetData(consulta);
        }
        private string compararConsulta(string cons){
            string query = "*";
            if (cons.Equals("Todo"))
            {
                query = "expediente, apellido, nombre, materia";
            }
            else if (cons.Equals("Materia"))
            {
                query = "expediente, materia";
            }
            else if (cons.Equals("Alumno (Expediente)"))
            {
                query = "expediente, materia";
            }
            else if (cons.Equals("Alumno (Nombre completo)"))
            {
                query = "apellido, nombre";
            }
            else if (cons.Equals("Alumno (Nombre y expediente)"))
            {
                query = " expediente, apellido, nombre";
            }
            
            return query;
        }
        private string ordenarConsulta(string ordenar)
        {
            string order = "";
            if (ordenar.Equals("Ninguno"))
            {
                order = "";
            }
            else if (ordenar.Equals("Materia"))
            {
                order = " order by materia asc, apellido asc;";
            }
            else if (ordenar.Equals("Alumno (Expediente)"))
            {
                order = " order by expediente asc;";
            }
            else if (ordenar.Equals("Alumno (Apellido)"))
            {
                order = " order by apellido asc, materia asc;";
            }
            else
            {
                order = "";
            }
            return order;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Criterios form3 = new Criterios();
            form3.ShowDialog();
            bool addTarea = form3.checkBox1.Checked;
            bool addFalta = form3.checkBox2.Checked;
            examenes = (int)form3.numericUpDown1.Value;
            label4.Text = ""+examenes;
            if (addTarea)
            {
                tareas = (int)form3.numericUpDown2.Value;
            }
            if (addFalta)
            {
                asistencia = (int)form3.numericUpDown3.Value;
            }
            label5.Text = "" + tareas;
            label6.Text = "" + asistencia;
            crearTablas(examenes,addTarea,addFalta);
            button4.Enabled = true;
            if (examenes >= 3)
            {
                button5.Enabled = true;
            } 
        }
        private void crearTablas(int x, bool ta, bool fal){
            //OleDbConnection vconn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Otros\\Documents\\PVI_Alumnos2.accdb");
            //vconn.Open();
           
            int exam = x;
            string query = "";
            string nombre = "Examen_";
            string [] nomcol = new string[exam];
            int j;
            string command = "ALTER TABLE Alumnos";
            
            if (ta == true)
            {
                query = " add tareas int";
                alterTable(command +query);
                //Console.WriteLine(command + query);
            }
            query = "";
            if (fal == true)
            {
                query = " add asistencia int";
                alterTable(command +query);
                //Console.WriteLine(command + query);
            }
            query = "";
            for (int i = 0; i < exam; i++)
            {
                j = i + 1;
                nomcol[i] = nombre+j.ToString();
            }
            for (int i = 0; i < nomcol.Length; i++)
            {
                query = " add " + nomcol[i] + " int";
                Console.WriteLine(command+query);
                alterTable(command + query);
            }
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Buscar form5 = new Buscar();
            form5.ShowDialog();
            string query = "";
            string choice = form5.comboBox1.Text;
            string text = form5.textBox1.Text;
            if (choice.Equals("Expediente"))
            {
                query = "WHERE " + choice + "=" + text + ";";
            } else {
                query = "WHERE " + choice + "='" + text + "';";
            }
            string consulta = "Select * from Alumnos " + query;
            Console.WriteLine(consulta);
            GetData(consulta);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            examenes++;
            string query = "";
            string nombre = "Examen_";
            string command = "ALTER TABLE Alumnos";
            query = " add " + nombre + examenes.ToString() + " int";
            //Console.WriteLine(command + query);
            alterTable(command + query);
            label4.Text = examenes + "";
            if (examenes >=3)
            {
                button5.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (examenes > 3)
            {
                string query = "";
                string nombre = "Examen_";
                string command = "ALTER TABLE Alumnos";
                query = " DROP COLUMN " + nombre + examenes.ToString();
                //Console.WriteLine(command + query);
                alterTable(command + query);
                examenes--;
                label4.Text = examenes + "";
            }
            else
            {
                button5.Enabled = false;
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Final formFinal = new Final(tareas, asistencia);
            formFinal.ShowDialog();

            int promedio;

            int ex  = (int)formFinal.numericUpDown1.Value;
            int totTareas = 0;
            int tar = (int)formFinal.numericUpDown2.Value;
            int totAsist = 0;
            int ast = (int)formFinal.numericUpDown3.Value;

            promedio = (ex * porcExamen) / 100;
            Console.WriteLine(promedio);
            if (tareas != 0)//10
            {
                totTareas = (tar * porcTareas) / tareas;
                Console.WriteLine(totTareas);
            }
            if (asistencia != 0)//20
            {
                totAsist = (ast * porcAsist) / asistencia;
                Console.WriteLine(totAsist);
            }
            int final = promedio + totTareas + totAsist;
            labelFinal.Text = final + "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Ponderar form7 = new Ponderar();
            form7.ShowDialog();
            porcExamen = (int)form7.numericUpDown1.Value;
            porcTareas = (int)form7.numericUpDown2.Value;
            porcAsist  = (int)form7.numericUpDown3.Value;
            label11.Text = porcExamen + "%";
            label12.Text = porcTareas + "%";
            label13.Text = porcAsist + "%";
            button6.Enabled = true;
        }

        
    }
}

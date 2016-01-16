namespace PVI_Final
{
    partial class Consultas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pVI_Alumnos2DataSet = new PVI_Final.PVI_Alumnos2DataSet();
            this.alumnos1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alumnos1TableAdapter = new PVI_Final.PVI_Alumnos2DataSetTableAdapters.Alumnos1TableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pVI_Alumnos2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnos1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Materia",
            "Alumno (Expediente)",
            "Alumno (Apellido)",
            "Ninguno"});
            this.comboBox2.Location = new System.Drawing.Point(215, 34);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.Text = "(Sin orden)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ordenar por";
            // 
            // pVI_Alumnos2DataSet
            // 
            this.pVI_Alumnos2DataSet.DataSetName = "PVI_Alumnos2DataSet";
            this.pVI_Alumnos2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // alumnos1BindingSource
            // 
            this.alumnos1BindingSource.DataMember = "Alumnos1";
            this.alumnos1BindingSource.DataSource = this.pVI_Alumnos2DataSet;
            // 
            // alumnos1TableAdapter
            // 
            this.alumnos1TableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 130);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Name = "Consultas";
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.Consultas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pVI_Alumnos2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnos1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private PVI_Alumnos2DataSet pVI_Alumnos2DataSet;
        private System.Windows.Forms.BindingSource alumnos1BindingSource;
        private PVI_Alumnos2DataSetTableAdapters.Alumnos1TableAdapter alumnos1TableAdapter;
        private System.Windows.Forms.Button button1;
    }
}
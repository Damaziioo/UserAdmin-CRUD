namespace UserAdmin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabListar = new System.Windows.Forms.TabPage();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.txtIdListar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCadastrar = new System.Windows.Forms.TabPage();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabListar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.tabCadastrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabListar);
            this.tabControl1.Controls.Add(this.tabCadastrar);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabListar
            // 
            this.tabListar.Controls.Add(this.btnSelecionar);
            this.tabListar.Controls.Add(this.dgvUsuario);
            this.tabListar.Controls.Add(this.txtIdListar);
            this.tabListar.Controls.Add(this.label1);
            this.tabListar.Location = new System.Drawing.Point(4, 24);
            this.tabListar.Name = "tabListar";
            this.tabListar.Padding = new System.Windows.Forms.Padding(3);
            this.tabListar.Size = new System.Drawing.Size(768, 398);
            this.tabListar.TabIndex = 0;
            this.tabListar.Text = "Listar";
            this.tabListar.UseVisualStyleBackColor = true;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(600, 362);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(142, 30);
            this.btnSelecionar.TabIndex = 3;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AllowUserToAddRows = false;
            this.dgvUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Location = new System.Drawing.Point(18, 50);
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.RowHeadersWidth = 51;
            this.dgvUsuario.RowTemplate.Height = 25;
            this.dgvUsuario.Size = new System.Drawing.Size(724, 297);
            this.dgvUsuario.TabIndex = 2;
            this.dgvUsuario.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Selecionar);
            // 
            // txtIdListar
            // 
            this.txtIdListar.Location = new System.Drawing.Point(600, 21);
            this.txtIdListar.Name = "txtIdListar";
            this.txtIdListar.Size = new System.Drawing.Size(142, 23);
            this.txtIdListar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(600, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pesquisar (ID):";
            // 
            // tabCadastrar
            // 
            this.tabCadastrar.Controls.Add(this.txtTelefone);
            this.tabCadastrar.Controls.Add(this.txtCpf);
            this.tabCadastrar.Controls.Add(this.btnDeletar);
            this.tabCadastrar.Controls.Add(this.btnAlterar);
            this.tabCadastrar.Controls.Add(this.btnCancelar);
            this.tabCadastrar.Controls.Add(this.btnCadastrar);
            this.tabCadastrar.Controls.Add(this.btnExaminar);
            this.tabCadastrar.Controls.Add(this.txtEmail);
            this.tabCadastrar.Controls.Add(this.txtNome);
            this.tabCadastrar.Controls.Add(this.label5);
            this.tabCadastrar.Controls.Add(this.label4);
            this.tabCadastrar.Controls.Add(this.label3);
            this.tabCadastrar.Controls.Add(this.label2);
            this.tabCadastrar.Controls.Add(this.picFoto);
            this.tabCadastrar.Location = new System.Drawing.Point(4, 24);
            this.tabCadastrar.Name = "tabCadastrar";
            this.tabCadastrar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCadastrar.Size = new System.Drawing.Size(768, 398);
            this.tabCadastrar.TabIndex = 1;
            this.tabCadastrar.Text = "Cadastrar/Alterar";
            this.tabCadastrar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(469, 240);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(88, 46);
            this.btnDeletar.TabIndex = 16;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(375, 240);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(88, 46);
            this.btnAlterar.TabIndex = 15;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(563, 240);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 46);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(281, 240);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(88, 46);
            this.btnCadastrar.TabIndex = 10;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(29, 240);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(164, 46);
            this.btnExaminar.TabIndex = 9;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(281, 178);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(368, 23);
            this.txtEmail.TabIndex = 8;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(281, 49);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(270, 23);
            this.txtNome.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telefone:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "CPF:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";
            // 
            // picFoto
            // 
            this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
            this.picFoto.Location = new System.Drawing.Point(29, 31);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(164, 188);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            this.picFoto.Click += new System.EventHandler(this.picFoto_Click);
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(281, 109);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(173, 23);
            this.txtCpf.TabIndex = 19;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(469, 109);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(182, 23);
            this.txtTelefone.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "UserAdmin";
            this.tabControl1.ResumeLayout(false);
            this.tabListar.ResumeLayout(false);
            this.tabListar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.tabCadastrar.ResumeLayout(false);
            this.tabCadastrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabListar;
        private Button btnSelecionar;
        private DataGridView dgvUsuario;
        private TextBox txtIdListar;
        private Label label1;
        private TabPage tabCadastrar;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private PictureBox picFoto;
        private TextBox txtNome;
        private Button btnCadastrar;
        private Button btnExaminar;
        private TextBox txtEmail;
        private Button btnCancelar;
        private Button btnDeletar;
        private Button btnAlterar;
        private TextBox txtCpf;
        private TextBox txtTelefone;
    }
}
using UserAdmin.UserAdmin.BLL.Interfaces;
using UserAdmin.UserAdmin.BLL.Service;
using UserAdmin.UserAdmin.DAO.Entities;

namespace UserAdmin
{
    public partial class Form1 : Form
    {
        IUserService _userService = new UserService();
        byte[] imagemByte;
        public Form1()
        {
            _userService = new UserService();
            InitializeComponent();
            atualizarGrid();
            ClearInputs();
        }

        private Usuario RecuperarInformacao_Cadastrar()
        {
            var usuario = new Usuario();
            usuario.Nome = txtNome.Text;
            usuario.Cpf = txtCpf.Text;
            usuario.Email = txtEmail.Text;
            usuario.Telefone = txtTelefone.Text;
            usuario.FotoUsuario = imagemByte;

            return usuario;

        }
        private Usuario RecuperarInformacao_Delete_Alterar()
        {
            var usuario = new Usuario();
            usuario.Id = int.Parse(txtIdListar.Text);
            usuario.Nome = txtNome.Text;
            usuario.Cpf = txtCpf.Text;
            usuario.Email = txtEmail.Text;
            usuario.Telefone = txtTelefone.Text;
            usuario.FotoUsuario = imagemByte;

            return usuario;

        }
        public void atualizarGrid()
        {
            dgvUsuario.DataSource = _userService.Listar().Tables[0];
            dgvUsuario.Columns[0].HeaderText = "ID";
            dgvUsuario.Columns[1].HeaderText = "Nome";
            dgvUsuario.Columns[2].HeaderText = "Email";
            dgvUsuario.Columns[3].HeaderText = "CPF";
            dgvUsuario.Columns[4].HeaderText = "Telefone";
            dgvUsuario.Columns["foto"].Visible = false;
        }

        public void ClearInputs()
        {
            txtNome.Text = null;
            txtEmail.Text = null;
            txtCpf.Text = null;
            txtTelefone.Text = null;

            btnCadastrar.Enabled = true;
            btnAlterar.Enabled = false;
            btnDeletar.Enabled = false;
            btnCancelar.Enabled = true;
        }

        public bool ValidationNullCreate()
        {
            if (txtNome.Text == "" || txtCpf.Text == "" || txtEmail.Text == "" || txtTelefone.Text == "")
            {
                MessageBox.Show("Possue campos em branco, insira os dados da forma correta!");
                return false;
            }
            return true;
        }
        public bool ValidationNull_Delete_Alterar()
        {
            if (txtNome.Text == "" || txtCpf.Text == "" || txtEmail.Text == "" || txtTelefone.Text == "" || txtIdListar.Text == "")
            {
                MessageBox.Show("Possue campos em branco, insira os dados da forma correta!");
                return false;
            }
            return true;
        }
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog selecImagem = new OpenFileDialog();
            selecImagem.Title = "Selecionar Imagem";

            if (selecImagem.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromStream(selecImagem.OpenFile());
                MemoryStream memoryStream = new MemoryStream();
                picFoto.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                imagemByte = memoryStream.ToArray();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidationNullCreate())
            {
                if (_userService.Cadastrar(RecuperarInformacao_Cadastrar()))
                {
                    MessageBox.Show("Usuário criado com sucesso!");
                    atualizarGrid();
                    ClearInputs();
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (ValidationNull_Delete_Alterar())
            {

                if (_userService.Alterar(RecuperarInformacao_Delete_Alterar()))
                {
                    MessageBox.Show("Usuario Alterdo com sucesso!");
                    atualizarGrid();
                    ClearInputs();
                }
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (ValidationNull_Delete_Alterar())
            {
                if (_userService.Deletar(RecuperarInformacao_Delete_Alterar()))
                {
                    MessageBox.Show("Usuario Deletado com sucesso!");
                    atualizarGrid();
                    ClearInputs();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            if (txtIdListar.Text != "")
            {
                var id = int.Parse(txtIdListar.Text);
            }
        }

        private void Selecionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dgvUsuario.ClearSelection();
            if (indice >= 0)
            {
                txtIdListar.Text = dgvUsuario.Rows[indice].Cells[0].Value.ToString();
                txtNome.Text = dgvUsuario.Rows[indice].Cells[1].Value.ToString();
                txtEmail.Text = dgvUsuario.Rows[indice].Cells[2].Value.ToString();
                txtCpf.Text = dgvUsuario.Rows[indice].Cells[3].Value.ToString();
                txtTelefone.Text = dgvUsuario.Rows[indice].Cells[4].Value.ToString();

                btnCadastrar.Enabled = false;
                btnAlterar.Enabled = true;
                btnDeletar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

    }
}
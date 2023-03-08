using System.Net.NetworkInformation;
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
            MemoryStream memoryStream = new MemoryStream();
            picFoto.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            usuario.FotoUsuario = memoryStream.ToArray();

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
            picFoto.Image = null;

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
            selecImagem.Filter = "JPEG|*.JPG|PNG|*.png";
            selecImagem.Title = "Selecionar Imagem";

            if (selecImagem.ShowDialog() == DialogResult.OK)
            {
                var path = selecImagem.FileName;
                FileInfo fileInfo = new FileInfo(path);
                var extension = fileInfo.Extension;
                picFoto.Image = Image.FromStream(selecImagem.OpenFile());
                MemoryStream memoryStream = new MemoryStream();
                if (extension.Equals(".png"))
                {
                    picFoto.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                {
                    picFoto.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
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
            atualizarGrid();
            ClearInputs();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            if (txtIdListar.Text != "")
            {
                var idSelecionar = int.Parse(txtIdListar.Text);

                var usuario = _userService.Select_User_Info(idSelecionar);
                txtNome.Text = usuario.Nome;
                txtTelefone.Text = usuario.Telefone;
                txtCpf.Text = usuario.Cpf;
                txtEmail.Text = usuario.Email;
                MemoryStream memoryStream = new MemoryStream(usuario.FotoUsuario);
                Image image = Image.FromStream(memoryStream);
                picFoto.Image = image;
            }
        }

        private void Selecionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            dgvUsuario.ClearSelection();

            txtIdListar.Text = dgvUsuario.Rows[indice].Cells[0].Value.ToString();
            var idSelecionar = int.Parse(dgvUsuario.Rows[indice].Cells[0].Value.ToString());

            var usuario = _userService.Select_User_Info(idSelecionar);
            txtNome.Text = usuario.Nome;
            txtTelefone.Text = usuario.Telefone;
            txtCpf.Text = usuario.Cpf;
            txtEmail.Text = usuario.Email;
            MemoryStream memoryStream = new MemoryStream(usuario.FotoUsuario);
            Image image = Image.FromStream(memoryStream);
            picFoto.Image = image;

            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = true;
            btnDeletar.Enabled = true;
            btnCancelar.Enabled = true;

        }


    }
}
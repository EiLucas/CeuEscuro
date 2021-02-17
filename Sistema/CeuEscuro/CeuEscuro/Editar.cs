using CeuEscuro.BLL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CeuEscuro
{
    public partial class Editar : Form
    {
        public Editar()
        {
            InitializeComponent();
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            gp2.Visible = 
                gp1.Visible=
                btnConfirmar.Visible=
                btnImagem.Visible=
                txtNome.Enabled=
                txtSenha.Enabled=
                txtData.Enabled=
                txtCPF.Enabled=
                txtTipoUser.Enabled=false;
        }

        //Metodo Limpar
        public void Limpar()
        {
            txtID.Text =
                txtNome.Text =
                txtData.Text =
                txtCPF.Text =
                txtSenha.Text =
                txtTipoUser.Text = string.Empty;
            pcBox1.Image = null;
            rb1.Checked = false;
            rb2.Checked = false;
            txtID.Enabled = true;
            gp2.Visible = false;
            txtID.Focus();
        }

        //Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Botão Pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //Checar o preenchimento do campo Id
            if (txtID.Text == "")
            {
                MessageBox.Show("Digite o Id do usuario!");
                txtID.Focus();
                return;
            }
            //Chamando os metodos
            int codigo = Convert.ToInt32(txtID.Text);
            UsuarioDTO objPesquisa = new UsuarioDTO();
            UsuarioBLL objPesqBLL = new UsuarioBLL();

            //Chamando o metodo Pesquisar/Seleciona
            objPesquisa = objPesqBLL.SelecionaUsuario(codigo);
            if (objPesquisa != null)
            {
                //Habilitando Componentes
                gp2.Visible = true;
                txtID.Enabled = false;

                //Passando as propriedades do banco para os componentes
                txtNome.Text = objPesquisa.NomeUsuario;
                txtCPF.Text = objPesquisa.CpfUsuario;
                txtSenha.Text = objPesquisa.SenhaUsuario;
                txtData.Text = objPesquisa.DataNascUsuario;
                txtTipoUser.Text = objPesquisa.DescricaoTipoUsuario;
                pcBox1.ImageLocation = objPesquisa.UrlImgUsuario;
            }
            else
            {
                MessageBox.Show("Não buscou! ");
                Limpar();
            }
        }

        //Botão Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Habilitando componentes
            btnConfirmar.Visible = true;
            btnEditar.Enabled = false;
            gp1.Visible = true;
            lblTipoUser.Visible = false;
            txtTipoUser.Visible = false;
            btnImagem.Visible = true;
            txtNome.Enabled =
                txtData.Enabled =
                txtCPF.Enabled =
                txtSenha.Enabled =
                txtTipoUser.Enabled = true;
            txtNome.Focus();
        }
        
        //Botão imagem
        private void btnImagem_Click(object sender, EventArgs e)
        {
            //Carregando a Imagem
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png| All Files(*.*)|*.*";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string img = dialog.FileName.ToString();
                pcBox1.ImageLocation = img;
            }
        }
        
        //Botão Confirmar
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Criando as Instancias
            UsuarioDTO objPesquisa = new UsuarioDTO();
            UsuarioBLL ObjPesqBLL = new UsuarioBLL();
            objPesquisa.IdUsuario = Convert.ToInt32(txtID.Text);
            objPesquisa.NomeUsuario = txtNome.Text;
            objPesquisa.CpfUsuario = txtCPF.Text;
            objPesquisa.SenhaUsuario = txtSenha.Text;
            objPesquisa.DataNascUsuario = txtData.Text;

            //Alterando radio buttons
            if ((!rb1.Checked)&&(!rb2.Checked))
            {
                gp1.BackColor = Color.DarkBlue;
                MessageBox.Show("Escolha uma opção! ");
                return;
            }

            //Atribuindo valores
            if (rb1.Checked)
            {
                objPesquisa.DescricaoTipoUsuario = "1";
            }
            else if (rb2.Checked)
            {
                objPesquisa.DescricaoTipoUsuario = "2";
            }
            gp1.BackColor = DefaultBackColor;

            //Salvando Url da Imagem
            if (pcBox1.Image!=null)
            {
                //Salvando a imagem
                string nomeImg = txtNome.Text + ".JPG";
                string pasta = @"C:\Users\lucas.aconceicao1\Desktop\Lucas\CeuEscuro\CeuEscuro\Imagens";
                string caminhoImg = Path.Combine(pasta, nomeImg);
                objPesquisa.UrlImgUsuario = caminhoImg;

                //Salvando na pasta
                Image a = pcBox1.Image;
                a.Save(caminhoImg);
            }
            else
            {
                MessageBox.Show("Selecione uma imagem! ");
                return;
            }

            //Chamando o metodo para confirmar a edição do usuario
            ObjPesqBLL.EditaUsuario(objPesquisa);
            MessageBox.Show("Usuario editado com sucesso! ");
            Limpar();
        }
        
        //Botão Excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Deseja mesmo excluir este registro!?" , "ATENÇÂO!!" , MessageBoxButtons.YesNo , MessageBoxIcon.Warning);

            //Manipulando o resultado escolhido pelo usuario
            if (msg==DialogResult.Yes)
            {
                UsuarioDTO objUser = new UsuarioDTO();
                objUser.NomeUsuario = txtNome.Text;
                UsuarioBLL objExcluiBLL = new UsuarioBLL();
                int codigo = Convert.ToInt32(txtID.Text);
                objExcluiBLL.ExcluirUsuario(codigo);
                Limpar();
                MessageBox.Show(objUser.NomeUsuario +" excluido com sucesso!");
            }
            else if (msg == DialogResult.No)
            {
                Limpar();
            }
        }
    }
}

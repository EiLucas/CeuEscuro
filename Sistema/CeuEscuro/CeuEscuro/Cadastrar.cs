using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CeuEscuro.BLL;//Inserido manualmente
using CeuEscuro.DTO;//Inserido manualmente
using System.IO;//Inserido manualmente

namespace CeuEscuro
{
    public partial class Cadastrar : Form
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        protected void Limpar()
        {
            txtNome.Text =
                txtCPF.Text =
                txtData.Text =
                txtSenha.Text = string.Empty;
            pcBox1.Image = null;
            rb1.Checked = false;
            rb2.Checked = false;
            txtNome.Focus();
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            //Carregando a imagem
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png| All Files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string img = dialog.FileName.ToString();
                pcBox1.ImageLocation = img;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Instanciar objeto modelo
            UsuarioDTO objCad = new UsuarioDTO();
            objCad.NomeUsuario = txtNome.Text;
            objCad.CpfUsuario = txtCPF.Text;
            objCad.SenhaUsuario = txtSenha.Text;
            objCad.DataNascUsuario = txtData.Text;

            //Salvando a imagem
            string nomeImg = txtNome.Text + ".JPG";
            string pasta = @"C:\Users\lucas.aconceicao1\Desktop\Lucas\CeuEscuro\CeuEscuro\Imagens";
            string caminhoImg = Path.Combine(pasta, nomeImg);
            objCad.UrlImgUsuario = caminhoImg;

            //Salvando na pasta
            Image a = pcBox1.Image;
            a.Save(caminhoImg);

            //Radio button
            if (rb1.Checked)
            {
                objCad.DescricaoTipoUsuario = "1";
            }
            else if (rb2.Checked)
            {
                objCad.DescricaoTipoUsuario = "2";
            }

            UsuarioBLL objCadastra = new UsuarioBLL();
            objCadastra.CadastrarUsuario(objCad);
            Limpar();
            MessageBox.Show("Usuário " + objCad.NomeUsuario + " cadastrado com sucesso!");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}

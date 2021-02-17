using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CeuEscuro.DTO;//Adicionado manualmente
using CeuEscuro.BLL;//Adicionado manualmente

namespace CeuEscuro
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Pegar informação digitada pelo usuário
                string objUser = txtNome.Text;
                string objSenha = txtSenha.Text;

                //Istanciar objetos para a ultilização dos recursos
                UsuarioDTO objModelo = new UsuarioDTO();
                UsuarioBLL objValida = new UsuarioBLL();

                //Chamando metodo AutenticaUser na BLL
                objModelo = objValida.AutenticaUser(objUser, objSenha);

                //Checando objModelo
                if (objModelo != null)
                {
                    switch (objModelo.DescricaoTipoUsuario)
                    {
                        case "1":
                            Session.nomeUsuario = txtNome.Text.Trim();
                            MainADM obj = new MainADM();
                            obj.Show();
                            this.Visible = false;
                            break;
                        case "2":
                            Session.nomeUsuario = txtNome.Text.Trim();
                            MainUSER obj2 = new MainUSER();
                            obj2.Show();
                            this.Visible = false;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Deu problema denovo!");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Usuario não cadastrado! " + ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

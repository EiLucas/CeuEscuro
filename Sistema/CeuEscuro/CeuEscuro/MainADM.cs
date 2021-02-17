using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CeuEscuro.BLL;

namespace CeuEscuro
{
    public partial class MainADM : Form
    {
        public MainADM()
        {
            InitializeComponent();
        }

        private void MainADM_Load(object sender, EventArgs e)
        {
            lblSessionADM.Text = "Seja bem vindo " + Session.nomeUsuario + " ao Céu Escuro! sua seção iniciada em:" + DateTime.Now.ToString();
        }


        private void fecharProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void Calculadora_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void Word_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void exelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("exel");
        }

        private void Exel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("exel");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void Notepad_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastrar objForme = new Cadastrar();
            objForme.ShowDialog();
        }

        private void CadastroUsuarios_Click(object sender, EventArgs e)
        {
            Cadastrar objForme = new Cadastrar();
            objForme.ShowDialog();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Listar objLista = new Listar();
            objLista.ShowDialog();
        }

        private void ConsultaUsuarios_Click(object sender, EventArgs e)
        {
            Listar objLista = new Listar();
            objLista.ShowDialog();
        }

        private void usuarioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Editar objEdita = new Editar();
            objEdita.ShowDialog();
        }

        private void EditarUsuarios_Click(object sender, EventArgs e)
        {
            Editar objEdita = new Editar();
            objEdita.ShowDialog();
        }

        private void deslogarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Splash obj = new Splash();
            obj.Show();
        }

        private void Deslogar_Click(object sender, EventArgs e)
        {
            Close();
            Splash obj = new Splash();
            obj.Show();
        }
    }
}

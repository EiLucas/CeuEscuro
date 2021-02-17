﻿using System;
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
    public partial class MainUSER : Form
    {
        public MainUSER()
        {
            InitializeComponent();
        }

        private void MainUSER_Load(object sender, EventArgs e)
        {
            lblSessionUSER.Text = "Seja bem vindo " + Session.nomeUsuario + " ao Céu Escuro! sua seção iniciada em:" + DateTime.Now.ToString();
        }


        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void Exel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("exel");
        }

        private void exelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("exel");
        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConsultaUsuario_Click(object sender, EventArgs e)
        {
            Listar objLista = new Listar();
            objLista.ShowDialog();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listar objLista = new Listar();
            objLista.ShowDialog();
        }

        private void Deslogar_Click(object sender, EventArgs e)
        {
            Close();
            Splash obj = new Splash();
            obj.Show();
        }

        private void deslogarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Splash obj = new Splash();
            obj.Show();
        }
    }
}

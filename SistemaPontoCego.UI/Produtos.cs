using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Produtos : Form
    {
        public Produtos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnComprar1_Click(object sender, EventArgs e)
        {

        }

        private void VitrineDeProdutos_Load(object sender, EventArgs e)
        {

        }

        private void btnComprar1_Click_1(object sender, EventArgs e)
        {
            // O sistema checa a classe que foi criada para controlar a sessão do usuário
            if (UsuarioSessao.EstaLogado)
            {
                // Se estiver logado, abre a tela de Compra
                Comprar telaCompra = new Comprar();
                telaCompra.Show();
                this.Hide();
            }
            else
            {
                // Se não estiver logado, manda para o Cadastro
                MessageBox.Show("Você precisa estar logado para comprar!");
                Cadastro telaCadastro = new Cadastro();
                telaCadastro.Show();
                this.Hide();
            }
        }

        private void btnComprar1_Click_2(object sender, EventArgs e)
        {
            //  faz aparecer a janela  de aviso
            MessageBox.Show("O item foi adicionado ao carrinho!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Comprar telaFinalizar = new Comprar();

            this.Hide(); // Esconde a tela de Produtos
            telaFinalizar.ShowDialog(); // Abre a tela de Comprar e trava o código aqui até ela ser fechada
            this.Show(); // Quando a tela de Comprar fechar, a de Produtos volta a aparecer
        }
    }
}

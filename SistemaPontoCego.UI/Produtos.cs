using System;
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Produtos : Form
    {
        public Produtos()
        {
            InitializeComponent();
        }

        // --- BOTÃO CARRINHO / FINALIZAR ---
        private void button1_Click(object sender, EventArgs e)
        {
            Comprar telaFinalizar = new Comprar();

            // 1. Esconde a vitrine (não fecha, apenas esconde para manter o app vivo)
            this.Hide();

            // 2. Abre o carrinho como Diálogo
            // O código "para" nesta linha até o carrinho ser fechado
            telaFinalizar.ShowDialog();

            // 3. Após o fechamento do carrinho, verificamos:
            // Se o Gerenciador foi aberto, esta tela continua escondida (e o Pagamento cuidará de tudo)
            // Se o Gerenciador NÃO existe, significa que o usuário cancelou a compra, então voltamos a vitrine
            if (Application.OpenForms["Gerenciador"] == null)
            {
                this.Show();
            }
        }

        private void btnComprar1_Click_1(object sender, EventArgs e)
        {
            if (UsuarioSessao.EstaLogado)
            {
                Comprar telaCompra = new Comprar();
                this.Hide();
                telaCompra.ShowDialog();

                if (Application.OpenForms["Gerenciador"] == null)
                    this.Show();
            }
            else
            {
                MessageBox.Show("Você precisa estar logado!");
                Cadastro c = new Cadastro();
                c.Show();
                this.Hide();
            }
        }

        private void btnComprar1_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("O item foi adicionado ao carrinho!", "Sucesso");
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void VitrineDeProdutos_Load(object sender, EventArgs e) { }
    }
}
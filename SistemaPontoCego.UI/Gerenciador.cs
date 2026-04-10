using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Gerenciador : Form
    {
        // Use a mesma string de conexão aqui
        string strCon = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SistemaPontoCego;Integrated Security=True";

        public Gerenciador()
        {
            InitializeComponent();
        }

        private void Gerenciador_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Vendas", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvControlador.DataSource = dt; // Nome do seu DataGridView
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
        }

        private void btnAumentar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValor.Text, out decimal valor))
                txtValor.Text = (valor + 1).ToString();
        }

        private void btnDiminuir_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValor.Text, out decimal valor) && valor > 0)
                txtValor.Text = (valor - 1).ToString();
        }

        private void btnAplicar_Click(object sender, EventArgs e) // BOTÃO ATUALIZAR/UPDATE
        {
            if (dgvControlador.CurrentRow == null) return;

            string id = dgvControlador.CurrentRow.Cells["id"].Value.ToString();

            using (SqlConnection con = new SqlConnection(strCon))
            {
                string sql = "UPDATE Vendas SET Valor = @novoValor WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@novoValor", decimal.Parse(txtValor.Text));
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Pedido atualizado!");
                AtualizarGrid();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) // BOTÃO EXCLUIR/DELETE
        {
            if (dgvControlador.CurrentRow == null) return;

            string id = dgvControlador.CurrentRow.Cells["id"].Value.ToString();

            if (MessageBox.Show("Deseja excluir este pedido?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Vendas WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    AtualizarGrid();
                }
            }
        }

        // Quando clica na linha, o valor vai para a caixinha de texto para você editar
        private void dgvControlador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvControlador.CurrentRow != null)
            {
                txtValor.Text = dgvControlador.CurrentRow.Cells["Valor"].Value.ToString();
            }
        }
    }
}
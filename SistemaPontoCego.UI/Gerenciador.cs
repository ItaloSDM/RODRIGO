using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Gerenciador : Form
    {
        // Conexão com o seu banco de dados
        string strCon = @"Server=.\SQLEXPRESS;Database=SistemaPontoCego;Trusted_Connection=True;TrustServerCertificate=True;";

        public Gerenciador()
        {
            InitializeComponent();
            // Garante que, ao fechar o Gerenciador, o processo do Windows seja encerrado de vez
            this.FormClosed += (s, e) => { Application.Exit(); };
        }

        private void Gerenciador_Load(object sender, EventArgs e)
        {
            ConfigurarVisualGrid();
            AtualizarGrid();
        }

        // Configura o visual do DataGridView para ficar profissional
        private void ConfigurarVisualGrid()
        {
            dgvControlador.BackgroundColor = Color.White;
            dgvControlador.BorderStyle = BorderStyle.None;
            dgvControlador.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvControlador.AllowUserToAddRows = false;

            dgvControlador.DefaultCellStyle.ForeColor = Color.Black;
            dgvControlador.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvControlador.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dgvControlador.EnableHeadersVisualStyles = false;
            dgvControlador.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 33, 33);
            dgvControlador.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvControlador.ColumnHeadersHeight = 40;
        }

        // Carrega os dados do banco no Grid
        private void AtualizarGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Vendas", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvControlador.DataSource = dt;
                    dgvControlador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        // Botão Aplicar Alterações (Onde estava o erro de Id_Venda)
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (dgvControlador.CurrentRow == null) return;

            // Pega o ID da venda (está na primeira coluna, índice 0)
            string idVenda = dgvControlador.CurrentRow.Cells[0].Value.ToString();

            using (SqlConnection con = new SqlConnection(strCon))
            {
                try
                {
                    // CORREÇÃO: Usando 'id' conforme sua tabela SQL
                    string sql = "UPDATE Vendas SET Valor = @val WHERE id = @id";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@val", decimal.Parse(txtValor.Text));
                    cmd.Parameters.AddWithValue("@id", idVenda);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Valor atualizado com sucesso!", "Sucesso");
                    AtualizarGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar: " + ex.Message);
                }
            }
        }

        // Botão Excluir Linha
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvControlador.CurrentRow == null) return;

            string idVenda = dgvControlador.CurrentRow.Cells[0].Value.ToString();

            if (MessageBox.Show("Deseja excluir esta venda?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    try
                    {
                        // CORREÇÃO: Usando 'id' conforme sua tabela SQL
                        string sql = "DELETE FROM Vendas WHERE id = @id";

                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@id", idVenda);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        AtualizarGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir: " + ex.Message);
                    }
                }
            }
        }

        // Quando clica na linha, o valor vai para a caixinha de texto
        private void dgvControlador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvControlador.CurrentRow != null)
            {
                // Busca o valor da coluna "Valor" e joga no txtValor
                txtValor.Text = dgvControlador.CurrentRow.Cells["Valor"].Value.ToString();
            }
        }

        // Botões + e - para ajuste rápido de preço
        private void btnAumentar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValor.Text, out decimal v))
                txtValor.Text = (v + 1).ToString("F2");
        }

        private void btnDiminuir_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValor.Text, out decimal v) && v > 0)
                txtValor.Text = (v - 1).ToString("F2");
        }
    }
}
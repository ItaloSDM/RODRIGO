namespace SistemaPontoCego.UI
{
    partial class Gerenciador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvControlador = new DataGridView();
            btnAumentar = new Button();
            btnDiminuir = new Button();
            btnExcluir = new Button();
            btnAplicar = new Button();
            txtValor = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvControlador).BeginInit();
            SuspendLayout();
            // 
            // dgvControlador
            // 
            dgvControlador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvControlador.BackgroundColor = SystemColors.ButtonHighlight;
            dgvControlador.BorderStyle = BorderStyle.None;
            dgvControlador.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvControlador.Location = new Point(12, 12);
            dgvControlador.Name = "dgvControlador";
            dgvControlador.ReadOnly = true;
            dgvControlador.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvControlador.Size = new Size(776, 236);
            dgvControlador.TabIndex = 0;
            dgvControlador.CellClick += dgvControlador_CellClick;
            // 
            // btnAumentar
            // 
            btnAumentar.BackColor = Color.FromArgb(64, 64, 64);
            btnAumentar.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAumentar.Location = new Point(37, 266);
            btnAumentar.Name = "btnAumentar";
            btnAumentar.Size = new Size(55, 49);
            btnAumentar.TabIndex = 1;
            btnAumentar.Text = "+";
            btnAumentar.UseVisualStyleBackColor = false;
            btnAumentar.Click += btnAumentar_Click;
            // 
            // btnDiminuir
            // 
            btnDiminuir.BackColor = Color.FromArgb(64, 64, 64);
            btnDiminuir.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDiminuir.Location = new Point(37, 389);
            btnDiminuir.Name = "btnDiminuir";
            btnDiminuir.Size = new Size(55, 49);
            btnDiminuir.TabIndex = 1;
            btnDiminuir.Text = "-";
            btnDiminuir.UseVisualStyleBackColor = false;
            btnDiminuir.Click += btnDiminuir_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.FromArgb(192, 0, 0);
            btnExcluir.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(256, 276);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(185, 59);
            btnExcluir.TabIndex = 1;
            btnExcluir.Text = "Excluir Linha";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnAplicar
            // 
            btnAplicar.BackColor = Color.FromArgb(0, 192, 0);
            btnAplicar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAplicar.ForeColor = Color.White;
            btnAplicar.Location = new Point(256, 341);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(185, 49);
            btnAplicar.TabIndex = 1;
            btnAplicar.Text = "Aplicar Alterações";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // txtValor
            // 
            txtValor.BackColor = Color.FromArgb(64, 64, 64);
            txtValor.ForeColor = Color.White;
            txtValor.Location = new Point(37, 341);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(100, 23);
            txtValor.TabIndex = 2;
            // 
            // Gerenciador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(txtValor);
            Controls.Add(btnAplicar);
            Controls.Add(btnExcluir);
            Controls.Add(btnDiminuir);
            Controls.Add(btnAumentar);
            Controls.Add(dgvControlador);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Gerenciador";
            Text = "Gerenciador";
            Load += Gerenciador_Load;
            ((System.ComponentModel.ISupportInitialize)dgvControlador).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvControlador;
        private Button btnAumentar;
        private Button btnDiminuir;
        private Button btnExcluir;
        private Button btnAplicar;
        private TextBox txtValor;
    }
}
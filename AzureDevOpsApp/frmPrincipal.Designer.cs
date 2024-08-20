namespace AzureDevOpsApp
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRun = new Button();
            txtUrlAzureDevOps = new TextBox();
            lblUrlAzureDevOps = new Label();
            lblProjeto = new Label();
            txtProjeto = new TextBox();
            lblToken = new Label();
            txtToken = new TextBox();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            label1 = new Label();
            rtxtDescricao = new RichTextBox();
            rtxtComentario = new RichTextBox();
            lblComentario = new Label();
            txtTags = new TextBox();
            lblTags = new Label();
            SuspendLayout();
            // 
            // btnRun
            // 
            btnRun.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRun.Location = new Point(713, 12);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(75, 23);
            btnRun.TabIndex = 0;
            btnRun.Text = "Executar";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // txtUrlAzureDevOps
            // 
            txtUrlAzureDevOps.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUrlAzureDevOps.Location = new Point(123, 13);
            txtUrlAzureDevOps.Name = "txtUrlAzureDevOps";
            txtUrlAzureDevOps.Size = new Size(584, 23);
            txtUrlAzureDevOps.TabIndex = 1;
            // 
            // lblUrlAzureDevOps
            // 
            lblUrlAzureDevOps.AutoSize = true;
            lblUrlAzureDevOps.Location = new Point(9, 17);
            lblUrlAzureDevOps.Name = "lblUrlAzureDevOps";
            lblUrlAzureDevOps.Size = new Size(108, 15);
            lblUrlAzureDevOps.TabIndex = 2;
            lblUrlAzureDevOps.Text = "URL Azure DevOps:";
            // 
            // lblProjeto
            // 
            lblProjeto.AutoSize = true;
            lblProjeto.Location = new Point(69, 45);
            lblProjeto.Name = "lblProjeto";
            lblProjeto.Size = new Size(48, 15);
            lblProjeto.TabIndex = 4;
            lblProjeto.Text = "Projeto:";
            // 
            // txtProjeto
            // 
            txtProjeto.Location = new Point(123, 42);
            txtProjeto.Name = "txtProjeto";
            txtProjeto.Size = new Size(209, 23);
            txtProjeto.TabIndex = 3;
            // 
            // lblToken
            // 
            lblToken.AutoSize = true;
            lblToken.Location = new Point(337, 45);
            lblToken.Name = "lblToken";
            lblToken.Size = new Size(41, 15);
            lblToken.TabIndex = 6;
            lblToken.Text = "Token:";
            // 
            // txtToken
            // 
            txtToken.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtToken.Location = new Point(377, 42);
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(411, 23);
            txtToken.TabIndex = 5;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(42, 72);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(40, 15);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTitulo.Location = new Point(88, 69);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(700, 23);
            txtTitulo.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 130);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 9;
            label1.Text = "Descrição:";
            // 
            // rtxtDescricao
            // 
            rtxtDescricao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtxtDescricao.EnableAutoDragDrop = true;
            rtxtDescricao.ImeMode = ImeMode.NoControl;
            rtxtDescricao.Location = new Point(88, 130);
            rtxtDescricao.Name = "rtxtDescricao";
            rtxtDescricao.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            rtxtDescricao.Size = new Size(700, 133);
            rtxtDescricao.TabIndex = 10;
            rtxtDescricao.Text = "";
            // 
            // rtxtComentario
            // 
            rtxtComentario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtxtComentario.EnableAutoDragDrop = true;
            rtxtComentario.ImeMode = ImeMode.NoControl;
            rtxtComentario.Location = new Point(88, 269);
            rtxtComentario.Name = "rtxtComentario";
            rtxtComentario.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            rtxtComentario.Size = new Size(700, 165);
            rtxtComentario.TabIndex = 12;
            rtxtComentario.Text = "";
            // 
            // lblComentario
            // 
            lblComentario.AutoSize = true;
            lblComentario.Location = new Point(9, 272);
            lblComentario.Name = "lblComentario";
            lblComentario.Size = new Size(73, 15);
            lblComentario.TabIndex = 11;
            lblComentario.Text = "Comentário:";
            // 
            // txtTags
            // 
            txtTags.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTags.Location = new Point(88, 101);
            txtTags.Name = "txtTags";
            txtTags.Size = new Size(700, 23);
            txtTags.TabIndex = 14;
            // 
            // lblTags
            // 
            lblTags.AutoSize = true;
            lblTags.Location = new Point(49, 104);
            lblTags.Name = "lblTags";
            lblTags.Size = new Size(33, 15);
            lblTags.TabIndex = 13;
            lblTags.Text = "Tags:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 516);
            Controls.Add(txtTags);
            Controls.Add(lblTags);
            Controls.Add(rtxtComentario);
            Controls.Add(lblComentario);
            Controls.Add(rtxtDescricao);
            Controls.Add(label1);
            Controls.Add(txtTitulo);
            Controls.Add(lblTitulo);
            Controls.Add(lblToken);
            Controls.Add(txtToken);
            Controls.Add(lblProjeto);
            Controls.Add(txtProjeto);
            Controls.Add(lblUrlAzureDevOps);
            Controls.Add(txtUrlAzureDevOps);
            Controls.Add(btnRun);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRun;
        private TextBox txtUrlAzureDevOps;
        private Label lblUrlAzureDevOps;
        private Label lblProjeto;
        private TextBox txtProjeto;
        private Label lblToken;
        private TextBox txtToken;
        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label label1;
        private RichTextBox rtxtDescricao;
        private RichTextBox rtxtComentario;
        private Label lblComentario;
        private TextBox txtTags;
        private Label lblTags;
    }
}

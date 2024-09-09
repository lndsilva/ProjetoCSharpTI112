
namespace MultJogos
{
    partial class frmSobreNos
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
            this.dgvCadCli = new System.Windows.Forms.DataGridView();
            this.gpbCadCli = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCadCli)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCadCli
            // 
            this.dgvCadCli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCadCli.Location = new System.Drawing.Point(21, 308);
            this.dgvCadCli.Name = "dgvCadCli";
            this.dgvCadCli.Size = new System.Drawing.Size(995, 315);
            this.dgvCadCli.TabIndex = 0;
            // 
            // gpbCadCli
            // 
            this.gpbCadCli.Location = new System.Drawing.Point(21, 24);
            this.gpbCadCli.Name = "gpbCadCli";
            this.gpbCadCli.Size = new System.Drawing.Size(995, 265);
            this.gpbCadCli.TabIndex = 1;
            this.gpbCadCli.TabStop = false;
            this.gpbCadCli.Text = "groupBox1";
            // 
            // frmSobreNos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 635);
            this.Controls.Add(this.gpbCadCli);
            this.Controls.Add(this.dgvCadCli);
            this.Name = "frmSobreNos";
            this.Text = "frmSobreNos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCadCli)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCadCli;
        private System.Windows.Forms.GroupBox gpbCadCli;
    }
}
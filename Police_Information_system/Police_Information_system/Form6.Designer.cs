namespace Police_Information_system
{
    partial class Form6
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
            this.label1 = new System.Windows.Forms.Label();
            this.candidate_list = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.candidate_list)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Assigned Candidates";
            // 
            // candidate_list
            // 
            this.candidate_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.candidate_list.Location = new System.Drawing.Point(35, 77);
            this.candidate_list.Name = "candidate_list";
            this.candidate_list.ReadOnly = true;
            this.candidate_list.RowTemplate.Height = 24;
            this.candidate_list.Size = new System.Drawing.Size(544, 413);
            this.candidate_list.TabIndex = 3;
            this.candidate_list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.candidate_list_CellContentClick);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 532);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.candidate_list);
            this.Name = "Form6";
            this.Text = "Form6";
            ((System.ComponentModel.ISupportInitialize)(this.candidate_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView candidate_list;
    }
}
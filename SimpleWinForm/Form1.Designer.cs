namespace SimpleWinForm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGetNewDeck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOBHVasc = new System.Windows.Forms.Button();
            this.btnOBHVdesc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGoToDataValidation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(176, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(841, 318);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
            // 
            // btnGetNewDeck
            // 
            this.btnGetNewDeck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGetNewDeck.BackgroundImage")));
            this.btnGetNewDeck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetNewDeck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetNewDeck.Location = new System.Drawing.Point(3, 12);
            this.btnGetNewDeck.Name = "btnGetNewDeck";
            this.btnGetNewDeck.Size = new System.Drawing.Size(157, 152);
            this.btnGetNewDeck.TabIndex = 2;
            this.btnGetNewDeck.Text = "Get New Deck";
            this.btnGetNewDeck.UseVisualStyleBackColor = true;
            this.btnGetNewDeck.Click += new System.EventHandler(this.BtnGetNewDeck_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(841, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "For values, assume: 2 < 3 < 4 < 5 < 6 < 7 < 8 < 9 < 10 < J < Q < K < A";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(841, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "For suits, assume: Hearts < Diamonds < Clubs < Spades";
            // 
            // btnOBHVasc
            // 
            this.btnOBHVasc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOBHVasc.Location = new System.Drawing.Point(174, 398);
            this.btnOBHVasc.Name = "btnOBHVasc";
            this.btnOBHVasc.Size = new System.Drawing.Size(266, 23);
            this.btnOBHVasc.TabIndex = 5;
            this.btnOBHVasc.Text = "Sort By Over All Hierarchy Card Value ascending ";
            this.btnOBHVasc.UseVisualStyleBackColor = false;
            this.btnOBHVasc.Click += new System.EventHandler(this.BtnOBHVasc_Click);
            // 
            // btnOBHVdesc
            // 
            this.btnOBHVdesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnOBHVdesc.Location = new System.Drawing.Point(446, 398);
            this.btnOBHVdesc.Name = "btnOBHVdesc";
            this.btnOBHVdesc.Size = new System.Drawing.Size(266, 23);
            this.btnOBHVdesc.TabIndex = 6;
            this.btnOBHVdesc.Text = "Sort By Over All Hierarchy Card Value descending";
            this.btnOBHVdesc.UseVisualStyleBackColor = false;
            this.btnOBHVdesc.Click += new System.EventHandler(this.BtnOBHVdesc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "8.1 Sorting Example";
            // 
            // btnGoToDataValidation
            // 
            this.btnGoToDataValidation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnGoToDataValidation.Location = new System.Drawing.Point(3, 210);
            this.btnGoToDataValidation.Name = "btnGoToDataValidation";
            this.btnGoToDataValidation.Size = new System.Drawing.Size(155, 23);
            this.btnGoToDataValidation.TabIndex = 8;
            this.btnGoToDataValidation.Text = "Go to 8.2 Data Validation";
            this.btnGoToDataValidation.UseVisualStyleBackColor = false;
            this.btnGoToDataValidation.Click += new System.EventHandler(this.BtnGoToDataValidation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 450);
            this.Controls.Add(this.btnGoToDataValidation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOBHVdesc);
            this.Controls.Add(this.btnOBHVasc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetNewDeck);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Playing Card Sort Examples.";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGetNewDeck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOBHVasc;
        private System.Windows.Forms.Button btnOBHVdesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGoToDataValidation;
    }
}


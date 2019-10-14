namespace SimpleWinForm
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblValFullName = new System.Windows.Forms.Label();
            this.lblValCityName = new System.Windows.Forms.Label();
            this.lblVarPhoneNumber = new System.Windows.Forms.Label();
            this.lblVarEmailAddress = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.lblLoopID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bttnLoopBegin = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnStep1 = new System.Windows.Forms.Button();
            this.btnStep2 = new System.Windows.Forms.Button();
            this.btnClearDataGrid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnStep2);
            this.splitContainer1.Panel1.Controls.Add(this.btnStep1);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClearDataGrid);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.lblValFullName);
            this.splitContainer1.Panel2.Controls.Add(this.lblValCityName);
            this.splitContainer1.Panel2.Controls.Add(this.lblVarPhoneNumber);
            this.splitContainer1.Panel2.Controls.Add(this.lblVarEmailAddress);
            this.splitContainer1.Panel2.Controls.Add(this.btnValidate);
            this.splitContainer1.Panel2.Controls.Add(this.lblLoopID);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.bttnLoopBegin);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtPhone);
            this.splitContainer1.Panel2.Controls.Add(this.txtCity);
            this.splitContainer1.Panel2.Controls.Add(this.txtEmail);
            this.splitContainer1.Panel2.Controls.Add(this.txtFullName);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1057, 674);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 69);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(346, 601);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Raw JSON data";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(357, 153);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(342, 50);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // lblValFullName
            // 
            this.lblValFullName.AutoSize = true;
            this.lblValFullName.ForeColor = System.Drawing.Color.Red;
            this.lblValFullName.Location = new System.Drawing.Point(322, 56);
            this.lblValFullName.Name = "lblValFullName";
            this.lblValFullName.Size = new System.Drawing.Size(10, 13);
            this.lblValFullName.TabIndex = 16;
            this.lblValFullName.Text = ".";
            // 
            // lblValCityName
            // 
            this.lblValCityName.AutoSize = true;
            this.lblValCityName.ForeColor = System.Drawing.Color.Red;
            this.lblValCityName.Location = new System.Drawing.Point(322, 82);
            this.lblValCityName.Name = "lblValCityName";
            this.lblValCityName.Size = new System.Drawing.Size(10, 13);
            this.lblValCityName.TabIndex = 15;
            this.lblValCityName.Text = ".";
            // 
            // lblVarPhoneNumber
            // 
            this.lblVarPhoneNumber.AutoSize = true;
            this.lblVarPhoneNumber.ForeColor = System.Drawing.Color.Red;
            this.lblVarPhoneNumber.Location = new System.Drawing.Point(322, 108);
            this.lblVarPhoneNumber.Name = "lblVarPhoneNumber";
            this.lblVarPhoneNumber.Size = new System.Drawing.Size(10, 13);
            this.lblVarPhoneNumber.TabIndex = 14;
            this.lblVarPhoneNumber.Text = ".";
            // 
            // lblVarEmailAddress
            // 
            this.lblVarEmailAddress.AutoSize = true;
            this.lblVarEmailAddress.ForeColor = System.Drawing.Color.Red;
            this.lblVarEmailAddress.Location = new System.Drawing.Point(322, 134);
            this.lblVarEmailAddress.Name = "lblVarEmailAddress";
            this.lblVarEmailAddress.Size = new System.Drawing.Size(10, 13);
            this.lblVarEmailAddress.TabIndex = 13;
            this.lblVarEmailAddress.Text = ".";
            // 
            // btnValidate
            // 
            this.btnValidate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidate.Location = new System.Drawing.Point(16, 153);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(335, 47);
            this.btnValidate.TabIndex = 12;
            this.btnValidate.Text = "Validate Data and insert into Grid below";
            this.btnValidate.UseVisualStyleBackColor = false;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // lblLoopID
            // 
            this.lblLoopID.AutoSize = true;
            this.lblLoopID.Location = new System.Drawing.Point(338, 19);
            this.lblLoopID.Name = "lblLoopID";
            this.lblLoopID.Size = new System.Drawing.Size(13, 13);
            this.lblLoopID.TabIndex = 11;
            this.lblLoopID.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Loop ID:";
            // 
            // bttnLoopBegin
            // 
            this.bttnLoopBegin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bttnLoopBegin.Location = new System.Drawing.Point(138, 8);
            this.bttnLoopBegin.Name = "bttnLoopBegin";
            this.bttnLoopBegin.Size = new System.Drawing.Size(140, 23);
            this.bttnLoopBegin.TabIndex = 9;
            this.bttnLoopBegin.Text = "Pull from JSON text";
            this.bttnLoopBegin.UseVisualStyleBackColor = false;
            this.bttnLoopBegin.Click += new System.EventHandler(this.btnLoopBegin_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "City Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Full Name";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(92, 101);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(224, 20);
            this.txtPhone.TabIndex = 4;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(92, 75);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(224, 20);
            this.txtCity.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(92, 127);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(224, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(92, 49);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(224, 20);
            this.txtFullName.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(699, 464);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
            // 
            // btnStep1
            // 
            this.btnStep1.Location = new System.Drawing.Point(11, 8);
            this.btnStep1.Name = "btnStep1";
            this.btnStep1.Size = new System.Drawing.Size(75, 23);
            this.btnStep1.TabIndex = 2;
            this.btnStep1.Text = "Run Step 1";
            this.btnStep1.UseVisualStyleBackColor = true;
            this.btnStep1.Click += new System.EventHandler(this.BtnStep1_Click);
            // 
            // btnStep2
            // 
            this.btnStep2.Location = new System.Drawing.Point(256, 8);
            this.btnStep2.Name = "btnStep2";
            this.btnStep2.Size = new System.Drawing.Size(75, 23);
            this.btnStep2.TabIndex = 3;
            this.btnStep2.Text = "Run Step 2";
            this.btnStep2.UseVisualStyleBackColor = true;
            this.btnStep2.Click += new System.EventHandler(this.BtnStep2_Click);
            // 
            // btnClearDataGrid
            // 
            this.btnClearDataGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClearDataGrid.Location = new System.Drawing.Point(16, 8);
            this.btnClearDataGrid.Name = "btnClearDataGrid";
            this.btnClearDataGrid.Size = new System.Drawing.Size(116, 23);
            this.btnClearDataGrid.TabIndex = 18;
            this.btnClearDataGrid.Text = "Clear Grid";
            this.btnClearDataGrid.UseVisualStyleBackColor = false;
            this.btnClearDataGrid.Click += new System.EventHandler(this.BtnClearDataGrid_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 674);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Validation Examples";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bttnLoopBegin;
        private System.Windows.Forms.Label lblLoopID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Label lblValFullName;
        private System.Windows.Forms.Label lblValCityName;
        private System.Windows.Forms.Label lblVarPhoneNumber;
        private System.Windows.Forms.Label lblVarEmailAddress;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStep2;
        private System.Windows.Forms.Button btnStep1;
        private System.Windows.Forms.Button btnClearDataGrid;
    }
}
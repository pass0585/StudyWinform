
namespace DEV_Form
{
    partial class FM_CUST
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
            this.label2 = new System.Windows.Forms.Label();
            this.chkCustOnly = new System.Windows.Forms.CheckBox();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoPump = new System.Windows.Forms.RadioButton();
            this.rdoCut = new System.Windows.Forms.RadioButton();
            this.radioCar = new System.Windows.Forms.RadioButton();
            this.rdoComV = new System.Windows.Forms.RadioButton();
            this.btnCustSearch = new System.Windows.Forms.Button();
            this.dtpCustStart = new System.Windows.Forms.DateTimePicker();
            this.dtpCustEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCustGrid = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "거래처 코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "거래처 명";
            // 
            // chkCustOnly
            // 
            this.chkCustOnly.AutoSize = true;
            this.chkCustOnly.Location = new System.Drawing.Point(49, 93);
            this.chkCustOnly.Name = "chkCustOnly";
            this.chkCustOnly.Size = new System.Drawing.Size(126, 24);
            this.chkCustOnly.TabIndex = 2;
            this.chkCustOnly.Text = "고객사만 검색";
            this.chkCustOnly.UseVisualStyleBackColor = true;
            // 
            // txtCustCode
            // 
            this.txtCustCode.Location = new System.Drawing.Point(106, 36);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.Size = new System.Drawing.Size(162, 27);
            this.txtCustCode.TabIndex = 3;
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(368, 36);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(162, 27);
            this.txtCustName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(594, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "거래 일자";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoPump);
            this.groupBox1.Controls.Add(this.rdoCut);
            this.groupBox1.Controls.Add(this.radioCar);
            this.groupBox1.Controls.Add(this.rdoComV);
            this.groupBox1.Location = new System.Drawing.Point(244, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 65);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "종목";
            // 
            // rdoPump
            // 
            this.rdoPump.AutoSize = true;
            this.rdoPump.Location = new System.Drawing.Point(334, 26);
            this.rdoPump.Name = "rdoPump";
            this.rdoPump.Size = new System.Drawing.Size(105, 24);
            this.rdoPump.TabIndex = 13;
            this.rdoPump.TabStop = true;
            this.rdoPump.Text = "펌프압축기";
            this.rdoPump.UseVisualStyleBackColor = true;
            // 
            // rdoCut
            // 
            this.rdoCut.AutoSize = true;
            this.rdoCut.Location = new System.Drawing.Point(238, 26);
            this.rdoCut.Name = "rdoCut";
            this.rdoCut.Size = new System.Drawing.Size(90, 24);
            this.rdoCut.TabIndex = 12;
            this.rdoCut.TabStop = true;
            this.rdoCut.Text = "절삭가공";
            this.rdoCut.UseVisualStyleBackColor = true;
            // 
            // radioCar
            // 
            this.radioCar.AutoSize = true;
            this.radioCar.Location = new System.Drawing.Point(127, 26);
            this.radioCar.Name = "radioCar";
            this.radioCar.Size = new System.Drawing.Size(105, 24);
            this.radioCar.TabIndex = 11;
            this.radioCar.TabStop = true;
            this.radioCar.Text = "자동차부품";
            this.radioCar.UseVisualStyleBackColor = true;
            // 
            // rdoComV
            // 
            this.rdoComV.AutoSize = true;
            this.rdoComV.Location = new System.Drawing.Point(11, 26);
            this.rdoComV.Name = "rdoComV";
            this.rdoComV.Size = new System.Drawing.Size(110, 24);
            this.rdoComV.TabIndex = 10;
            this.rdoComV.TabStop = true;
            this.rdoComV.Text = "상용차 부품";
            this.rdoComV.UseVisualStyleBackColor = true;
            // 
            // btnCustSearch
            // 
            this.btnCustSearch.Location = new System.Drawing.Point(782, 82);
            this.btnCustSearch.Name = "btnCustSearch";
            this.btnCustSearch.Size = new System.Drawing.Size(126, 45);
            this.btnCustSearch.TabIndex = 11;
            this.btnCustSearch.Text = "조회";
            this.btnCustSearch.UseVisualStyleBackColor = true;
            this.btnCustSearch.Click += new System.EventHandler(this.btnCustSearch_Click);
            // 
            // dtpCustStart
            // 
            this.dtpCustStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCustStart.Location = new System.Drawing.Point(674, 37);
            this.dtpCustStart.Name = "dtpCustStart";
            this.dtpCustStart.Size = new System.Drawing.Size(164, 27);
            this.dtpCustStart.TabIndex = 12;
            this.dtpCustStart.Value = new System.DateTime(2021, 5, 25, 0, 0, 0, 0);
            // 
            // dtpCustEnd
            // 
            this.dtpCustEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCustEnd.Location = new System.Drawing.Point(868, 36);
            this.dtpCustEnd.Name = "dtpCustEnd";
            this.dtpCustEnd.Size = new System.Drawing.Size(164, 27);
            this.dtpCustEnd.TabIndex = 13;
            this.dtpCustEnd.Value = new System.DateTime(2021, 5, 25, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(844, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "~";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtpCustEnd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpCustStart);
            this.groupBox2.Controls.Add(this.chkCustOnly);
            this.groupBox2.Controls.Add(this.btnCustSearch);
            this.groupBox2.Controls.Add(this.txtCustCode);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.txtCustName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1071, 150);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "거래처 조회";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvCustGrid);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1071, 501);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "거래처 정보";
            // 
            // dgvCustGrid
            // 
            this.dgvCustGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCustGrid.Location = new System.Drawing.Point(3, 68);
            this.dgvCustGrid.Name = "dgvCustGrid";
            this.dgvCustGrid.RowHeadersWidth = 51;
            this.dgvCustGrid.RowTemplate.Height = 29;
            this.dgvCustGrid.Size = new System.Drawing.Size(1065, 430);
            this.dgvCustGrid.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(165, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 37);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(93, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 37);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(21, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 37);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FM_CUST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 651);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FM_CUST";
            this.Text = "거래처 마스터";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCustOnly;
        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoPump;
        private System.Windows.Forms.RadioButton rdoCut;
        private System.Windows.Forms.RadioButton radioCar;
        private System.Windows.Forms.RadioButton rdoComV;
        private System.Windows.Forms.Button btnCustSearch;
        private System.Windows.Forms.DateTimePicker dtpCustStart;
        private System.Windows.Forms.DateTimePicker dtpCustEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvCustGrid;
    }
}
namespace GraphOfFunction
{
    partial class FormMy
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelGraphFunction = new System.Windows.Forms.Panel();
            this.labelMinX = new System.Windows.Forms.Label();
            this.labelMaxX = new System.Windows.Forms.Label();
            this.labelMinY = new System.Windows.Forms.Label();
            this.labelMaxY = new System.Windows.Forms.Label();
            this.textBoxMinX = new System.Windows.Forms.TextBox();
            this.textBoxMaxX = new System.Windows.Forms.TextBox();
            this.textBoxMaxY = new System.Windows.Forms.TextBox();
            this.textBoxMinY = new System.Windows.Forms.TextBox();
            this.groupBoxDiapason = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.groupBoxFunctions = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listBoxFunctions = new System.Windows.Forms.ListBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxDiapason.SuspendLayout();
            this.groupBoxFunctions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGraphFunction
            // 
            this.panelGraphFunction.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelGraphFunction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelGraphFunction.Location = new System.Drawing.Point(11, 12);
            this.panelGraphFunction.Name = "panelGraphFunction";
            this.panelGraphFunction.Size = new System.Drawing.Size(400, 400);
            this.panelGraphFunction.TabIndex = 1;
            this.panelGraphFunction.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraphFunction_Paint);
            // 
            // labelMinX
            // 
            this.labelMinX.AutoSize = true;
            this.labelMinX.Location = new System.Drawing.Point(7, 22);
            this.labelMinX.Name = "labelMinX";
            this.labelMinX.Size = new System.Drawing.Size(34, 13);
            this.labelMinX.TabIndex = 3;
            this.labelMinX.Text = "Min X";
            // 
            // labelMaxX
            // 
            this.labelMaxX.AutoSize = true;
            this.labelMaxX.Location = new System.Drawing.Point(165, 22);
            this.labelMaxX.Name = "labelMaxX";
            this.labelMaxX.Size = new System.Drawing.Size(37, 13);
            this.labelMaxX.TabIndex = 4;
            this.labelMaxX.Text = "Max X";
            // 
            // labelMinY
            // 
            this.labelMinY.AutoSize = true;
            this.labelMinY.Location = new System.Drawing.Point(7, 48);
            this.labelMinY.Name = "labelMinY";
            this.labelMinY.Size = new System.Drawing.Size(34, 13);
            this.labelMinY.TabIndex = 5;
            this.labelMinY.Text = "Min Y";
            // 
            // labelMaxY
            // 
            this.labelMaxY.AutoSize = true;
            this.labelMaxY.Location = new System.Drawing.Point(165, 48);
            this.labelMaxY.Name = "labelMaxY";
            this.labelMaxY.Size = new System.Drawing.Size(37, 13);
            this.labelMaxY.TabIndex = 6;
            this.labelMaxY.Text = "Max Y";
            // 
            // textBoxMinX
            // 
            this.textBoxMinX.Location = new System.Drawing.Point(54, 19);
            this.textBoxMinX.Name = "textBoxMinX";
            this.textBoxMinX.Size = new System.Drawing.Size(84, 20);
            this.textBoxMinX.TabIndex = 7;
            this.textBoxMinX.Text = "-20";
            this.textBoxMinX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxMaxX
            // 
            this.textBoxMaxX.Location = new System.Drawing.Point(212, 19);
            this.textBoxMaxX.Name = "textBoxMaxX";
            this.textBoxMaxX.Size = new System.Drawing.Size(84, 20);
            this.textBoxMaxX.TabIndex = 8;
            this.textBoxMaxX.Text = "20";
            this.textBoxMaxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxMaxY
            // 
            this.textBoxMaxY.Location = new System.Drawing.Point(212, 45);
            this.textBoxMaxY.Name = "textBoxMaxY";
            this.textBoxMaxY.Size = new System.Drawing.Size(84, 20);
            this.textBoxMaxY.TabIndex = 9;
            this.textBoxMaxY.Text = "20";
            this.textBoxMaxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxMinY
            // 
            this.textBoxMinY.Location = new System.Drawing.Point(54, 45);
            this.textBoxMinY.Name = "textBoxMinY";
            this.textBoxMinY.Size = new System.Drawing.Size(84, 20);
            this.textBoxMinY.TabIndex = 10;
            this.textBoxMinY.Text = "-20";
            this.textBoxMinY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBoxDiapason
            // 
            this.groupBoxDiapason.Controls.Add(this.buttonRefresh);
            this.groupBoxDiapason.Controls.Add(this.textBoxMinX);
            this.groupBoxDiapason.Controls.Add(this.labelMinX);
            this.groupBoxDiapason.Controls.Add(this.labelMaxY);
            this.groupBoxDiapason.Controls.Add(this.textBoxMinY);
            this.groupBoxDiapason.Controls.Add(this.textBoxMaxX);
            this.groupBoxDiapason.Controls.Add(this.labelMaxX);
            this.groupBoxDiapason.Controls.Add(this.labelMinY);
            this.groupBoxDiapason.Controls.Add(this.textBoxMaxY);
            this.groupBoxDiapason.Location = new System.Drawing.Point(418, 12);
            this.groupBoxDiapason.Name = "groupBoxDiapason";
            this.groupBoxDiapason.Size = new System.Drawing.Size(447, 108);
            this.groupBoxDiapason.TabIndex = 13;
            this.groupBoxDiapason.TabStop = false;
            this.groupBoxDiapason.Text = "Diapason";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(7, 79);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 11;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // groupBoxFunctions
            // 
            this.groupBoxFunctions.Controls.Add(this.button1);
            this.groupBoxFunctions.Controls.Add(this.listBox1);
            this.groupBoxFunctions.Controls.Add(this.buttonAdd);
            this.groupBoxFunctions.Controls.Add(this.listBoxFunctions);
            this.groupBoxFunctions.Location = new System.Drawing.Point(418, 142);
            this.groupBoxFunctions.Name = "groupBoxFunctions";
            this.groupBoxFunctions.Size = new System.Drawing.Size(447, 154);
            this.groupBoxFunctions.TabIndex = 14;
            this.groupBoxFunctions.TabStop = false;
            this.groupBoxFunctions.Text = "Functions";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Evaluate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(104, 19);
            this.listBox1.MultiColumn = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(326, 95);
            this.listBox1.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(7, 121);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listBoxFunctions
            // 
            this.listBoxFunctions.FormattingEnabled = true;
            this.listBoxFunctions.Location = new System.Drawing.Point(7, 20);
            this.listBoxFunctions.MultiColumn = true;
            this.listBoxFunctions.Name = "listBoxFunctions";
            this.listBoxFunctions.Size = new System.Drawing.Size(91, 95);
            this.listBoxFunctions.TabIndex = 0;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(7, 64);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 5;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.BtnSolve_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(265, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 46);
            this.label3.TabIndex = 19;
            this.label3.Text = "+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(377, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 39);
            this.label2.TabIndex = 18;
            this.label2.Text = "x2";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(314, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(57, 38);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 39);
            this.label1.TabIndex = 16;
            this.label1.Text = "x1";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(150, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(57, 38);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "0";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Max Z =",
            "Min Z ="});
            this.comboBox1.Location = new System.Drawing.Point(7, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 39);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.Text = "Max Z =";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btnSolve);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(418, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 97);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Goal function";
            // 
            // FormMy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 429);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxFunctions);
            this.Controls.Add(this.groupBoxDiapason);
            this.Controls.Add(this.panelGraphFunction);
            this.Name = "FormMy";
            this.Text = "FormHome";
            this.Load += new System.EventHandler(this.FormMy_Load);
            this.groupBoxDiapason.ResumeLayout(false);
            this.groupBoxDiapason.PerformLayout();
            this.groupBoxFunctions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGraphFunction;
        private System.Windows.Forms.Label labelMinX;
        private System.Windows.Forms.Label labelMaxX;
        private System.Windows.Forms.Label labelMinY;
        private System.Windows.Forms.Label labelMaxY;
        private System.Windows.Forms.TextBox textBoxMinX;
        private System.Windows.Forms.TextBox textBoxMaxX;
        private System.Windows.Forms.TextBox textBoxMaxY;
        private System.Windows.Forms.TextBox textBoxMinY;
        private System.Windows.Forms.GroupBox groupBoxDiapason;
        private System.Windows.Forms.GroupBox groupBoxFunctions;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListBox listBoxFunctions;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}


namespace WinFormsApp1
{
    partial class Form1
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
            TbSave = new Button();
            TbId = new TextBox();
            TbName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BtnListar = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // TbSave
            // 
            TbSave.Location = new Point(444, 38);
            TbSave.Name = "TbSave";
            TbSave.Size = new Size(173, 25);
            TbSave.TabIndex = 0;
            TbSave.Text = "SALVAR";
            TbSave.UseVisualStyleBackColor = true;
            TbSave.Click += TbSave_Click;
            // 
            // TbId
            // 
            TbId.Location = new Point(31, 38);
            TbId.Name = "TbId";
            TbId.Size = new Size(54, 23);
            TbId.TabIndex = 1;
            // 
            // TbName
            // 
            TbName.Location = new Point(91, 38);
            TbName.Name = "TbName";
            TbName.Size = new Size(347, 23);
            TbName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 19);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 4;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 20);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 5;
            label2.Text = "NOME";
            // 
            // BtnListar
            // 
            BtnListar.Location = new Point(444, 73);
            BtnListar.Name = "BtnListar";
            BtnListar.Size = new Size(173, 25);
            BtnListar.TabIndex = 6;
            BtnListar.Text = "VERIFY";
            BtnListar.UseVisualStyleBackColor = true;
            BtnListar.Click += BtnListar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 86);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 11;
            label5.Text = "ID";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 110);
            Controls.Add(label5);
            Controls.Add(BtnListar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TbName);
            Controls.Add(TbId);
            Controls.Add(TbSave);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button TbSave;
        private TextBox TbId;
        private TextBox TbName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button BtnListar;
        private Label label5;
    }
}
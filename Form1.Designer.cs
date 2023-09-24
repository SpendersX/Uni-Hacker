namespace UniHook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            button13 = new Button();
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            listBox1 = new ListBox();
            label2 = new Label();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            textBox2 = new TextBox();
            button7 = new Button();
            label3 = new Label();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            listBox2 = new ListBox();
            button12 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 20, 20);
            panel1.Controls.Add(button13);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-10, -9);
            panel1.Name = "panel1";
            panel1.Size = new Size(1603, 76);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // button13
            // 
            button13.FlatStyle = FlatStyle.Popup;
            button13.ForeColor = Color.FromArgb(192, 0, 0);
            button13.Location = new Point(1479, 25);
            button13.Name = "button13";
            button13.Size = new Size(38, 37);
            button13.TabIndex = 2;
            button13.Text = "➖";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.FromArgb(192, 0, 0);
            button1.Location = new Point(1537, 23);
            button1.Name = "button1";
            button1.Size = new Size(38, 37);
            button1.TabIndex = 1;
            button1.Text = "❌";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(432, 25);
            label1.Name = "label1";
            label1.Size = new Size(111, 26);
            label1.TabIndex = 0;
            label1.Text = "Uni Hook";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.InactiveCaption;
            textBox1.Font = new Font("Doppio One", 16.2F);
            textBox1.Location = new Point(12, 73);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(871, 41);
            textBox1.TabIndex = 1;
            textBox1.Text = "Path To DLL";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDark;
            button2.Font = new Font("Doppio One", 16.2F);
            button2.Location = new Point(900, 73);
            button2.Name = "button2";
            button2.Size = new Size(94, 42);
            button2.TabIndex = 2;
            button2.Text = "Select Path";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ControlDark;
            button3.Font = new Font("Doppio One", 16.2F);
            button3.Location = new Point(12, 674);
            button3.Name = "button3";
            button3.Size = new Size(679, 42);
            button3.TabIndex = 4;
            button3.Text = "Inject";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.FromArgb(64, 64, 64);
            listBox1.ForeColor = Color.White;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 127);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(679, 544);
            listBox1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Yellow;
            label2.Location = new Point(697, 127);
            label2.Name = "label2";
            label2.Size = new Size(186, 26);
            label2.TabIndex = 2;
            label2.Text = "No Dlls Injected";
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ControlDark;
            button4.Font = new Font("Doppio One", 16.2F);
            button4.Location = new Point(701, 566);
            button4.Name = "button4";
            button4.Size = new Size(297, 42);
            button4.TabIndex = 6;
            button4.Text = "Refresh";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ControlDark;
            button5.Font = new Font("Doppio One", 16.2F);
            button5.Location = new Point(697, 156);
            button5.Name = "button5";
            button5.Size = new Size(297, 42);
            button5.TabIndex = 7;
            button5.Text = "End Task";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.ControlDark;
            button6.Font = new Font("Doppio One", 16.2F);
            button6.Location = new Point(697, 217);
            button6.Name = "button6";
            button6.Size = new Size(297, 42);
            button6.TabIndex = 8;
            button6.Text = "Open Process Path";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(701, 402);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(293, 27);
            textBox2.TabIndex = 9;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.ControlDark;
            button7.Font = new Font("Doppio One", 16.2F);
            button7.Location = new Point(697, 324);
            button7.Name = "button7";
            button7.Size = new Size(297, 42);
            button7.TabIndex = 10;
            button7.Text = "Change App Name";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(754, 373);
            label3.Name = "label3";
            label3.Size = new Size(180, 26);
            label3.TabIndex = 11;
            label3.Text = "Enter New Name";
            // 
            // button8
            // 
            button8.BackColor = SystemColors.ControlDark;
            button8.Font = new Font("Doppio One", 16.2F);
            button8.Location = new Point(701, 449);
            button8.Name = "button8";
            button8.Size = new Size(297, 42);
            button8.TabIndex = 12;
            button8.Text = "Minimize App";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.BackColor = SystemColors.ControlDark;
            button9.Font = new Font("Doppio One", 16.2F);
            button9.Location = new Point(701, 518);
            button9.Name = "button9";
            button9.Size = new Size(297, 42);
            button9.TabIndex = 13;
            button9.Text = "Maximize App";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.BackColor = SystemColors.ControlDark;
            button10.Font = new Font("Doppio One", 16.2F);
            button10.Location = new Point(700, 614);
            button10.Name = "button10";
            button10.Size = new Size(297, 42);
            button10.TabIndex = 14;
            button10.Text = "Freeze App";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click_1;
            // 
            // button11
            // 
            button11.BackColor = SystemColors.ControlDark;
            button11.Font = new Font("Doppio One", 16.2F);
            button11.Location = new Point(701, 662);
            button11.Name = "button11";
            button11.Size = new Size(297, 42);
            button11.TabIndex = 15;
            button11.Text = "Un Freeze App";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // listBox2
            // 
            listBox2.BackColor = Color.FromArgb(64, 64, 64);
            listBox2.ForeColor = Color.White;
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(1010, 117);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(555, 584);
            listBox2.TabIndex = 16;
            // 
            // button12
            // 
            button12.BackColor = SystemColors.ControlDark;
            button12.Font = new Font("Doppio One", 16.2F);
            button12.Location = new Point(1010, 72);
            button12.Name = "button12";
            button12.Size = new Size(555, 42);
            button12.TabIndex = 17;
            button12.Text = "Load Modules";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(1577, 728);
            Controls.Add(button12);
            Controls.Add(listBox2);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(label3);
            Controls.Add(button7);
            Controls.Add(textBox2);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "UniHook";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ListBox listBox1;
        private Label label2;
        private Button button4;
        private Button button5;
        private Button button6;
        private TextBox textBox2;
        private Button button7;
        private Label label3;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private ListBox listBox2;
        private Button button12;
        private Button button13;
    }
}

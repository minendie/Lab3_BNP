namespace Lab3
{
    partial class Form10
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
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(155, 277);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(227, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 281);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 2;
            label1.Text = "Your name:  ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 350);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 4;
            label2.Text = "Message:  ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(155, 346);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(449, 58);
            textBox2.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(645, 356);
            button1.Name = "button1";
            button1.Size = new Size(130, 48);
            button1.TabIndex = 5;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(93, 30);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(644, 207);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(645, 269);
            button2.Name = "button2";
            button2.Size = new Size(130, 48);
            button2.TabIndex = 7;
            button2.Text = "Connect ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form10
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form10";
            Text = "Chat Client ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1; // enter client's name 
        private Label label1;//
        private Label label2;
        private TextBox textBox2; // enter message 
        private Button button1; // button for sending message 
        private RichTextBox richTextBox1; // display all message from all clients connected 
        private Button button2;
    }
}
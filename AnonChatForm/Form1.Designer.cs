namespace AnonChatForm
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
            this.ChatTextBox = new System.Windows.Forms.RichTextBox();
            this.MessageInput = new System.Windows.Forms.TextBox();
            this.SendMessage = new System.Windows.Forms.Button();
            this.BotTypingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ChatTextBox.ForeColor = System.Drawing.Color.White;
            this.ChatTextBox.Location = new System.Drawing.Point(117, 2);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(557, 448);
            this.ChatTextBox.TabIndex = 0;
            this.ChatTextBox.Text = "";
            this.ChatTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // MessageInput
            // 
            this.MessageInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.MessageInput.ForeColor = System.Drawing.Color.White;
            this.MessageInput.Location = new System.Drawing.Point(273, 383);
            this.MessageInput.Name = "MessageInput";
            this.MessageInput.Size = new System.Drawing.Size(209, 20);
            this.MessageInput.TabIndex = 1;
            this.MessageInput.TextChanged += new System.EventHandler(this.MessageInput_TextChanged);
            this.MessageInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageInput_KeyPress);
            // 
            // SendMessage
            // 
            this.SendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.SendMessage.ForeColor = System.Drawing.Color.White;
            this.SendMessage.Location = new System.Drawing.Point(488, 381);
            this.SendMessage.Name = "SendMessage";
            this.SendMessage.Size = new System.Drawing.Size(75, 23);
            this.SendMessage.TabIndex = 2;
            this.SendMessage.Text = "Send";
            this.SendMessage.UseVisualStyleBackColor = false;
            this.SendMessage.Click += new System.EventHandler(this.SendMessage_Click);
            this.SendMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendMessage_KeyPress);
            // 
            // BotTypingLabel
            // 
            this.BotTypingLabel.AutoSize = true;
            this.BotTypingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.BotTypingLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.BotTypingLabel.Location = new System.Drawing.Point(342, 346);
            this.BotTypingLabel.Name = "BotTypingLabel";
            this.BotTypingLabel.Size = new System.Drawing.Size(88, 16);
            this.BotTypingLabel.TabIndex = 3;
            this.BotTypingLabel.Text = "Bot is typing...";
            this.BotTypingLabel.Visible = false;
            this.BotTypingLabel.Click += new System.EventHandler(this.BotTypingLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BotTypingLabel);
            this.Controls.Add(this.SendMessage);
            this.Controls.Add(this.MessageInput);
            this.Controls.Add(this.ChatTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ChatTextBox;
        private System.Windows.Forms.TextBox MessageInput;
        private System.Windows.Forms.Button SendMessage;
        private System.Windows.Forms.Label BotTypingLabel;
    }
}


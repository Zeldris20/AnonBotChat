using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnonChatForm
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> botResponses;
        public Form1()
        {
            InitializeComponent();

         
            // Attatch the event handler to the KeyPress event of Message

            // Initialise bot responses 
            botResponses = new Dictionary<string, string>
            {
                { "hello", "Hi there! How can I assist you?" },
                { "how are you", "I'm just a bot, but I'm here and ready to help!" },
                { "name", "I'm ChatBot, your friendly assistant." },
                { "joke", "Sure, here's one: Why don't scientists trust atoms? Because they make up everything!" },
                { "help", "Of course, I'm here to help! What do you need assistance with?" },
                { "goodbye", "Goodbye! If you have more questions, don't hesitate to come back." }
                // Add more user messages and responses as needed
            };
        }

            
        private void ShowBotTypingIndicator()
        {
            BotTypingLabel.Visible = true;
          

            


        }
        
       private void HideBotTypingIndicator()
        {
            BotTypingLabel.Visible = false;

            
        }

       

        
        private void Form1_Load(object sender, EventArgs e)
        {
            ChatTextBox.Visible = false;
            MessageInput.Focus();
            
        }
      
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void SendMessage_Click(object sender, EventArgs e)

        {

            string userMessage = MessageInput.Text;


            if (!string.IsNullOrWhiteSpace(userMessage))
            {
                DisplayUserMessage("You: " + userMessage);

                BotTypingLabel.Visible = false;

                ShowBotTypingIndicator();

                // Simulate bot thinking with a delay 
                await Task.Delay(1500); // delay for 1.5 seconds

               

                string botResponse = GetBotResponse(userMessage);
                DisplayBotMessage("Bot: " + botResponse);

                HideBotTypingIndicator();


                MessageInput.Clear();
            }
        }
               private string GetBotResponse(string userMessage)
              {
            foreach (var kvp in botResponses)
            {
                if (userMessage.ToLower().Contains(kvp.Key.ToLower()))
                {
                    return kvp.Value;
                }

            }

                return "I'm not sure how to respond to that. Feel free to ask me something else!";
        }

        private void MessageInput_TextChanged(object sender, EventArgs e)
        {
            ChatTextBox.Visible = true;
        }

        private void SendMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void MessageInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendMessage.PerformClick();
                e.Handled = true;
            }
        }

        private void BotTypingLabel_Click(object sender, EventArgs e)
        {
           
        }

        private void Bot_Paint(object sender, PaintEventArgs e)
        {

        
        }
    
        private void DisplayUserMessage (string message)
        {
            // remove the last message bubble 
            if (ChatTextBox.Controls.Count > 0)
            {
                ChatTextBox.Controls.RemoveAt(ChatTextBox.Controls.Count - 1);
            }
            Panel messageBubble = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size(200, 200), // Limit bubble width
                Margin = new Padding(5, 5, 50, 5),
                Padding = new Padding(10),
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Right // Align user messages to the right
            };
            Label messageLabel = new Label
            {
                Text = message,
                AutoSize = true
            };
            messageBubble.Controls.Add(messageLabel);
            ChatTextBox.Controls.Add(messageBubble);

           
        }
        private void DisplayBotMessage(string message)
        {
            if (ChatTextBox.Controls.Count > 0)
            {
                ChatTextBox.Controls.RemoveAt(ChatTextBox.Controls.Count - 1);
            }
            Panel messageBubble = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size(200, 200), // Limit bubble width
                Margin = new Padding(5, 50, 5, 5),
                Padding = new Padding(10),
                BackColor = Color.LightGreen,
                BorderStyle = BorderStyle.FixedSingle,
                
                Dock = DockStyle.Left // Align bot messages to the left
            };
            Label messageLabel = new Label

            {
                Text = message,
                AutoSize = true
            };
            messageBubble.Controls.Add (messageLabel);
            ChatTextBox.Controls.Add(messageBubble);
        
        }

    }
  }


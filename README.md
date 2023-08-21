# AnonBotChat
Im learning C# I decided to make a chat system and I wanted a way to send messages through the application and have it go through a database but I dont have any clue about how databases work
so... I faked it and basically made a messaging application but you get an auto response from a bot instead because its just easy enough to get my foot through the door
I began asking chatgpt for prompts that my bot could use to respond to the user, I also wanted the bot to use some intelligence instead of selecting a random prompt I want it to choose a prompt based off what the user types
I then used "botResponses = new Dictionary<string, string>" // creating dictionary to put the response of the bot inside and Implemented the bot that would respond to the users messages
After I created something that would turn the message that the user typed all in lowercase to make it more simple and not to confuse the bot if it were in capital letters and I used this code 
"  private string GetBotResponse(string userMessage)
        {
            foreach (var kvp in botResponses)
            {
                if (userMessage.Contains(kvp.Key, StringComparison.OrdinalIgnoreCase))
                {
                    return kvp.Value;
                }
            }

            return "I'm not sure how to respond to that. Feel free to ask me something else!"; 

            }

 "
I noticed I was getting an error "no overload for method 'contains' takes 2 arguments" basically it was about the contains method not having an overload argument so I updated my code to this instead 
            
"  private string GetBotResponse(string userMessage)
   {
   * if (userMessage.ToLower().Contains(kvp.Key.ToLower()))
     {
     return kvp.Value;
     }
   }
  return "I'm not sure how to respond to that. Feel free to ask me something else!";
}

"
basically this just makes both user input and the keys in the dictionary we created both converted to lowercase 
next I wanted to create a function that makes the send button activate with the enter button and here I got really stuck I tried 
" private void MessageInput_KeyPress(object sender, KeyPressEventArgs e)
{
    if (e.KeyChar == (char)Keys.Enter)
    {
        SendMessageButton.PerformClick();
        e.Handled = true; // Prevent the default Enter behavior
    }
}
"
with no luck, didnt seem to do anything at all, I figured it checks if the enter key is pressed if it is then it will perform click on the SendMessageButton I created which as well as "e.Handled. true;" 
which indicates the event handler that it already processed the event and dealt with it and doesnt need to proceed any further, basically telling the program that no further action is needed after this and still it did nothing, so I took a break and came back to it 
made sure the keypress event was attatched to the textbox so when its in focus and the enter key is pressed it should trigger the button 
but it didnt so I changed my code and instead of using "SendMessageButton.PerformClick();
                                                         e.Handled = true; " 
I deleted that and instead I changed it to " e.SuppressKeyPress = true; 
                                              SendMessageButton_Click(sender, e); "
so when the enter button gets pressed the code supresses the default behaviour of the enter key and instead acts as a trigger for the button to send your message, which worked perfectly 
after that I noticed the bot would immediately respond after me which felt very unnatural so what I did was add a panel and put the text "Bot is Typing..." and id have it show up whenever the bot would "type" 
id actually just add a delay to simulate the bot typing 

"  
                ChatTextBox.AppendText("You: " + userMessage + Environment.NewLine); // "You: " followed by your message 
                
                botIsTyping = true;
                TypingIndicatorLabel.Visible = true; // makes the panel "bot is typing... " visable 

                // Simulate bot typing
                await Task.Delay(1500); // next after the panel shows the bot will wait 1.5 seconds 

                string botResponse = GetBotResponse(userMessage); // this creates the bot response with both getbotresponse and usermessage 
                DisplayBotResponse(botResponse); // this displays the string we just made with GetBotResponse and userMessage 

                TypingIndicatorLabel.Visible = false; // this is the non bot typing state
                botIsTyping = false;

                MessageInput.Clear();
            }
        }
 " so I made a simple way to communicate with the bot by making "You: " and "Bot: " and adding a panel that would appear and added a 1.5 second delay to simulate the bot typing a message to you and reading and typing to seem more interactive, then I needed to make the Panel disappear so i just made the typing indicator to false as well as the botTyping to false 

 and then I just did the same for the bot 
 but it didnt seem to give a delay like I expected it would so I made some changes to the code at the moment im still a noob and not entirely sure what alot of functions do and how they interact with eachother in the code as its my first project so im not sure whats causing this but I do believe it is a simple logic issue im overlooking 
so to my code I added "ShowBotTypingIndicator();" and just above the "messageInput.Clear();" I added 
"HideBotTypingIndicator();" 
then I had to give them meaning 

" private void ShowBotTypingIndicator()
{
    BotTypingLabel.Visible = true;
    ChatFlowLayoutPanel.Controls.Add(BotTypingLabel); // show
}

private void HideBotTypingIndicator()
{
    BotTypingLabel.Visible = false;
    YourPanel.Controls.Remove(BotTypingLabel); // hide
}

private async void DisplayBotResponse(string botResponse)
{
    ShowBotTypingIndicator();

    // Delay before displaying the bot's response // waits for 1 second before sending the message 
    await Task.Delay(1000); // Delay for 1 second "
}

next I wanted to implement Message bubbles 
"  Panel messageBubble = new Panel
    {
        AutoSize = true,
        MaximumSize = new Size(300, 0), // Limit bubble width
        Margin = new Padding(5),
        Padding = new Padding(10),
        BackColor = isUserMessage ? Color.LightBlue : Color.LightGreen,
        BorderStyle = BorderStyle.FixedSingle,
        BorderRadius = 10, // Adjust as needed
        Dock = isUserMessage ? DockStyle.Right : DockStyle.Left // Align bubbles
    };
"
and the same for the bot 
then I just adjusted the size from 300 - 200 and more margin padding
I also added a 2nd 200 for the size to try and achieve a more square look than a rectangle for the chat boxes
after that I encountered another issue where the bot would type twice saying something and I realised that was a logic error caused by me forgetting to delete 
" ChatTextBox.AppendText("Bot: " + botResponse + Environment.NewLine); "
next I realised that when sending alot of messages to the bot caused the window to crowd with boxes so I wanted the program to replace the boxes everytime either the user or the bot sends a message 
and I did this by basically adding this at the very start of the program 

" // Remove the last message bubble if there is one
    if (ChatTextBox.Controls.Count > 0)
    {
        ChatTextBox.Controls.RemoveAt(ChatTextBox.Controls.Count - 1);
    }
" basically just checks if theres a textbox and deleting the last text box and replacing it with a new one 
and doing the same for the bot as well as the user the if (ChatTextBox.Controls.Count > 0) check ensures that there is at least one message bubble in the chat area before attempting to remove it
my next problem was I didnt want the program to launch in the "bot typing" state 
so basically all I did was change the visability of the panel to false so that was another logic issue on my behalf 
next issue I wanted to tackle was the richtextbox being selected at the start of the program instead of the textbox, I wanted by default to be the textbox the user types in 
so what I initally did was in form1_load I added a function " MessageInput.Focus();" I thought this function would focus to the MessageInput textbox that the user is supposed to type in but when I tried that it didnt work
so I had an idea that instead of making the focus to the textbox that id just hide the richtextbox at the initial launch of the program 
so in form1_load I added 2 functions "RichTextBox.Visible = false;" hiding the richtextbox
and "ChatTextBox.Focus();" this will give the focus to the text box after the rich text box disappears 
and then I wanted to make it come back after I typed something so in " private void ChatTextBox_TextChanged(object sender, EventArgs e)" I added " RichTextBox.Visible = true; " which just makes the rich chat text box come back 

thanks for reading please feel free to reach out to me if you wish my email is: christianclapson@gmail.com
    

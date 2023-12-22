using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI; // Ensure you have the OpenAI API package or library correctly referenced
using TMPro; // Namespace for TextMeshPro

public class ChatGPTManager : MonoBehaviour
{
    private OpenAIApi openAI = new OpenAIApi("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", "org-p9Y6HsEobbfbl6OlBazeG7jK");
    private List<ChatMessage> messages = new List<ChatMessage>();

    [SerializeField]
    private TMP_InputField userInputField; // Serialized TMP_InputField to take the question from

    [SerializeField]
    private TMP_Text responseText; // Serialized TMP_Text to display the response

     private string prompt = "Act as HoloTutor, an AI assistant in a educational XR app to help answer questions of students. Always respond in a way that is direct and straight to the point. Don't break character.";

    public async void SendReply()
        {
            responseText.text = "Waiting for Response...";

            var newMessage = new ChatMessage()
            {
                Role = "user",
                Content = userInputField.text
            };
            
            //AppendMessage(newMessage);

            if (messages.Count == 0) newMessage.Content = prompt + "\n" + userInputField.text; 
            
            messages.Add(newMessage);
            
            userInputField.text = "";
            userInputField.enabled = false;

            Debug.Log(messages);
            
            // Complete the instruction
            var completionResponse = await openAI.CreateChatCompletion(new CreateChatCompletionRequest()
            {
                Model = "gpt-3.5-turbo",
                Messages = messages,
                MaxTokens = 45,
            });
             Debug.Log(completionResponse);
            try
            {
                // Handle the response
                
                if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
                {   
                
                    var message = completionResponse.Choices[0].Message;
                    message.Content = message.Content.Trim();
                    
                    messages.Add(message);
                    responseText.text = message.Content;
                }
                else
                {
                    Debug.LogWarning("No text was generated from this prompt.");
                }

                //button.enabled = true;
                userInputField.enabled = true;
            }

             catch (System.Net.WebException webEx)
             {
                // Handle web exceptions (e.g., network errors, server errors)
                Debug.LogError($"Web Exception: {webEx.Message}");
                responseText.text = "GPT is currently unavailable";
            }
            catch (System.Exception ex)
            {
                // Handle any other exceptions
                Debug.LogError($"An error occurred: {ex.Message}");
                responseText.text = "GPT is currently unavailable";
            }
        }  
}

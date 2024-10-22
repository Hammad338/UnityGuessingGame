using UnityEngine;
using TMPro;
using System.Diagnostics;

public class PythonRunner : MonoBehaviour
{
    public TMP_InputField inputField;  // TMP InputField to get the user's guess
    public TMP_Text outputText;  // TMP Text to display the result

    public void RunPythonScript()
    {
        try
        {
            // Get the user's guess from the InputField
            string userGuess = inputField.text;

            // Check if the user input is not empty
            if (string.IsNullOrEmpty(userGuess))
            {
                outputText.text = "Please enter a guess.";
                return;
            }

            // Set up the process to run the Python script
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "/usr/local/bin/python3",  // Make sure the Python path is correct
                Arguments = $"-u '/Users/Hammad/Desktop/Unity game/GuessingGame/Assets/PythonScripts/test_script.py' {userGuess}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            // Execute the process
            using (Process process = Process.Start(startInfo))
            {
                using (System.IO.StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    outputText.text = result;  // Display the result
                }

                using (System.IO.StreamReader errorReader = process.StandardError)
                {
                    string error = errorReader.ReadToEnd();
                    if (!string.IsNullOrEmpty(error))
                    {
                        outputText.text = "Error: " + error;  // Display any errors
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            outputText.text = "Error running Python script: " + ex.Message;
        }
    }
}

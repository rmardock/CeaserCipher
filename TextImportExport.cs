using System;
using System.IO;

namespace Simple_Text_Encryption_Tool
{
    public class TextImportExport
    {
        public static string ReadFileText(string fileExtension)//Opens and reads input from file if user selects file input
        {
            string filePath = Prompts.FileImportPrompt(fileExtension);
            string inputText = File.ReadAllText(filePath);
            //Exception handling here

            return inputText;
        }

        public static string TypeText(string isEncryptionOrDecryption)//Gets input from user if typing input is selected
        {
            Console.WriteLine($"Enter the text you would like to {isEncryptionOrDecryption}: ");
            string inputText = Console.ReadLine();

            return inputText;
        }

        public static void WriteFileText(string fileExtension, string exportText, string filePath)
        {
            try
            {
                File.WriteAllText(filePath, exportText);//Attempts to write contents to file 
            }
            catch(IOException e)
            {
                Console.WriteLine($"Exception: IOException\nException Message: {e.Message}\nEnsure that the file path is valid.\n");
                Console.WriteLine("Exiting Program...\n");
                Environment.Exit(1);
            }
        }
    }
}
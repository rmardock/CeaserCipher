using System;

namespace Simple_Text_Encryption_Tool
{
    class Program
    {
        /*Add an invalid data exception (or prompt user for text input or exit sequence) 
        check if input file contains numbers or symbols*/
        //Provide parameters in feedback
        //Possibly add help/user instruction class and implement in start up menu options
        static void Main()
        {
            string fileExtension = ".txt";//Files are limited to .txt for now. Will update to support more filetypes in the future
            string encryptDecryptOption = Prompts.PromptMenu();
            
            //Possibly move this whole block to its own class
            if(encryptDecryptOption == "E")//If encryption is chosen 
            {
                string isEncryptionOrDecryption = "encrypt";
                string inputMethodOption = Prompts.InputMethodPrompt(isEncryptionOrDecryption);
                if(inputMethodOption == "F")
                {
                    string inputText = TextImportExport.ReadFileText(fileExtension);
                    int shift = Prompts.ShiftValue(isEncryptionOrDecryption);

                    string encryptedText = EncryptText.Encrypt(inputText, shift);
                }   
                else//If typing text into terminal is chosen
                {
                    string inputText = TextImportExport.TypeText(isEncryptionOrDecryption);
                    int shift = Prompts.ShiftValue(isEncryptionOrDecryption);

                    string encryptedText = EncryptText.Encrypt(inputText, shift);

                    Console.WriteLine($"\nYour encrypted text is : {encryptedText}");
                    //Prompt user for options to save encrypted text to a new text(for now) file 
                }
            }
            else//If decryption is chosen
            {
                string isEncryptionOrDecryption = "decrypt";
                string inputMethodOption = Prompts.InputMethodPrompt(isEncryptionOrDecryption);
                if(inputMethodOption == "F")//Import from file
                {
                    string inputText = TextImportExport.ReadFileText(fileExtension);
                    int shift = Prompts.ShiftValue(isEncryptionOrDecryption);

                    string decryptedText = EncryptText.Encrypt(inputText, shift);

                    Console.WriteLine($"\nYour decrypted text is: {decryptedText}");
                }
                else//Type input manually 
                {
                    string inputText = TextImportExport.TypeText(isEncryptionOrDecryption);
                    int shift = Prompts.ShiftValue(isEncryptionOrDecryption);

                    string decryptedText = EncryptText.Encrypt(inputText, shift);

                    Console.WriteLine($"\nYour decrypted text is: {decryptedText}");
                }
            }
            //Block End

            
            //Use class method to return file extension to Main() and then pass through to PathInitialization
            //Build class to encrypt text
            //Build class to decrypt text 
            //Class for providing users with choice(menu) to encrypt or decrypt text
            //Apply class methods for encrypting/decrypting
            //Prompt user for options to show result in console or create a new text document 
            //If user chooses to show in console prompt for options to create a text document and warn the user any data not saved to a text file will be deleted
            //Prompt user for options to repeat the program or not




            //For future updates --- allow for multiple files read for the process and utilize data structures to hold and print out information
            //Add functionality for more input and output formats
            //Build class for file extension --> prompt user to select a file extension input/output for data if they choose to use files 
            //In class build a list or enum of possible file extensions and use in prompt

            //Add GUI
            //*******
            //Add functionality for user to customize encryption/decryptions between multiple input and output documents of various file types
            

        }
    }
}


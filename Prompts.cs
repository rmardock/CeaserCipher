using System;

namespace Simple_Text_Encryption_Tool
{
    public class Prompts
    {
        public static string PromptMenu()//Opening prompt to give user the option of encryption or decryption
        {
            Console.WriteLine("\n\n\t***Ceaser Cipher Tool***\n\n");
            Console.WriteLine("Would you like to to encrypt or decrypt a file (using the Ceaser Cipher)?");
            Console.WriteLine("Type E for encryption and D for decryption (E/D): ");
            string input = Console.ReadLine().ToUpper();

            while(input != "E" && input != "D")//Error check for invalid input
            {
                Console.WriteLine("\nInvalid input! Select one of the given options (E/D): ");
                input = Console.ReadLine().ToUpper();
            }
            return input;
        }

        public static string InputMethodPrompt(string encryptionOrDecryption)//Prompt for input method options
        {
            Console.WriteLine($"\nWould you like to type text to {encryptionOrDecryption} into this console or read it from a file?");
            Console.WriteLine("Type T for typing text or F for read from file (T/F): ");
            string input = Console.ReadLine().ToUpper();
             while(input != "T" && input != "F")
             {
                 Console.WriteLine("\nInvalid input! Select one of the given options (T/F): ");
                 input = Console.ReadLine().ToUpper();
             }
            return input;
        }

        public static string FileImportPrompt(string fileExtension)//Prompt for importing file
        {
            Console.WriteLine("Enter the path to the file you are importing here: ");
            string input = Console.ReadLine();
            string filePath = PathInitialization.Initialize(input , fileExtension);
            bool fileExistence = PathInitialization.CheckFileExistence(filePath);

            //If file not found 
            while(fileExistence == false)//Add functionality for exit sequence here 
            {
                Console.WriteLine($"Invalid path: {filePath}");
                Console.WriteLine("Make sure you entered the path correctly and that the file is within that path.");
                Console.WriteLine("Enter the import file path: ");
                input = Console.ReadLine();

                filePath = PathInitialization.Initialize(input, fileExtension);
                fileExistence = PathInitialization.CheckFileExistence(filePath);
            }

            return filePath;
        }

        public static int ShiftValue(string isEncryptionOrDecryption)//Propmt for shift value initialization
        {
            Console.WriteLine($"Enter the Ceaser Cipher shift value you will be using to {isEncryptionOrDecryption} your file (0-25): ");
            int shift = Int32.Parse(Console.ReadLine());//Find way to handle if input is not digit
            
            if(isEncryptionOrDecryption == "decrypt")
            {
                shift = shift - (shift * 2);
                while(shift < -25 || shift > 0)//Invert parameters for decryption
                {
                    Console.WriteLine("\nInvalid input! Enter a number between 0 and 25 (0-25): ");
                    shift = Int32.Parse(Console.ReadLine());
                }
                return shift;
            }
            else
            {
                while(shift < 0 || shift > 25)//Encryption
                {
                    Console.WriteLine("\nInvalid input! Enter a number between 0 and 25 (0-25): ");
                    shift = Int32.Parse(Console.ReadLine());
                }
                return shift;
            }
        }

        public static void FileOutputPrompt(string encryptionOrDecryption, string fileExtension, string exportText)//Prompt for writing encrypted/decrypted content to file
        {
            Console.WriteLine($"\nWould you like to save the {encryptionOrDecryption}ed text to a file? (Y/N): ");
            string option = Console.ReadLine().ToUpper();

            while(option != "Y" && option != "N")//Error check for user input
            {
                Console.WriteLine("Invalid input! Enter on of the given options (Y/N): ");
                option = Console.ReadLine().ToUpper();
            }

            if(option == "Y")//If user chooses to write to file 
            {
                Console.WriteLine("Enter the file path you want to save the output file to.");
                Console.WriteLine("Use the format ~/Destination/filename.txt: ");
                string tmpFilePath = Console.ReadLine();
                string filePath = PathInitialization.Initialize(tmpFilePath, fileExtension);

                TextImportExport.WriteFileText(fileExtension, exportText, filePath);
                Console.WriteLine($"\nYour {encryptionOrDecryption}ed text has been successfully saved to {filePath}\n");
            }
            else 
            {
                Console.WriteLine("Exiting Program...\n");
                Environment.Exit(1);
            }
        }
    }
}
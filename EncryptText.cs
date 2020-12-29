using System.Text;

namespace Simple_Text_Encryption_Tool
{
    public class EncryptText
    {
        public static string Encrypt(string inputText, int shift)
        {
            StringBuilder encryptedTextSb = new StringBuilder();

            for(int i = 0; i < inputText.Length; i++)
            {
                if(char.IsUpper(inputText[i]))
                {
                    char c = (char)(((int)inputText[i] + shift - 65) % 26 + 65);
                    encryptedTextSb.Append(c);
                }
                if(char.IsWhiteSpace(inputText[i]))
                {
                    continue;//Skips spaces 
                } 
                else 
                {
                    char c = (char)(((int)inputText[i] + shift - 97) % 26 + 97);
                    encryptedTextSb.Append(c);
                }
            }
            string encryptedText = encryptedTextSb.ToString();
            return encryptedText;
        }
    }
}
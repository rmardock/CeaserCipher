using System.Runtime.InteropServices;

//This class is in place because there is an option to automatically save to current directory
//Windows uses backslashes while Linux and MacOSX use forward slashes in their file directories
namespace Simple_Text_Encryption_Tool
{
    public class DetectOS
    {
        public static string OSDetection()
        {
            string fileSystemSlash = FindSlash();
            return fileSystemSlash;//Return correct slash for user file directory based on OS
        }

        //Private method for OS detection for added security
        private static string FindSlash()
        {
            string osPlatform = "";
            string fileSystemSlash = "";

            //Detect user OS and store in string
            if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true)
            {
                osPlatform = "windows";
            }
            if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Linux) == true)
            {
                osPlatform = "linux";
            }
            if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX) == true)
            {
                osPlatform = "mac";
            }

            //Assign correct slash based on OS
            if(osPlatform == "windows")
            {
                fileSystemSlash = "\\";
            }
            if(osPlatform == "linux")
            {
                fileSystemSlash = "/";
            }
            else
            {
                fileSystemSlash = "/";
            }
            return fileSystemSlash;//Return correct slash used in file directory for user OS
        }
    }
}
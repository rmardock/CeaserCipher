using System;
using System.IO;
using System.Text;

namespace Simple_Text_Encryption_Tool
{
    public class PathInitialization
    {
        public static string Initialize(string tmpFilePath, string fileExtension)
        {   //Detect OS for use of correct forward/backslash in file directory
            string slash = DetectOS.OSDetection();

            //StringBuilder for appending user input
            StringBuilder filePathSb = new StringBuilder();

            //Variable for detecting if user input supplied file path or only file name
            bool filePathRootStatus = Path.IsPathRooted(tmpFilePath);

            //Run through ArgumentCheck method
            string filePath = ArgumentCheck(filePathSb, tmpFilePath, fileExtension, filePathRootStatus, slash);
            return filePath;//Return processed file path
        }

        private static string ArgumentCheck(StringBuilder pathSb, string tmpPath, string fileExtension, bool pathRootStatus, string slash)
        {
            string path;
            if(tmpPath.Contains(fileExtension))//If user provides file extension
            {
                if(pathRootStatus == false)//If only file name is given
                {
                    pathSb.Append(Environment.CurrentDirectory + slash + tmpPath);
                } 
                else 
                {
                    pathSb.Append(tmpPath);
                }
                path = pathSb.ToString();
                return path;//Return path string
            }
            else 
            {
                if(pathRootStatus == false)
                {
                    pathSb.Append(Environment.CurrentDirectory + slash + tmpPath + fileExtension);
                }
                else
                {
                    pathSb.Append(tmpPath + fileExtension);
                }
                path = pathSb.ToString();
                return path;//Return path string 
            }
        }

        public static bool CheckFileExistence(string filePath)//Returns true if file found and false if not found
        {
            bool fileStatus;
            fileStatus = File.Exists(filePath);
            return fileStatus;
        }
    }
}

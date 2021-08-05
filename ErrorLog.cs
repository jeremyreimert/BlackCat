/*****************************************************************************************
 * Application: VINYLCAT
 * Class:       ErrorLog
 * Developer:   ninedimensions
 * Last Update: March 15, 2021
 * Description: Catalog for vinyl record collection
 *              Cover art retrieved through LastFm and MusicBrainz APIs
 *
 * LastFM credentials:
 *  API Key:        718eb9ee6bd589e09bb940d77e8ea0d8
 *  Shared Secret:  7514ead22ec833370327f1dc06b1f2d5
 *  Registered to:  ninedimensions
 * **************************************************************************************/

using System;
using System.IO;
using System.Windows.Forms;

namespace BlackCat
{
    class ErrorLog
    {
        /*****************************************************
        * LogError(Exception ex)
        * Accepts an exception and write it to a file.
        * Returns nothing
        * ***************************************************/
        public static void LogError(Exception ex)
        {
            try
            {
                string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")); // add current date and time to message

                // add exception information to message
                message += Environment.NewLine;
                message += "-----------------------------------------------------------";
                message += Environment.NewLine;
                message += string.Format("Message: {0}", ex.Message);
                message += Environment.NewLine;
                message += string.Format("StackTrace: {0}", ex.StackTrace);
                message += Environment.NewLine;
                message += string.Format("Source: {0}", ex.Source);
                message += Environment.NewLine;
                message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
                message += Environment.NewLine;
                message += "-----------------------------------------------------------";
                message += Environment.NewLine;

                string path = PathToFile("\\ErrorLog.txt"); // path to text file

                // Write the error message tom the file
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(message);
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /************************************************************
        * PathToFile(string localPath)
        * Accepts the local path of a file in the solution directory
        * Returns the full path as a string
        * ***********************************************************/
        private static string PathToFile(string localPath)
        {
            try
            {
                string currentDir = Environment.CurrentDirectory; // get current directory
                DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath))); // create full path from currentDir and localPath
                return directory.ToString(); // return the full path
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return String.Empty;
            }
        }
    }
}

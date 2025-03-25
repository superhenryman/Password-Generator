using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Password_Generator_Installer
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        private static void Install_App()
        {
            
            string sourcePath = "gen.exe";
            string destPath = @"C:\gen";
            try
            {
                System.IO.Directory.CreateDirectory(destPath);
                System.IO.File.Copy(sourcePath, destPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while installing the password generator. {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                string currentPath = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
                if (!currentPath.Contains(destPath))
                {
                    Environment.SetEnvironmentVariable("Path", currentPath + ";" + destPath, EnvironmentVariableTarget.Machine);
                }
            }
            MessageBox.Show($"Installed to {destPath}", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Main(string[] args)
        {
            FreeConsole();
            Console.SetOut(TextWriter.Null);

            // Redirect input to prevent user interaction
            Console.SetIn(TextReader.Null);
            DialogResult result = MessageBox.Show("Are you sure you want to install this app?", "Installer", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Install_App();
                MessageBox.Show("To use: Open Powershell or cmd, then run 'gen', you'll see the help info needed to use it.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Okay then, bye.", "cya", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

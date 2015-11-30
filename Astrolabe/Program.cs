using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astrolabe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            switch (args.Length)
            {
                case 0:
                    //Open program without specifying a file.
                    Application.Run(new Form1());
                    break;
                case 1:
                    //Possibly a single file specified on command line
                    //Make sure it's a file, then open it.
                    if (verifyFile(args[0])) {
                        Application.Run(new Form1(args[0]));
                    } else {
                        Application.Run(new Form1());
                    }
                    break;

                default:
                    //Invalid number of files specified, ignore CLI input
                    Application.Run(new Form1());
                    break;
            }
            return 0;
        }
        /// <summary>
        /// Perform checks against the string supplied on the command-
        /// line to verify that it represents the path to a suitable
        /// file, where suitable is currently defined as being a
        /// regular file. Possibly expand the check here to exclude
        /// too-large files, or files for which we have no read perms.
        /// </summary>
        /// <returns>Whether or not the specified argument represents the path to a suitable file</returns>
        public static bool verifyFile(String filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schala
{
    internal class Init
    {
        public static void InitializeProject(bool verbose)
        {
            string[] dirs = new string[]
            {
                ".schala",
                // refs directory structure
                @".schala\refs",
                @".schala\refs\heads",
                // objects directory structure
                @".schala\objects",
                @".schala\objects\blobs",
                @".schala\objects\commits",
                @".schala\objects\trees",
            };

            foreach (string dir in dirs)
            {
                try
                {
                    Directory.CreateDirectory(dir);
                    if (verbose)
                    {
                        Console.WriteLine($"Created directory: {dir}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating directory {dir}: {ex.Message}");
                    return;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Project initialized successfully!");
            Console.ResetColor();

        }

    }
}

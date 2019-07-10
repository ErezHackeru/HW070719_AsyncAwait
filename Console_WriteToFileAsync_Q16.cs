using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW0707asyncawaitConsole
{
    class Program
    {
        private static async Task WriteToFileAsync()
        {
            try 
	        {
		        // Set a variable to the Documents path.
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteTextAsync.txt")))
                {
                    for (int i = 1; i <= 1000; i++)
                    {
                        await outputFile.WriteAsync(" + This is Number " + i.ToString());
                        Thread.Sleep(10);
                    }                
                }
	        }
	        catch (Exception e)
	        {
                Console.WriteLine(e.ToString());
	        }
        }

        public static void Main(string[] args)
        {
            Task WriteToFileAsyncTask = WriteToFileAsync();

            while (!WriteToFileAsyncTask.Wait(100))
            {
                Console.Write(".");
            }
            
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}

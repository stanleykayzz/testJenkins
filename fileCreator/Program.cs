using fileCreator.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputTextFile = "Enum.txt";
            string outputCsvFile = "Enum.csv";

            //chemin du fichier
            string filePath = Settings.Default.fichierEntrant;
            //on passe un paramètre un fichier et on rend un fichier txt
            CreateNewTextFile(filePath, outputTextFile);
            CreateNewCSVFile(filePath, outputCsvFile);
            Console.ReadLine();

        }

        private static void CreateNewCSVFile(string filePath, string outputFile)
        {
            string absoluteOutputFilePath = String.Format(@"{0}\{1}", Settings.Default.repertoire, outputFile);
            string myLine = null;
            List<string> allLines = File.ReadLines(filePath).ToList();

            foreach(string line in allLines)
            {
                myLine += String.Format("{0};", line);
            }
            File.AppendAllText(absoluteOutputFilePath, myLine);

        }

        private static void CreateNewTextFile(string filePath, string outputFile)
        {
            string absoluteOutputFilePath = String.Format(@"{0}\{1}", Settings.Default.repertoire, outputFile);
            int linePosition = 0;
            char firstChar;
            List<string> newLines = new List<string>();
            List<string> allLines = File.ReadLines(filePath).ToList();

            foreach(string line in allLines)
            {
                firstChar = line.Remove(0, 4)[0];
                newLines.Add(String.Format("{0}{1} = {2};", firstChar.ToString().ToUpper(), line.Remove(0, 5), linePosition));
                linePosition++;
            }
            File.WriteAllLines(absoluteOutputFilePath, newLines);

        }
    }
}

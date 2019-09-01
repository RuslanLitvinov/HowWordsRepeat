using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWordsRepeat
{
    public class TextFileStrings : IInputString
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == true)
            {
                FilePath = openDialog.FileName;
                return true;   // !!!
            }
            return false;   // !!!
        }
        public List<string> GetStrings()
        {
            // Диалог открытия текстового файла
            if (!OpenFileDialog())
                return null;   // !!!

            List<string> inString = new List<string>();

            //Чтение и возврат коллекции строк
            StreamReader sr = new StreamReader(FilePath);

            string line = sr.ReadLine();

            while (line != null)
            {
                inString.Add(line);
                line = sr.ReadLine();
            }

            return inString;  // !!!
        }
    }
}

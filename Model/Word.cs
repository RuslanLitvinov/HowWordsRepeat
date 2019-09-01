using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWordsRepeat
{
    public class Word 
    {
        private string key;
        private int number;
        public string Key
        {
            get { return key; }
            set { key = value; }
        } 
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
    }
}

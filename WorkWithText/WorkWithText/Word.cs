using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithText
{
    class Word
    {
        public string word;
        public char punctuation;

        public Word(String word, char punctuation)
        {
            this.word = word;
            this.punctuation = punctuation;
        }
        public int GetLength()
        {
            return word.Length;
        }

        public void Change(String str)//меняет на слово, которе вводим
        {
            this.word = str;
        }
    }
}

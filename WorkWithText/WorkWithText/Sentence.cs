using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithText
{
    enum SentType         //тип предложения(сразу присваиваем для удобства, не нужно считывать сразу всё предл)
    {
        Interrogative,//вопросительное
        Exclamatory,//восклицательное
        Declarative//повествовательное
    }

    class Sentence : IComparable<Sentence>
    {
        public List<Word> words = new List<Word>();
        public SentType type;
        public string sentence = null;//для удобства не определён

        public Sentence()//конструктор и в данном случае нам не нужно, чтобы в нем что-то было
        {

        }

        public void Sentences(String sentence, SentType type)
        {
            this.sentence = sentence;
            this.type = type;
        }

        public void Add(Word word)//добавляем в лист
        {
            words.Add(word);
        }

        public int CompareTo(Sentence other)//сравнение по длинне предложения
        {
            if (this.words.Count < other.words.Count) return 1;
            if (this.words.Count > other.words.Count) return -1;
            return 0;
        }
    }
}

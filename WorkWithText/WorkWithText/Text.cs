using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithText
{
    class Text
    {
        public List<Sentence> sentences = new List<Sentence>();//храним лист слов

        public Text()
        {
        }

        public void Add(Sentence sentence)
        {
            sentences.Add(sentence);
        }

        public void Sort()
        {
            this.sentences.Sort();
        }

        public SentType GetType(Sentence sentence)
        {
            if (sentence.type == SentType.Declarative) return SentType.Declarative;
            if (sentence.type == SentType.Exclamatory) return SentType.Exclamatory;
            return SentType.Interrogative;
        }

        public List<String> SameWordsLength(int length)//слова заданной длины
        {
            List<String> lengthWords = new List<String>();
            for (int i = 0; i < sentences.Count; i++)
            {
                if (GetType(sentences[i]) == SentType.Interrogative)
                {
                    for (int j = 0; j < sentences[i].words.Count; j++)
                    {
                        if (sentences[i].words[j].GetLength() == length)
                        {
                            lengthWords.Add(sentences[i].words[j].word);
                        }
                    }
                }
            }
            for (int i = 0; i < lengthWords.Count; i++)
            {
                for (int j = 0; j < lengthWords.Count && j != i; j++)
                {
                    if (lengthWords[i] == lengthWords[j])
                    {
                        lengthWords.Remove(lengthWords[j]);
                        i = 0;
                    }
                }
            }
            return lengthWords;
        }

        public List<String> Concordance()//Обычной проблемой анализа текстов является определение частоты и расположения слов в документе. Эта
//информация запоминается в конкордансе, где различные слова перечислены в алфавитном порядке
        {
            List<String> ABC = new List<String>();

            for (int i = 0; i < sentences.Count; i++)
            {
                for (int j = 0; j < sentences[i].words.Count; j++)
                {
                    if (ABC.Contains(sentences[i].words[j].word))
                    {
                        continue;
                    }
                    else
                    {
                        ABC.Add(sentences[i].words[j].word);
                    }
                }
            }
            ABC.Sort();
            return ABC;
        }
    }
}

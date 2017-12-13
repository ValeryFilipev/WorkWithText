using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithText
{
    class Program
    {
        public static char[] consonantsABC =
{
            'B','C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z', 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'
        };

        public static void Main(string[] args)
        {
            //1.Text Processing
            //Вывести предложения в порядке возрастания по количеству слов
            Parser parser = new Parser();

            Text text = parser.TextParse();

            text.Sort();

            for (int i = 0; i < text.sentences.Count; i++)
            {
                Console.WriteLine("Count of words in sentence: {0}\nSentence: {1}", parser.text.sentences[i].words.Count, parser.text.sentences[i].sentence);
            }

            //Во всех ? предложениях найти и напечатать  без повторений слова заданной длинны

            Console.Write("\nEnter size of word to find in an interrogative sentences: ");
            int lengthOfWord = Int32.Parse(Console.ReadLine());

            List<String> lengthWords = text.SameWordsLength(lengthOfWord);

            for (int i = 0; i < lengthWords.Count; i++)
            {
                Console.WriteLine("Words: " + lengthWords[i]);
            }

            //Из текста удалить все слова заданной длинны, начинающиеся на согласную букву
            Console.Write("\nEnter size of word to delete in text by ABC: ");
            lengthOfWord = Int32.Parse(Console.ReadLine());

            bool flag = false;

            for (int i = 0; i < text.sentences.Count; i++)
            {
                for (int j = 0; j < text.sentences[i].words.Count; j++)
                {
                    if (flag == true)
                    {
                        i = 0;
                    }
                    flag = false;
                    if (text.sentences[i].words[j].GetLength() == lengthOfWord)
                    {
                        for (int k = 0; k < consonantsABC.Length; k++)
                        {
                            if (text.sentences[i].words[j].word[0] == consonantsABC[k])
                            {
                                text.sentences[i].words.RemoveAt(j);
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag == true)
                    {
                        break;
                    }
                }
                if (flag == true)
                {
                    i = 0;
                }
            }

            for (int i = 0; i < text.sentences.Count; i++)
            {
                for (int k = 0; k < text.sentences[i].words.Count; k++)
                {
                    Console.WriteLine(text.sentences[i].words[k].word);
                }
            }

            //В некоторых предложениях текста слова заданной длинны заменить указанной подстрокой, длина которой может не совпадать с длинной слова
            Console.Write("\nEnter size of word to change in text: ");
            lengthOfWord = Int32.Parse(Console.ReadLine());

            Console.Write("Enter string which should be insert into text: ");
            String str = Console.ReadLine();

            text = parser.TextParse();

            for (int i = 0; i < text.sentences.Count; i++)
            {
                for (int j = 0; j < text.sentences[i].words.Count; j++)
                {
                    if (text.sentences[i].words[j].GetLength() == lengthOfWord)
                    {
                        text.sentences[i].words[j].Change(str);
                    }
                }
            }

            for (int i = 0; i < text.sentences.Count; i++)
            {
                for (int j = 0; j < text.sentences[i].words.Count; j++)
                {
                    Console.Write(text.sentences[i].words[j].word + text.sentences[i].words[j].punctuation);
                }
            }

            Console.Write('\n');

            //2.Concordance
            //Вывести список слов в алфавитном порядке для каждого слова указать частоту его в тексте, список номеров строк, если в строке слово повторяетя строку выписывать один раз
            text = parser.TextParse();

            List<String> ABC = text.Concordance();

            int count = 0;

            for (int i = 0; i < ABC.Count; i++)
            {
                List<int> index = new List<int>();
                for (int j = 0; j < text.sentences.Count; j++)
                {
                    for (int k = 0; k < text.sentences[j].words.Count; k++)
                    {
                        if (String.Equals(ABC[i], text.sentences[j].words[k].word) == true)
                        {
                            count++;
                            index.Add(j);
                        }
                    }
                }
                Console.Write("Word: {0}, frequency of repetitions: {1}, lines with this word: ", ABC[i], count + 1);
                for (int q = 0; q < index.Count; q++)
                {
                    for (int j = 0; j < index.Count && j != q; j++)
                    {
                        if (index[q] == index[j])
                        {
                            index.Remove(index[j]);
                            q = 0;
                        }
                    }
                }
                for (int l = 0; l < index.Count; l++)
                {
                    Console.Write(index[l] + " ");
                }
                Console.Write('\n');
                count = 0;
            }
            Console.ReadKey();
        }
    }
}
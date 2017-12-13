using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithText
{
    class Parser
    {
        String Path = Directory.GetCurrentDirectory() + "\\" + "text.txt";
        public static char[] punctuationMarks = { ',', '-', ':', ';', '\'', '(', ')', ' ', '\n' };
        public static char[] endMarks = { '.', '!', '?' };
        public Text text;
        public Sentence sent;
        public Word nextWord;

        public Parser()
        {
        }

        public Text TextParse()
        {
            String word = null;
            String sentense = null;
            SentType type = SentType.Interrogative;
            if (File.Exists(Path))
            {
                using (StreamReader file = new StreamReader(Path))
                {
                    text = new Text();
                    sent = new Sentence();
                    while (!file.EndOfStream)
                    {
                        char ch = (char)file.Read();
                       // if ((int)ch == 13 || (int)ch == 10) ch = ' ';//для того, чтобы не выводило непонятные символы
                        if (punctuationMarks.Contains(ch) || endMarks.Contains(ch))
                        {
                            nextWord = new Word(word, ch);
                            sentense += word + ch;
                            word = null;
                            if (endMarks.Contains(ch))
                            {
                                for (int i = 0; i < punctuationMarks.Length; i++)
                                {
                                    if (ch == '.')
                                    {
                                        type = SentType.Declarative;
                                        break;
                                    }
                                    else if (ch == '!')
                                    {
                                        type = SentType.Exclamatory;
                                        break;
                                    }
                                    else
                                    {
                                        type = SentType.Interrogative;
                                        break;
                                    }
                                }
                                sent.Add(nextWord);
                                sent.Sentences(sentense, type);
                                text.Add(sent);
                                sent = new Sentence();
                                sentense = null;
                            }
                            else
                            {
                                sent.Add(nextWord);
                            }
                            for (int i = 0; i < punctuationMarks.Length; i++)
                            {
                                if (file.Peek() == (int)punctuationMarks[i])
                                {
                                    ch = (char)file.Read();
                                }
                            }
                        }
                        else
                        {
                            word += ch;
                        }
                    }
                }
            }
            return text;
        }
    }
}
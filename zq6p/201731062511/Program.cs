using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _201731062511
{
    public class Program
    {
        static void Main(string[] args)
        {
            string gettext = Console.ReadLine();
            string text = @gettext;
            
            if (!File.Exists(text))
            {
                Console.WriteLine("文件不存在！");
                return;
            }
            Hashtable ht = new Hashtable(StringComparer.OrdinalIgnoreCase);
            StreamReader sr = new StreamReader(text, System.Text.Encoding.UTF8);
            string line = sr.ReadToEnd();

            StreamWriter sw = new StreamWriter(@"C:\Users\VULCAN\WordCount\out.txt");
            Console.SetOut(sw);
            Console.WriteLine("字符数:{0}", CountChar(line));
            Console.WriteLine("换行数:{0}", CountLines(line));
            sw.Flush();
            sw.Close();
            CountWord(text);
            Console.ReadKey();
        }
        public static int CountChar(string text)//统计字符数
        {
            int counter = 0;
            foreach (var num in text)
            {
                if (num < 128 && num >= 0)
                    counter++;
            }
            return counter;
        }
        public static int CountLines(string text)//统计换行数
        {
            int counter = 0;
            foreach (var num in text)
            {
                if (num == '\n')
                    counter++;
            }

            return counter;
        }
        public static void CountWord(string text)
        {
            if (!File.Exists(text))
            {
                Console.WriteLine("文件不存在！");
                return;
            }
            Hashtable ht = new Hashtable(StringComparer.OrdinalIgnoreCase);
            StreamReader sr = new StreamReader(text, System.Text.Encoding.UTF8);
            string line = sr.ReadLine();
            string[] wordArr = null;
            int num = 0;
            while (!sr.EndOfStream)
            {
                wordArr = line.Split(' ');
                foreach (string s in wordArr)
                {
                    if (s.Length == 0)
                        continue;
                    //去除标点
                    line = Regex.Replace(line, @"[\p{P}*]", "", RegexOptions.Compiled);
                    //将单词加入哈希表
                    if (ht.ContainsKey(s))
                    {
                        num = Convert.ToInt32(ht[s]) + 1;
                        ht[s] = num;
                    }
                    else
                    {
                        ht.Add(s, 1);
                    }
                }
                line = sr.ReadLine();
            }
            ArrayList keysList = new ArrayList(ht.Keys);
            //对Hashtable中的Keys按字母序排列
            keysList.Sort();
            //按次数进行插入排序【稳定排序】，所以相同次数的单词依旧是字母序
            string tmp = String.Empty;
            int valueTmp = 0;
            for (int i = 1; i < keysList.Count; i++)
            {
                tmp = keysList[i].ToString();
                valueTmp = (int)ht[keysList[i]];//次数
　　              int j = i;
                while (j > 0 && valueTmp > (int)ht[keysList[j - 1]])
                {
                    keysList[j] = keysList[j - 1];
                    j--;
                }
                keysList[j] = tmp;//j=0
            }
            //打印出来
            StreamWriter sw = new StreamWriter(@"C:\Users\VULCAN\WordCount\out.txt", true);
            Console.SetOut(sw);
            Console.WriteLine($"单词总数：{keysList.Count}");
            int f = 0;
            foreach (object item in keysList)
            {
                Console.WriteLine(item.ToString() + ":" + ht[item].ToString());
                f++;
                if (f > 10)
                    break;
            }
            sw.Flush();
            sw.Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

namespace SantaClauseConsoleApp
{
    class Program
    {
        Child andrei= new Child();
        Child andreea;
        Child stefan;
        static void Main(string[] args)
        {
            Question1();
            Question2();
            Question3();
            Question4();
            Question5();
            Question6();
        }

        static void Question1()
        {
            Child child_number1 = new Child(1,"Andrei",new DateTime(2010, 12, 25),"Cluj-Napoca, Str. Observatorului, Nr 14", BehaviorEnum.Good, new Letter(new DateTime(2021, 12, 20), new List<Item>(2) { new Item(1, "Ursulet"), new Item(2, "Masinuta") }));
            Child child_number2 = new Child(2,"Andreea",new DateTime(2009, 08, 12),"Brasov, Str. M. Eminescu, Nr 28", BehaviorEnum.Good, new Letter(new DateTime(2021, 12, 21), new List<Item>(2) { new Item(3, "Set Lego"), new Item(4, "PS5") }));
            Child child_number3 = new Child(3,"Stefan",new DateTime(2005, 05, 3),"Bucuresti, Str. Gheorghe Lazar, Nr 36", BehaviorEnum.Bad, new Letter(new DateTime(2021, 12, 22), new List<Item>(2) { new Item(5, "RTX 3090TI"), new Item(6, "128 GB RAM DDR5 3400MHZ") }));

        }

        public static async Task WriteInFile(Child child, int index_letter)
        {
            int days = (DateTime.Now - child.Date_of_birth).Days;
            int age;
            age = days / 365;
            string text =
                "Dear Santa, \n" +
                "I am " + child.Name + "\n" +
                "I am " + age + " years old. I live at " + child.Address + ". I have been a very " + 
                child.Behavior + " child this year \nWhat I would like the most this Christmas is:\n" +
                child.Letter.Items[0].Name + "," + child.Letter.Items[1].Name;

            await File.WriteAllTextAsync("TextLetter"+index_letter+".txt", text);
        }

        static Child createchild(string text, int index)
        {
            Child child;
            string patternName = @"am [A-Z]+";
            string patternAge = @"am [0-9]+";
            string patternAddress = @"at [a-zA-Z/-]+[,] +[a-zA-Z/.]+ [a-zA-Z/.]+ [a-zA-Z/,]+ [a-zA-Z]+ [0-9]+";
            string patternBehav = @"very [a-zA-Z]+";
            string patternItems = @"[a-zA-Z]+,[a-zA-Z]+";
            Match mName = Regex.Match(text, patternName, RegexOptions.IgnoreCase);
            Match mAge = Regex.Match(text, patternAge, RegexOptions.IgnoreCase);
            Match mAddress = Regex.Match(text, patternAddress, RegexOptions.IgnoreCase);
            Match mBehav = Regex.Match(text, patternBehav, RegexOptions.IgnoreCase);
            Match mItems = Regex.Match(text, patternItems, RegexOptions.IgnoreCase);
            string name="";
            string age="";
            string address = "";
            string behav = "";
            string items = "";
            string[] words = { "", "" };
            int behavior = 0;
            DateTime birthday= new DateTime(1,1,1);
            if (mName.Success){
                name = mName.Value.Substring(3, (mName.Value.Length - 3));
            }
            if (mAge.Success){
                age = mAge.Value.Substring(3, (mAge.Value.Length - 3));
                int days = Int32.Parse(age) * 365;
                var baseDate = new DateTime(1, 1, 1);
                var end = baseDate.AddDays(days);
                int year = (DateTime.Now.Year +(end.Year - baseDate.Year));
                int month = (DateTime.Now.Month -(end.Month - baseDate.Month));
                int day = (DateTime.Now.Day -(end.Day - baseDate.Day));
                birthday = new DateTime(year, month, end.Day - baseDate.Day);
            }
            if (mAddress.Success)
            {
                address = mAddress.Value.Substring(3, (mAddress.Value.Length - 3));
            }
            if (mBehav.Success)
            {
                behav = mBehav.Value.Substring(5, (mBehav.Value.Length - 5));
                if (behav.Equals("Good"))
                    behavior = 0;
                else
                    behavior = 1;
            }
            if (mItems.Success)
            {
                items = mItems.Value.Substring(0, mItems.Value.Length);
                words = items.Split(',');
            }
            child = new Child(index, name, birthday, address, (BehaviorEnum)behavior, new Letter(new DateTime(2021,12,22), items: new List<Item>(2) { new Item((index+8), words[0]), new Item((index + 9), words[1]) }));
            return child;
        }
        static void Question2()
        {
            Child child_number1 = new Child(1, "Andrei", new DateTime(2010, 12, 25), "Cluj-Napoca, Str. Nicolae Titulescu, Nr 14", BehaviorEnum.Good, new Letter(new DateTime(2021, 12, 20), new List<Item>(2) { new Item(1, "Ursulet"), new Item(2, "Masinuta") }));
            Child child_number2 = new Child(2, "Andreea", new DateTime(2009, 08, 12), "Brasov, Str. M. Eminescu, Nr 28", BehaviorEnum.Good, new Letter(new DateTime(2021, 12, 21), new List<Item>(2) { new Item(3, "Lego"), new Item(4, "PS5") }));
            Child child_number3 = new Child(3, "Stefan", new DateTime(2008, 05, 3), "Bucuresti, Str. Gheorghe Lazar, Nr 36", BehaviorEnum.Bad, new Letter(new DateTime(2021, 12, 22), new List<Item>(2) {new Item(5,"PC") , new Item(6, "SSD") }));
            WriteInFile(child_number1, 1);
            WriteInFile(child_number2, 2);
            WriteInFile(child_number3, 3);

            string text1 = System.IO.File.ReadAllText(@"C:\Users\anama\OneDrive\Desktop\ddroidd\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\bin\Debug\net5.0\TextLetter1.txt");
            string text2 = System.IO.File.ReadAllText(@"C:\Users\anama\OneDrive\Desktop\ddroidd\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\bin\Debug\net5.0\TextLetter2.txt");
            string text3 = System.IO.File.ReadAllText(@"C:\Users\anama\OneDrive\Desktop\ddroidd\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\bin\Debug\net5.0\TextLetter3.txt");
            Child c1 = createchild(text1,5);
            Child c2 = createchild(text2,6);
            Child c3 = createchild(text3,7);
            Console.WriteLine(c1.Name);
            Console.WriteLine(c2.Name);
            Console.WriteLine(c3.Name+"\n");
        }

        static void Question3()
        {
            Child child_number1 = new Child(4, "Mihai", new DateTime(2005, 12, 24), "Sibiu, Str. Nicolae Titulescu, Nr 74", BehaviorEnum.Good, new Letter(new DateTime(2021, 12, 20), new List<Item>(2) { new Item(1, "Ceas"), new Item(2, "Adidasi") }));
            Child child_number2 = new Child(5, "Mihaela", new DateTime(2004, 08, 11), "Brasov, Str. M. Eminescu, Nr 88", BehaviorEnum.Good, new Letter(new DateTime(2021, 12, 21), new List<Item>(2) { new Item(3, "Controler"), new Item(4, "PS5") }));
            Child child_number3 = new Child(6, "Adrian", new DateTime(2003, 05, 5), "Bucuresti, Str. Gheorghe Lazar, Nr 56", BehaviorEnum.Bad, new Letter(new DateTime(2021, 12, 22), new List<Item>(2) { new Item(5, "Laptop"), new Item(6, "PS5") }));
            WriteInFile(child_number1, 4);
            WriteInFile(child_number2, 5);
            WriteInFile(child_number3, 6);

        }

        static string[] ReadItems(string text)
        {
            string patternItems = @"[a-zA-Z]+,[a-zA-Z]+";
            Match mItems = Regex.Match(text, patternItems, RegexOptions.IgnoreCase);
            string items = "";
            string[] words = { "", "" };
            if (mItems.Success)
            {
                items = mItems.Value.Substring(0, mItems.Value.Length);
                words = items.Split(',');
            }
            return words;
        }

        static void report(Dictionary<string, int> dict, string[] words)
        {
            int firstitem = 0;
            int seconditem = 0;
            int val1 = 0;
            int val2 = 0;
            foreach (var kvp in dict)
            {
                if (words[0].Equals(kvp.Key))
                {
                    firstitem = 1;
                    val1 = kvp.Value;
                    val1 = val1 + 1;
                }
                if (words[1].Equals(kvp.Key))
                {
                    seconditem = 1;
                    val2 = kvp.Value;
                    val2 = val2 + 1;
                }
            }
            if(firstitem==0)
            {
                dict.Add(words[0], 1);
            }
            else
            {
                foreach (var kvp in dict)
                {
                    if (words[0].Equals(kvp.Key))
                    {
                        dict.Remove(words[0]);
                        dict.Add(words[0], val1);
                        break;
                    }   
                }
            }
            if (seconditem == 0)
            {
                dict.Add(words[1], 1);
            }
            else
            {
                foreach (var kvp in dict)
                {
                    if (words[1].Equals(kvp.Key))
                    {
                        dict.Remove(words[1]);
                        dict.Add(words[1], val2);
                        break;
                    }
                }

            }
            

        }
        static void Question4()
        {
            Dictionary<string, int> dict =new Dictionary<string, int>();
            string[] words = { "", "" };
            string text1 = System.IO.File.ReadAllText(@"C:\Users\anama\OneDrive\Desktop\ddroidd\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\bin\Debug\net5.0\TextLetter4.txt");
            string text2 = System.IO.File.ReadAllText(@"C:\Users\anama\OneDrive\Desktop\ddroidd\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\bin\Debug\net5.0\TextLetter5.txt");
            string text3 = System.IO.File.ReadAllText(@"C:\Users\anama\OneDrive\Desktop\ddroidd\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\bin\Debug\net5.0\TextLetter6.txt");
            words = ReadItems(text1);
            report(dict, words);
            words=ReadItems(text2);
            report(dict, words);
            words =ReadItems(text3);
            report(dict, words);
            var sortedDict = from kvp in dict orderby kvp.Value descending select kvp;
            foreach (var value in sortedDict)
            {
                Console.WriteLine(value.Key+" - "+value.Value);
            }
        }

        static void Question5()
        {
            /*
             * No, because singletons don't allow any parameters to be specified when creating the instance
             */
        }

        static string[] ReadAddress(string text)
        {
            string patternAddress = @"at [a-zA-Z/-]+[,] +[a-zA-Z/.]+ [a-zA-Z/.]+ [a-zA-Z/,]+ [a-zA-Z]+ [0-9]+";
            Match mAddress = Regex.Match(text, patternAddress, RegexOptions.IgnoreCase);
            string address = "";
            string[] words = { "", "" };
            if (mAddress.Success)
            {
                address = mAddress.Value.Substring(3, (mAddress.Value.Length - 3));
                words = address.Split(", S");
                words[1] = words[1].Insert(0,"S");
            }
            return words;
        }

        static void travelitinerary(Dictionary<string, string> dict, string[] words)
        {
            int firstitem = 0;
            foreach (var kvp in dict)
            {
                if (words[0].Equals(kvp.Key))
                {
                    firstitem = 1;
                    break;
                }
            }
            if (firstitem == 0)
            {
                dict.Add(words[0], words[1]);
            }
            else
            {
                foreach (var kvp in dict)
                {
                    if (words[0].Equals(kvp.Key))
                    {
                        dict.Add(kvp.Key, words[1]);
                        break;
                    }
                }
            }
        }
        static void Question6()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string[] words = { "", "" };
            string text1 = System.IO.File.ReadAllText(@"C:\Users\anama\OneDrive\Desktop\ddroidd\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\bin\Debug\net5.0\TextLetter4.txt");
            string text2 = System.IO.File.ReadAllText(@"C:\Users\anama\OneDrive\Desktop\ddroidd\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\bin\Debug\net5.0\TextLetter5.txt");
            string text3 = System.IO.File.ReadAllText(@"C:\Users\anama\OneDrive\Desktop\ddroidd\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\bin\Debug\net5.0\TextLetter6.txt");
            words = ReadAddress(text1);
            travelitinerary(dict, words);
            words = ReadAddress(text2);
            travelitinerary(dict, words);
            words = ReadAddress(text3);
            travelitinerary(dict, words);
            var dictionary = dict.GroupBy(dict => dict.Key);
        }
    }
}

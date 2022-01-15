using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MyString
{

    class RunClass
    {
        public static void Run(){
            // stringTest();
            // stringBuilderTest();
            // TestFormat();
            // TestFormat1();
            // TestFormat2();
            // TestFormat3();
            // TestFormat4();
            TestRex();
        }

        public static void print<T>(T o){
            System.Console.WriteLine( $"{o}");
            return;
        }   

        //字符串构造示例
        public static void stringTest(){
            string greetingText = "Hello from all the guys at Wrox Press. "; 
            //这里有说法的
            //greetingText是不可变的数据类型，意味着它保存着的数据内容没办法被修改。
            //因此对字符串内容的修改，实际上是在创建一个新字符串，然后让其引用到新的字符串对象上
            //旧的数据对象，会在下次gc时被清理掉。
            greetingText += "We do hope you enjoy this book as much as we enjoyed writing it.";


            // 现在要对字符串编码，将其中的每个字符的ASCII值加1

            //string greetingText = "Hello from all the guys at Wrox Press. "; 
            //greetingText += "We do hope you enjoy this book as much as we " + "enjoyed writing it."; 
            print($"Not encoded:\n {greetingText}"); 
            for(int i = 'z'; i>= 'a'; i--) { 
                char old1 = (char)i; 
                char new1 = (char)(i+1); 
                greetingText = greetingText.Replace(old1, new1); //引用替换
            } 
            for(int i = 'Z'; i>='A'; i--) { 
                char old1 = (char)i; 
                char new1 = (char)(i+1); 
                greetingText = greetingText.Replace(old1, new1);//引用替换 
            } 
            print($"Encoded:\n {greetingText}");


            
            //在本示例中，Replace（）方法以一种智能的方式工作，在某种程度上，
            //它并没有创建一个新字符串，除非其实际上要对旧字符串进行某些改变。
            //原来的字符串包含23个不同的小写字母和3个不同的大写字母。所以Replace（）分配一个新字符串，共计分配26次，
            //每个新字符串都包含103个字符。因此加密过程需要在堆上有一个总共能存储2678个字符的字符串对象，该对象最终将等待被垃圾收集！
            //显然，如果使用字符串频繁进行文字处理，应用程序就会遇到严重的性能问题。


        }

        public static void stringBuilderTest(){
            var greetingBuilder = new StringBuilder("Hello from all the guys at Wrox Press. ", 150); 
            greetingBuilder.AppendFormat("We do hope you enjoy this book as much " + "as we enjoyed writing it");

            // var greetingBuilder = new StringBuilder("Hello from all the guys at Wrox Press. ", 150); 
            // greetingBuilder.AppendFormat("We do hope you enjoy this book as much " + "as we enjoyed writing it"); 
            print("Not Encoded:\n" + greetingBuilder); 
            for(int i = 'z'; i>='a'; i--) { 
                char old1 = (char)i; 
                char new1 = (char)(i+1); 
                greetingBuilder.Replace(old1, new1); 
                //greetingBuilder = greetingBuilder.Replace(old1, new1); 
            } 
            for(int i = 'Z'; i>='A'; i--) { 
                char old1 = (char)i; char new1 = (char)(i+1); 
                greetingBuilder.Replace(old1, new1); 
                //greetingBuilder = greetingBuilder.Replace(old1, new1); 
            } 
            print("Encoded:\n" + greetingBuilder);


        }

        public static void TestFormat(){
            int x = 3, y = 4; 
            FormattableString s = $"The result of {x} + {y} is {x + y}"; 
            print($"format: {s.Format }"); 
            for (int i = 0; i < s.ArgumentCount ; i++) { 
                print($"argument {i}: {s.GetArgument(i)} "); 
            }

        }
        private static string Invariant(FormattableString s) => s.ToString(CultureInfo.InvariantCulture);

        public static void TestFormat1(){
            var day = new DateTime(2025, 2, 14); 
            print($"{day:d}"); 
            print(Invariant($"{day:d}") );


        }
        public static void TestFormat2(){
            string s = "Hello"; 
            print($"{{s}} displays the value of s: {s}");

            string formatString = $"{s}, {{0}}"; 
            //相当于
            //string formatString = String.Format("{0}, {{0}}", s);
            string s2 = "World"; 
            System.Console.WriteLine(formatString, s2);
        }
        public static void TestFormat3(){
            var day = new DateTime(2025, 2, 14); 
            print($"{day:D}"); 
            print($"{day:d}");
            print($"{day:dd-MM-yyyy}");
        }
        public static void TestFormat4(){
            var p1 = new Person { FirstName = "Stephanie", LastName = "Nagel" }; 
            print(p1.ToString("F"));
            print($"{p1:L}");// =>相当于 p1.ToString("L")

        }

        public static void TestRex(){

            const string input = @"This book is perfect for both experienced C# programmers looking to " 
            + "sharpen their skills and professional developers who are using C# for "
            + "the first time. The authors deliver unparalleled coverage of " 
            + "Visual Studio 2013 and .NET Framework 4.5.1 additions, as well as " 
            + "new test-driven development and concurrent programming features. " 
            + "Source code for all the examples are available for download, so you " 
            + "can start writing Windows desktop, Windows Store apps, and ASP.NET " 
            + "web applications immediately.";

            Find1(input);


        }

        public static void Find1(string text) { 
            const string pattern = @"ion.{3}"; 
            //第三个参数是匹配选项
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture); 
            foreach (Match nextMatch in matches) { 
                print(nextMatch.Value); 
            } 
        }

        public static void WriteMatches(string text, MatchCollection matches) { 
            print($"Original text was: \n\n{text}\n"); 
            print($"No. of matches: {matches.Count}"); 
            foreach (Match nextMatch in matches) { 
                int index = nextMatch.Index; 
                string result = nextMatch.ToString(); 
                int charsBefore = (index < 5) ? index : 5; 
                int fromEnd = text.Length - index - result.Length; 
                int charsAfter = (fromEnd < 5) ? fromEnd : 5; 
                int charsToDisplay = charsBefore + charsAfter + result.Length; 
                print($"Index: {index}, \tString: {result}, \t" + "{text.Substring(index - charsBefore, charsToDisplay)}"); 
            } 
        }


    }

    public class Person : IFormattable { 
        //方法 IFormattable => ToString(String, IFormatProvider)
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public override string ToString() => FirstName + " " + LastName; 
        public virtual string ToString(string format) => ToString(format, null); 
        public string ToString(string format, IFormatProvider formatProvider) { 
            switch (format) { 
                case null: 
                case "A": return ToString(); 
                case "F": return FirstName; 
                case "L": return LastName; 
                default: 
                throw new FormatException($"invalid format string {format}"); 
            } 
        } 
    }



}
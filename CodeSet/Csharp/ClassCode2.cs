namespace ClassCode2{
    public static class StringExtension { 
        public static int GetWordCount1(this string s) => s.Split().Length; 
    }
    public static class StringExtension1 { 
        public static int GetWordCount(this string s) => s.Split().Length; 
    }
    public static class StringExtension2{ 
        public static int GetWordCount(this int s) => s*10; 
    }

    class RunClass
    {
        public enum Color{
            red,
            y,
            b,
        }
        //更换类型
        public enum Color1: short{
            red,
            y,
            b,
        }
        
        public static void InputTest(){
            string input2 = Console.ReadLine(); 
            int result; 
            if (int.TryParse(input2, out result) ) 
            { 
                Console.WriteLine($"n: {result}"); 
            } 
            else 
            { 
                Console.WriteLine("not a number"); 
            }
        }
        
        [Flags] public enum DaysOfWeek { 
            Monday = 0x1, Tuesday = 0x2, Wednesday = 0x4, Thursday = 0x8, Friday = 0x10, Saturday = 0x20, Sunday = 0x40 
        }

        [Flags] public enum DaysOfWeek1 { Monday = 0x1, Tuesday = 0x2, Wednesday = 0x4, Thursday = 0x8, Friday = 0x10, Saturday = 0x20, Sunday = 0x40, 
        Weekend = Saturday | Sunday, Workday = 0x1f, AllWeek = Workday | Weekend }

        public static void ChangeValue(Dimensions a){
            a.Length = 100;
        }
        public static void ChangeValue(ref Dimensions a){
            a.Length = 1000;

        }
        public static void ChangeValue(Dimensions1 a){
            a.Length = 100;
            a = new Dimensions1(1001,1001);
        }
        public static void ChangeValue(ref Dimensions1 a){
            a.Length = 1000;
            a = new Dimensions1(10000,10000);
        }

        public static void Run(){
            //匿名类型，字段 = value
            var t1 = new {Firstname = "liliya",LastName = "Wuhu"};
            //如果字段都相同，则t1类型与t2类型一致
            var t3 = new {Firstname = "liliya1",LastName = "Wuhu"};
            //t4 则与t1,t3类型不一致
            var t4 = new {Firstname1 = "liliya1",LastName = "Wuhu"};
            //编译器推断出t2的类型
            var t2 = new String("aaaa");
            Console.WriteLine(t1.GetType().ToString());     
            Console.WriteLine(t4.GetType().ToString());     
            Console.WriteLine(t3.GetType().ToString());     
            Console.WriteLine(t2.GetType().ToString());   


            //引用类型与值类型的区别：
            Dimensions d1 = new Dimensions();
            
            d1.Width = 10;
            d1.Length = 10;  
            Console.WriteLine(d1.Diagonal); 
            Dimensions1 d2 = new Dimensions1(0,0);
            // d2.Width = 10;
            // d2.Length = 10;  
            // Console.WriteLine(d2.Diagonal);   
            //d1为结构体，d2为类，d1为值传递，d2为引用传递
            ChangeValue(d1);
            ChangeValue(d2);
            Console.WriteLine($"d1.Length:{d1.Length}");
            Console.WriteLine($"d2.Length:{d2.Length}");

            ChangeValue(ref d1);
            ChangeValue(ref d2);
            Console.WriteLine($"d1.Length:{d1.Length}");
            Console.WriteLine($"d2.Length:{d2.Length}");


            //InputTest();
            //可空类型
            int int_var = 3;
            int? int_var1 = null;
            //需要类型转换,可空类型也可能为空因此，需要先判空
            //int_var = (int)int_var1; ？？为可空类型的特殊语法，如果可空类型不为空，则提取可空类型的值，否则为操作符后续的值
            int_var = int_var1 ?? -1;
            int_var = int_var1.HasValue ? int_var1.Value : 99;
            //这个不需要类型转换
            int_var1 = int_var;
            Console.WriteLine($"int_var:{int_var}");
            Console.WriteLine($"int_var1:{int_var1}");
            //直接打印不会显示具体的值，而是会打印这个枚举类型的名字
            Console.WriteLine($"Color.red:{(int)Color.red}");
            Console.WriteLine($"Color.red:{(int)Color.y}");
            Console.WriteLine($"Color.red:{(int)Color.b}");

            //隐式类型转换，达咩
            //int ca = Color.red;
            DaysOfWeek day = DaysOfWeek.Friday | DaysOfWeek.Monday;
            Console.WriteLine($"day:{day}");

            DaysOfWeek1 day1 = DaysOfWeek1.Saturday | DaysOfWeek1.Sunday;
            Console.WriteLine($"day:{day1}");


            string fox = "the quick brown fox jumped over the lazy dogs down " + "9876543210 times"; 
            int wordCount = fox.GetWordCount(); 
            Console.WriteLine($"{wordCount} words");

            Console.WriteLine($"{wordCount.GetWordCount()} words");

            
        }
    }
    //结构体，值类型，初始化在栈上
    public struct Dimensions { 
        public double Length { get; set; }
        public double Width { get; set; } 
        public Dimensions(double length, double width) { Length = length; Width = width; } 
        //表达式属性,返回了Math.Sqrt(Length * Length + Width * Width)
        public double Diagonal => Math.Sqrt(Length * Length + Width * Width); 
    }
    public class Dimensions1 { 
        public double Length { get; set; }
        public double Width { get; set; } 
        public Dimensions1(double length, double width) { Length = length; Width = width; } 
        //表达式属性,返回了Math.Sqrt(Length * Length + Width * Width)
        public double Diagonal => Math.Sqrt(Length * Length + Width * Width); 
    }
}
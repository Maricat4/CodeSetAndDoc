///操作符
using System.Collections.Generic;
using System.Collections;
using System;
namespace MyDelegate{
    class RunClass
    {
        public static void Run(){
            testDelegate();
            testDelegate2();
            testDelegate3();
        }
        public static void print<T>(T o){
            System.Console.WriteLine( $"{o}");
            return;
        }
        private delegate string GetAString(); 
        public static void testDelegate(){
            
            int x = 40; 
            int y = 50;
            GetAString firstStringMethod = new GetAString(x.ToString); 
            GetAString firstStringMethod1 = y.ToString;
            // With firstStringMethod initialized to x.ToString(),
            print($"String is {firstStringMethod()}"); 
            x = 50;
            print($"String is {firstStringMethod1()}"); 
            // the above statement is equivalent to saying 
            // Console.WriteLine($"String is {x.ToString()}"); }

        }
        //private delegate string GetAString(); 
        public static void testDelegate2() { 
            int x = 40; 
            GetAString firstStringMethod = x.ToString; 
            print($"String is {firstStringMethod()}"); 
            var balance = new Currency(34, 50); 
            // firstStringMethod references an instance method 
            firstStringMethod = balance.ToString; 
            print($"String is {firstStringMethod()}"); 
            // firstStringMethod references a static method 
            firstStringMethod = new GetAString(Currency.GetCurrencyUnit); 
            print($"String is {firstStringMethod()}"); 
        }
        delegate double DoubleOp(double x);
        public static void testDelegate3() { 
            Func<double,double>[] operations = { MathOperations.MultiplyByTwo, MathOperations.Square }; 
            for (int i=0; i < operations.Length; i++) { 
                print($"Using operations[{i}]:"); 
                ProcessAndDisplayNumber(operations[i], 2.0); 
                ProcessAndDisplayNumber(operations[i], 7.94); 
                ProcessAndDisplayNumber(operations[i], 1.414);
                print("");
            } 
        } 
        static void ProcessAndDisplayNumber(Func<double,double> action, double value) { 
            double result = action(value); 
            print($"Value is {value}, result of operation is {result}"); 
        }

    }


    struct Currency { 
        public uint Dollars; 
        public ushort Cents; 
        public Currency(uint dollars, ushort cents) 
        { this.Dollars = dollars; this.Cents = cents; } 
        public override string ToString() => $"${Dollars}.{Cents,2:00}"; 
        public static string GetCurrencyUnit() => "Dollar"; 
        public static explicit operator Currency (float value) { 
            checked { 
                uint dollars = (uint)value; ushort cents = (ushort)((value-dollars) * 100);
                 return new Currency(dollars, cents); 
                } 
        } 
        public static implicit operator float (Currency value) => value.Dollars + (value.Cents / 100.0f); 
        public static implicit operator Currency (uint value) => new Currency(value, 0); 
        public static implicit operator uint (Currency value) => value.Dollars; 
    }


    
    class MathOperations { 
        public static double MultiplyByTwo(double value) => value * 2; 
        public static double Square(double value) => value * value; 
    }

     


}
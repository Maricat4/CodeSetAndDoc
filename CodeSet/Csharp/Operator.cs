///操作符
using System.Collections.Generic;
using System.Collections;
using System;

namespace MyOperator{
    class RunClass
    {
        public static void Run(){
            int a = 10;
            NameA a1 = new NameA();
            NameA a2 = a1;
            string s1 = "strtest";
            System.Console.WriteLine($"{nameof(a1.a)}:{a1.a}");
            System.Console.WriteLine($"{nameof(s1)}:{s1}");
            NameA a3 = new NameA();
            System.Console.WriteLine(convert(a3));

            BiJiaoOp();

            //运算符重载
            opover();

            //索引器重载
            opIndex();
            
            //类型转换重载
            opkh();
            opkh1();
        }


        //没办法传递名称，读取的变量为当前作用域内的变量名
        public static string convert(object o){
            return $"{nameof(o)}";
        }
        public static void print<T>(T o){
            System.Console.WriteLine( $"{o}");
            return;
        }
        public static void Method(object o) { 
            if (o == null) throw new ArgumentNullException(nameof(o));
        }
        public static void BiJiaoOp() { 
            //引用的比较
            NameA x,y,z,v;
            x = new NameA();
            y = new NameA();
            z = null;
            v = null;
            var k = x;
            print(Object.ReferenceEquals(x,y));
            print(Object.ReferenceEquals(x,k));
            print(Object.ReferenceEquals(x,z));
            print(Object.ReferenceEquals(v,z));
            print("------------------------");
            print(Object.Equals(x,y));
            print(Object.Equals(x,k));
            print(Object.Equals(x,z));
            print(Object.Equals(v,z));
            print("------------------------");
            var kk = new NameA(-999);
            print(kk.Equals(x));
            print(y.Equals(x));
        }


        public static void opover(){

            Vector vect1, vect2, vect3,vect4; 
            vect1 = new Vector(3.0, 3.0, 1.0); 
            vect2 = new Vector(2.0, -4.0, -4.0); 
            vect4 = new Vector(2.0, -4.0, -4.0); 
            vect3 = vect1 + vect2; 
            print($"vect1 = {vect1}"); 
            print($"vect2 = {vect2}"); 
            print($"vect3 = {vect3}");
            print(vect3 == vect2);
            print(vect3 != vect2);
            print(Object.Equals(vect2,vect2));
            print(Object.Equals(vect2,vect4));
            
        }

        //索引器重载
        public static void opIndex(){
            var p1 = new Person("Ayrton", "Senna", new DateTime(1960, 3, 21)); 
            var p2 = new Person("Ronnie", "Peterson", new DateTime(1944, 2, 14)); 
            var p3 = new Person("Jochen", "Rindt", new DateTime(1942, 4, 18)); 
            var p4 = new Person("Francois", "Cevert", new DateTime(1944, 2, 25)); 
            var coll = new PersonCollection(p1, p2, p3, p4); 
            print(coll[2]); 
            foreach (var r in coll[new DateTime(1960, 3, 21)]) { 
                print(r); 
            }

        }

        //自定义类型转换
        public static void opkh(){
            float amount = 45.63f; 
            Currency amount2 = (Currency)amount;

            print(amount2);
            // Currency amount3 = amount;
        }

        public static void opkh1(){
            try { 
                var balance = new Currency(50,35); 
                print(balance); 
                print($"balance is {balance}"); // implicitly invokes ToString 
                float balance2= balance; 
                print($"After converting to float, = {balance2}"); 
                balance = (Currency) balance2; 
                print($"After converting back to Currency, = {balance}"); 
                print("Now attempt to convert out of range value of " + "-$50.50 to a Currency:"); 
                checked { 
                    balance = (Currency) (-50.50); 
                    print($"Result is {balance}"); 
                    } 
                } 
            catch(Exception e) { 
                print($"Exception occurred: {e.Message}"); 
            }
        }
    }
    class NameA
    {
        public int a;

        public NameA(int val = -1)
        {
            a = val;
        }

        // override object.Equals
        // public override bool Equals(object obj)
        // {
        //     //
        //     // See the full list of guidelines at
        //     //   http://go.microsoft.com/fwlink/?LinkID=85237
        //     // and also the guidance for operator== at
        //     //   http://go.microsoft.com/fwlink/?LinkId=85238
        //     //
            
        //     if (obj == null || GetType() != obj.GetType())
        //     {
        //         return false;
        //     }
            
        //     // TODO: write your implementation of Equals() here
        //     NameA t = (NameA)obj;
        //     if(t.a == a) return true;
        //     return false;
        //     // return base.Equals (obj);
        // }
        
        // // override object.GetHashCode
        // public override int GetHashCode()
        // {
        //     // TODO: write your implementation of GetHashCode() here
        //     throw new System.NotImplementedException();
        //     return base.GetHashCode();
        // }
    }

    class Vector { 
        public Vector(double x, double y, double z) { X = x; Y = y; Z = z; } 
        public Vector(Vector v) { X = v.X; Y = v.Y; Z = v.Z; } 
        public double X { get; } 
        public double Y { get; } 
        public double Z { get; } 
        public override string ToString() => $"( {X}, {Y}, {Z} )"; 


        //运算符重载
        public static Vector operator + (Vector left, Vector right) => new Vector(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        //参数顺序会影响编译器识别表达式，第一个为左，第二个为右，其中，int类型乘以
        public static Vector operator * (double left, Vector right) => new Vector(left * right.X, left * right.Y, left * right.Z);
        public static Vector operator * (Vector left , double right) => right * left;

        public static bool operator == (Vector left , Vector right) { 
            if (object.ReferenceEquals(left, right)) return true; 
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z; 
        }

        public static bool operator != (Vector left , Vector right) => ! (right == left);
    }


    public class Person { 
        public DateTime Birthday { get; } 
        public string FirstName { get; } 
        public string LastName { get; } 
        public Person(string firstName, string lastName, DateTime birthDay) { 
            FirstName = firstName; 
            LastName = lastName; 
            Birthday = birthDay; 
        } 
        public override string ToString() => $"{FirstName} {LastName}"; 
    }

    public class PersonCollection { 
        private Person[] _people; 
        public PersonCollection(params Person[] people) { 
            _people =people.ToArray();
        } 

        public Person this[int index] { get { return _people[index]; } set { _people[index] = value; } }
        //不仅仅可以用int作为索引，DataTime也行

        //返回的一个可Person迭代器
        public IEnumerable<Person> this[DateTime birthDay] { get { return _people.Where(p => p.Birthday == birthDay); } }

    }
    

    public struct Currency { 
        public uint Dollars { get; } 
        public ushort Cents { get; } 
        public Currency(uint dollars, ushort cents) { Dollars = dollars; Cents = cents; } 
        public override string ToString() => $"${Dollars}.{Cents, -2:00}"; 
        
        public static implicit operator float(Currency value) => value.Dollars + (value.Cents/100.0f);

        public static explicit operator Currency (float value) { 
            uint dollars = (uint)value; 
            ushort cents = (ushort)((value-dollars)*100); 
            return new Currency(dollars, cents); 
        }
    }
    
}
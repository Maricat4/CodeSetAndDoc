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
}
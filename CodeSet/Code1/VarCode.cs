namespace myLearn_11_10 { 
    using static System.Console; 
    using System;
    using System.Linq.Expressions;
    class Program { 
        static void Main() 
        { 
            my_varClass.run();
        } 
    }
    class my_class{
        private int m_a;
        private int m_b;
        public int a{set{m_a = value;}get{return m_a;}}
        public int b{set{m_b = value;}get{return m_b;}}
        // public my_class(){
        //     WriteLine(m_a.ToString()+"ma");
        //     WriteLine(m_b.ToString()+"mb");
        // } 
        public int retMa()
        {
            return m_a + m_b;
        }
    }
    //变量的一些测试代码
    class my_varClass{
        public static void run(){
            //未初始化的对象单纯为一个引用，没有东西，此实例为语法错误，过不了编译
            // my_class a;
            // WriteLine(a.retMa());

            //正确的对象创建
            my_class t = new my_class();
            WriteLine(GetName2(() => t)+t.retMa());
            my_class t1;
            t1 = new my_class();
            WriteLine(GetName2(() => t1)+t1.retMa().ToString());

            //类型推断
            var var1 = t1;
            WriteLine(GetName2(() => var1));

            //作用域
            // { 
            //     for (int i = 0; i < 10; i++) { WriteLine(i); }
            //     // i goes out of scope here 
            //     // We can declare a variable named i again, because 
            //     // there's no other variable with that name in scope 
            //     for (int i = 9; i >= 0; i --) { WriteLine(i); } // i goes out of scope here. 
            //     //return 0; 
            // } 
            //作用域
            // int j = 20; 
            // for (int i = 0; i < 10; i++) 
            // { 
            //     int j = 30; // Can't do this - j is still in scope 
            //     WriteLine(j + i);
            // }


            //变量类型
            int i = 20,j = i;
            i += 1;
            WriteLine(GetName2(()=>i)+i.ToString());
            WriteLine(GetName2(()=>j)+j.ToString());
            //由于int是值类型因此i，j存在不同的内存位置

            my_class mc1 = new my_class(),mc2 = mc1;
            //由于my_class自定义类型，因此它为引用类型
            WriteLine(GetName2(()=>mc1.a)+mc1.a.ToString());
            WriteLine(GetName2(()=>mc2.a)+mc2.a.ToString());
            mc1.a = 99999;
            //mc1 = null;
            WriteLine(GetName2(()=>mc1.a)+mc1.a.ToString());
            WriteLine(GetName2(()=>mc2.a)+mc2.a.ToString());
        }
        //获取变量名字的方法
        //使用实例
        // GetName(new { var1 });
        // GetName2(() => var1);
        // GetName3(() => var1);
        static string GetName<T>(T item) where T : class 
        {
            return typeof(T).GetProperties()[0].Name;
        }

        static string GetName2<T>(Expression<Func<T>> expr) 
        {
            return ((MemberExpression)expr.Body).Member.Name+":";
        }

        static string GetName3<T>(Func<T> expr) 
        {
            return expr.Target.GetType().Module.ResolveField(BitConverter.ToInt32(expr.Method.GetMethodBody().GetILAsByteArray(), 2)).Name;
        }
    }
}



using System;

namespace ClassCode
{
    class RunClass
    {
        public static void Run(){

            // ClassA tmp = new ClassA(3);
            // Console.WriteLine(tmp.Output(1,c:3));
            // Console.WriteLine(tmp.Output(1,4));
            // Console.WriteLine(tmp.Output(1,2,4,5,1));
            // Console.WriteLine(tmp.Output(1,2,4,5,"gggggg"));
            // Console.WriteLine(tmp.a);
            Console.WriteLine(ClassA._stB);
        }
    }

    class ClassA
    {
        //构造函数
        static ClassA(){
            Console.WriteLine("ClassA静态构造函数");
            _stB = 0;
        }
        //构造函数2
        public ClassA(int a){
            Console.WriteLine("ClassA构造函数");
            //_a = a;
        }
        //字段
        private int _a;

        public static int _stB;
        //属性
        public int a{get{return _a;}private set{}}
    
        //可变参数
        public int Output(int a,int b = 1,int c = 2,int d = 4){
            Console.WriteLine("OutPut1");
            Console.WriteLine("C:"+c.ToString());
            return a + b + c + d;
        }

        public int Output(params int[] ans){
            Console.WriteLine("OutPut2");
            
            var sum = 0;
            foreach (var item in ans)
            {
                sum+=item;
            }
            return sum;
        }
        public string Output(params object[] ans){
            Console.WriteLine("OutPut3");
            
            var sum = "";
            foreach (var item in ans)
            {
                sum+=item.ToString();
            }
            return sum;
        }
    }
}
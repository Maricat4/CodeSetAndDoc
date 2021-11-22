//类继承
namespace ClassCode3{
    class RunClass
    {
        public static void Run(){
            var t1 = new DerivedClass();
            BaseClass t2 = new DerivedClass();
            ITest i1 = new DerivedClass();
            t1.print();
            System.Console.WriteLine("-----------------------t1 end");
            t2.print();

            System.Console.WriteLine("---------------------------------");
            var Base = new Shape();
            var Base_d = new Ellipse();
            Shape Base_1 = new Ellipse();
            Base.MoveBy(0,0);
            Base_d.MoveBy(0,0);
            Base_1.MoveBy(0,0);
            System.Console.WriteLine("---------------------------------");
            i1.print1();
            i1.print2();
            i1.print3();
            System.Console.WriteLine("---------------------------------");
            BaseClass t3 = new BaseClass();
            TestIsAs(t3);
            TestIsAs(t2);
            TestIsAs(Base_1);
        }

        public static void TestIsAs(object o){
            if(o is BaseClass){
                var t = o as ITest;
                //不是该类型时返回空引用
                if(t!=null){
                    System.Console.WriteLine("both baseClass ITest");
                    t.print1();
                    return;
                }
                else
                {
                    System.Console.WriteLine("not ITest");
                    return;    
                }
                
            }
            System.Console.WriteLine("not baseClass");
        }
    }
    //隐式public
    public interface ITest{
        void print1();
        void print2();
        void print3();
    }
    class BaseClass{
        public BaseClass(){
            System.Console.WriteLine("BaseClass init");
        }
        private int _j;
        public virtual int print(){
            System.Console.WriteLine($"BaseClass,and j:{_j}");
            return _j;
        }
    }

    class DerivedClass:BaseClass,ITest{
        public DerivedClass(){
            System.Console.WriteLine("DerivedClass init");
        }
        public override int print(){
            System.Console.WriteLine($"DerivedClass,and j:-1");
            return -1;
        }
        public void print1(){
            System.Console.WriteLine("ITest,print1");
        }
        public void print2(){
            System.Console.WriteLine("ITest,print2");
        }
        public void print3(){
            System.Console.WriteLine("ITest,print3");
        }
    }

    public class Shape { // various members 
        public Shape(){

        }
        public Shape(int x,int y){

        }
        public void MoveBy(int x, int y) { 
            System.Console.WriteLine("Shape_MoveBy");
            
        }
        private void MoveTo(int x, int y) { 
            System.Console.WriteLine("Shape_MoveTo");
            
        }
    }

    public class Ellipse: Shape { 
        public Ellipse():base(0,0){

        }
        new public void MoveBy(int x, int y) { 
            System.Console.WriteLine("Ellipse_MoveBy");
        } 
    }
}
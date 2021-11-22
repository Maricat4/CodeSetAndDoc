namespace Generic
{
    using System.Collections;
    using System.Collections.Generic;
    class RunClass{
        public static void Run(){
            System.Console.WriteLine("-------------Generic-------------");
            TestTypeChange();
            System.Console.WriteLine("-------------Generic-------------");
        }

        //装箱拆箱实例
        private static void TestTypeChange(){
            // 下面的例子显示了System.Collections名称空间中的ArrayList类。
            // ArrayList存储对象，Add（）方法定义为需要把一个对象作为参数，所以要装箱一个整数类型。
            //在读取ArrayList中的值时，要进行拆箱，把对象转换为整数类型。
            //可以使用类型强制转换运算符把ArrayList集合的第一个元素赋予变量i1，在访问int类型的变量i2的foreach语句中，也要使用类型强制转换运算符：

            var list = new ArrayList(); 
            list.Add(44); // boxing - convert a value type to a reference type 
            int i1 = (int)list[0]; // unboxing - convert a reference type to a value type 
            foreach (int i2 in list) { 
                System.Console.WriteLine(i2); // unboxing 
            }
            // 装箱和拆箱操作很容易使用，但性能损失比较大，遍历许多项时尤其如此。

            // System.Collections.Generic名称空间中的List<T>类不使用对象，而是在使用时定义类型。
            // 在下面的例子中，List<T>类的泛型类型定义为int，所以int类型在JIT（Just-In-Time）编译器动态生成的类中使用，不再进行装箱和拆箱操作：

            var glist = new List<int>();
            glist.Add(55);
            int gi = glist[0];//不需要拆箱
            foreach (int item in glist)
            {
                System.Console.WriteLine(item);//不需要拆箱
            }

            int t = 14;
            Nullable<int> a = t;
            t = (int)a;


            var accounts = new List<Account>() { 
                new Account("Christian", 1500), 
                new Account("Stephanie", 2200), 
                new Account("Angela", 1800), 
                new Account("Matthias", 2400) };
            decimal amount = Algorithms.AccumulateSimple(accounts);
            decimal amount1 = Algorithms.Accumulate(accounts);
            System.Console.WriteLine(amount);
            System.Console.WriteLine(amount1);
        }
    }


    public class LinkedListNode { 
        public LinkedListNode(object value) { Value = value; } 
        public object Value { get; private set; } 
        public LinkedListNode Next { get; internal set; } 
        public LinkedListNode Prev { get; internal set; } 
    }
    public class LinkedList: IEnumerable { 
        public LinkedListNode First { get; private set; } 
        public LinkedListNode Last { get; private set; } 
        public LinkedListNode AddLast(object node) { 
            var newNode = new LinkedListNode(node); 
            if (First == null) { 
                First = newNode; 
                Last = First; 
            } 
            else 
            {
                LinkedListNode previous = Last; Last.Next = newNode; Last = newNode; Last.Prev = previous; 
            } 
            return newNode; 
        } 
        public IEnumerator GetEnumerator() {
            //yield语句创建一个枚举器的状态机
            LinkedListNode current = First; 
            while (current != null) { 
                yield return current.Value; 
                current = current.Next; 
            } 
        } 
    }
    public class LinkedListNode<T> { 
        public LinkedListNode(T value) { Value = value; } 
        public T Value { get; private set; } 
        public LinkedListNode<T> Next { get; internal set; } 
        public LinkedListNode<T> Prev { get; internal set; } 
    }
    public class LinkedList<T>: IEnumerable<T> { 
        public LinkedListNode<T> First { get; private set; } 
        public LinkedListNode<T> Last { get; private set; } 
        public LinkedListNode<T> AddLast(T node) { 
            var newNode = new LinkedListNode<T>(node); 
            if (First == null) { First = newNode; Last = First; } 
            else { LinkedListNode<T> previous = Last; 
                Last.Next = newNode; Last = newNode; 
                Last.Prev = previous; } return newNode; 
            } 
            public IEnumerator<T> GetEnumerator() { 
                LinkedListNode<T> current = First; 
                while (current != null) { 
                    yield return current.Value; 
                    current = current.Next; 
                } 
            } 
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 
    }

    // 协变与抗变
    class baseC<T>
    {
        private int _id;
    }
    class c1<T>:baseC<T>,ITest<T>
    {
        public int Test(T a){
            return 0;
        }
        public float Test1(T a){
            return 0;
        }
    }

    interface ITest<in T>{
        int Test(T a);
        float Test1(T a);
    };
    interface ITest1<out T>{
        int Test(int a);
        T Test1(int a);
    };


    public struct Nullable<T> where T: struct { 
        public Nullable(T value) { _hasValue = true; _value = value; } 
        private bool _hasValue; 
        public bool HasValue => _hasValue; 
        private T _value; 
        public T Value { get { if (! _hasValue) { throw new InvalidOperationException("no value"); } return _value; } } 
        //用户定义的强制类型转换操作符
        public static explicit operator T(Nullable<T> value) {
            System.Console.WriteLine("强制类型转换");
            return value.Value;
        }
        public static implicit operator Nullable<T>(T value){
            System.Console.WriteLine("隐式类型转换");
            return new Nullable<T>(value);
        } 
        public override string ToString() => ! HasValue ? string.Empty : _value.ToString(); 
    
    }



    public class Account:IAccount { 
        public string Name { get; } 
        public decimal Balance { get; private set; } 
        public Account(string name, Decimal balance) { Name = name; Balance = balance; } 
    }
    public interface IAccount { decimal Balance { get; } string Name { get; } }
    public static class Algorithms { 
        public static decimal AccumulateSimple(IEnumerable<Account> source) { 
            decimal sum = 0; 
            foreach (Account a in source) { 
                sum += a.Balance; 
            } 
            return sum; 
        } 

        public static decimal Accumulate<TAccount>(IEnumerable<TAccount> source) where TAccount: IAccount { 
            decimal sum = 0; 
            foreach (TAccount a in source) { 
                sum += a.Balance; 
            } 
            return sum; 
        }

        public static T2 Accumulate1<T1, T2>(IEnumerable<T1> source, Func<T1, T2, T2> action) { 
            T2 sum = default(T2); 
            foreach (T1 item in source) { 
                sum = action(item, sum); 
            } 
            return sum; 
        }

    }


    public class MethodOverloads { 
        public void Foo<T>(T obj) { System.Console.WriteLine($"Foo<T>(T obj), obj type: {obj.GetType().Name}"); } 
        public void Foo(int x) { System.Console.WriteLine("Foo(int x)"); } 
        public void Foo<T1, T2>(T1 obj1, T2 obj2) { System.Console.WriteLine($"Foo<T1, T2>(T1 obj1, T2 obj2); {obj1.GetType().Name} " + $"{obj2.GetType().Name}"); } 
        public void Foo<T>(int obj1, T obj2) { System.Console.WriteLine($"Foo<T>(int obj1, T obj2); {obj2.GetType().Name}"); } 
        public void Bar<T>(T obj) { Foo(obj); } }

}
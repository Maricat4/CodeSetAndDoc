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


}
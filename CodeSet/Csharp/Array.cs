using System.Collections.Generic;
using System.Collections;
using System;
namespace MyArray
{
    class RunClass
    {
        public static void Run(){
            int[] array1;
            array1 = new int[4];
            
            printArr(array1);
            List<int> arr = new List<int>{1,2,3,45,1};
            printArr(arr);

            int[, ] twodim = new int[3, 3]; 
            twodim[0, 0] = 1; twodim[0, 1] = 2; twodim[0, 2] = 3; 
            twodim[1, 0] = 4; twodim[1, 1] = 5; twodim[1, 2] = 6; 
            twodim[2, 0] = 7; twodim[2, 1] = 8; twodim[2, 2] = 9;
            foreach (int item in twodim) { 
                System.Console.WriteLine(item.ToString()); 
            }
            int[][] jagged = new int[3][]; 
            jagged[0] = new int[2] { 1, 2 }; 
            jagged[1] = new int[6] { 3, 4, 5, 6, 7, 8 }; 
            jagged[2] = new int[3] { 9, 10, 11 };

            HelloCollection hc = new HelloCollection();
            foreach (var item in hc)
            {
                System.Console.WriteLine(item);
            }
            //printArr(twodim);
        }

        public static void printArr<T1>(IEnumerable<T1> source) { 
            System.Console.WriteLine("--------------IEnumerable--------------"); 
            foreach (T1 item in source) { 
                System.Console.WriteLine(item.ToString()); 
            }
            System.Console.WriteLine("--------------IEnumerable--------------"); 
        }

        public static void testEnum(){
            HelloCollection hc = new HelloCollection(); 
            IEnumerator<int> enumerator = hc.GetEnumerator(); 
            while (enumerator.MoveNext()) { 
                int p = enumerator.Current; 
                System.Console.WriteLine(p); 
            }
        }
    }

    public class HelloCollection { 
        int[] _data = {1,2,3,5,6,7};
        int index = 0;
        public IEnumerator<int> GetEnumerator() { 
            yield return _data[index++]; 
            yield return _data[index++]; 
        } 
    }
    
    public class HelloCollection1 { 
        public IEnumerator GetEnumerator() => new Enumerator(0); 
        public class Enumerator:IEnumerator<string>, IEnumerator, IDisposable { 
            private int _state;
            private string _current;
            public Enumerator(int state) {
                 _state = state; 
            } 
            bool System.Collections.IEnumerator.MoveNext() { 
                switch (_state) { 
                case 0: _current = "Hello"; _state = 1; 
                return true; 
                case 1: _current = "World"; _state = 2; 
                return true; 
                case 2: 
                break; 
                } 
                return false;
            } 
            void System.Collections.IEnumerator.Reset() { 
                throw new NotSupportedException(); 
            } 
            string System.Collections.Generic.IEnumerator<string>.Current => _current; 
            object System.Collections.IEnumerator.Current => _current; 
            
            void IDisposable.Dispose() { } 
        }
    }

}
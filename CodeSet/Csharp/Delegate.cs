///操作符
using System.Collections.Generic;
using System.Collections;
using System;
using System.Windows;
// PackageReference System.Windows();
namespace MyDelegate{
    class RunClass
    {
        public static void Run(){
            // testDelegate();
            // testDelegate2();
            // testDelegate3();
            // SortTest();
            // MultiDelegate();
            // AnonymousMethod();
            // AnonymousMethod1();
            EventDipatch();
            EventDipatch1();
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

        static void SortTest() { 
            Employee[] employees = { 
                new Employee("Bugs Bunny", 20000), 
                new Employee("Elmer Fudd", 10000), 
                new Employee("Daffy Duck", 25000), 
                new Employee("Wile Coyote", 1000000.38m), 
                new Employee("Foghorn Leghorn", 23000), 
                new Employee("RoadRunner", 50000) }; 
            Sort(employees, Employee.CompareSalary); 
            foreach (var employee in employees) { print(employee); }

        }
        
        static void MultiDelegate(){
            Action<double> operations = MathOperations.MultiplyByTwo1; 
            operations += MathOperations.Square1;
            operations(10);
        }


        static public void Sort<T>(IList<T> sortArray, Func<T, T, bool> comparison){
            bool swapped = true; 
            do { 
                swapped = false; 
                for (int i = 0; i < sortArray.Count - 1; i++) { 
                    if (comparison(sortArray[i],sortArray[i+1]))
                    // problem with this test 
                    { 
                        T temp = sortArray[i]; 
                        sortArray[i] = sortArray[i + 1]; 
                        sortArray[i + 1] = temp; 
                        swapped = true; 
                    } 
                } 
            } while (swapped);

        }


        static public void AnonymousMethod() { 
            string mid = ", middle part, "; 
            Func<string, string> anonDel = delegate(string param) { 
                param += mid; 
                param += " and this was added to the string."; 
                return param; 
            }; 
            print(anonDel("Start of string")); 
        } 

        static void AnonymousMethod1() { 
            string mid = ", middle part, "; 
            Func<string, string> lambda = param => { 
                param += mid; param += " and this was added to the string."; 
                return param; 
            }; 
            print(lambda("lambda")); 
        }
        static void EventDipatch() { 
            var dealer = new CarDealer(); 
            var daniel = new Consumer("Daniel"); 
            var michael = new Consumer("michael"); 
            //var sebastian = new Consumer("sebastian");

            dealer.NewCarInfo += michael.NewCarIsHere; 
            dealer.NewCar("Mercedes"); 
            var sebastian = new Consumer("Sebastian"); 
            dealer.NewCarInfo += sebastian.NewCarIsHere; 
            dealer.NewCar("Ferrari"); 
            dealer.NewCarInfo -= sebastian.NewCarIsHere; 
            dealer.NewCar("Red Bull Racing"); 
        }
        static void EventDipatch1() { 
            var dealer = new CarDealer(); 
            var daniel = new Consumer("Daniel"); 
            WeakEventManager<CarDealer, CarInfoEventArgs>.AddHandler(dealer, "NewCarInfo", daniel.NewCarIsHere);
            dealer.NewCar("Mercedes"); 
            var sebastian = new Consumer("Sebastian"); 
            WeakEventManager<CarDealer, CarInfoEventArgs>.AddHandler(dealer, "NewCarInfo", sebastian.NewCarIsHere); 
            dealer.NewCar("Ferrari"); 
            WeakEventManager<CarDealer, CarInfoEventArgs>.RemoveHandler(dealer, "NewCarInfo", sebastian.NewCarIsHere); 
            dealer.NewCar("Red Bull Racing");
        }


    }

    class Employee { 
        public Employee(string name, decimal salary) { Name = name; Salary = salary; } 
        public string Name { get; } 
        public decimal Salary { get; private set; } 
        public override string ToString() => $"{Name}, {Salary:C}"; 
        public static bool CompareSalary(Employee e1, Employee e2) => e1.Salary < e2.Salary; 
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
        public static void MultiplyByTwo1(double value){ 
            RunClass.print(value * 2);
        }
        public static double Square(double value) => value * value; 
        public static void Square1(double value) {
            RunClass.print(value * value);
            
        } 
    }

     
    public class CarInfoEventArgs: EventArgs { 
        public CarInfoEventArgs(string car) { Car = car; } 
        public string Car { get; } 
    } 
    public class CarDealer { 
        public event EventHandler<CarInfoEventArgs> NewCarInfo; 
        public void NewCar(string car) { 
            RunClass.print($"事件发布, 有车车来了 {car}"); 
            NewCarInfo? .Invoke(this, new CarInfoEventArgs(car)); 
            //相当于：
            // EventHandler<CarInfoEventArgs> newCarInfo = NewCarInfo; 
            // if (newCarInfo ! = null) { 
            //     newCarInfo(this, new CarInfoEventArgs(car)
            // );
        } 
    }

    public class Consumer { 
        private string _name; 
        public Consumer(string name) { 
            _name = name; 
        }
        public void NewCarIsHere(object sender, CarInfoEventArgs e) { 
            RunClass.print($"我{_name}知道: 车车 {e.Car} 它来了,发布者{sender.ToString()}"); 
        } 
    }


    public class Consumer1: IWeakEventListener { 
        private string _name; 
        public Consumer1(string name) { this._name = name; } 
        public void NewCarIsHere(object sender, CarInfoEventArgs e) { 
            RunClass.print("Consumer1{_name}: car {e.Car} is new"); 
        }
        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e) { 
             NewCarIsHere(sender, e as CarInfoEventArgs); 
             return true; 
        } 
    }


}
using System.Collections.Generic;
using System.Collections;
using System;
namespace MyList
{
    class RunClass
    {
        public static void Run(){
            //test1();
            //sortlist();
            // dc();        
            testSet();
        }

        public static void sortlist(){
            var books = new SortedList<string, string>(); 
            books.Add("Professional WPF Programming", "978-0-470-04180-2"); 
            books.Add("Professional ASP.NET MVC 5", "978-1-118-79475-3"); 
            books["Beginning Visual C# 2012"] = "978-1-118-31441-8"; 
            books["Professional C# 5 and .NET 4.5.1"] = "978-1-118-83303-2";

            foreach (KeyValuePair<string, string> book in books) { 
                print($"{book.Key}, {book.Value}"); 
            }

        } 
        public static void print<T>(T o){
            System.Console.WriteLine( $"{o}");
            return;
        }   
        public static void dc(){
            var employees = new Dictionary<EmployeeId, Employee>(31); 
            var idTony = new EmployeeId("C3755"); 
            var tony = new Employee(idTony, "Tony Stewart", 379025.00m); 
            var idCarl = new EmployeeId("F3547"); 
            var carl = new Employee(idCarl, "Carl Edwards", 403466.00m); 
            var idKevin = new EmployeeId("C3386"); 
            var kevin = new Employee(idKevin, "Kevin Harwick", 415261.00m); 
            var idMatt = new EmployeeId("F3323"); 
            var matt = new Employee(idMatt, "Matt Kenseth", 1589390.00m); 
            var idBrad = new EmployeeId("D3234"); 
            var brad = new Employee(idBrad, "Brad Keselowski", 322295.00m); 
            employees = new Dictionary<EmployeeId, Employee>(31) { 
                [idTony] = tony, 
                [idCarl] = carl, 
                [idKevin] = kevin, 
                [idMatt] = matt, 
                [idBrad] = brad 
            }; 
            foreach (var employee in employees.Values) { print(employee);}
        }
        public static void test1(){
            //创建列表
            var intlst = new List<int>();
            var racers = new List<Racer>();
            var graham = new Racer(7, "Graham", "Hill", "UK", 14); 
            var emerson = new Racer(13, "Emerson", "Fittipaldi", "Brazil", 14); 
            var mario = new Racer(16, "Mario", "Andretti", "USA", 12); 
            var racers1 = new List<Racer>(20) {graham, emerson, mario}; 
            racers1.Add(new Racer(24, "Michael", "Schumacher", "Germany", 91)); 
            racers1.Add(new Racer(27, "Mika", "Hakkinen", "Finland", 20));
            racers1.Sort(new RacerComparer(RacerComparer.CompareType.Wins));
            foreach (var item in racers1)
            {
                print(item.ToString("W"));
            }
        }
        public static void printArr<T1>(IEnumerable<T1> source) { 
            System.Console.WriteLine("--------------IEnumerable--------------"); 
            foreach (T1 item in source) { 
                System.Console.WriteLine(item.ToString()); 
            }
            System.Console.WriteLine("--------------IEnumerable--------------"); 
        }

        public static void testSet(){
            var companyTeams = new HashSet<string>() { "Ferrari", "McLaren", "Mercedes" }; 
            var traditionalTeams = new HashSet<string>() { "Ferrari", "McLaren" }; 
            var privateTeams = new HashSet<string>() { "Red Bull", "Toro Rosso", "Force India", "Sauber" }; 
            if (privateTeams.Add("Williams")) { 
                print("Williams added"); 
            } 
            if (! companyTeams.Add("McLaren")) { 
                print("McLaren was already in this set"); 
            }
            if (traditionalTeams.IsSubsetOf(companyTeams)) { 
                print("traditionalTeams is subset of companyTeams"); 
            }
            if (companyTeams.IsSupersetOf(traditionalTeams)) {
                print("companyTeams is a superset of traditionalTeams"); 
            }
            traditionalTeams.Add("Williams"); 
            //重叠
            if (privateTeams.Overlaps(traditionalTeams)) { 
                print("At least one team is the same with traditional and private teams"); 
            }
            
            var allTeams = new SortedSet<string>(companyTeams); 
            allTeams.UnionWith(privateTeams); 
            allTeams.UnionWith(traditionalTeams); 
            print("all teams"); 
            foreach (var team in allTeams) { print(team); }

            allTeams.ExceptWith(privateTeams); 
            print("no private team left"); 
            foreach (var team in allTeams) { print(team); }
        }
    }

   public class Racer: IComparable<Racer>, IFormattable { 
        public int Id { get; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Country { get; set; } 
        public int Wins { get; set; } 
        public Racer(int id, string firstName, string lastName, string country) :this(id, firstName, lastName, country, wins: 0) { } 
        public Racer(int id, string firstName, string lastName, string country, int wins) { 
            Id = id; FirstName = firstName; LastName = lastName; Country = country; Wins = wins; 
            } 
        public override string ToString() => $"{FirstName} {LastName}"; 
        public string ToString(string format, IFormatProvider formatProvider) { 
            if (format == null) format = "N"; 
            switch (format.ToUpper()) { 
                case "N": // name 
                    return ToString(); 
                case "F": // first name 
                return FirstName; 
                case "L": // last name 
                    return LastName; 
                case "W": // Wins 
                    return $"{ToString()}, Wins: {Wins}"; 
                case "C": // Country 
                    return $"{ToString()}, Country: {Country}"; 
                case "A": // All 
                return $"{ToString()}, Country: {Country} Wins: {Wins}"; 
                default: throw new FormatException(String.Format(formatProvider, $"Format {format} is not supported")); 
            }
        } 
        public string ToString(string format) => ToString(format, null); 
        public int CompareTo(Racer other) { 
            int compare = LastName? .CompareTo(other? .LastName) ?? -1; 
            if (compare == 0) {
                return FirstName? .CompareTo(other? .FirstName) ?? -1;
            } 
            return compare; 
        } 
    }

    public class RacerComparer : IComparer<Racer> { 
        public enum CompareType { 
            FirstName, 
            LastName, 
            Country, 
            Wins 
        } 
        private CompareType _compareType; 
        public RacerComparer(CompareType compareType) { _compareType = compareType; } 
        public int Compare(Racer x, Racer y) { 
            if (x == null && y == null) return 0; 
            if (x == null) return -1; 
            if (y == null) return 1; 
            int result; 
            switch (_compareType) { 
                case CompareType.FirstName: 
                    return string.Compare(x.FirstName, y.FirstName); 
                case CompareType.LastName: 
                    return string.Compare(x.LastName, y.LastName); 
                case CompareType.Country: 
                    result = string.Compare(x.Country, y.Country); 
                    if (result == 0) return string.Compare(x.LastName, y.LastName); 
                    else return result; 
                case CompareType.Wins: return x.Wins.CompareTo(y.Wins); 
                    default: throw new ArgumentException("Invalid Compare Type"); 
            } 
        } 
    }

    public class EmployeeIdException : Exception { 
        public EmployeeIdException(string message) : base(message) { } 
    } 
    public struct EmployeeId : IEquatable<EmployeeId> { 
        private readonly char _prefix; 
        private readonly int _number; 
        public EmployeeId(string id) { 
            //Contract.Requires<ArgumentNullException>(id ! = null); 
            _prefix = (id.ToUpper())[0]; int numLength = id.Length - 1; 
            try {
                    _number = int.Parse(id.Substring(1, numLength > 6 ? 6 : numLength)); 
                }
            catch (FormatException) { 
                throw new EmployeeIdException("Invalid EmployeeId format"); 
            } 
        } 
        public override string ToString() => _prefix.ToString() + $"{_number,6:000000}"; 
        public override int GetHashCode() => (_number ^ _number << 16) * 0x15051505; 
        public bool Equals(EmployeeId other) => (_prefix == other._prefix && _number == other._number); 
        public override bool Equals(object obj) => Equals((EmployeeId)obj); 
        public static bool operator ==(EmployeeId left, EmployeeId right) => left.Equals(right);
        public static bool operator !=(EmployeeId left, EmployeeId right) => !(left == right); 
    }


    public class Employee { 
        private string _name; 
        private decimal _salary; 
        private readonly EmployeeId _id; 
        public Employee(EmployeeId id, string name, decimal salary) { 
            _id = id; _name = name; _salary = salary; 
        } 
        public override string ToString() => $"{_id.ToString()}: {_name, -20} {_salary:C}"; 
    }
}
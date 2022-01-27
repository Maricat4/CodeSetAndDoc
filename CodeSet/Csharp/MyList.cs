using System.Collections.Generic;
using System.Collections;
using System;
namespace MyList
{
    class RunClass
    {
        public static void Run(){
            
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
        }
        public static void printArr<T1>(IEnumerable<T1> source) { 
            System.Console.WriteLine("--------------IEnumerable--------------"); 
            foreach (T1 item in source) { 
                System.Console.WriteLine(item.ToString()); 
            }
            System.Console.WriteLine("--------------IEnumerable--------------"); 
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

}
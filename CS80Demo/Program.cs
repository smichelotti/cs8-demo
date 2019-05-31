using System;
using System.Threading.Tasks;

namespace CS80Demo
{
    class Program
    {
        // C# 7.1: Async main (where have you been for the last 7 years??)
        static async Task xMain(string[] args)
        {
            // C# 8.0: Async stream
            await foreach (var item in QueueClient.GetQueueItems())
            {
                Console.WriteLine($"Item is: {item}");
            }
        }

        static void Main(string[] args)
        {
            IPerson person = new Person { FirstName = "Steve", LastName = "Michelotti" };
            Console.WriteLine(person.FullName);
        }

        private static void UsingDeclaration()
        {
            // Typical using statement to Dispose - since C# 1.0
            // C# 8.0: using declaration
            using var file = new System.IO.StreamReader("test.txt");
            var text = file.ReadToEnd();
            Console.WriteLine(text);
            // file is disposed here

        }

        private static void IndicesAndRanges()
        {
            var words = new string[]
                        {
                         // index from start    index from end
                "Do",    // 0                   ^8
                "or",    // 1                   ^7
                "do",    // 2                   ^6
                "not",   // 3                   ^5
                "there", // 4                   ^4
                "is",    // 5                   ^3
                "no",    // 6                   ^2
                "try"    // 7                   ^1
                        };

            Console.WriteLine(words[words.Length - 1]);
            // C# 8.0: Indices
            Console.WriteLine(words[^1]);

            // C# 8.0: Ranges
            var subset = words[1..4];
            DisplayWords(subset);

            var fromEnd = words[^2..^0];
            DisplayWords(fromEnd);

            var fromStartAndEnd = words[2..^2];
            DisplayWords(fromStartAndEnd);

            var allWords = words[..];
            DisplayWords(allWords);

            var first4 = words[..4];
            DisplayWords(first4);

            var last = words[5..];
            DisplayWords(last);

            Range lastRange = 5..;
            DisplayWords(words[lastRange]);



            // C# 7.0: Local Function with Expression Bodied Member
            // C# 8.0: Static Local Function
            static void DisplayWords(string[] items) => Console.WriteLine(string.Join(',', items));
        }

        private static void MorePatterns()
        {
            //ProcessOrPrint(21);
            //ProcessOrPrint("hello");
            //ProcessOrPrint("5/28/2019");

            var premiumCalc = new PremiumCalculator();

            var femaleGoodStudent = new Student { HasGoodGrades = true, Gender = Gender.Female };
            (var goodGrades, var gender) = femaleGoodStudent;
            Console.WriteLine($"The extracted values are: {goodGrades}, {gender}");
            var femaleBadStudent = new Student { HasGoodGrades = false, Gender = Gender.Female };
            var maleGoodStudent = new Student { HasGoodGrades = true, Gender = Gender.Male };
            var maleBadStudent = new Student { HasGoodGrades = false, Gender = Gender.Male };

            Console.WriteLine($"The premium for a female good student is: {premiumCalc.Calculate(femaleGoodStudent):C}");
            Console.WriteLine($"The premium for a female bad student is: {premiumCalc.Calculate(femaleBadStudent):C}");
            Console.WriteLine($"The premium for a male good student is: {premiumCalc.Calculate(maleGoodStudent):C}");
            Console.WriteLine($"The premium for a male bad student is: {premiumCalc.Calculate(maleBadStudent):C}");
        }

        private static void ProcessOrPrint(object value)
        {
            // Pre-C# 7
            ////if (value.GetType() == typeof(int))
            //if (value is int val)
            //{
            //    //var val = (int)value;
            //    var result = val * 2;
            //    Console.WriteLine($"{value} doubled is: {result}");
            //}
            //else if (value is string s && DateTime.TryParse(s, out var date))
            //{
            //    Console.WriteLine($"the year is: {date.Year}");
            //}
            //else
            //{
            //    Console.WriteLine($"Not an int: {value}");
            //}

            // C#7 feature: Pattern matching (switch statement is "when" keyword)
            switch (value)
            {
                case int val:
                    var result = val * 2;
                    Console.WriteLine($"{value} doubled is: {result}");
                    break;
                case string s when DateTime.TryParse(s, out var date):
                    Console.WriteLine($"Year of date is: {date.Year}");
                    break;
                default:
                    Console.WriteLine($"Not an int: {value}");
                    break;
            }
        }

        private static void NullableReferenceTypes()
        {
            var contacts = ContactService.GetContacts();
            foreach (var contact in contacts)
            {
                //var fullName = $"{contact.FirstName} {contact.MiddleName[0]} {contact.LastName}";
                var fullName = contact.MiddleName != null
                    ? $"{contact.FirstName} {contact.MiddleName[0]} {contact.LastName}"
                    : $"{contact.FirstName} {contact.LastName}";
                Console.WriteLine(fullName);
            }
        }
    }
}

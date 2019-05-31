using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS80Demo
{
    public class PremiumCalculator
    {
        public int Calculate(object person) => person switch // C# 8.0: switch expression
        {
            Adult a when a.VehicleCost > 100_000 => 1100,
            Adult a when a.VehicleCost > 60_000 => 800,
            Adult a when a.VehicleCost > 20_000 => 200,

            // C# 8.0: Recursive/nested pattern
            Adult a => a.MaritalStatus switch
            {
                MaritalStatus.Married => 400,
                MaritalStatus.Separated => 500,
                _ => 600
                //MaritalStatus.Single => 600,
                //MaritalStatus.Divorced => 600,
                //MaritalStatus.Widow => 600,
                //_ => throw new ArgumentException("Invalid enum value")
            },

            // C# 8.0: Property patterns
            TruckDriver d => d switch
            {
                { State: "MD" } => 550,
                { State: "VA" } => 650,
                { State: "DC" } => 750,
                _ => 500
            },

            // C# 8.0: Recursive w/positional via Tuple and Deconstructor
            //Student s => s switch
            //{
            //    var (goodGrades, gender) when goodGrades && gender == Gender.Female => 500,
            //    var (goodGrades, gender) when !goodGrades && gender == Gender.Female => 600,
            //    var (goodGrades, gender) when goodGrades && gender == Gender.Male => 700,
            //    var (goodGrades, gender) when !goodGrades && gender == Gender.Male => 800,
            //    _ => throw new ArgumentException("Invalid enum value")
            //},

            Student s => s switch
            {
                (true, Gender.Female) => 500,
                (false, Gender.Female) => 600,
                (true, Gender.Male) => 700,
                (false, Gender.Male) => 800,
                _ => throw new ArgumentException("Invalid enum value")
            },


            { } => throw new ArgumentException(message: "Not a known person type", paramName: nameof(person)),
            null => throw new ArgumentNullException(nameof(person))
        };
    }
}

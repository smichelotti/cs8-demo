using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS80Demo
{
    public class Adult
    {
        public int VehicleCost { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

        //public bool IsMarried
        //{
        //    get
        //    {
        //        switch (this.MaritalStatus)
        //        {
        //            case MaritalStatus.Single:
        //                return false;
        //            case MaritalStatus.Married:
        //                return true;
        //            case MaritalStatus.Separated:
        //                return true;
        //            case MaritalStatus.Divorced:
        //                return false;
        //            case MaritalStatus.Widow:
        //                return false;
        //            default:
        //                throw new ArgumentException("Invalid enum");
        //        }
        //    }
        //}

        // C# 8.0: switch expression
        public bool IsMarried => this.MaritalStatus switch
        {
            MaritalStatus.Married => true,
            MaritalStatus.Separated => true,
            _ => false
            //MaritalStatus.Single => false,
            //MaritalStatus.Divorced => false,
            //MaritalStatus.Widow => false,
            //_ => throw new ArgumentException("Invalid enum")
        };
    }

    public class Student
    {
        public bool HasGoodGrades { get; set; }
        public Gender Gender { get; set; }

        // C# 7.0: Deconstructor
        public void Deconstruct(out bool goodGrades, out Gender gender) => (goodGrades, gender) = (this.HasGoodGrades, this.Gender);
    }

    public class TruckDriver
    {
        public string? State { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum MaritalStatus
    {
        Single,
        Married,
        Separated,
        Divorced,
        Widow
    }
}

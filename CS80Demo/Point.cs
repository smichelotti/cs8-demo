using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS80Demo
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public readonly double Distance => Math.Sqrt(X * X + Y * Y);

        // C# 8.0: readonly members
        public readonly override string ToString() => $"({X}, {Y}) is {Distance} from the origin";
    }
}

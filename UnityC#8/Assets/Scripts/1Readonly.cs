using System;
using UnityEngine;

public class CSharp8_1ReadOnly
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public readonly double Distance => Math.Sqrt(X * X + Y * Y);

        public override readonly string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
    }
    
}

using System;

namespace CSharp8Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new string[]
            {
                // index from start    index from end
                "The", // 0                   ^9
                "quick", // 1                   ^8
                "brown", // 2                   ^7
                "fox", // 3                   ^6
                "jumped", // 4                   ^5
                "over", // 5                   ^4
                "the", // 6                   ^3
                "lazy", // 7                   ^2
                "dog" // 8                   ^1
            }; // 9 (or words.Length) ^0

            Console.WriteLine($"The last word is {words[^0]}");
            var quickBrownFox = words[1..4];
            var lazyDog = words[^2..^0];
            var allWords = words[..]; // contains "The" through "dog".
            var firstPhrase = words[..4]; // contains "The" through "fox"
            var lastPhrase = words[6..]; // contains "the", "lazy" and "dog"

            Range phrase = 1..4;
            var text = words[phrase];

            Span<Coords<int>> coordinates = stackalloc[]
            {
                new Coords<int> {X = 0, Y = 0},
                new Coords<int> {X = 0, Y = 3},
                new Coords<int> {X = 4, Y = 0}
            };
            
            Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };
            var ind = numbers.IndexOfAny(stackalloc[] { 2, 4, 6, 8 });
            Console.WriteLine(ind);  // output: 1
        }

        public struct Coords<T>
        {
            public T X;
            public T Y;
        }
    }
}
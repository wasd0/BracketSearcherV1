using System;

namespace BracketSearcherV1
{
    class Program
    {
        public static void Main(string[] arr)
        {
            string someText = "()";

            DuoBracketsChecker checker = new DuoBracketsChecker();

            Console.WriteLine(checker.TextEualsValidBorders(someText));
            Console.WriteLine(checker.FindMaxBracketPairs(someText));

            Console.ReadKey();
        }
    }

    public class DuoBracketsChecker
    {
        private Stack<char> _leftBorders;
        private Stack<char> _rightBorders;
        private bool _borderIsOpen;

        public DuoBracketsChecker()
        {
            _leftBorders = new Stack<char>();
            _rightBorders = new Stack<char>();
            _borderIsOpen = false;
        }

        public bool TextEualsValidBorders(string text)
        {
            foreach (char c in text)
            {
                if (c == '(')
                {
                    _borderIsOpen = true;
                    _leftBorders.Push(c);
                }
                else if (_borderIsOpen)
                {
                    _leftBorders.Pop();

                    if (_leftBorders.Count == 0) _borderIsOpen = false;
                }
                else return false;
            }
            _leftBorders.Clear();

            if (_borderIsOpen || text.Length == 0) return false;
            else return true;
        }

        public int FindMaxBracketPairs(string text)
        {
            int maxBracketPairs = 0;

            foreach (char c in text)
            {
                if (c == '(')
                {
                    _borderIsOpen = true;
                    _leftBorders.Push(c);
                }
                else if (_borderIsOpen)
                {
                    maxBracketPairs++;
                    _rightBorders.Push(c);
                    _leftBorders.Pop();

                    if (_leftBorders.Count == 0) _borderIsOpen = false; 
                }
            }
            return maxBracketPairs;
        }
    }
}
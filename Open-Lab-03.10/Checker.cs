using System;

namespace Open_Lab_03._10
{
    public class Checker
    {
        public int GetNumberOfCharsInString(char letter, string str)
        {
            int freq = str.Split(letter).Length - 1;
            return freq;
            
        }
    }
}

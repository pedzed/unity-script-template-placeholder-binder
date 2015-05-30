using System;
using System.Globalization;

namespace PedZed.StringManipulation
{
    public class StringToPascalCase : StringManipulator
    {
        public StringToPascalCase(string toPascalCase)
        {
            if(toPascalCase.Length == 1)
            {
                outputString = toPascalCase.ToUpper();
            }
            else
            {
                string[] words = SplitStringIntoWords(toPascalCase);

                outputString = "";
                foreach(string word in words)
                {
                    outputString += char.ToUpper(word[0]);
                    outputString += word.Substring(1);
                }
            }
        }

        private string[] SplitStringIntoWords(string stringToSplit)
        {
            return stringToSplit.Split(
                new char[] {},
                StringSplitOptions.RemoveEmptyEntries
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountOccurence
{
    public class Class1
    {
        public Task<Dictionary<string, int>> CountOccurence(string text)
        {
            string textToLower = text.ToLower();

            Regex reg_exp = new Regex("[^а-я0-9]");
            textToLower = reg_exp.Replace(textToLower, " ");
            string[] Value = textToLower.Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> CountTheOccurrences = new Dictionary<string, int>();
            for (int i = 0; i < Value.Length; i++)                                       // Loop the splited string  
            {
                if (CountTheOccurrences.ContainsKey(Value[i]))                           // Check if word is already in dictionary update the count  
                {
                    int value = CountTheOccurrences[Value[i]];
                    CountTheOccurrences[Value[i]] = value + 1;
                }
                else
                // If we found the same word we just increase the count in the dictionary 
                {
                    CountTheOccurrences.Add(Value[i], 1);
                }
            }
            CountTheOccurrences = CountTheOccurrences.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return Task.FromResult(CountTheOccurrences);
        }
    }
}

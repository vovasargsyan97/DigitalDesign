using CountOccurence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {

        [HttpPost]
        public async Task<Dictionary<string, int>> GetUsedWordsInText(string filePath)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string text = System.IO.File.ReadAllText(filePath);
            Dictionary<string, int> CountWords = new Dictionary<string, int>();

            Class1 obj = new();
            CountWords = await obj.CountOccurence(text);

            //var method = obj.GetType().GetMethod("CountOccurence", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //CountWords = (Dictionary<string, int>)method.Invoke(obj, new object[] { text });

            // StringBuilder sb = new StringBuilder();

            foreach (var kvp in CountWords)
            {
                StreamWriter sw = new StreamWriter(@"C:\gago\Occurence.txt", true, Encoding.UTF8);


                sw.Write(kvp.Key + "--" + kvp.Value + System.Environment.NewLine);

                //close the file
                sw.Close();
            }
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            return CountWords;
        }
    }
}

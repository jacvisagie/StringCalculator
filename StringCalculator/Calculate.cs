using System;

namespace StringCalculator
{
    public class Calculate
    {
        public static string Exceptions { get; set; }
        public static string Result { get; set; }
        public static void Main(string[] args)
        {
            Console.WriteLine("Insert Numbers String to calculate their sum or type 'bye' to exit");

            var Numbers = Console.ReadLine();

            while (Numbers != "bye")
            {
                try
                {

                    //Result = Add(Numbers).ToString();
                    Result = NumbersAdding.Add(Numbers).ToString();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    //return;
                }

                Console.WriteLine($"Your result is :{Result}");
                Numbers = Console.ReadLine();
            }
        }
    }

    public static class NumbersAdding
    {
        public static int Add(string nmbrs)
        {
            //empty string returns 0
            if (nmbrs == "")
                return 0;

            //check if first line contains seperator directives
            var s1 = nmbrs.IndexOf("//");

            //create mem for non seperator directive data
            var sub2 = "";

            //if delimiter directives in first line
            if (s1 != -1)
            {
                //find end of delimiter directives
                var s2 = nmbrs.IndexOf("\n");
                var s3 = s2 + 1;

                //clean delimiter string - get values from after // untill before \n
                var sub1 = nmbrs[2..s2];

                //load data string with rest
                sub2 = nmbrs[s3..];

                //if delimiter string contains multiple delimiters
                if (sub1.IndexOf("[") != -1)
                {
                    //create comma delimmeted from brackets
                    var sub3 = sub1.Replace("][", ",");

                    //remove first and last brackets
                    sub3 = sub3[1..^1];

                    //get string array from result
                    var strlist1 = sub3.Split(",");

                    //foreach delimiter in array, replace with , in data string
                    foreach (var item in strlist1)
                    {
                        sub2 = sub2.Replace(item, ",");
                    }
                }
                else
                {
                    //replace new delimiter in data string with existing default
                    //delimiters = new char[] { char.Parse(sub1) };
                    sub2 = sub2.Replace(sub1, ",");
                }
            }
            else
            {
                //no delimiter directives so load orrigional input string as worker string
                sub2 = nmbrs;
            }

            //clean rest of string by replacing carriage returns with default delimiter
            sub2 = sub2.Replace("\n", ",");

            //split string by delimeters into string array
            var strlist = sub2.Split(',');

            //sum total to be returned
            var summer = 0;
            var exceptns = "";

            foreach (var item in strlist)
            {
                var newint = 0;

                _ = Int32.TryParse(item, out newint);

                //add negative values to exception string
                if (newint < 0)
                {
                    exceptns = $"{exceptns},{newint}";
                }
                else
                {
                    //do addition
                    summer += newint;
                }
            }

            if (exceptns.Length > 0)
            {
                var excString1 = exceptns.Substring(1);
                var excString2 = $"negatives not allowed : {excString1}";
                throw new Exception(excString2);
            }

            return summer;
        }
    }
}

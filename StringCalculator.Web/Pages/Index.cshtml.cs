using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StringCalculator.Web.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICalculateService _calculateService;

        [BindProperty]
        public InputStringsViewModel Input { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ICalculateService calculateService)
        {
            _logger = logger;
            _calculateService = calculateService;
        }

        public void OnGet() {}

        public IActionResult OnPost(string action)
        {
            try
            {
                Input.Output1 = _calculateService.Calculate(Input.Input1);//NumbersAdding.Add(Input.Input1).ToString();
            }
            catch (Exception ex)
            {
                Input.Output1 = ex.Message;
            }

            return Page();
        }
    }

    //public static class NumbersAdding
    //{
    //    public static int Add(string nmbrs)
    //    {
    //        //empty string returns 0
    //        if (nmbrs == "")
    //            return 0;

    //        //remove escapes - generated by textbox
    //        var unescapedString = Regex.Unescape(nmbrs);

    //        //check if first line contains seperator directives
    //        var s1 = unescapedString.IndexOf("//");

    //        //create mem for non seperator directive data
    //        var sub2 = "";

    //        //if delimiter directives in first line
    //        if (s1 != -1)
    //        {
    //            //find end of delimiter directives
    //            var s2 = unescapedString.IndexOf("\n");
    //            var s3 = s2 + 1;

    //            //clean delimiter string - get values from after // untill before \n
    //            var sub1 = unescapedString[2..s2];

    //            //load data string with rest
    //            sub2 = unescapedString[s3..];

    //            //if delimiter string contains multiple delimiters
    //            if (sub1.IndexOf("[") != -1)
    //            {
    //                //create comma delimmeted from brackets
    //                var sub3 = sub1.Replace("][", ",");

    //                //remove first and last brackets
    //                sub3 = sub3[1..^1];

    //                //get string array from result
    //                var strlist1 = sub3.Split(",");

    //                //foreach delimiter in array, replace with , in data string
    //                foreach (var item in strlist1)
    //                {
    //                    sub2 = sub2.Replace(item, ",");
    //                }
    //            }
    //            else
    //            {
    //                //replace new delimiter in data string with existing default
    //                //delimiters = new char[] { char.Parse(sub1) };
    //                sub2 = sub2.Replace(sub1, ",");
    //            }
    //        }
    //        else
    //        {
    //            //no delimiter directives so load orrigional input string as worker string
    //            sub2 = unescapedString;
    //        }

    //        //clean rest of string by replacing carriage returns with default delimiter
    //        sub2 = sub2.Replace("\n", ",");

    //        //split string by delimeters into string array
    //        var strlist = sub2.Split(',');

    //        //sum total to be returned
    //        var summer = 0;
    //        var exceptns = "";

    //        foreach (var item in strlist)
    //        {
    //            var newint = 0;

    //            _ = Int32.TryParse(item, out newint);

    //            //add negative values to exception string
    //            if (newint < 0)
    //            {
    //                exceptns = $"{exceptns},{newint}";
    //            }
    //            else if (newint < 1001)//ignore bigger than 1000
    //            {
    //                //do addition
    //                summer += newint;
    //            }
    //        }

    //        if (exceptns.Length > 0)
    //        {
    //            var excString1 = exceptns.Substring(1);
    //            var excString2 = $"negatives not allowed : {excString1}";
    //            throw new Exception(excString2);
    //        }

    //        return summer;
    //    }
    //}

    public class InputStringsViewModel
    {
        public string Input1 { get; set; }
        public string Output1 { get; set; }

    }
}

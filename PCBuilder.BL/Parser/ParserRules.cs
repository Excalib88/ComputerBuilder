using Newtonsoft.Json;
using ComputerBuilder.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ComputerBuilder.BL.Parser
{
    public class ParserRule
    {
        public string Rule_name { get; set; }
        public string HardwareType { get; set; }
        public Dictionary<string, string> Property_templates { get; set; }

        public ParserRule()
        {
            Rule_name = "";
            HardwareType = "";
            Property_templates = new Dictionary<string, string>();
        }

        public List<ParserRule> GetRules()
        {
            List<ParserRule> rulesList = new List<ParserRule>();
            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\Templates.json", Encoding.Default))
                {
                    var json = sr.ReadToEnd();
                    rulesList = JsonConvert.DeserializeObject<List<ParserRule>>(json);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return rulesList;
        }

        public override string ToString()
        {
            return Rule_name;
        }
    }

}

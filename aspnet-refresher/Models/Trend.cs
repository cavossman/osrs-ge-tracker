using System;
using Newtonsoft.Json.Linq;

namespace aspnetrefresher.Models
{
    public class Trend
    {
        public String Value { get; }
        public String Change { get; }
        public Trend(JObject trend)
        {
            Value = (String)trend["trend"];
            Change = (String)trend["change"];
        }
    }
}

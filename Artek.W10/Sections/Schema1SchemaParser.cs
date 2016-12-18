using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Artek.Sections
{
    /// <summary>
    /// Implementation of the Schema1SchemaParser class.
    /// </summary>
    public class Schema1SchemaParser : IParser<Schema1Schema>
    {	
        public IEnumerable<Schema1Schema> Parse(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            var result = new Collection<Schema1Schema>();
            JToken jtokenData = JsonConvert.DeserializeObject<JToken>(data);
            IEnumerable<JToken> elements = jtokenData.SelectToken("response.[1]")?.Select(s => s);
            if (elements != null)
            {
                foreach (JToken item in elements)
                {
                    var itemResult = new Schema1Schema();
					itemResult._id = item.SelectToken("id")?.ToString();
					itemResult.text = item.SelectToken("text")?.ToString().DecodeHtml();
					itemResult.src = item.SelectToken("attachment.photo.src")?.ToString();
                    result.Add(itemResult);
                }
            }
            return result;
        }
    }
}

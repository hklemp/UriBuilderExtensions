using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace UriBuilderExtension
{
	public static class UriBuilderExtensions
    {

        /// <summary>
        /// Sets the specified query parameter key-value pair of the URI.
        /// If the key already exists, the value is overwritten.
        /// </summary>
        public static UriBuilder SetQueryParam(this UriBuilder uri, string key, Microsoft.Extensions.Primitives.StringValues value)
        {
            
            var queryDictionary = ParseQuery(uri.Query);

            queryDictionary.Add(key, value);

           
            uri.Query = BuildQuery(queryDictionary);

            return uri;
        }


        private static string BuildQuery(Dictionary<string, Microsoft.Extensions.Primitives.StringValues> dictionary)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("?");

            foreach (var item in dictionary)
            {
                sb.AppendFormat("{0}={1}&", item.Key, item.Value);
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        private static Dictionary<string,Microsoft.Extensions.Primitives.StringValues> ParseQuery(string queryString)
        {
            return QueryHelpers.ParseQuery(queryString);
        }
    }
}

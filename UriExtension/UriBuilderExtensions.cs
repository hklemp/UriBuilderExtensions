using System;
using System.Collections.Generic;
using System.Text;

namespace UriBuilderExtension
{
	/// <summary>
	/// Extension for the .net UriBuilder to simply extend the query
    /// </summary>
	public static class UriBuilderExtensions
    {

        /// <summary>
        /// Sets the specified query parameter key-value pair of the URI.
        /// </summary>
		/// <param name="uri">The <see cref="Uri"/></param>
        /// <param name="key">The key to add</param>
		/// <param name="value">The value to add</param>
		/// <returns>The modified <see cref="Uri"/></returns>
		public static UriBuilder SetQueryParam(this UriBuilder uri, string key, string value)
		{       
			return SetQueryParam(uri,key,new string[] {value});
        }

		/// <summary>
        /// Sets the specified query parameter key-value pair of the URI.
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/></param>
        /// <param name="key">The key to add</param>
		/// <param name="values">The values to add</param>
        /// <returns>The modified <see cref="Uri"/></returns>
        public static UriBuilder SetQueryParam(this UriBuilder uri, string key, string[] values)
        {
            var queryDictionary = ParseQuery(uri.Query);

			queryDictionary.Add(key, String.Join(",",values));
           
            uri.Query = BuildQuery(queryDictionary);

            return uri;
        }
       
		/// <summary>
		/// Get the values from the query for a key
		/// </summary>
		/// <param name="uri">The <see cref="Uri"/></param>
		/// <param name="key">The key to you are looking for</param>
		/// <returns>A collection with all values for the specific key</returns>
		public static ICollection<string> GetQueryParamValue(this UriBuilder uri, string key)
		{
			var queryDictionary = ParseQuery(uri.Query);
			string paramValue = String.Empty;
			HashSet<string> result = new HashSet<string>();
			queryDictionary.TryGetValue(key, out paramValue);

			var values = paramValue.Split(',');

			foreach (var item in values)
			{
				result.Add(item);
			}

			return result;
		}

		/// <summary>
        /// Check if the given key exists in the uri
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/></param>
        /// <param name="key">The key to look for</param>
        /// <returns>True or false</returns>
		public static bool HasQueryParam(this UriBuilder uri, string key)
		{
			var queryDictionary = ParseQuery(uri.Query);

			return queryDictionary.ContainsKey(key);
		}

		/// <summary>
        /// Remove the given key in the uri
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/></param>
        /// <param name="key">The key to look for</param>
		/// <returns>The modified <see cref="Uri"/></returns>
		public static UriBuilder RemoveQueryParam(this UriBuilder uri, string key)
        {         
			if (!HasQueryParam(uri,key))
			{
				return uri;
			}

			var queryDictionary = ParseQuery(uri.Query);
			queryDictionary.Remove(key);
			uri.Query = BuildQuery(queryDictionary);

			return uri;
        }

		/// <summary>
        /// Get all paramter key's in the given uri
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/></param>
		/// <returns>A collection with all key's</returns>
		public static ICollection<string> GetQueryParamKeys(this UriBuilder uri)
		{
			var queryDictionary = ParseQuery(uri.Query);         
			return queryDictionary.Keys;
		}
      
		private static string BuildQuery(Dictionary<string, string> dictionary)
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

        private static Dictionary<string,string> ParseQuery(string queryString)
        {
			Dictionary<string, string> queryDictionary = new Dictionary<string, string>();

			if (queryString != String.Empty)
			{
				if (queryString.StartsWith("?"))
				{
					queryString = queryString.Remove(0,1);
				}

				var querys = queryString.Split('&');

                foreach (var item in querys)
                {
                    queryDictionary.Add(item.Split('=')[0], item.Split('=')[1]);
                }
			}
             
			return queryDictionary;
        }
    }
}

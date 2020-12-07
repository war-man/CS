using System.Collections.Specialized;
using System.Linq;

namespace CS.Common.Extensions
{
    public static class NameValueCollectionExtensions
    {
        public static NameValueCollection MergeWith(this NameValueCollection source, NameValueCollection target)
        {
            foreach (var key in target.AllKeys)
            {
                if ((source.Get(key)) == null)
                    source.Add(key, target.Get(key));
                else
                    source.Set(key, target.Get(key));
            }

            return source;
        }

        public static bool TryGetValue(this NameValueCollection source, string key, out string value)
        {
            value = null;

            if (source.AllKeys.All(k => k != key))
                return false;

            value = source[key];
            return true;
        }

        public static string GetValue(this NameValueCollection source, string key, string defaultValue = null)
        {
            if (source.AllKeys.All(k => k != key))
                return defaultValue;

            return source[key];
        }
    }
}

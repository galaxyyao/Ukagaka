using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;

namespace Common
{
    public static class XML
    {
        public static T GetFirstDescendantsValue<T>(XDocument source, string descendantsName)
        {
            Type type = typeof(T);
            object value = TypeDescriptor.GetConverter(type).ConvertFromInvariantString(source.Descendants(descendantsName).FirstOrDefault().Value);
            T result;
            try
            {
                result = (T)Convert.ChangeType(value, type);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException(ex.Message);
            }
            return result;
        }

        public static T GetFirstDescendantsValue<T>(XElement source, string descendantsName)
        {
            Type type = typeof(T);
            object value = TypeDescriptor.GetConverter(type).ConvertFromInvariantString(source.Descendants(descendantsName).FirstOrDefault().Value);
            T result;
            try
            {
                result = (T)Convert.ChangeType(value, type);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException(ex.Message);
            }
            return result;
        }

        public static List<T> GetDescendantsValues<T>(XDocument doc, string descendantsName)
        {
            Type type = typeof(T);
            List<T> results = new List<T>();
            IEnumerable<XElement> elements = doc.Descendants(descendantsName);
            foreach (var element in elements)
            {
                object value = TypeDescriptor.GetConverter(type).ConvertFromInvariantString(element.Value);
                T result;
                try
                {
                    result = (T)Convert.ChangeType(value, type);
                    results.Add(result);
                }
                catch (InvalidCastException ex)
                {
                    throw new InvalidCastException(ex.Message);
                }
            }
            return results;
        }
    }
}

using System;
using System.Xml.Serialization;

namespace GymManagementSystemBLL
{
    public class XMLSerializerUtility
    {

        /// <summary>
        /// A generic method that can be used to serialize any type of object in xml format.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="path">xml file to which data is to be serialized</param>
        /// <param name="obj">object containing data to be serialized</param>
        public static void XMLSerialize<T>(string path, T obj)
        {
            TextWriter tw = null;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                tw = new StreamWriter(path);
                xmlSerializer.Serialize(tw, obj);
            }
            finally
            {
                if (tw != null)
                {
                    tw.Close();
                }
            }
        }
        /// <summary>
        /// A generic method that can be used to deserialize any type of object in xml format.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="path">xml file to which data is to be serialized</param>
        /// <param name="obj">object containing data to be serialized</param>
        public static void XMLDeserialize<T>(string path, ref T obj)
        {
            TextReader tr = null;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                tr = new StreamReader(path);
                obj = (T)xmlSerializer.Deserialize(tr);
            }
            finally
            {
                if (tr != null)
                {
                    tr.Close();
                }
            }
        }
    }
}

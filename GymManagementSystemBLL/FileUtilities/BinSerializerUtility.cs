using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace GymManagementSystemBLL
{
    public class BinSerializerUtility
    {
        /// <summary>
        /// Method to serialize an object to a binary file 
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="fileName">binary file to which data is to be serialized</param>
        /// <param name="list">object of List<T> that containing all animals</param>
        public static void Serialize<T>(string fileName, List<T> list)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                binaryFormatter.Serialize(fileStream, list);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        /// <summary>
        /// Method to deserialize an object from a binary file 
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="fileName">binary file to which data is to be deserialized</param>
        /// <param name="list">object of List<T> that containing all animals</param>
        /// <exception cref="FileNotFoundException"></exception>
        public static void Deserialize<T>(string fileName, ref List<T> list)
        {
            list = null;
            FileStream fileStream = null;
            try
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("File not found", fileName);
                }
                fileStream = new FileStream(fileName, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                list = new List<T>();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                list = binaryFormatter.Deserialize(fileStream) as List<T>;
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }


    }
}

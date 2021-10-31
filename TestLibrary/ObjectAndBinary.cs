using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{

    public static class ObjectAndBinary<Type> where Type : class
    {   
        public static bool GetBytes(Type obj, out byte[] resultBytes)
        {            
            bool result = true;
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                formatter.Serialize(memoryStream, obj);
                resultBytes = memoryStream.ToArray();
            }
            catch
            {
                resultBytes = null;
                result = false;
            }
            finally
            {
                memoryStream?.Close();
            }
            return result;
        }

        public static bool GetObject(byte[] bytes, out Type obj)
        {
            bool result = true;
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream(bytes);
            try
            {
                obj = (Type)formatter.Deserialize(memoryStream);
            }
            catch
            {
                result = false;
                obj = null;
            }
            finally
            {
                memoryStream?.Close();
            }
            return result;
        }


        public static bool LoadFromFile(string pathFile, out Type obj)
        {
            BinaryFormatter formater = new BinaryFormatter();
            FileStream fileStream = null;
            bool result = true;

            try
            {
                fileStream = new FileStream(pathFile, FileMode.Open);
                obj = (Type)formater.Deserialize(fileStream);
            }
            catch
            {
                obj = null;
                result = false;
            }
            finally
            {
                fileStream?.Close();
            }

            return result;
        }
                
        public static bool SaveToFile(string pathFile, Type obj)
        {
            BinaryFormatter formater = new BinaryFormatter();
            FileStream fileStream = null;
            bool result = true;

            if (File.Exists(pathFile)) File.Delete(pathFile);

            try
            {
                fileStream = new FileStream(pathFile, FileMode.OpenOrCreate);
                formater.Serialize(fileStream, obj);
            }
            catch
            {
                result = false;
            }
            finally
            {
                fileStream?.Close();
            }

            return result;
        }

        public static string GetString(byte[] bytes)
        {
            StringBuilder result = new StringBuilder("");
            for (int i = 0; i < bytes.Length; i++)
            {
                result = result.Append(bytes[i].ToString());
            }
            return result.ToString();
        }
    } 
}



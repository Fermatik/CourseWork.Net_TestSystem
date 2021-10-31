using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class MessageClientServer
    {
        public MessageClientServer()
        {
            this.TypeMessage = TypeMessage.ClientMessage;
            this.TextMessage = String.Empty;
            this.SubTextMessage = String.Empty;
            this.ObjectMessage = null;
        }

        public MessageClientServer
            (
                TypeMessage typeMessage, 
                string textMessage, 
                string subTextMessage, 
                object objectMessage
            )
        {
            this.TypeMessage = typeMessage;
            this.TextMessage = textMessage;
            this.SubTextMessage = subTextMessage;
            this.ObjectMessage = objectMessage;
        }


        public TypeMessage TypeMessage { set; get; }
        public string TextMessage { set; get; }
        public string SubTextMessage { set; get; }

        public object ObjectMessage { set; get; }


        public override string ToString()
        {

            return $"TypeMessage       [{TypeMessage}]\n" +
                    $"TextMessage      [{TextMessage}]\n" +
                    $"SubTextMessage   [{SubTextMessage}]\n" +
                    $"TypeObjectMessage[{ObjectMessage.GetType()}]";
        }

        public bool GetBytes(out byte[] resultBytes)
        {
            if (this == null)
            {
                resultBytes = null;
                return false;
            }

            bool result = true;
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                formatter.Serialize(memoryStream, this);
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

        

        public static MessageClientServer GetObject(byte[] bytes)
        {
            if (bytes == null) return null;
            if (bytes.Length == 0) return null;
            MessageClientServer result;
            BinaryFormatter formatter = new BinaryFormatter();            
            MemoryStream memoryStream = new MemoryStream(bytes);
            //try
            //{
            result = (MessageClientServer)formatter.Deserialize(memoryStream);
            //}
            //catch
            //{

            //    result = null;                
            //}
            //finally
            //{
            memoryStream?.Close();
            //}
            return result;
        }

        

    }


}

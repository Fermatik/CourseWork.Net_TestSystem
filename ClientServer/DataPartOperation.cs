using System;

namespace ClientServer
{
    public static class DataPartOperation
    {
        public static byte[][] BufferSplit(byte[] buffer, int blockSize)
        {
            byte[][] blocks = new byte[(buffer.Length + blockSize - 1) / blockSize][];
            for (int i = 0, j = 0; i < blocks.Length; i++, j += blockSize)
            {
                blocks[i] = new byte[Math.Min(blockSize, buffer.Length - j)];
                Array.Copy(buffer, j, blocks[i], 0, blocks[i].Length);
            }
            return blocks;
        }

        public static string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }

        //public static  void SendMessage(Object obj)
        //{
        //    Info tmp = obj as Info;
        //    UdpClient client = tmp.client;
        //    IPEndPoint remoteEndPoint = tmp.remoteEndPoint;
        //    Bitmap picture = tmp.picture;

        //    const int SIZE_BLOCK = 60000;
        //    byte[] data;

        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        picture.Save(memoryStream, ImageFormat.Jpeg);
        //        data = memoryStream.ToArray();
        //    }


        //    byte[][] bufferArray = BufferSplit(data, SIZE_BLOCK);
        //    string id = GenerateId();
        //    var binaryFormatter = new BinaryFormatter();
        //    for (int i = 0; i < bufferArray.Length; i++)
        //    {
        //        DataPart.DataPart dataPart = new DataPart.DataPart() { Id = id, PartCount = bufferArray.Length, PartNum = i, Buffer = bufferArray[i] };
        //        byte[] dataPartArr;
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            binaryFormatter.Serialize(memoryStream, dataPart);
        //            dataPartArr = memoryStream.ToArray();
        //        }

        //        //lock (client)
        //        //{
        //        client.Send(dataPartArr, dataPartArr.Length, remoteEndPoint);
        //        //}


        //    }
        //}
    }
}

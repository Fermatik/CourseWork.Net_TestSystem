using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer
{
    [Serializable]
    public class DataPart
    {
        public string Id { get; set; }
        public int PartCount { get; set; }
        public int PartNum { get; set; }
        public byte[] Buffer { get; set; }
    }
}

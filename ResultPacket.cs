using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class ResultPacket : Packet
    {
        public string result;
        public ResultPacket(string result)
        {
            type = PacketType.RESULT;

            this.result = result;
        }
    }
}

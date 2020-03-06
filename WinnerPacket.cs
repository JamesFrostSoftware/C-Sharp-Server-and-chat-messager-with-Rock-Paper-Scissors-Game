using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class WinnerPacket : Packet
    {
        public string winner;
        public WinnerPacket(string winner)
        {
            type = PacketType.WINNER;

            this.winner = winner;
        }
    }
}

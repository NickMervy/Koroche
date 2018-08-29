using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    public interface ISurrogatePacket
    {
        ISurrogateSelector SurrogateSellector { get; }
    }
}
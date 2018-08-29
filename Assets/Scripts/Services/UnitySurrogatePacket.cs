using System.Runtime.Serialization;
using Services;
using UnityEngine;

namespace Models
{
    public class UnitySurrogatePacket : ISurrogatePacket
    {
        private readonly SurrogateSelector _surrogateSelector = new SurrogateSelector();
        public ISurrogateSelector SurrogateSellector { get { return _surrogateSelector; } }

        public UnitySurrogatePacket()
        {
            RegisterSurrogates();
        }

        private void RegisterSurrogates()
        {
            _surrogateSelector.AddSurrogate(typeof(Vector3), 
                new StreamingContext(StreamingContextStates.All), 
                new Vector3SerializationSurrogate());
        }
    }
}
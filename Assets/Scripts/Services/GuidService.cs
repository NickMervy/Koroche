using System;

namespace Services
{
    public class GuidService
    {
        [Inject] public ILogger Logger { get; set; }

        public Guid GenerateGuid()
        {
            var guid = Guid.NewGuid();
            Logger.Log(string.Format(
                @"New GUID genereted: ""{0}""", guid));

            return guid;
        }
    }
}
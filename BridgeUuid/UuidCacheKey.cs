using System;

namespace BridgeUuid
{
    [Serializable]
    public class UuidCacheKey
    {
        public string PreFix { get; set; }

        public string BasisObject { get; set; }
        public string Objekt { get; set; }
        public string TypeRolle { get; set; }
        public string Value { get; set; }
        
        public string GetKey()
        {
            return string.Format($"{BasisObject}{Objekt}{TypeRolle}{Value}");
        }


    }
}

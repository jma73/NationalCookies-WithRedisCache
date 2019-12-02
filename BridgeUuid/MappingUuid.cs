using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BridgeUuid.TestData;

namespace BridgeUuid
{

    public interface IMappingUuid
    {
        Guid GetUuid(string key);
    }

    public class MappingUuid : IMappingUuid
    {
        private IDictionary<string, Guid> _cacheStub;


        //public MappingUuid(IMappingListUuidTestData mappingListUuidTestData)
        //{
            
        //}

        public MappingUuid()
        {
            // todo jad: mangler noget dependency injection!!!

            var mappingListUuidTestData = new MappingListUuidTestData();
            string filename = @"TestData\mapnigsliste-uuid-jad.csv";    // it works!
            _cacheStub = mappingListUuidTestData.GetCacheStub(filename);
        }

        public Guid GetUuid(string key)
        {
            var keyValuePairs = _cacheStub.Where(k => k.Key == key);
            return keyValuePairs.FirstOrDefault().Value;
        }
    }
}

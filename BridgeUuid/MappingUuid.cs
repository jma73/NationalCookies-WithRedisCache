using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
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
        private IMappingListUuidTestData _mappingListUuidTestData;
        
        public MappingUuid(IMappingListUuidTestData mappingListUuidTestData)
        {
            _mappingListUuidTestData = mappingListUuidTestData;
            InitializeMappingList();
        }

        //public MappingUuid()
        //{
            

        //    // todo jad: mangler noget dependency injection!
        //    InitializeMappingList();
        //}

        private void InitializeMappingList()
        {
//var mappingListUuidTestData = new MappingListUuidTestData();        // denne skal vel injectes.
            string filename = @"TestData\mapnigsliste-uuid-jad.csv"; // it works!
            //string filename = @""; // it is for mock testing
            //_cacheStub = mappingListUuidTestData.GetCacheStub(filename);
            _cacheStub = _mappingListUuidTestData.GetCacheStub(filename);
        }

        public Guid GetUuid(string key)
        {
            var keyValuePairs = _cacheStub.Where(k => k.Key == key);
            return keyValuePairs.FirstOrDefault().Value;
        }
    }
}

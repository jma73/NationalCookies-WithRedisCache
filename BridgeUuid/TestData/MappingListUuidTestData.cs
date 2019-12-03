using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BridgeUuid.TestData
{
    public class MappingListUuidTestData : IMappingListUuidTestData
    {
        public string[] GetMappingList(string path)
        {
            return File.ReadAllLines(path);
        }

        public IDictionary<string, Guid> GetCacheStub(string filename)
        {
            IDictionary<string, Guid> cacheDictionary = new Dictionary<string, Guid>();

            string[] lines = File.ReadAllLines(filename);
            bool firstLine = true;
            foreach (string line in lines)
            {
                // skip first line
                if (firstLine)
                {
                    firstLine = false;
                    continue;
                }

                if (!String.IsNullOrEmpty(line) || line != ";;;;")
                {
                    // lineStrings
                    string[] lineStrings = line.Split(";", StringSplitOptions.None);

                    string key = string.Format($"{lineStrings[0]}{lineStrings[1]}{lineStrings[2]}{lineStrings[3]}");
                    string value = lineStrings[4];

                    try
                    {

                        KeyValuePair<string, Guid> keyValuePair = new KeyValuePair<string, Guid>(key, new Guid(value));
                        cacheDictionary.Add(keyValuePair);

                    }
                    catch (FormatException e)   // avoid problems when not enough data. Fx. no Guid.
                    {
                        Console.WriteLine(e);
                        // throw;
                    }
                }


            }

            return cacheDictionary;
        }
    }

    /// <summary>
    /// Creates test data.
    /// </summary>
    public interface IMappingListUuidTestData
    {
        string[] GetMappingList(string path);
        
        /// <summary>
        /// Read testdata from csv file.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        IDictionary<string, Guid> GetCacheStub(string filename);
    }
}

/*
 * Indhold af "cache":
 
SagSagTypeSag  -->  7f04a5f2-5437-4bf3-9605-46a5ba882bcc
SagSagRolleOversag  -->  d29c49f0-931e-4d42-8db4-a8fc67c8af58
SagJournalpostTypeDokument  -->  198dd40f-88fe-49a3-8716-b6230544c23b
SagJournalpostRolleVedlagt  -->  b21faed9-c4a2-49d3-aa15-35f5181d7735 
SagJournalpostRolleTilakteret  -->  69a0a697-0a77-4916-bea3-226594fa6627
SagJournalpostRolleJournalnotat  -->  1281739d-93ea-486c-8950-607a4263bef0
SagSagsaktørTypeOrganisation  -->  bc6972cd-8f2b-4b9d-8d37-62916d6a71aa
SagSagsaktørTypeOrgEnhed  -->  c5fc3b3b-5197-49ee-92e6-ae6ba1957174
SagSagsaktørTypeOrgFunktion  -->  aa9b7bdb-7148-4b5c-8fc9-97d6f9743270 
SagSagsaktørTypeInteressefaellesskab  -->  4b3652c6-cbdf-4699-b847-54b387db5d3f
SagSagsaktørTypeBruger  -->  85d65133-4b00-460d-992e-3984857b5768
SagSagsaktørTypeIt-system  -->  f659a5d2-6ad5-4bcc-acc0-da2eb2d8ba7b
SagSagsarkivTypeArkiv  -->  94c2f5bb-649f-4a90-9b17-87fc74204b5a
SagSagsgenstandTypeEjendom  -->  4c3949ee-d086-4637-9348-365775e2b188
SagSagspartRollePrimaerPart  -->  d839f26a-d4d1-4441-b2d6-3dbbb12a9404
SagIt-systemTypeIt-system  -->  29fe1da2-897a-46cd-b635-b9be8e0bffd6
DokumentDokumentpartTypePerson  -->  12e3cd0d-03bb-46cf-b8d8-95b3fe082478
DokumentDokumentpartTypeVirksomhed  -->  d53c9233-f640-4641-8db8-15f45e2133d7 
DokumentDokumentpartRolleParter  -->  808a219f-fb0d-4a54-9519-929f7841bbb6
DokumentDokumentpartRolleKopiParter  -->  ffe7ec2b-4928-47a8-9a73-d7a9931b5621

 */


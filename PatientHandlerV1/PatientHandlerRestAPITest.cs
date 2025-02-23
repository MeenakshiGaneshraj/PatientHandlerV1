using System.Reflection;

namespace PatientHandlerV1
{
    [TestClass]
    public class PatientHandlerRestAPITest : PageTest
    {
        private readonly PlaywrightDriver _playwrightDriver = new PlaywrightDriver();

        [TestMethod]
        public async Task TC_001_Missing_identifier_field()
        {
            // Prepare the payload for the POST request
            var data = new Dictionary<string, object>
            {
                { "Recip_ID", "" },
                { "First_Name", "John" },
                { "Last_Name", "Doe" },
                { "Gender", "M" },
                { "Date_of_Birth", "19850101" },
                { "Date_of_Death", "" },
                { "Language_Code", "EN" },
                { "Home_Phone_Number", "555-1234" },
                { "Work_Phone_Number", "555-5678" }
            };

            var response = await _playwrightDriver.ApiRequestContext?.PostAsync("", new() { DataObject = data });
            Assert.AreEqual(400, response.Status);
            var responseJson = await response.JsonAsync();
          

            var ErrorCode = responseJson?.GetProperty("ErrorCode").GetInt32();               
            Assert.AreEqual(42014, ErrorCode);
        }

        [TestMethod]
        public async Task TC_002_Missing_First_Name_and_Date_of_Birth()
        {
            // Prepare the payload for the POST request
            var data = new Dictionary<string, object>
            {
                { "Recip_ID", "002" },
                { "First_Name", "John" },
                { "Last_Name", "Doe" },
                { "Gender", "M" },
                { "Date_of_Birth", "" },
                { "Date_of_Death", "" },
                { "Language_Code", "EN" },
                { "Home_Phone_Number", "555-1234" },
                { "Work_Phone_Number", "555-5678" }
            };


            var response = await _playwrightDriver.ApiRequestContext?.PostAsync("", new() { DataObject = data });
            Assert.AreEqual(400, response.Status);
            var responseJson = await response.JsonAsync();


            var ErrorCode = responseJson?.GetProperty("ErrorCode").GetInt32();
            Assert.AreEqual(42074, ErrorCode);
        }

        [TestMethod]
        public async Task TC_003_New_record()
        {
            // Prepare the payload for the POST request
            var data = new Dictionary<string, object>
            {
                { "Recip_ID", "003" },
                { "First_Name", "Meenakshi" },
                { "Last_Name", "Doe" },
                { "Gender", "F" },
                { "Date_of_Birth", "19930401" },
                { "Date_of_Death", "" },
                { "Language_Code", "EN" },
                { "Home_Phone_Number", "555-1234" },
                { "Work_Phone_Number", "555-5678" }
            };



            var response = await _playwrightDriver.ApiRequestContext?.PostAsync("", new() { DataObject = data });
            Assert.AreEqual(201, response.Status);
            var responseJson = await response.JsonAsync();


            var Recip_ID = responseJson?.GetProperty("Recip_ID").GetString();
            Assert.AreEqual("003", Recip_ID);
        }

        [TestMethod]
        public async Task TC_004_NO_PERSON_record()
        {
            // Prepare the payload for the POST request
            var data = new Dictionary<string, object>
            {
                { "Recip_ID", "004" },
                { "First_Name", "John" },
                { "Last_Name", "Doe" },
                { "Gender", "M" },
                { "Date_of_Birth", "20000503" },
                { "Date_of_Death", "" },
                { "Language_Code", "EN" },
                { "Home_Phone_Number", "555-1234" },
                { "Work_Phone_Number", "555-5678" }
            };

            var response = await _playwrightDriver.ApiRequestContext?.PostAsync("", new() { DataObject = data });
            Assert.AreEqual(400, response.Status);
            var responseJson = await response.JsonAsync();


            var ErrorCode = responseJson?.GetProperty("ErrorCode").GetInt32();
            Assert.AreEqual(46008, ErrorCode);
        }

        [TestMethod]
        public async Task TC_005_Multiple_PERSON_records()
        {
            // Prepare the payload for the POST request            
            var data = new Dictionary<string, object>
            {
                { "Recip_ID", "005" },
                { "First_Name", "John" },
                { "Last_Name", "Doe" },
                { "Gender", "M" },
                { "Date_of_Birth", "19930404" },
                { "Date_of_Death", "" },
                { "Language_Code", "EN" },
                { "Home_Phone_Number", "555-1234" },
                { "Work_Phone_Number", "555-5678" }
            };


            var response = await _playwrightDriver.ApiRequestContext?.PostAsync("", new() { DataObject = data });
            Assert.AreEqual(400, response.Status);
            var responseJson = await response.JsonAsync();


            var ErrorCode = responseJson?.GetProperty("ErrorCode").GetInt32();
            Assert.AreEqual(43034, ErrorCode);
        }

        [TestMethod]
        public async Task TC_006_First_Name_and_Date_of_Birth_mismatch()
        {
            // Prepare the payload for the POST request
            
           var data = new Dictionary<string, object>
        {
            { "Recip_ID", "006" },
            { "First_Name", "John" },
            { "Last_Name", "Doe" },
            { "Gender", "M" },
            { "Date_of_Birth", "19930404" },
            { "Date_of_Death", "" },
            { "Language_Code", "EN" },
            { "Home_Phone_Number", "555-1234" },
            { "Work_Phone_Number", "555-5678" }
        };

            var response = await _playwrightDriver.ApiRequestContext?.PostAsync("", new() { DataObject = data });
            Assert.AreEqual(400, response.Status);
            var responseJson = await response.JsonAsync();

            var ErrorCode = responseJson?.GetProperty("ErrorCode").GetInt32();
            Assert.AreEqual(43027, ErrorCode);
        }

        [TestMethod]
        public async Task TC_007_Exact_match_with_existing_PERSON_record()
        {
            // Prepare the payload for the POST request

            var data = new Dictionary<string, object>
           {
                { "Recip_ID", "007" },
                { "First_Name", "John" },
                { "Last_Name", "Doe" },
                { "Gender", "M" },
                { "Date_of_Birth", "19930404" },
                { "Date_of_Death", "" },
                { "Language_Code", "EN" },
                { "Home_Phone_Number", "555-1234" },
                { "Work_Phone_Number", "555-5678" }
           };

            var response = await _playwrightDriver.ApiRequestContext?.PostAsync("", new() { DataObject = data });
            Assert.AreEqual(200, response.Status);
            var responseJson = await response.JsonAsync();

            var Recip_ID = responseJson?.GetProperty("Recip_ID").GetString();
            Assert.AreEqual("007", Recip_ID);
        }

        [TestMethod]
        public async Task TC_008_Update_existing_PERSON_record()
        {
            // Prepare the payload for the POST request

            var data = new Dictionary<string, object>
            {
                { "Recip_ID", "008" },
                { "First_Name", "John" },
                { "Last_Name", "Doe" },
                { "Gender", "M" },
                { "Date_of_Birth", "19930404" },
                { "Date_of_Death", "" },
                { "Language_Code", "EN" },
                { "Home_Phone_Number", "555-1234" },
                { "Work_Phone_Number", "555-5678" }
            };

            var response = await _playwrightDriver.ApiRequestContext?.PostAsync("", new() { DataObject = data });
            Assert.AreEqual(200, response.Status);
            var responseJson = await response.JsonAsync();


            var Recip_ID = responseJson?.GetProperty("Recip_ID").GetString();
            Assert.AreEqual("008", Recip_ID);
        }
    }

}


# PatientHandlerV1 - API Test Suite

## Overview

This repository contains automated tests for the `PatientHandlerV1` service, focusing on testing various POST request scenarios to validate the handling of patient data via the API. The tests are implemented using the **Playwright** and **Unit Testing** frameworks.

## Prerequisites

To run these tests, you need the following:

- .NET SDK
- Playwright (for API testing)
- A unit testing framework (such as MSTest)
  
Make sure to install necessary dependencies:

```bash
dotnet restore
```

## Test Class: `PatientHandlerRestAPITest`

The test class `PatientHandlerRestAPITest` contains several test methods that cover a variety of cases for handling POST requests related to patient data. Each test verifies the response and error codes from the API, ensuring correct behavior in different situations.

### Test Scenarios

1. **TC_001_Missing_identifier_field**  
   Verifies the error when the `Recip_ID` field is missing.  
   Expected ErrorCode: `42014`

2. **TC_002_Missing_First_Name_and_Date_of_Birth**  
   Verifies the error when both `First_Name` and `Date_of_Birth` are missing.  
   Expected ErrorCode: `42074`

3. **TC_003_New_record**  
   Tests the creation of a new patient record and verifies the response.  
   Expected Response Code: `201`  
   Verifies the correct `Recip_ID` in the response.

4. **TC_004_NO_PERSON_record**  
   Tests for a non-existing patient record and verifies the appropriate error message.  
   Expected ErrorCode: `46008`

5. **TC_005_Multiple_PERSON_records**  
   Tests the scenario when there are multiple records with the same `Recip_ID`.  
   Expected ErrorCode: `43034`

6. **TC_006_First_Name_and_Date_of_Birth_mismatch**  
   Verifies the error when there is a mismatch between `First_Name` and `Date_of_Birth`.  
   Expected ErrorCode: `43027`

7. **TC_007_Exact_match_with_existing_PERSON_record**  
   Verifies the behavior when the exact `Recip_ID` already exists, ensuring the record is returned correctly.  
   Expected Response Code: `200`

8. **TC_008_Update_existing_PERSON_record**  
   Tests updating an existing patient record.  
   Expected Response Code: `200`

## Running the Tests

To run the tests using the MSTest framework:

```bash
dotnet test
```

## Conclusion

These tests help ensure that the `PatientHandlerV1` API behaves correctly under various scenarios, including creating, updating, and handling errors for patient records.

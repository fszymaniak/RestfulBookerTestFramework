# High-Priority Test Cases Implementation Guide

**Date:** December 2025
**Status:** Feature Files and Step Definitions Created
**Next Steps:** Driver Method Implementation Required

## Overview

This document describes the implementation of 11 high-priority test cases identified in the Test Case Repository (v3.1). The test cases have been implemented as Reqnroll/SpecFlow feature files with corresponding step definitions.

## Implementation Summary

### ✅ Completed

1. **Feature Files Created** (8 new feature files)
2. **Step Definitions Created** (3 new step definition classes)
3. **Test Organization** (New folders for ValidationTests, E2ETests, SecurityTests)

### ⚠️ Pending

1. **Driver Method Implementation** (Methods referenced in step definitions need to be added to driver interfaces and implementations)
2. **Test Execution** (Tests cannot run until driver methods are implemented)
3. **Integration Testing** (Validate tests work end-to-end)

---

## Test Cases Implemented

### 1. Content-Type Validation Tests (TC-162, TC-163)

**File:** `Features/ValidationTests/ContentTypeValidation.feature`

**Test Cases:**
- TC-162: POST /booking without Content-Type header
- TC-163: PUT /booking without Content-Type header

**Step Definitions:** `StepDefinitions/ValidationTestSteps.cs`

**Required Driver Methods:**
```csharp
// ICreateBookingDriver
Task CreateBookingWithoutContentType();

// IUpdateBookingDriver
Task PutUpdateBookingWithoutContentType();
Task PatchUpdateBookingWithoutContentType();
```

---

### 2. Date Range Filtering Test (TC-164)

**File:** `Features/ValidationTests/DateRangeFiltering.feature`

**Test Case:**
- TC-164: Filter bookings with both checkin and checkout parameters

**Step Definitions:** `StepDefinitions/FilteringTestSteps.cs`

**Required Driver Methods:**
```csharp
// ICreateBookingDriver
void GenerateBookingWithDates(string checkin, string checkout);
int GetCreatedBookingId();

// IGetBookingsIdsDriver
Task GetBookingIdsWithDateRange(string checkin, string checkout);
List<int> GetBookingIdsFromResponse();
```

---

### 3. Same-Day Checkin/Checkout Test (TC-165)

**File:** `Features/ValidationTests/SameDayBooking.feature`

**Test Case:**
- TC-165: Create booking with same checkin and checkout date

**Step Definitions:** `StepDefinitions/ValidationTestSteps.cs`

**Required Driver Methods:**
```csharp
// ICreateBookingDriver
void GenerateBookingWithDates(string checkin, string checkout);
```

---

### 4. Mixed Valid/Invalid Fields Test (TC-166)

**File:** `Features/ValidationTests/MixedFieldValidation.feature`

**Test Case:**
- TC-166: PUT update with mixed valid and invalid fields

**Step Definitions:** `StepDefinitions/ValidationTestSteps.cs`

**Required Driver Methods:**
```csharp
// ICreateBookingDriver
void GenerateBookingWithMixedValidInvalidFields();
```

---

### 5. Nested PATCH Update Tests (TC-167, TC-168)

**File:** `Features/ValidationTests/NestedPatchUpdate.feature`

**Test Cases:**
- TC-167: PATCH update bookingdates object with only checkin
- TC-168: PATCH update only checkin date within bookingdates

**Step Definitions:** `StepDefinitions/ValidationTestSteps.cs`

**Required Driver Methods:**
```csharp
// ICreateBookingDriver
void GeneratePartialBookingdatesRequest(string checkin);

// IValidationDriver
Booking GetBookingFromResponse();
void VerifyUnchangedFieldsAfterPatch();
```

**Note:** TC-168 leverages existing step definition pattern already in the codebase.

---

### 6. Cross-Endpoint Consistency Tests (TC-169, TC-170, TC-171)

**File:** `Features/E2ETests/CrossEndpointConsistency.feature`

**Test Cases:**
- TC-169: Created booking immediately appears in GetBookingIds
- TC-170: Updated firstname is filterable
- TC-171: Deleted booking removed from filters

**Step Definitions:** `StepDefinitions/CrossEndpointConsistencySteps.cs`

**Required Driver Methods:**
```csharp
// ICreateBookingDriver
int GetCreatedBookingId();

// IGetBookingsIdsDriver
Task GetAllBookingIds();
Task GetBookingIdsByFirstname(string firstname);
Task GetBookingIdsByLastname(string lastname);
List<int> GetBookingIdsFromResponse();

// IUpdateBookingDriver
void GenerateUpdateRequestWithFirstname(string firstname);
void GenerateUpdateRequestWithNames(string firstname, string lastname);
int GetUpdatedBookingId();

// IDeleteBookingDriver
int GetDeletedBookingId();
```

---

### 7. Null Byte Injection Test (TC-172)

**File:** `Features/SecurityTests/NullByteInjection.feature`

**Test Case:**
- TC-172: Null byte injection in firstname field

**Step Definitions:** `StepDefinitions/ValidationTestSteps.cs`

**Required Driver Methods:**
```csharp
// ICreateBookingDriver
void GenerateBookingWithNullByteInFirstname();

// IValidationDriver
string GetResponseStatusCode();
Booking GetBookingFromResponse();
```

---

## Implementation Roadmap

### Phase 1: Driver Interface Updates (Estimated: 2-3 hours)

1. Update `ICreateBookingDriver` interface:
   ```csharp
   void GenerateBookingWithDates(string checkin, string checkout);
   void GenerateBookingWithMixedValidInvalidFields();
   void GeneratePartialBookingdatesRequest(string checkin);
   void GenerateBookingWithNullByteInFirstname();
   Task CreateBookingWithoutContentType();
   int GetCreatedBookingId();
   ```

2. Update `IUpdateBookingDriver` interface:
   ```csharp
   Task PutUpdateBookingWithoutContentType();
   Task PatchUpdateBookingWithoutContentType();
   void GenerateUpdateRequestWithFirstname(string firstname);
   void GenerateUpdateRequestWithNames(string firstname, string lastname);
   int GetUpdatedBookingId();
   ```

3. Update `IGetBookingsIdsDriver` interface:
   ```csharp
   Task GetBookingIdsWithDateRange(string checkin, string checkout);
   Task GetAllBookingIds();
   Task GetBookingIdsByFirstname(string firstname);
   Task GetBookingIdsByLastname(string lastname);
   List<int> GetBookingIdsFromResponse();
   ```

4. Update `IDeleteBookingDriver` interface:
   ```csharp
   int GetDeletedBookingId();
   ```

5. Update `IValidationDriver` interface:
   ```csharp
   string GetResponseStatusCode();
   Booking GetBookingFromResponse();
   void VerifyUnchangedFieldsAfterPatch();
   ```

### Phase 2: Driver Implementations (Estimated: 4-6 hours)

Implement the methods in the concrete driver classes:
- `CreateBookingDriver.cs`
- `UpdateBookingDriver.cs`
- `GetBookingsIdsDriver.cs`
- `DeleteBookingDriver.cs`
- `ValidationDriver.cs`

### Phase 3: Test Execution & Debugging (Estimated: 2-4 hours)

1. Build the solution
2. Run each test case individually
3. Fix any issues discovered
4. Verify all tests pass or fail as expected

### Phase 4: CI/CD Integration (Estimated: 1-2 hours)

1. Tag tests appropriately in CI/CD pipeline
2. Add high-priority tests to daily build execution
3. Update test reporting

---

## File Structure

```
RestfulBookerTestFramework/
├── docs/
│   ├── TestCaseRepository.md (v3.1)
│   └── HighPriorityTestCasesImplementationGuide.md (this file)
└── tests/
    └── RestfulBookerTestFramework.Tests.Api/
        ├── Features/
        │   ├── ValidationTests/
        │   │   ├── ContentTypeValidation.feature
        │   │   ├── DateRangeFiltering.feature
        │   │   ├── SameDayBooking.feature
        │   │   ├── MixedFieldValidation.feature
        │   │   └── NestedPatchUpdate.feature
        │   ├── E2ETests/
        │   │   └── CrossEndpointConsistency.feature
        │   └── SecurityTests/
        │       └── NullByteInjection.feature
        └── StepDefinitions/
            ├── ValidationTestSteps.cs
            ├── FilteringTestSteps.cs
            └── CrossEndpointConsistencySteps.cs
```

---

## Test Tags

All new tests are tagged with appropriate suite identifiers:

- `@HighPriority` - All 11 new test cases
- `@ValidationTest` - TC-162, TC-163, TC-164, TC-165, TC-166, TC-167, TC-168
- `@E2ETest` - TC-169, TC-170, TC-171
- `@SecurityTest` - TC-172
- `@ApiIntegrationTest` - All tests
- Additional specific tags for filtering and organization

---

## Expected Outcomes

After full implementation:

1. **11 new automated test cases** covering critical gaps
2. **Improved test coverage** in:
   - Input validation (Content-Type, same-day dates)
   - Cross-endpoint consistency
   - Security (null byte injection)
   - Edge cases (mixed fields, nested updates)

3. **Enhanced CI/CD pipeline** with high-priority test execution
4. **Better API quality assurance** through comprehensive validation

---

## Notes

- Some step definitions leverage existing patterns (e.g., TC-168 uses existing `PartialBookingDatesWithOnlyCheckIn`)
- The `@ignore` tag from existing nested PATCH tests suggests this is a known API limitation
- TC-167 and TC-168 may expose existing bugs in the bookingdates PATCH implementation
- All tests include proper cleanup with `@CleanUpBooking` and `@AuthorizeRequest` tags

---

## Next Steps

1. **Immediate:** Implement driver methods (Phase 1 & 2)
2. **Short-term:** Execute and validate tests (Phase 3)
3. **Medium-term:** Integrate into CI/CD (Phase 4)
4. **Long-term:** Implement remaining 38 medium/low priority test cases from TestCaseRepository.md

---

**Contact:** For questions about this implementation, refer to the TestCaseRepository.md for detailed test case specifications.

*— End of Implementation Guide —*

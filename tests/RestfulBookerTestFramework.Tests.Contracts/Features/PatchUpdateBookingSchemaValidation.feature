@ContractTest
@PatchBookingFeature
@SetupOneBooking
@CleanUpBooking
@AuthorizeRequest
Feature: Patch Update Booking Happy Path Schema Validation

Description:
    As RestfulBooker user
    I want to sent valid PATCH request to the /booking/{id} endpoint
    So that I will be able to sucessfully validate response schema

    Scenario Outline: Endpoint Booking update partial booking with single property request successfully
        Given Prerequisite: API is running
        And the '<PartialBookingWithSingleProperty>' booking with single property request is created
        When trying to 'PATCH' update booking
        Then 'Booking' response schema is valid
        
        Examples:
          | PartialBookingWithSingleProperty      |
          | PartialBookingWithOnlyFirstName       |
          | PartialBookingWithOnlyLastName        |
          | PartialBookingWithOnlyDepositPaid     |
          | PartialBookingWithOnlyTotalPrice      |
          | PartialBookingWithOnlyAdditionalNeeds |
      
    Scenario Outline: Endpoint Booking update partial booking with multiple properties request successfully
        Given Prerequisite: API is running
        And the '<PartialBookingWithMultipleProperties>' booking request is created
        When trying to 'PATCH' update booking
        Then 'Booking' response schema is valid
        
        Examples:
          | PartialBookingWithMultipleProperties |
          | PartialBookingWithoutFirstName       |
          | PartialBookingWithoutLastName        |
          | PartialBookingWithoutDepositPaid     |
          | PartialBookingWithoutTotalPrice      |
          | PartialBookingWithoutAdditionalNeeds |
@SetupOneBooking
@CleanUpBooking
@AuthorizeRequest

Feature: Patch Update Booking Endpoint Happy Path
Description: Send the valid PATCH request with valid booking request to /booking/{id} endpoint and it should return 200 (OK) with proper booking

    Scenario Outline: Endpoint Booking update partial booking with single property request successfully
        Given Prerequisite: API is running
        And the '<PartialBookingWithSingleProperty>' booking with single property request is created
        When trying to 'Patch' update booking
        Then status code should be '200'
        And the newly 'Patch' updated booking should be valid
        
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
        When trying to 'Patch' update booking
        Then status code should be '200'
        And the newly 'Patch' updated booking should be valid
        
        Examples:
          | PartialBookingWithMultipleProperties      |
          | PartialBookingWithoutFirstName            |
          | PartialBookingWithoutLastName             |
          | PartialBookingWithoutDepositPaid          |
          | PartialBookingWithoutTotalPrice           |
          | PartialBookingWithoutAdditionalNeeds      |
          
    @ignore
    ## ignored due to the bug in the Booking Dates PATCH update implementation
    Scenario Outline: Endpoint Booking update partial booking dates update request successfully
        Given Prerequisite: API is running
        And the '<PartialBookingWithSingleProperty>' booking with single property request is created
        When trying to 'Patch' update booking
        Then status code should be '200'
        And the newly 'Patch' updated booking should be valid
        
        Examples:
          | PartialBookingWithSingleProperty          |
          | PartialBookingDatesWithOnlyCheckIn        |
          | PartialBookingDatesWithOnlyCheckOut       |
          | PartialBookingWithoutBookingDatesCheckIn  |
          | PartialBookingWithoutBookingDatesCheckOut |

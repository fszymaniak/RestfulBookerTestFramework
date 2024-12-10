@AuthorizeRequest
Feature: Create Booking Endpoint Unhappy Path with missing Body properites
    
Description:
    As RestfulBooker user
    I want to sent POST request with invalid body for the existing booking to the /booking/{id} endpoint
    So that I will be able to get error code (400 Bad Request Status Code) and the booking cannot be updated

    @ignore #The invalid Status Code was implemented here, there should be 400 (Bad Request) but there is 500 (Internal Server Error) or 200 (OK) which is misleading
    Scenario Outline: Booking Endpoint invalid request without one of the property should return Bad Request
        Given Prerequisite: API is running
        And the '<PartialBookingWithMultipleProperties>' booking request is created
        When trying to create a new booking
        Then status code should be '400'

        Examples:
          | PartialBookingWithMultipleProperties      |
          | PartialBookingWithoutFirstName            |
          | PartialBookingWithoutLastName             |
          | PartialBookingWithoutDepositPaid          |
          | PartialBookingWithoutTotalPrice           |
          | PartialBookingWithoutBookingDatesCheckIn  |
          | PartialBookingWithoutBookingDatesCheckOut |
          | PartialBookingWithoutAdditionalNeeds      |
          
    @ignore #The invalid Status Code was implemented here, there should be 400 (Bad Request) but there is 500 (Internal Server Error) or 200 (OK) which is misleading
    Scenario Outline: Booking Endpoint invalid request with single property should return Bad Request
        Given Prerequisite: API is running
        And the '<PartialBookingWithSingleProperty>' booking with single property request is created
        When trying to create a new booking
        Then status code should be '400'

        Examples:
          | PartialBookingWithSingleProperty      |
          | PartialBookingWithOnlyFirstName       |
          | PartialBookingWithOnlyLastName        |
          | PartialBookingWithOnlyDepositPaid     |
          | PartialBookingWithOnlyTotalPrice      |
          | PartialBookingDatesWithOnlyCheckIn    |
          | PartialBookingDatesWithOnlyCheckOut   |
          | PartialBookingWithOnlyAdditionalNeeds |

@SetupOneBooking
@CleanUpBooking
@AuthorizeRequest
Feature: Put Update Booking Endpoint Unhappy Path with missing Body properites
    
Description:
    As RestfulBooker user
    I want to sent PUT request with invalid body for the existing booking to the /booking/{id} endpoint
    So that I will be able to get error code (400 Bad Request Status Code) and the booking cannot be updated

    Scenario Outline: Booking Endpoint invalid request without one of the property should return Bad Request
        Given Prerequisite: API is running
        And the '<PartialBookingWithMultipleProperties>' booking request is created
        When trying to 'PUT' update booking
        Then status code should be '400'

        Examples:
          | PartialBookingWithMultipleProperties      |
          | PartialBookingWithoutFirstName            |
          | PartialBookingWithoutLastName             |
          | PartialBookingWithoutDepositPaid          |
          | PartialBookingWithoutTotalPrice           |
          | PartialBookingWithoutBookingDatesCheckIn  |
          | PartialBookingWithoutBookingDatesCheckOut |

    @ignore 
    # ignored due to the bug in the PATCH update Without Additional Needs implementation
    # entity is updated and returned while the 400 (Bad Request) error should be returned
    Scenario Outline: Booking Endpoint invalid request without Additional Needs property should return Bad Request
        Given Prerequisite: API is running
        And the '<PartialBookingWithMultipleProperties>' booking request is created
        When trying to 'PUT' update booking
        Then status code should be '400'

        Examples:
          | PartialBookingWithMultipleProperties      |
          | PartialBookingWithoutAdditionalNeeds      |
          
    Scenario Outline: Booking Endpoint invalid request with single property should return Bad Request
        Given Prerequisite: API is running
        And the '<PartialBookingWithSingleProperty>' booking with single property request is created
        When trying to 'PUT' update booking
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

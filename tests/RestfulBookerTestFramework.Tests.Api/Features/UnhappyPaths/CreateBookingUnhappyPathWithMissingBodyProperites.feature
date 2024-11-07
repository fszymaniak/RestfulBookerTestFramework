@AuthorizeRequest

Feature: Create Booking Endpoint Unhappy Path with missing Body properites
Description: Send the invalid POST request with invalid body to the /booking endpoint and it should return 400 (Bad Request)

    @ignore #The invalid Status Code was implemented here, there should be 400 (Bad Request) but there is 500 (Internal Server Error) or 200 (OK) which is misleading
    Scenario Outline: Booking Endpoint invalid request without one of the property should return Bad Request
        Given Prerequisite: API is running
        And the '<PartialBooking>' booking request is created
        When trying to create a new booking
        Then status code should be '400'

        Examples:
          | PartialBooking                            |
          | PartialBookingWithoutFirstName            |
          | PartialBookingWithoutLastName             |
          | PartialBookingWithoutDepositPaid          |
          | PartialBookingWithoutTotalPrice           |
          | PartialBookingWithoutBookingDatesCheckIn  |
          | PartialBookingWithoutBookingDatesCheckOut |
          | PartialBookingWithoutAdditionalNeeds      |

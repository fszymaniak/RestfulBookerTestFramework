Feature: Create Booking Endpoint Unhappy Path with missing Body properites
Description: Send the invalid POST request with invalid body to the /booking endpoint and it should return 400 (Bad Request)

    Scenario Outline: Booking Endpoint invalid request without one of the property should return Bad Request
        Given Prerequisite: API is running
        And the '<InvalidBooking>' booking request is created
        When trying to create a new booking
        Then status code should be '400'

        Examples:
          | InvalidBooking                            |
          | InvalidBookingWithoutFirstName            |
          | InvalidBookingWithoutLastName             |
          | InvalidBookingWithoutDepositPaid          |
          | InvalidBookingWithoutTotalPrice           |
          | InvalidBookingWithoutBookingDatesCheckIn  |
          | InvalidBookingWithoutBookingDatesCheckOut |
          | InvalidBookingWithoutAdditionalNeeds      |

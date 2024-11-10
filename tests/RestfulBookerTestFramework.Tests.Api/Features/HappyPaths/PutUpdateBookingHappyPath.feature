@SetupOneBooking
@CleanUpBooking
@AuthorizeRequest

Feature: Put Update Booking Endpoint Happy Path
Description: Send the valid PUT request with valid booking request to /booking/{id} endpoint and it should return 200 (OK) with proper booking

    Scenario:  Endpoint Booking get single specific entity successfully
        Given Prerequisite: API is running
        And a new valid booking request is created
        When trying to 'PUT' update booking
        Then status code should be '200'
        And the newly updated booking should be valid
@AuthorizeRequest

Feature: Get Booking Endpoint Unhappy Path when Booking not exist
Description: Send the valid GET request with not existing booking id to the /booking/{id} endpoint then it should return 404 (Not Found)

    Scenario: Endpoint Booking cannot get specific entity as it is not exists
        Given Prerequisite: API is running
        When trying to send 'Get' method for not existing booking
        Then status code should be '404'
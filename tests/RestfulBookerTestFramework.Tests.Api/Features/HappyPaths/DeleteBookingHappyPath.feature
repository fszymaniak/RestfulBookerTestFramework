@SetupOneBooking
@AuthorizeRequest

Feature: Delete Booking Endpoint Happy Path
Description: Send the valid DELETE request with valid booking id /booking/{id} endpoint and token then it should return 200 (OK) with proper booking

    Scenario: Endpoint Booking delete specific entity successfully
        Given Prerequisite: API is running
        When trying to delete booking
        #Reccomended status code for DELETE is 204 (or 202 / 200)
        Then status code should be '201'
        And the booking should be deleted and not found
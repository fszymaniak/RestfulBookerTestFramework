@HappyPath
@ApiIntegrationTest
@DeleteBookingFeature
@SetupOneBooking
@AuthorizeRequest
Feature: Delete Booking Endpoint Happy Path

Description:
    As RestfulBooker user
    I want to sent valid DELETE request with valid existing booking id to the /booking/{id} endpoint
    So that I will be able to sucessfully (201) delete existing booking

    Scenario: Endpoint Booking delete specific entity successfully
        Given Prerequisite: API is running
        When trying to delete booking
        #Reccomended status code for DELETE is 204 (or 202 / 200)
        Then status code should be '201'
        And the booking should be deleted and not found
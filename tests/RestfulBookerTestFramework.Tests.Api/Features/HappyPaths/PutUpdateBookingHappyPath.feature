@SetupOneBooking
@CleanUpBooking
@AuthorizeRequest
Feature: Put Update Booking Endpoint Happy Path

Description:
    As RestfulBooker user
    I want to sent valid PUT request with existing booking id and valid full request to the /booking/{id} endpoint
    So that I will be able to sucessfully (200 OK Status Code) update existing booking

    Scenario:  Endpoint Booking get single specific entity successfully
        Given Prerequisite: API is running
        And a new valid booking request is created
        When trying to 'PUT' update booking
        Then status code should be '200'
        And the newly 'Put' updated booking should be valid
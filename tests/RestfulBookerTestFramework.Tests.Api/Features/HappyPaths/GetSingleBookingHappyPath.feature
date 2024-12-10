@SetupOneBooking
@CleanUpBooking
@AuthorizeRequest
Feature: Get Single Booking Endpoint Happy Path

Description:
    As RestfulBooker user
    I want to sent valid GET request with valid existing booking id to the /booking/{id} endpoint
    So that I will be able to sucessfully (200 OK Status Code) get existing booking

    Scenario:  Endpoint Booking get single specific entity successfully
        Given Prerequisite: API is running
        When trying to get single booking
        Then status code should be '200'
        And the single get booking should be valid                                                                                                                                                                                                                                                        
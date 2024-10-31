@SetupOneBooking

Feature: Get Single Booking Endpoint Happy Path
Description: Send the valid GET request with valid booking id  /booking/{id} endpoint and it should return 200 (OK) and return proper booking

    Scenario:  Endpoint Booking get single specific entity successfully
        Given Prerequisite: API is running
        When trying to get single booking
        Then status code should be '200'
        And the single get booking should be valid                                                                                                                                                                                                                                                              
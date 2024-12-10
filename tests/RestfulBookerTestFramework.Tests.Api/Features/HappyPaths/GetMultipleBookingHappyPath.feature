@SetupMultipleBookings
@AuthorizeRequest
Feature: Get Multiple Bookings Ids Endpoint Happy Path

Description:
    As RestfulBooker user
    I want to sent valid GET request to the /booking endpoint
    So that I will be able to sucessfully (200 OK Status Code) retrive existing booking Ids list

    Scenario: Endpoint Booking get multiple booking Ids successfully
        Given Prerequisite: API is running
        When trying to get multiple bookings Ids
        Then status code should be '200'
        And the multiple bookings ids should be exist
        
    @ignore #Filtering by checkIn and checkOut is not working, this feature has to be double checked and implemented
    Scenario: Endpoint Booking get multiple booking Ids filtering by checkIn and checkOut date successfully
        Given Prerequisite: API is running
        When trying to get multiple bookings Ids with checkIn and checkOut filter
        Then status code should be '200'
        And the multiple bookings ids filtered by dates should be exist
        
    Scenario: Endpoint Booking get single booking Id filtered by first name and last name successfully
        Given Prerequisite: API is running
        When trying to get single booking Id with first name and last name filter
        Then status code should be '200'
        And the single booking id filtered by name should be exist                                                                                                                                                                                                                                              
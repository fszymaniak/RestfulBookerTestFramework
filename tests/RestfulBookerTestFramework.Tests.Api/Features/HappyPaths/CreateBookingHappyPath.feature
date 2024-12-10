@CleanUpBooking
@AuthorizeRequest
Feature: Create Booking Endpoint Happy Path

Description: 
    As RestfulBooker user
    I want to sent valid POST request with valid body to the /booking endpoint
    So that I will be able to sucessfully (201 Created Status Code) create booking entity

    Scenario: Booking Endpoint Valid Booking entity is created successfully
        Given Prerequisite: API is running
        And a new valid booking request is created
        When trying to create a new booking
        Then status code should be '200'
        And the newly created booking should be valid                                                                                                                                                                                                                                                                    
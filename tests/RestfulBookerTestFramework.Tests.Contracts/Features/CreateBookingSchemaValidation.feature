@CleanUpBooking
@AuthorizeRequest
Feature: Create Booking Happy Patch Schema Validation

Description:
    As RestfulBooker user
    I want to sent valid POST request to the /booking endpoint
    So that I will be able to sucessfully validate response schema

    Scenario: Booking Endpoint response schema is valid while creating new booking
        Given Prerequisite: API is running
        And a new valid booking request is created
        When trying to create a new booking
        Then 'CreatedBooking' response schema is valid                                                                                                                                                                                                                                           
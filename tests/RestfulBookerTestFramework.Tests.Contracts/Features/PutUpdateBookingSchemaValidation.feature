@SetupOneBooking
@CleanUpBooking
@AuthorizeRequest
Feature: Put Update Booking Happy Path Schema Validation

Description:
    As RestfulBooker user
    I want to sent valid PUT request to the /booking/{id} endpoint
    So that I will be able to sucessfully validate response schema

    Scenario: Booking Endpoint response schema is valid while Put updating new booking
        Given Prerequisite: API is running
        And a new valid booking request is created
        When trying to 'PUT' update booking
        Then 'Booking' response schema is valid
@SetupOneBooking
@CleanUpBooking
@AuthorizeRequest
Feature: Get Single Booking Endpoint Schema Validation

Description:
    As RestfulBooker user
    I want to sent valid GET request with valid existing booking id to the /booking/{id} endpoint
    So that I will be able to sucessfully validate single booking response schema

    Scenario:  Endpoint Booking get single specific entity successfully
        Given Prerequisite: API is running
        When trying to get single booking
        Then 'Booking' response schema is valid                                                                                                                                                                                                                           
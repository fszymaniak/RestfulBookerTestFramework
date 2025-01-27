@ContractTest
@GetBookingIdsFeature
@SetupMultipleBookings
@AuthorizeRequest
Feature: Get Multiple Bookings Ids Schema Validation

Description:
    
    As RestfulBooker user
    I want to sent valid GET request to the /booking endpoint
    So that I will be able to sucessfully validate booking ids response schema

    Scenario: Endpoint Booking get multiple booking Ids successfully
        Given Prerequisite: API is running
        When trying to get multiple bookings Ids
        Then 'BookingsIds' response schema is valid

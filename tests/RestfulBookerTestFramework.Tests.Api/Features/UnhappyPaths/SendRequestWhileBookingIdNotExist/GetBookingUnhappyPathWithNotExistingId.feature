@AuthorizeRequest
Feature: Get Booking Endpoint Unhappy Path when Booking not exist
    
Description:
    As RestfulBooker user
    I want to sent valid GET request with not existing booking id to the /booking/{id} endpoint
    So that I will be able to get error code (404 Not Found Status Code) and the booking cannot be retrived

    Scenario: Endpoint Booking cannot get specific entity as it is not exists
        Given Prerequisite: API is running
        When trying to send 'Get' method for not existing booking
        Then status code should be '404'
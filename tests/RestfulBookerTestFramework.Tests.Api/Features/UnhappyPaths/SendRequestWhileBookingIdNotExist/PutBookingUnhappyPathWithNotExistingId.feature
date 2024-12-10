@AuthorizeRequest
Feature: Put Booking Endpoint Unhappy Path when Booking not exist
    
Description:
    As RestfulBooker user
    I want to sent valid PUT request with not existing booking id to the /booking/{id} endpoint
    So that I will be able to get error code (404 Not Found Status Code) and the booking cannot be updated

    @ignore
    # ignored due to the bug in the PUT request when {id} is not exist
    # 405 (Method Not Allowed) is returned while the 404 (Not Found) error should be used
    Scenario: Endpoint Booking cannot Put update specific entity as it is not exists
        Given Prerequisite: API is running
        And a new valid booking request is created
        When trying to send 'Put' method for not existing booking
        Then status code should be '404'
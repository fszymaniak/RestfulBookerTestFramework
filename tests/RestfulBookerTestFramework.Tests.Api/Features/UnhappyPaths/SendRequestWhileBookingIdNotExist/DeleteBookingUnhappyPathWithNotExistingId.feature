@AuthorizeRequest

Feature: Delete Booking Endpoint Unhappy Path
Description: Send the valid DELETE request with valid booking id /booking/{id} endpoint and token then it should return 200 (OK) with proper booking

    @ignore 
    # ignored due to the bug in the DELETE request when {id} is not exist
    # 405 (Method Not Allowed) is returned while the 404 (Not Found) error should be used
    Scenario: Endpoint Booking cannot delete specific entity as it is not exists
        Given Prerequisite: API is running
        When trying to send 'Delete' method for not existing booking
        Then status code should be '404'

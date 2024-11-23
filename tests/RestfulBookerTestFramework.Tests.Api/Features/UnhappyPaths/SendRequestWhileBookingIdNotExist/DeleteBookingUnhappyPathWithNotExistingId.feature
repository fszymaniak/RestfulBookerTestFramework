@AuthorizeRequest

Feature: Delete Booking Endpoint Unhappy Path
Description: Send the valid DELETE request with not existing booking id to the /booking/{id} endpoint then it should return 404 (Not Found)

    @ignore 
    # ignored due to the bug in the DELETE request when {id} is not exist
    # 405 (Method Not Allowed) is returned while the 404 (Not Found) error should be used
    Scenario: Endpoint Booking cannot delete specific entity as it is not exists
        Given Prerequisite: API is running
        When trying to send 'Delete' method for not existing booking
        Then status code should be '404'

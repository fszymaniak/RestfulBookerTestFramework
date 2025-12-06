@ValidationTest
@ApiIntegrationTest
@ContentTypeValidation
@CleanUpBooking
@AuthorizeRequest
Feature: Content-Type Header Validation

Description:
    As RestfulBooker API consumer
    I want to ensure proper Content-Type header validation
    So that API requests are handled correctly based on content type

    @HighPriority
    @TC-162
    Scenario: POST /booking without Content-Type header should be handled
        Given Prerequisite: API is running
        And a new valid booking request is created
        When trying to create a new booking without Content-Type header
        Then status code should be '400' or '500'

    @HighPriority
    @TC-163
    @SetupOneBooking
    Scenario: PUT /booking without Content-Type header should be handled
        Given Prerequisite: API is running
        And a new valid booking request is created
        When trying to 'Put' update booking without Content-Type header
        Then status code should be '400' or '500'

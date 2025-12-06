@ValidationTest
@ApiIntegrationTest
@UpdateBookingFeature
@SetupOneBooking
@CleanUpBooking
@AuthorizeRequest
Feature: Mixed Valid and Invalid Field Validation on Update

Description:
    As RestfulBooker API consumer
    I want to test PUT requests with mixed valid and invalid fields
    So that I can verify the API properly validates all fields in update requests

    @HighPriority
    @TC-166
    Scenario: PUT update with some valid and some invalid fields
        Given Prerequisite: API is running
        And a booking update request with valid firstname and invalid totalprice is created
        When trying to 'Put' update booking
        Then status code should be '400' or '500'

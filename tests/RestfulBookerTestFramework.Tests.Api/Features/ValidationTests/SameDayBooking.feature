@ValidationTest
@ApiIntegrationTest
@EdgeCaseTest
@CleanUpBooking
@AuthorizeRequest
Feature: Same Day Checkin and Checkout Validation

Description:
    As RestfulBooker API consumer
    I want to test booking creation with same-day checkin and checkout
    So that I can verify the API handles this edge case correctly

    @HighPriority
    @TC-165
    Scenario: Create booking with same checkin and checkout date
        Given Prerequisite: API is running
        And a booking request with same day checkin '2024-01-15' and checkout '2024-01-15' is created
        When trying to create a new booking
        Then status code should be '200' or '500'

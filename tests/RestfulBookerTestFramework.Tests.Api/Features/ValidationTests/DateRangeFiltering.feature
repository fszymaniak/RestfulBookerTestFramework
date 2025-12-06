@ValidationTest
@ApiIntegrationTest
@FilteringTest
@SetupOneBooking
@CleanUpBooking
Feature: Date Range Filtering for Booking IDs

Description:
    As RestfulBooker API consumer
    I want to filter bookings using both checkin and checkout date parameters
    So that I can retrieve bookings within a specific date range

    @HighPriority
    @TC-164
    Scenario: Filter bookings with both checkin and checkout date parameters
        Given Prerequisite: API is running
        And a booking with checkin date '2024-01-01' and checkout date '2024-01-15' exists
        When requesting booking IDs with checkin filter '2024-01-01' and checkout filter '2024-01-31'
        Then status code should be '200'
        And the response should contain the booking in date range

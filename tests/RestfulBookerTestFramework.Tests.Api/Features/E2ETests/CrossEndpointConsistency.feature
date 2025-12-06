@E2ETest
@ApiIntegrationTest
@CrossEndpointConsistency
@CleanUpBooking
@AuthorizeRequest
Feature: Cross-Endpoint Data Consistency

Description:
    As RestfulBooker API consumer
    I want to ensure data consistency across different endpoints
    So that operations on one endpoint are immediately reflected in others

    @HighPriority
    @TC-169
    Scenario: Created booking immediately appears in GetBookingIds list
        Given Prerequisite: API is running
        And a new valid booking request is created
        When trying to create a new booking
        Then status code should be '200'
        And the newly created booking should appear in GetBookingIds list

    @HighPriority
    @TC-170
    @SetupOneBooking
    Scenario: Updated firstname is filterable in GetBookingIds
        Given Prerequisite: API is running
        And the booking firstname is updated to 'UpdatedName'
        When trying to 'Put' update booking
        Then status code should be '200'
        And the booking should be filterable by firstname 'UpdatedName'

    @HighPriority
    @TC-171
    @SetupOneBooking
    Scenario: Deleted booking is removed from filtered results
        Given Prerequisite: API is running
        And the existing booking has firstname 'TestUser' and lastname 'Smith'
        When the booking is deleted
        Then status code should be '201'
        And the booking should not appear in firstname filter 'TestUser'
        And the booking should not appear in lastname filter 'Smith'

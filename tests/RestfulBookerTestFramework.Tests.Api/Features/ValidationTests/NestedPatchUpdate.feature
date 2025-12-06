@ValidationTest
@ApiIntegrationTest
@PatchBookingFeature
@SetupOneBooking
@CleanUpBooking
@AuthorizeRequest
Feature: Nested Bookingdates Object PATCH Update

Description:
    As RestfulBooker API consumer
    I want to PATCH update nested bookingdates object fields
    So that I can partially update checkin or checkout dates without affecting other fields

    @HighPriority
    @TC-167
    Scenario: PATCH update entire bookingdates object with only checkin
        Given Prerequisite: API is running
        And a partial bookingdates update request with only checkin '2024-02-01' is created
        When trying to 'Patch' update booking
        Then status code should be '200'
        And the checkin date should be updated to '2024-02-01'
        And other booking fields should remain unchanged

    @HighPriority
    @TC-168
    Scenario: PATCH update only checkin date within bookingdates
        Given Prerequisite: API is running
        And the 'PartialBookingDatesWithOnlyCheckIn' booking with single property request is created
        When trying to 'Patch' update booking
        Then status code should be '200'
        And the newly 'Patch' updated booking should be valid

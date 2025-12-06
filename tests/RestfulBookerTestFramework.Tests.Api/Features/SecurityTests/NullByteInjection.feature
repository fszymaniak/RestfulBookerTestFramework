@SecurityTest
@ApiIntegrationTest
@InjectionTest
@CleanUpBooking
@AuthorizeRequest
Feature: Null Byte Injection Security Testing

Description:
    As RestfulBooker API security tester
    I want to test null byte injection attempts in booking fields
    So that I can verify the API properly sanitizes or rejects malicious input

    @HighPriority
    @TC-172
    Scenario: Create booking with null byte in firstname should be sanitized or rejected
        Given Prerequisite: API is running
        And a booking request with null byte in firstname is created
        When trying to create a new booking
        Then status code should be '200' or '400'
        And if booking is created then firstname should not contain null byte

@PerformanceTest
@Inject
@GetBookingIdsFeature
Feature: Performance test inject of getting multiple booking ids
    Description:
    As RestfulBooker user
    I want to sent valid GET request to the /booking endpoint
    So that I will be able to sucessfully (200 OK Status Code) test performance of this endpoint

    Scenario: Performance Inject Get Multiple Booking Ids Endpoint 
        Given Prerequisite: API is running
        When run inject performance scenario: 'Get multiple bookings ids (inject)' for 'GET' method and '/booking' endpoint with Rate: 5, Interval in seconds: 1 and During in seconds: 5
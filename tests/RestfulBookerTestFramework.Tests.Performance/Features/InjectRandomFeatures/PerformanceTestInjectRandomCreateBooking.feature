@PerformanceTest
@InjectRandom
@BookingCreationFeature
@CleanUpPerformanceBookings
@AuthorizeRequest
Feature: Performance test inject random of creating booking

Description:
As RestfulBooker user
I want to sent valid POST request with valid body to the /booking endpoint
So that I will be able to sucessfully create booking entity (201 Created Status Code) and test performance of this endpoint

    Scenario: Performance Inject Random Create Booking Endpoint 
        Given Prerequisite: API is running
        And a new valid booking request is created
        When run inject random performance scenario: 'Create booking (inject random)' for 'POST' method and '/booking' endpoint with MinRate: 5, MaxRate: 10, Interval in seconds: 1 and During in seconds: 5

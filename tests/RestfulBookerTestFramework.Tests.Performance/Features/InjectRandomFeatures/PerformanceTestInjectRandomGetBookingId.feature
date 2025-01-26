@PerformanceTest
@InjectRandom
@GetBookingFeature
@SetupOneBooking
@CleanUpBooking
@AuthorizeRequest
Feature: Performance test inject random of getting single booking id
    Description:
    As RestfulBooker user
    I want to sent valid GET request to the /booking/{id} endpoint
    So that I will be able to sucessfully (200 OK Status Code) test performance of this endpoint

    Scenario: Performance Inject Random Get Single Booking Id Endpoint 
        Given Prerequisite: API is running
        When run inject performance scenario: 'Get single bookings ids (inject random)' for 'GET' method and '/booking/{id}' endpoint with Rate: 5, Interval in seconds: 1 and During in seconds: 5
@PerformanceTest
@RampingInject
@BookingCreationFeature
@CleanUpPerformanceBookings
@AuthorizeRequest
Feature: Performance test ramping inject of creating booking

Description:
As RestfulBooker user
I want to sent valid POST request with valid body to the /booking endpoint
So that I will be able to sucessfully create booking entity (201 Created Status Code) and test performance of this endpoint

    Scenario: Performance Ramping Inject Create Booking Endpoint 
        Given Prerequisite: API is running
        And a new valid booking request is created
        When run ramping inject performance scenario: 'Create booking (ramping inject)' for 'POST' method and '/booking' endpoint with Rate: 5, Interval in seconds: 1 and During in seconds: 5

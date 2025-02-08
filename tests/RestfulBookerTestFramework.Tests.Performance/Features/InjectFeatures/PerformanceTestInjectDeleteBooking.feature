@PerformanceTest
@Inject
@DeleteBookingFeature
@AuthorizeRequest
Feature: Performance test inject of deleting booking

Description:
As RestfulBooker user
I want to sent valid DELETE request with valid booking id to the /booking endpoint
So that I will be able to sucessfully create delete entity (201 Created Status Code) and test performance of this endpoint

    Scenario: Performance Inject Delete Booking Endpoint 
        Given Prerequisite: API is running
        And a new valid booking request is created
        When run inject delete performance scenario: 'Create and then delete booking (inject)'  with Rate: 5, Interval in seconds: 1 and During in seconds: 5

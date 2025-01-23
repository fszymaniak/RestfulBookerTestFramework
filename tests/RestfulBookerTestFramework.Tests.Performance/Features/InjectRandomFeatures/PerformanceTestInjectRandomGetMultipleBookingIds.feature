Feature: Performance test inject random of getting multiple booking ids
    Description:
    As RestfulBooker user
    I want to sent valid GET request to the /booking endpoint
    So that I will be able to sucessfully (200 OK Status Code) test performance of this endpoint

    Scenario: Performance Inject Random Get Multiple Booking Ids Endpoint 
        Given Prerequisite: API is running
        When run inject random performance scenario: 'Get multiple bookings ids (inject random)' for 'GET' method and '/booking' endpoint with MinRate: 5, MaxRate: 10, Interval in seconds: 1 and During in seconds: 5
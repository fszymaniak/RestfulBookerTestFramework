@PerformanceTest
@InjectRandom
@AuthorizationFeature
Feature: Performance test inject random of creating authentication token
    Description:
    As RestfulBooker user
    I want to sent valid POST request with username and password to the /auth endpoint
    So that I will be able to sucessfully create auth token (200 OK Status Code) and test performance of this endpoint

    Scenario: Performance Inject Random Authentication Endpoint 
        Given Prerequisite: API is running
        And a new valid auth token request is created
        When run inject random performance scenario: 'Create auth token (inject)' for 'POST' method and '/auth' endpoint with MinRate: 5, MaxRate: 10, Interval in seconds: 1 and During in seconds: 5
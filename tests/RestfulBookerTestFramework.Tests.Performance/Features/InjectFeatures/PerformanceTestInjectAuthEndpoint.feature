﻿@PerformanceTest
@Inject
@AuthorizationFeature
Feature: Performance test inject of creating authentication token
    Description:
    As RestfulBooker user
    I want to sent valid POST request with username and password to the /auth endpoint
    So that I will be able to sucessfully create auth token (200 OK Status Code) and test performance of this endpoint

    Scenario: Performance Inject Authentication Endpoint 
        Given Prerequisite: API is running
        And a new valid auth token request is created
        When run inject performance scenario: 'Create auth token (inject)' for 'POST' method and '/auth' endpoint with Rate: 5, Interval in seconds: 1 and During in seconds: 5
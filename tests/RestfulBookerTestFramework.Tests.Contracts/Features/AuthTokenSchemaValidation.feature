@ContractTest
@AuthorizationFeature
Feature: Auth Endpoint Happy Path Schema Validation

Description:
    As RestfulBooker user
    I want to sent valid POST request to the /auth endpoint
    So that I will be able to sucessfully validate response schema

    Scenario: Authorization Endpoint Valid Token response schema is valid 
        Given Prerequisite: API is running
        And a new valid auth token request is created
        When the new auth token is created
        Then 'Authentication' response schema is valid
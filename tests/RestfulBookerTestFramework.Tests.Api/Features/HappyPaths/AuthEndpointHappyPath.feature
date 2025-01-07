@HappyPath
@ApiIntegrationTest
@AuthorizationFeature
Feature: Auth Endpoint Happy Path
Description:
    As RestfulBooker user
    I want to sent valid POST request to the /auth endpoint
    So that I will be able to sucessfully (200 OK Status Code) retrive token

Scenario: Authorization Endpoint Valid Token is created successfully 
    Given Prerequisite: API is running
    And a new valid auth token request is created
	When the new auth token is created
    Then status code should be '200'
    And authorization token should be valid

Feature: Auth endpoint validation tests
Description: Send the valid request to the /auth endpoint and it should return 200 (OK) response including token

Scenario: Authorization Endpoint Happy Path
    Given Prerequisite: API is running
    And a new valid auth token request is created
	When the new valid auth token is created
    Then status code should be '200'
    And authorization token should be valid

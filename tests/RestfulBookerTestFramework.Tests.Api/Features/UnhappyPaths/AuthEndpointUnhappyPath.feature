Feature: Auth endpoint unhappy path tests
Description: Send the invalid request to the /auth endpoint 

    Scenario Outline: Authorization Endpoint Unhappy Path with invalid username
        Given Prerequisite: API is running
        And an invalid auth token request with is following user name: '(.*)' and password: '(.*)' is created
        When the new auth token is created
        Then bad credentials message should occur
        And status code should be '401'
        
    Examples: 
        | userName        | password        |
        | validUserName   | invalidPassword |
        | invalidUserName | validPassword   |
        | invalidUserName | invalidPassword |
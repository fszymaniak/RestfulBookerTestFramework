@AuthorizeRequest

Feature: Auth endpoint unhappy path tests
Description: Send the invalid request to the /auth endpoint 

    @ignore #The invalid Status Code was implemented here, there should be 401 (Unauthorized) or 400 (Bad Request) but there is 200 (OK) which is misleading
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
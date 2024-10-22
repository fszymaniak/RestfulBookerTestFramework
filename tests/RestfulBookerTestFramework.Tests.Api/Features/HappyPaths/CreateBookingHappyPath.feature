Feature: Create Booking Endpoint Happy Path
Description: Send the valid POST request with valid body to the /booking endpoint and it should return 201 (Created) and created booking entity

    Scenario: Booking Endpoint Valid Booking entity is created successfully
        Given Prerequisite: API is running
        And a new valid booking request is created
        When the new booking is created
        Then status code should be '200'
        And the booking should be valid                                                                                                                                                                                                                                                                                         
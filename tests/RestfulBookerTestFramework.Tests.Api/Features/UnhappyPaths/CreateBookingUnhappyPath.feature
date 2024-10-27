Feature: Create Booking Endpoint Unhappy Path
Description: Send the invalid POST request with invalid body to the /booking endpoint and it should return 400 (Bad Request)

    Scenario: Booking Endpoint invalid request without First Name property returns Bad Request
        Given Prerequisite: API is running
        And the 'InvalidBookingWithoutFirstName' booking request is created
        When trying to create a new booking
        Then status code should be '400'
        
    Scenario: Booking Endpoint invalid request without Last Name property returns Bad Request
        Given Prerequisite: API is running
        And the 'InvalidBookingWithoutLastName' booking request is created
        When trying to create a new booking
        Then status code should be '400'
        
    Scenario: Booking Endpoint invalid request without Deposit Paid property returns Bad Request
        Given Prerequisite: API is running
        And the 'InvalidBookingWithoutDepositPaid' booking request is created
        When trying to create a new booking
        Then status code should be '400'
        
    Scenario: Booking Endpoint invalid request without Total Price property returns Bad Request
        Given Prerequisite: API is running
        And the 'InvalidBookingWithoutTotalPrice' booking request is created
        When trying to create a new booking
        Then status code should be '400'
        
    Scenario: Booking Endpoint invalid request without Booking Dates Check In property returns Bad Request
        Given Prerequisite: API is running
        And the 'InvalidBookingWithoutBookingDatesCheckIn' booking request is created
        When trying to create a new booking
        Then status code should be '400'
        
    Scenario: Booking Endpoint invalid request without Booking Dates Check Out property returns Bad Request
        Given Prerequisite: API is running
        And the 'InvalidBookingWithoutBookingDatesCheckOut' booking request is created
        When trying to create a new booking
        Then status code should be '400'
        
    Scenario: Booking Endpoint invalid request without Additional Needs property returns Bad Request
        Given Prerequisite: API is running
        And the 'InvalidBookingWithoutAdditionalNeeds' booking request is created
        When trying to create a new booking
        Then status code should be '400'
        
    

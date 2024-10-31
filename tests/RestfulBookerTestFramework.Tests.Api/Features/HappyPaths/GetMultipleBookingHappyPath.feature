@SetupMultipleBookings

Feature: Get Multiple Bookings Ids Endpoint Happy Path
Description: Send the valid GET request to the /booking endpoint and it should return 200 (OK) with list of bookingIds

    Scenario:  Endpoint Booking get multiple booking Ids successfully
        Given Prerequisite: API is running
        When trying to get multiple bookings Ids
        Then status code should be '200'
        And the multiple bookings ids should be exist                                                                                                                                                                                                                                                     
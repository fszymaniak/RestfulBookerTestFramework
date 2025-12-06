# Restful-Booker API - Unified Test Case Repository

**Base URL:** https://restful-booker.herokuapp.com
**Version:** 3.1 (Enhanced with High-Priority Additions)
**Last Updated:** December 2025

-----

## 1. Suite Tag Legend

Each test case is tagged with one or more suite identifiers. Use these tags to filter tests for specific execution scenarios.

|Tag            |Suite            |Description & When to Run                                                           |
|---------------|-----------------|------------------------------------------------------------------------------------|
|`[SMOKE]`      |Smoke Tests      |Quick validation of core functionality. Run after every deployment. (~2 min)        |
|`[SANITY]`     |Sanity Tests     |Focused validation after bug fixes or minor changes. Run on daily builds. (5-10 min)|
|`[REGRESSION]` |Regression Tests |Full feature verification. Run before releases and sprint end. (30-45 min)          |
|`[SECURITY]`   |Security Tests   |Vulnerability identification. Run periodically and before releases. (20-30 min)     |
|`[PERFORMANCE]`|Performance Tests|Response time and load testing. Run before major releases. (30-60 min)              |
|`[E2E]`        |End-to-End Tests |Complete workflow testing. Run before releases. (15-20 min)                         |
|`[VALIDATION]` |Data Validation  |Input validation and data type handling. Run during sprint testing. (15-20 min)     |
|`[BOUNDARY]`   |Boundary Tests   |Edge cases and limit testing. Run during comprehensive testing. (10-15 min)         |

### 1.1 Quick Execution Guide

|Scenario         |Filter by Tags                         |
|-----------------|---------------------------------------|
|Every Commit/PR  |`[SMOKE]`                              |
|Daily Build      |`[SMOKE]` + `[SANITY]`                 |
|Sprint End       |`[SMOKE]` + `[SANITY]` + `[REGRESSION]`|
|Release Candidate|All tags                               |
|Security Audit   |`[SECURITY]`                           |
|Performance Check|`[PERFORMANCE]`                        |

-----

## 2. Ping - Health Check

**Endpoint:** `GET /ping`
**Purpose:** Simple health check to confirm API is up and running.

|ID    |Test Name               |Description                               |Expected Result            |Priority|Tags                               |
|------|------------------------|------------------------------------------|---------------------------|--------|-----------------------------------|
|TC-001|Health Check Success    |Send GET /ping to verify API is running   |Status 201, body: 'Created'|Critical|`[SMOKE]` `[SANITY]` `[REGRESSION]`|
|TC-002|Response Time Check     |Measure /ping response time               |Response < 100ms (p95)     |High    |`[PERFORMANCE]`                    |
|TC-003|Concurrent Health Checks|Send 50 simultaneous /ping requests       |All return 201, no failures|Medium  |`[PERFORMANCE]`                    |
|TC-004|No Auth Required        |Confirm /ping works without authentication|Status 201, no auth needed |Medium  |`[SANITY]` `[REGRESSION]`          |
|TC-005|Wrong HTTP Method       |Send POST /ping instead of GET            |Status 404 or 405          |Low     |`[REGRESSION]` `[BOUNDARY]`        |
|TC-006|Invalid Endpoint        |Send GET /pings (misspelled)              |Status 404 Not Found       |Low     |`[BOUNDARY]`                       |

-----

## 3. Auth - CreateToken

**Endpoint:** `POST /auth`
**Purpose:** Creates auth token for access to PUT and DELETE /booking endpoints.

### 3.1 Positive Test Cases

|ID    |Test Name         |Description                             |Expected Result                 |Priority|Tags                                       |
|------|------------------|----------------------------------------|--------------------------------|--------|-------------------------------------------|
|TC-007|Valid Credentials |POST /auth with admin/password123       |Status 200, returns valid token |Critical|`[SMOKE]` `[SANITY]` `[REGRESSION]`        |
|TC-008|Token Format Valid|Verify returned token format            |Non-empty alphanumeric string   |High    |`[SANITY]` `[REGRESSION]`                  |
|TC-009|Content-Type JSON |Send with Content-Type: application/json|Request accepted, token returned|High    |`[REGRESSION]`                             |
|TC-010|Multiple Tokens   |Generate multiple tokens with same creds|Each request returns new token  |Medium  |`[REGRESSION]`                             |
|TC-011|Token Usability   |Use generated token for PUT request     |Token authorizes the request    |Critical|`[SMOKE]` `[SANITY]` `[REGRESSION]` `[E2E]`|
|TC-012|Auth Response Time|Measure POST /auth response time        |Response < 500ms (p95)          |High    |`[PERFORMANCE]`                            |

### 3.2 Negative Test Cases

|ID    |Test Name             |Description                          |Expected Result                      |Priority|Tags                         |
|------|----------------------|-------------------------------------|-------------------------------------|--------|-----------------------------|
|TC-013|Invalid Username      |POST /auth with wrong username       |Status 200, reason: 'Bad credentials'|Critical|`[SANITY]` `[REGRESSION]`    |
|TC-014|Invalid Password      |POST /auth with wrong password       |Status 200, reason: 'Bad credentials'|Critical|`[SANITY]` `[REGRESSION]`    |
|TC-015|Empty Credentials     |POST /auth with empty user/pass      |Status 200, reason: 'Bad credentials'|High    |`[SANITY]` `[REGRESSION]`    |
|TC-016|Missing Username      |POST /auth without username field    |Status 200, reason: 'Bad credentials'|High    |`[REGRESSION]` `[VALIDATION]`|
|TC-017|Missing Password      |POST /auth without password field    |Status 200, reason: 'Bad credentials'|High    |`[REGRESSION]` `[VALIDATION]`|
|TC-018|Empty Request Body    |POST /auth with empty JSON body      |Status 200, reason: 'Bad credentials'|High    |`[REGRESSION]` `[VALIDATION]`|
|TC-019|SQL Injection         |Username: ' OR '1'='1                |Request handled safely, no token     |Critical|`[SECURITY]`                 |
|TC-020|NoSQL Injection       |Username: {$ne: null}                |Request handled safely, no token     |Critical|`[SECURITY]`                 |
|TC-021|XSS in Credentials    |Username: `<script>alert(1)</script>`|Script not executed                  |High    |`[SECURITY]`                 |
|TC-022|Brute Force Protection|100 rapid login attempts             |Rate limiting or account lockout     |High    |`[SECURITY]`                 |
|TC-023|Special Characters    |Username/password with special chars |Handled appropriately                |Low     |`[VALIDATION]` `[BOUNDARY]`  |

-----

## 4. Booking - GetBookingIds

**Endpoint:** `GET /booking`
**Purpose:** Returns IDs of all bookings. Supports filtering by firstname, lastname, checkin, checkout.

### 4.1 Positive Test Cases

|ID    |Test Name               |Description                               |Expected Result                       |Priority|Tags                               |
|------|------------------------|------------------------------------------|--------------------------------------|--------|-----------------------------------|
|TC-024|Get All Booking IDs     |GET /booking without filters              |Status 200, array of bookingid objects|Critical|`[SMOKE]` `[SANITY]` `[REGRESSION]`|
|TC-025|Filter by Firstname     |GET /booking?firstname=John               |Status 200, filtered results          |High    |`[SANITY]` `[REGRESSION]`          |
|TC-026|Filter by Lastname      |GET /booking?lastname=Smith               |Status 200, filtered results          |High    |`[SANITY]` `[REGRESSION]`          |
|TC-027|Filter by Checkin       |GET /booking?checkin=2024-01-01           |Status 200, checkin >= date           |High    |`[SANITY]` `[REGRESSION]`          |
|TC-028|Filter by Checkout      |GET /booking?checkout=2024-01-15          |Status 200, checkout <= date          |High    |`[SANITY]` `[REGRESSION]`          |
|TC-029|Multiple Filters        |GET /booking?firstname=John&lastname=Smith|Status 200, all criteria matched      |High    |`[REGRESSION]`                     |
|TC-030|All Filters Combined    |Apply all four filter parameters          |Status 200, all filters applied       |Medium  |`[REGRESSION]`                     |
|TC-031|Accept Header JSON      |Request with Accept: application/json     |Response in JSON format               |Medium  |`[REGRESSION]`                     |
|TC-032|Accept Header XML       |Request with Accept: application/xml      |Response in XML if supported          |Low     |`[REGRESSION]`                     |
|TC-033|List Response Time      |Measure GET /booking response time        |Response < 1000ms (p95)               |High    |`[PERFORMANCE]`                    |
|TC-034|Concurrent List Requests|50 simultaneous GET /booking              |All return 200, consistent data       |Medium  |`[PERFORMANCE]`                    |

### 4.2 Negative Test Cases

|ID    |Test Name             |Description                        |Expected Result                   |Priority|Tags                       |
|------|----------------------|-----------------------------------|----------------------------------|--------|---------------------------|
|TC-035|Non-existent Firstname|Filter with name that doesn't exist|Status 200, empty array           |Medium  |`[REGRESSION]`             |
|TC-036|Invalid Date Format   |checkin=invalid-date               |Error or handled gracefully       |Medium  |`[VALIDATION]`             |
|TC-037|Future Checkin Date   |Filter with far future date        |Status 200, empty or valid results|Low     |`[BOUNDARY]`               |
|TC-038|Invalid Query Param   |GET /booking?invalidparam=value    |Parameter ignored, returns all    |Low     |`[BOUNDARY]`               |
|TC-039|Empty Query Value     |GET /booking?firstname=            |Returns all or empty result       |Low     |`[BOUNDARY]` `[VALIDATION]`|
|TC-040|SQL in Filter         |firstname=' OR '1'='1              |Input sanitized, no injection     |Critical|`[SECURITY]`               |

-----

## 5. Booking - GetBooking

**Endpoint:** `GET /booking/:id`
**Purpose:** Returns a specific booking based on the booking id provided.

### 5.1 Positive Test Cases

|ID    |Test Name                |Description                      |Expected Result                                           |Priority|Tags                               |
|------|-------------------------|---------------------------------|----------------------------------------------------------|--------|-----------------------------------|
|TC-041|Get Valid Booking        |GET /booking/{valid_id}          |Status 200, full booking object                           |Critical|`[SMOKE]` `[SANITY]` `[REGRESSION]`|
|TC-042|Verify Response Schema   |Check all required fields present|firstname, lastname, totalprice, depositpaid, bookingdates|Critical|`[SANITY]` `[REGRESSION]`          |
|TC-043|Booking Dates Structure  |Verify bookingdates object       |Contains checkin/checkout in YYYY-MM-DD                   |High    |`[REGRESSION]` `[VALIDATION]`      |
|TC-044|Accept JSON Header       |Accept: application/json         |Response in JSON format                                   |Medium  |`[REGRESSION]`                     |
|TC-045|Get Booking Response Time|Measure response time            |Response < 300ms (p95)                                    |High    |`[PERFORMANCE]`                    |
|TC-046|Data Consistency         |Compare with list endpoint data  |Same data in both endpoints                               |High    |`[E2E]` `[REGRESSION]`             |

### 5.2 Negative Test Cases

|ID    |Test Name         |Description                   |Expected Result             |Priority|Tags                             |
|------|------------------|------------------------------|----------------------------|--------|---------------------------------|
|TC-047|Non-existent ID   |GET /booking/9999999          |Status 404 Not Found        |Critical|`[SANITY]` `[REGRESSION]`        |
|TC-048|Invalid ID Format |GET /booking/abc              |Status 404 or error         |High    |`[REGRESSION]` `[VALIDATION]`    |
|TC-049|Negative ID       |GET /booking/-1               |Status 404 Not Found        |Medium  |`[BOUNDARY]`                     |
|TC-050|Zero ID           |GET /booking/0                |Status 404 Not Found        |Medium  |`[BOUNDARY]`                     |
|TC-051|Deleted Booking ID|GET previously deleted booking|Status 404 Not Found        |Critical|`[SANITY]` `[REGRESSION]` `[E2E]`|
|TC-052|Max Integer ID    |GET /booking/2147483647       |Status 404 or handled       |Low     |`[BOUNDARY]`                     |
|TC-053|Path Traversal    |GET /booking/../../../etc     |Path not traversed, error   |High    |`[SECURITY]`                     |
|TC-054|IDOR Attempt      |Access other users' bookings  |Only authorized data visible|Critical|`[SECURITY]`                     |

-----

## 6. Booking - CreateBooking

**Endpoint:** `POST /booking`
**Purpose:** Creates a new booking in the API.

### 6.1 Positive Test Cases

|ID    |Test Name            |Description                  |Expected Result                |Priority|Tags                               |
|------|---------------------|-----------------------------|-------------------------------|--------|-----------------------------------|
|TC-055|Create Valid Booking |POST with all required fields|Status 200, bookingid + booking|Critical|`[SMOKE]` `[SANITY]` `[REGRESSION]`|
|TC-056|With Additional Needs|Include additionalneeds field|Status 200, field saved        |High    |`[SANITY]` `[REGRESSION]`          |
|TC-057|Minimum Fields       |Only mandatory fields        |Status 200, booking created    |High    |`[REGRESSION]`                     |
|TC-058|Deposit Paid True    |depositpaid: true            |Value stored correctly         |Medium  |`[REGRESSION]` `[VALIDATION]`      |
|TC-059|Deposit Paid False   |depositpaid: false           |Value stored correctly         |Medium  |`[REGRESSION]` `[VALIDATION]`      |
|TC-060|Verify Created Data  |Create then GET to verify    |All data matches               |Critical|`[SANITY]` `[E2E]`                 |
|TC-061|Created in List      |Create then check in list    |New booking appears in list    |High    |`[E2E]` `[REGRESSION]`             |
|TC-062|Create Response Time |Measure POST response time   |Response < 800ms (p95)         |High    |`[PERFORMANCE]`                    |
|TC-063|Concurrent Creates   |50 simultaneous creates      |All succeed with unique IDs    |High    |`[PERFORMANCE]`                    |

### 6.2 Negative Test Cases

|ID    |Test Name              |Description                           |Expected Result               |Priority|Tags                                    |
|------|-----------------------|--------------------------------------|------------------------------|--------|----------------------------------------|
|TC-064|Missing Firstname      |Without firstname field               |Status 500 or validation error|Critical|`[SANITY]` `[REGRESSION]` `[VALIDATION]`|
|TC-065|Missing Lastname       |Without lastname field                |Status 500 or validation error|Critical|`[REGRESSION]` `[VALIDATION]`           |
|TC-066|Missing Totalprice     |Without totalprice field              |Status 500 or validation error|Critical|`[REGRESSION]` `[VALIDATION]`           |
|TC-067|Missing Depositpaid    |Without depositpaid field             |Status 500 or validation error|Critical|`[REGRESSION]` `[VALIDATION]`           |
|TC-068|Missing Bookingdates   |Without bookingdates object           |Status 500 or validation error|Critical|`[REGRESSION]` `[VALIDATION]`           |
|TC-069|Missing Checkin        |bookingdates without checkin          |Status 500 or validation error|High    |`[REGRESSION]` `[VALIDATION]`           |
|TC-070|Missing Checkout       |bookingdates without checkout         |Status 500 or validation error|High    |`[REGRESSION]` `[VALIDATION]`           |
|TC-071|Invalid Date Format    |checkin: '15/01/2024'                 |Status 500 or validation error|High    |`[VALIDATION]`                          |
|TC-072|Checkout Before Checkin|checkout < checkin date               |Validation error or warning   |High    |`[VALIDATION]` `[BOUNDARY]`             |
|TC-073|Negative Price         |totalprice: -100                      |Validation error              |High    |`[VALIDATION]` `[BOUNDARY]`             |
|TC-074|String as Price        |totalprice: 'abc'                     |Status 500 or validation error|High    |`[VALIDATION]`                          |
|TC-075|Empty Request Body     |POST with empty JSON {}               |Status 500 or validation error|High    |`[REGRESSION]` `[VALIDATION]`           |
|TC-076|Malformed JSON         |Invalid JSON syntax                   |Status 400 Bad Request        |Medium  |`[VALIDATION]`                          |
|TC-077|XSS in Name            |firstname: `<script>alert(1)</script>`|Script escaped/stripped       |High    |`[SECURITY]`                            |
|TC-078|SQL in Fields          |SQL injection in name fields          |Input sanitized               |Critical|`[SECURITY]`                            |
|TC-079|Very Large Payload     |JSON payload > 1MB                    |413 or handled gracefully     |Medium  |`[BOUNDARY]` `[PERFORMANCE]`            |

### 6.3 Data Type Validation

|ID    |Test Name         |Description             |Expected Result            |Priority|Tags                       |
|------|------------------|------------------------|---------------------------|--------|---------------------------|
|TC-080|Empty Firstname   |firstname: ''           |Validation error or default|High    |`[VALIDATION]`             |
|TC-081|Max Length Name   |255+ character firstname|Accepted or truncated      |Medium  |`[VALIDATION]` `[BOUNDARY]`|
|TC-082|Unicode Names     |Names with émojis, 中文   |Correctly stored/retrieved |Medium  |`[VALIDATION]`             |
|TC-083|Whitespace Name   |firstname: '   '        |Validation error or trimmed|Medium  |`[VALIDATION]`             |
|TC-084|Null Firstname    |firstname: null         |Validation error           |High    |`[VALIDATION]`             |
|TC-085|Zero Price        |totalprice: 0           |Accepted (valid)           |Medium  |`[VALIDATION]` `[BOUNDARY]`|
|TC-086|Decimal Price     |totalprice: 99.99       |Accepted or rounded        |Medium  |`[VALIDATION]`             |
|TC-087|Very Large Price  |totalprice: 999999999   |Accepted or max limit      |Low     |`[BOUNDARY]`               |
|TC-088|String Boolean    |depositpaid: 'true'     |Converted or error         |Medium  |`[VALIDATION]`             |
|TC-089|Number Boolean    |depositpaid: 1          |Converted or error         |Medium  |`[VALIDATION]`             |
|TC-090|Invalid Date Value|checkin: '2024-02-30'   |Validation error           |Medium  |`[VALIDATION]`             |
|TC-091|Past Dates        |checkin: '2020-01-01'   |Accepted (historical)      |Low     |`[VALIDATION]` `[BOUNDARY]`|
|TC-092|Leap Year Date    |checkin: '2024-02-29'   |Date accepted              |Low     |`[BOUNDARY]`               |

-----

## 7. Booking - UpdateBooking

**Endpoint:** `PUT /booking/:id`
**Purpose:** Updates a current booking. Requires Cookie or Basic Auth.

### 7.1 Positive Test Cases

|ID    |Test Name             |Description                   |Expected Result            |Priority|Tags                               |
|------|----------------------|------------------------------|---------------------------|--------|-----------------------------------|
|TC-093|Update with Cookie    |PUT with Cookie: token={token}|Status 200, booking updated|Critical|`[SMOKE]` `[SANITY]` `[REGRESSION]`|
|TC-094|Update with Basic Auth|PUT with Authorization: Basic |Status 200, booking updated|Critical|`[SANITY]` `[REGRESSION]`          |
|TC-095|Update Firstname      |Change firstname field        |Firstname updated          |High    |`[REGRESSION]`                     |
|TC-096|Update Lastname       |Change lastname field         |Lastname updated           |High    |`[REGRESSION]`                     |
|TC-097|Update Totalprice     |Change totalprice             |Price updated              |High    |`[REGRESSION]`                     |
|TC-098|Update Depositpaid    |Toggle depositpaid value      |Value toggled              |Medium  |`[REGRESSION]`                     |
|TC-099|Update Dates          |Change checkin/checkout       |Dates updated              |High    |`[REGRESSION]`                     |
|TC-100|Update Additional     |Modify additionalneeds        |Field updated              |Medium  |`[REGRESSION]`                     |
|TC-101|Verify Update Persists|PUT then GET to verify        |Changes persisted          |Critical|`[SANITY]` `[E2E]`                 |
|TC-102|Update Response Time  |Measure PUT response time     |Response < 800ms (p95)     |High    |`[PERFORMANCE]`                    |

### 7.2 Negative Test Cases

|ID    |Test Name              |Description               |Expected Result               |Priority|Tags                                  |
|------|-----------------------|--------------------------|------------------------------|--------|--------------------------------------|
|TC-103|No Authentication      |PUT without auth header   |Status 403 Forbidden          |Critical|`[SANITY]` `[REGRESSION]` `[SECURITY]`|
|TC-104|Invalid Token          |PUT with invalid token    |Status 403 Forbidden          |Critical|`[SANITY]` `[REGRESSION]` `[SECURITY]`|
|TC-105|Invalid Basic Auth     |PUT with wrong credentials|Status 403 Forbidden          |Critical|`[REGRESSION]` `[SECURITY]`           |
|TC-106|Expired Token          |PUT with expired token    |Status 403 Forbidden          |High    |`[SECURITY]`                          |
|TC-107|Non-existent Booking   |PUT /booking/9999999      |Status 405 Method Not Allowed |Critical|`[SANITY]` `[REGRESSION]`             |
|TC-108|Missing Required Fields|PUT without all fields    |Status 400 or 500             |High    |`[REGRESSION]` `[VALIDATION]`         |
|TC-109|Invalid ID Format      |PUT /booking/abc          |Status 405 or error           |Medium  |`[BOUNDARY]` `[VALIDATION]`           |
|TC-110|Empty Body with Auth   |PUT with empty body       |Status 400 or 500             |Medium  |`[VALIDATION]`                        |
|TC-111|Token Tampering        |Modify token value        |Status 403 Forbidden          |Critical|`[SECURITY]`                          |
|TC-112|Concurrent Updates     |20 simultaneous on same ID|Last write wins, no corruption|Medium  |`[PERFORMANCE]` `[BOUNDARY]`          |

-----

## 8. Booking - PartialUpdateBooking

**Endpoint:** `PATCH /booking/:id`
**Purpose:** Updates booking with partial payload. Requires authentication.

### 8.1 Positive Test Cases

|ID    |Test Name             |Description               |Expected Result       |Priority|Tags                               |
|------|----------------------|--------------------------|----------------------|--------|-----------------------------------|
|TC-113|Patch Firstname Only  |PATCH {firstname: 'New'}  |Only firstname updated|Critical|`[SMOKE]` `[SANITY]` `[REGRESSION]`|
|TC-114|Patch Lastname Only   |PATCH {lastname: 'New'}   |Only lastname updated |High    |`[REGRESSION]`                     |
|TC-115|Patch Totalprice      |PATCH {totalprice: 500}   |Only price updated    |High    |`[REGRESSION]`                     |
|TC-116|Patch Depositpaid     |PATCH {depositpaid: true} |Only deposit toggled  |Medium  |`[REGRESSION]`                     |
|TC-117|Patch Multiple Fields |PATCH firstname + lastname|Both fields updated   |High    |`[REGRESSION]`                     |
|TC-118|Patch with Cookie     |PATCH using Cookie auth   |Update successful     |Critical|`[SANITY]` `[REGRESSION]`          |
|TC-119|Patch with Basic Auth |PATCH using Basic Auth    |Update successful     |High    |`[REGRESSION]`                     |
|TC-120|Other Fields Unchanged|Verify unpatched fields   |Other fields intact   |Critical|`[SANITY]` `[E2E]`                 |

### 8.2 Negative Test Cases

|ID    |Test Name           |Description             |Expected Result     |Priority|Tags                                  |
|------|--------------------|------------------------|--------------------|--------|--------------------------------------|
|TC-121|No Authentication   |PATCH without auth      |Status 403 Forbidden|Critical|`[SANITY]` `[REGRESSION]` `[SECURITY]`|
|TC-122|Invalid Token       |PATCH with invalid token|Status 403 Forbidden|Critical|`[REGRESSION]` `[SECURITY]`           |
|TC-123|Non-existent Booking|PATCH /booking/9999999  |Status 405          |Critical|`[REGRESSION]`                        |
|TC-124|Empty Patch Body    |PATCH with empty {}     |No changes or error |Medium  |`[VALIDATION]` `[BOUNDARY]`           |
|TC-125|Invalid Field Type  |totalprice as string    |Error or handled    |Medium  |`[VALIDATION]`                        |

-----

## 9. Booking - DeleteBooking

**Endpoint:** `DELETE /booking/:id`
**Purpose:** Deletes a booking. Requires Cookie or Basic Auth.

### 9.1 Positive Test Cases

|ID    |Test Name             |Description                   |Expected Result       |Priority|Tags                               |
|------|----------------------|------------------------------|----------------------|--------|-----------------------------------|
|TC-126|Delete with Cookie    |DELETE with valid token       |Status 201 Created    |Critical|`[SMOKE]` `[SANITY]` `[REGRESSION]`|
|TC-127|Delete with Basic Auth|DELETE with Basic Auth        |Status 201 Created    |Critical|`[SANITY]` `[REGRESSION]`          |
|TC-128|Verify Deletion       |GET deleted booking ID        |Status 404 Not Found  |Critical|`[SANITY]` `[REGRESSION]` `[E2E]`  |
|TC-129|Delete Newly Created  |Create then delete immediately|Booking removed       |High    |`[E2E]`                            |
|TC-130|Delete Response Time  |Measure DELETE response       |Response < 500ms (p95)|Medium  |`[PERFORMANCE]`                    |

### 9.2 Negative Test Cases

|ID    |Test Name           |Description                 |Expected Result       |Priority|Tags                                  |
|------|--------------------|----------------------------|----------------------|--------|--------------------------------------|
|TC-131|No Authentication   |DELETE without auth         |Status 403 Forbidden  |Critical|`[SANITY]` `[REGRESSION]` `[SECURITY]`|
|TC-132|Invalid Token       |DELETE with invalid token   |Status 403 Forbidden  |Critical|`[REGRESSION]` `[SECURITY]`           |
|TC-133|Invalid Basic Auth  |DELETE with wrong creds     |Status 403 Forbidden  |High    |`[REGRESSION]` `[SECURITY]`           |
|TC-134|Non-existent Booking|DELETE /booking/9999999     |Status 405            |Critical|`[REGRESSION]`                        |
|TC-135|Already Deleted     |DELETE same ID twice        |Second request: 405   |High    |`[REGRESSION]` `[BOUNDARY]`           |
|TC-136|Invalid ID Format   |DELETE /booking/abc         |Status 405 or error   |Medium  |`[BOUNDARY]`                          |
|TC-137|Negative ID         |DELETE /booking/-1          |Status 405            |Low     |`[BOUNDARY]`                          |
|TC-138|Delete During Update|DELETE while PUT in progress|Consistent final state|Low     |`[BOUNDARY]` `[PERFORMANCE]`          |

-----

## 10. End-to-End Workflow Tests

Complete user journey tests that span multiple endpoints.

|ID    |Test Name        |Description                   |Expected Result                |Priority|Tags                   |
|------|-----------------|------------------------------|-------------------------------|--------|-----------------------|
|TC-139|Full CRUD Flow   |Create→Read→Update→Delete     |All operations succeed         |Critical|`[E2E]` `[REGRESSION]` |
|TC-140|Auth Then Update |Get token, use for PUT        |Token authorizes update        |Critical|`[E2E]` `[REGRESSION]` |
|TC-141|Auth Then Delete |Get token, use for DELETE     |Token authorizes delete        |Critical|`[E2E]` `[REGRESSION]` |
|TC-142|Create and Filter|Create, filter by firstname   |New booking in filtered results|High    |`[E2E]` `[REGRESSION]` |
|TC-143|Bulk Operations  |Create 10 bookings, verify all|All bookings retrievable       |High    |`[E2E]` `[PERFORMANCE]`|
|TC-144|Token Reuse      |Same token for multiple ops   |Token valid for all requests   |High    |`[E2E]` `[REGRESSION]` |
|TC-145|Booking Lifecycle|Complete booking simulation   |Mimics real user workflow      |High    |`[E2E]`                |
|TC-146|Data Consistency |Verify data across endpoints  |Same data everywhere           |High    |`[E2E]` `[REGRESSION]` |
|TC-147|API Reset Check  |Verify 10-min reset behavior  |Pre-loaded data restored       |Low     |`[E2E]` `[BOUNDARY]`   |
|TC-148|Error Recovery   |Continue after error          |System recovers gracefully     |Medium  |`[E2E]` `[BOUNDARY]`   |

-----

## 11. Additional Security Tests

Security-specific tests not covered in endpoint sections.

|ID    |Test Name              |Description                   |Expected Result             |Priority|Tags        |
|------|-----------------------|------------------------------|----------------------------|--------|------------|
|TC-149|Sensitive Data Exposure|Check responses for secrets   |No passwords/tokens exposed |Critical|`[SECURITY]`|
|TC-150|Error Message Leak     |Trigger errors, check messages|No stack traces leaked      |High    |`[SECURITY]`|
|TC-151|HTTP Methods Check     |Test unsupported methods      |405 Method Not Allowed      |Medium  |`[SECURITY]`|
|TC-152|CORS Policy            |Cross-origin requests         |Proper CORS headers         |Medium  |`[SECURITY]`|
|TC-153|Security Headers       |Check security headers        |X-Frame-Options, CSP present|Medium  |`[SECURITY]`|
|TC-154|HTTPS Enforcement      |Attempt HTTP connection       |Redirect to HTTPS or refused|High    |`[SECURITY]`|
|TC-155|Command Injection      |OS commands in fields         |Commands not executed       |Critical|`[SECURITY]`|

-----

## 12. Additional Performance Tests

Load and stress tests not covered in endpoint sections.

|ID    |Test Name          |Description                 |Expected Result     |Priority|Tags                        |
|------|-------------------|----------------------------|--------------------|--------|----------------------------|
|TC-156|Normal Load Test   |10 VUs, 5 min, all endpoints|< 1% error rate     |High    |`[PERFORMANCE]`             |
|TC-157|Peak Load Test     |50 VUs, 10 min              |< 2% error rate     |High    |`[PERFORMANCE]`             |
|TC-158|Stress Test        |100 VUs, 5 min              |Graceful degradation|Medium  |`[PERFORMANCE]`             |
|TC-159|Spike Test         |0→100 VUs spike             |Recovery < 30s      |Medium  |`[PERFORMANCE]`             |
|TC-160|Soak Test          |20 VUs, 1 hour              |No memory leaks     |Low     |`[PERFORMANCE]`             |
|TC-161|Rate Limiting Check|100 auth req/min            |429 if rate limited |Low     |`[PERFORMANCE]` `[SECURITY]`|

-----

## 13. HIGH PRIORITY ADDITIONS - December 2025

### 13.1 Content-Type & Accept Header Validation

|ID    |Test Name                    |Description                              |Expected Result               |Priority|Tags                       |
|-------|-----------------------------|-----------------------------------------|------------------------------|--------|---------------------------|
|TC-162|Missing Content-Type POST    |POST /booking without Content-Type header|400 Bad Request or handled    |High    |`[VALIDATION]` `[BOUNDARY]`|
|TC-163|Update Without Content-Type  |PUT without Content-Type header          |400 or handled                |High    |`[VALIDATION]`             |

### 13.2 GetBookingIds - Advanced Filtering

|ID    |Test Name                    |Description                              |Expected Result               |Priority|Tags                       |
|-------|-----------------------------|-----------------------------------------|------------------------------|--------|---------------------------|
|TC-164|Date Range Both Parameters   |checkin=2024-01-01&checkout=2024-01-31   |Returns bookings in range     |High    |`[REGRESSION]`             |

### 13.3 Create Booking - Edge Cases

|ID    |Test Name                    |Description                              |Expected Result               |Priority|Tags                       |
|-------|-----------------------------|-----------------------------------------|------------------------------|--------|---------------------------|
|TC-165|Same Day Checkin/Checkout    |checkin = checkout date                  |Accepted or validation error  |High    |`[BOUNDARY]` `[VALIDATION]`|

### 13.4 Update Booking - Additional Cases

|ID    |Test Name                    |Description                              |Expected Result               |Priority|Tags                       |
|-------|-----------------------------|-----------------------------------------|------------------------------|--------|---------------------------|
|TC-166|Mixed Valid/Invalid Fields   |PUT with some valid, some invalid fields |Full rejection or partial update|High  |`[VALIDATION]`            |

### 13.5 Partial Update - Nested & Null Cases

|ID    |Test Name                    |Description                              |Expected Result               |Priority|Tags                       |
|-------|-----------------------------|-----------------------------------------|------------------------------|--------|---------------------------|
|TC-167|Patch Bookingdates Object    |PATCH {"bookingdates": {"checkin": "..."}}|Only checkin updated         |High    |`[REGRESSION]`             |
|TC-168|Patch Checkin Only           |PATCH only checkin within bookingdates   |Only checkin updated          |High    |`[REGRESSION]`             |

### 13.6 Cross-Endpoint Data Consistency

|ID    |Test Name                    |Description                              |Expected Result               |Priority|Tags                       |
|-------|-----------------------------|-----------------------------------------|------------------------------|--------|---------------------------|
|TC-169|Immediate List Visibility    |Create booking, immediately check list   |Appears in GetBookingIds      |High    |`[E2E]` `[REGRESSION]`     |
|TC-170|Update Preserves Filters     |Update firstname, verify filter still works|Updated name filterable     |High    |`[E2E]` `[REGRESSION]`     |
|TC-171|Delete Removes from Filters  |Delete, verify not in filtered results   |Not returned by any filter    |High    |`[E2E]` `[REGRESSION]`     |

### 13.7 Security Tests

|ID    |Test Name              |Description                   |Expected Result             |Priority|Tags        |
|------|-----------------------|------------------------------|----------------------------|--------|------------|
|TC-172|Null Byte Injection    |firstname with \0 null byte   |Sanitized or rejected       |High    |`[SECURITY]`|

-----

## 14. Test Summary & Statistics

### 14.1 Total Test Count by Tag

|Tag            |Count|Estimated Duration|Automation Priority                        |
|---------------|-----|------------------|-------------------------------------------|
|`[SMOKE]`      |8    |< 2 minutes       |Must Automate - Run on every commit        |
|`[SANITY]`     |28   |5-10 minutes      |Must Automate - Run on daily builds        |
|`[REGRESSION]` |80   |35-50 minutes     |Must Automate - Run before releases        |
|`[SECURITY]`   |25   |20-30 minutes     |Should Automate - Run periodically         |
|`[PERFORMANCE]`|18   |30-60 minutes     |Should Automate - Run before major releases|
|`[E2E]`        |21   |15-25 minutes     |Must Automate - Run before releases        |
|`[VALIDATION]` |43   |20-25 minutes     |Must Automate - Run during sprints         |
|`[BOUNDARY]`   |24   |10-15 minutes     |Should Automate - Comprehensive testing    |

### 14.2 Test Count by Priority

|Priority|Count|Description                                   |
|--------|-----|----------------------------------------------|
|Critical|38   |Core functionality - must pass for any release|
|High    |73   |Important features - should pass for release  |
|Medium  |42   |Secondary features - investigate failures     |
|Low     |19   |Edge cases - nice-to-have coverage            |

### 14.3 Quick Execution Reference

|Scenario          |Filter Command (Example)                                  |
|------------------|----------------------------------------------------------|
|Every Commit      |`--tags @SMOKE`                                           |
|Daily Build       |`--tags "@SMOKE or @SANITY"`                              |
|Sprint Testing    |`--tags "@SMOKE or @SANITY or @REGRESSION or @VALIDATION"`|
|Pre-Release       |`--tags "@SMOKE or @SANITY or @REGRESSION or @E2E"`       |
|Full Release      |Run all tests (no filter)                                 |
|Security Audit    |`--tags @SECURITY`                                        |
|Performance Review|`--tags @PERFORMANCE`                                     |
|Critical Only     |`--priority Critical`                                     |

### 14.4 Overall Statistics

|Metric                    |Value                                                                                                       |
|--------------------------|------------------------------------------------------------------------------------------------------------|
|**Total Test Cases**      |**172** (was 161, added 11 high-priority tests)                                                            |
|Endpoints Covered         |8 (Ping, Auth, GetBookingIds, GetBooking, CreateBooking, UpdateBooking, PartialUpdateBooking, DeleteBooking)|
|Full Execution Time (Est.)|~2-3 hours                                                                                                  |
|Smoke Only Time           |< 2 minutes                                                                                                 |
|Sanity + Smoke Time       |~10 minutes                                                                                                 |
|Regression Suite Time     |~50 minutes                                                                                                 |

### 14.5 Changes in Version 3.1

**Summary:** Added 11 high-priority test cases identified through gap analysis:

1. **Content-Type Validation** (2 tests)
   - Missing Content-Type on POST/PUT operations

2. **Advanced Filtering** (1 test)
   - Date range filtering with both checkin and checkout parameters

3. **Edge Cases** (1 test)
   - Same-day checkin/checkout validation

4. **Update Validation** (1 test)
   - Mixed valid/invalid field handling in PUT requests

5. **Partial Update Enhancement** (2 tests)
   - Nested bookingdates object updates
   - Individual date field updates within bookingdates

6. **Cross-Endpoint Consistency** (3 tests)
   - Immediate visibility after creation
   - Filter consistency after updates
   - Filter removal after deletion

7. **Security Enhancement** (1 test)
   - Null byte injection protection

**Impact:** These additions strengthen validation coverage, cross-endpoint consistency testing, and security posture.

-----

## Appendix A: Sample Request/Response Bodies

### A.1 Auth Request

```json
{
    "username": "admin",
    "password": "password123"
}
```

### A.2 Auth Response (Success)

```json
{
    "token": "abc123xyz789"
}
```

### A.3 Booking Request Body

```json
{
    "firstname": "John",
    "lastname": "Doe",
    "totalprice": 150,
    "depositpaid": true,
    "bookingdates": {
        "checkin": "2024-01-15",
        "checkout": "2024-01-20"
    },
    "additionalneeds": "Breakfast"
}
```

### A.4 Booking Response

```json
{
    "bookingid": 1,
    "booking": {
        "firstname": "John",
        "lastname": "Doe",
        "totalprice": 150,
        "depositpaid": true,
        "bookingdates": {
            "checkin": "2024-01-15",
            "checkout": "2024-01-20"
        },
        "additionalneeds": "Breakfast"
    }
}
```

### A.5 GetBookingIds Response

```json
[
    {"bookingid": 1},
    {"bookingid": 2},
    {"bookingid": 3}
]
```

### A.6 Partial Update (PATCH) Request - Nested Object

```json
{
    "bookingdates": {
        "checkin": "2024-02-01"
    }
}
```

### A.7 Partial Update (PATCH) Request - Individual Field

```json
{
    "firstname": "Jane"
}
```

-----

## Appendix B: Authentication Headers

### B.1 Cookie Authentication

```
Cookie: token=abc123xyz789
```

### B.2 Basic Authentication

```
Authorization: Basic YWRtaW46cGFzc3dvcmQxMjM=
```

(Base64 encoded `admin:password123`)

-----

## Appendix C: Test Case Implementation Priority

For teams implementing these test cases, use this recommended order:

### Phase 1: Foundation (Weeks 1-2)
- All `[SMOKE]` tests (8 tests)
- Critical priority tests (38 tests)

### Phase 2: Core Coverage (Weeks 3-4)
- All `[SANITY]` tests (28 tests)
- High priority tests (73 tests)

### Phase 3: Comprehensive Coverage (Weeks 5-6)
- All `[REGRESSION]` tests (80 tests)
- All `[E2E]` tests (21 tests)

### Phase 4: Specialized Testing (Weeks 7-8)
- All `[SECURITY]` tests (25 tests)
- All `[VALIDATION]` tests (43 tests)
- All `[BOUNDARY]` tests (24 tests)

### Phase 5: Performance & Optimization (Weeks 9-10)
- All `[PERFORMANCE]` tests (18 tests)
- Medium and Low priority tests

-----

*— End of Document —*

# CLAUDE.md - RestfulBooker Test Framework

> **Documentation for AI Assistants**
> This file provides comprehensive guidance for AI assistants working with this codebase.
> Last updated: 2025-11-18

---

## Table of Contents

1. [Project Overview](#project-overview)
2. [Repository Structure](#repository-structure)
3. [Technology Stack](#technology-stack)
4. [Architecture & Design Patterns](#architecture--design-patterns)
5. [Development Workflows](#development-workflows)
6. [Coding Conventions](#coding-conventions)
7. [Working with Tests](#working-with-tests)
8. [Configuration Management](#configuration-management)
9. [Common Tasks](#common-tasks)
10. [Important File Locations](#important-file-locations)
11. [Testing Guidelines](#testing-guidelines)
12. [Git Workflow](#git-workflow)
13. [Troubleshooting](#troubleshooting)

---

## Project Overview

**RestfulBooker Test Framework** is a comprehensive, multi-layered test automation framework for the RestfulBooker API (https://restful-booker.herokuapp.com). It demonstrates enterprise-level test architecture with support for:

- **API Integration Testing** - Functional testing of REST endpoints
- **Contract Testing** - JSON schema validation
- **Performance Testing** - Load testing with NBomber

### Key Characteristics

- **Language**: C# (.NET 8.0)
- **Test Framework**: Reqnroll (BDD) + NUnit
- **Architecture**: Multi-project solution with clear separation of concerns
- **Design Philosophy**: Interface-driven, dependency injection-based, highly modular
- **Target API**: RestfulBooker - A hotel booking API for testing purposes

### Projects in Solution

```
RestfulBookerTestFramework.sln
├── RestfulBookerTestFramework.Tests.Commons      # Shared library
├── RestfulBookerTestFramework.Tests.Api          # API functional tests
├── RestfulBookerTestFramework.Tests.Contracts    # Schema validation tests
└── RestfulBookerTestFramework.Tests.Performance  # Performance/load tests
```

---

## Repository Structure

```
RestfulBookerTestFramework/
├── .git/                           # Git repository
├── .idea/                          # JetBrains Rider configuration
├── .sonarqube/                     # SonarQube analysis files
├── .vscode/                        # VS Code configuration
├── tests/
│   ├── RestfulBookerTestFramework.Tests.Commons/
│   │   ├── Configuration/          # AppSettings, Urls, Credentials
│   │   ├── Constants/              # Endpoints, Context, ErrorMessages, etc.
│   │   ├── Drivers/                # API abstraction layer (Booking, Auth, Request, Validation)
│   │   ├── DTOs/Models/            # Data models (Booking, BookingDates, BookingIdentifier)
│   │   ├── Extensions/             # Extension methods (ScenarioContext, RestRequest, etc.)
│   │   ├── Factories/              # Test data generators using Bogus
│   │   ├── Helpers/                # Business logic helpers (Booking, Endpoints, Auth, Schema, Date)
│   │   ├── JsonNamingPolicy/       # Custom JSON serialization policies
│   │   ├── Payloads/               # Request/Response DTOs
│   │   │   ├── Requests/           # Request payloads
│   │   │   │   ├── Partial/        # Incomplete requests for negative testing
│   │   │   │   │   ├── SingleProperty/      # Requests with only one property
│   │   │   │   │   └── MultipleProperties/  # Requests missing one property
│   │   │   └── Responses/          # Response payloads
│   │   └── Regex/                  # Regular expression patterns
│   │
│   ├── RestfulBookerTestFramework.Tests.Api/
│   │   ├── Configuration/          # Test base setup
│   │   ├── Features/               # Gherkin feature files
│   │   │   ├── HappyPaths/         # Positive scenarios (7 features)
│   │   │   └── UnhappyPaths/       # Negative scenarios (7 features)
│   │   ├── Hooks/                  # Before/After scenario hooks
│   │   ├── StepDefinitions/        # Step implementations
│   │   ├── Support/                # Dependency injection setup
│   │   └── appsettings.json        # Configuration file
│   │
│   ├── RestfulBookerTestFramework.Tests.Contracts/
│   │   ├── Constants/              # Schema-specific constants
│   │   ├── Drivers/                # SchemaValidationDriver
│   │   ├── Features/               # Schema validation scenarios (6 features)
│   │   ├── Schemas/                # JSON schema files (.json)
│   │   ├── StepDefinitions/        # Schema validation steps
│   │   ├── Support/                # DI setup
│   │   └── appsettings.json        # Configuration file
│   │
│   └── RestfulBookerTestFramework.Tests.Performance/
│       ├── Extensions/             # Performance-specific extensions
│       ├── Features/               # Performance test scenarios (14 features)
│       │   ├── InjectFeatures/              # Constant rate injection (5 features)
│       │   ├── InjectRandomFeatures/        # Random interval injection (5 features)
│       │   └── RampingInjectFeatures/       # Ramping injection (4 features)
│       ├── Helpers/                # PerformanceHelper
│       ├── Hooks/                  # Performance test hooks
│       ├── StepDefinitions/        # Performance step definitions
│       ├── Support/                # DI setup
│       └── appsettings.json        # Configuration file
│
├── Directory.Packages.props        # Centralized NuGet package versions
├── RestfulBookerTestFramework.sln  # Solution file
├── .gitignore                      # Git ignore rules
├── LICENSE                         # MIT License
└── README.md                       # Project README
```

### File Count Summary

- **Total C# files**: 143 across all projects
- **Feature files**: 34 total (14 API + 6 Contract + 14 Performance)
- **JSON schema files**: Located in `Tests.Contracts/Schemas/`

---

## Technology Stack

### Core Framework

| Technology | Version | Purpose |
|------------|---------|---------|
| .NET | 8.0 | Runtime framework |
| C# | 12 | Programming language with modern features (primary constructors, pattern matching) |
| Reqnroll | 2.2.1 | BDD framework (SpecFlow successor) |
| NUnit | 4.2.2 | Test runner and assertions |
| Autofac | 8.1.1 | Dependency injection container |

### API Testing Libraries

| Library | Version | Purpose |
|---------|---------|---------|
| RestSharp | 112.1.0 | HTTP client for API calls (used in API & Contract tests) |
| FluentAssertions | 6.12.1 | Fluent assertion library |
| Bogus | 35.6.1 | Fake data generation |
| System.Text.Json | 9.0.0 | JSON serialization |
| Newtonsoft.Json.Schema | 4.0.1 | JSON schema validation |

### Performance Testing

| Library | Version | Purpose |
|---------|---------|---------|
| NBomber | 5.8.2 | Load testing framework |
| NBomber.Http | 5.2.0/5.2.1 | HTTP protocol support for NBomber |
| NBomber.Contracts | 5.6.0 | NBomber contracts/interfaces |

### Configuration & Extensions

| Library | Version | Purpose |
|---------|---------|---------|
| Microsoft.Extensions.Configuration | 8.0.0 | Configuration system |
| Microsoft.Extensions.Configuration.Json | 8.0.1 | JSON configuration provider |
| Microsoft.Extensions.Configuration.UserSecrets | 8.0.1 | Secure credential storage |
| Microsoft.Extensions.Options | 8.0.2 | Options pattern support |

### Test Infrastructure

| Library | Version | Purpose |
|---------|---------|---------|
| Microsoft.NET.Test.Sdk | 17.11.1 | Test SDK |
| NUnit3TestAdapter | 4.6.0 | Visual Studio test adapter |
| NUnit.Analyzers | 4.6.0 | Code quality analyzers |
| coverlet.collector | 6.0.0 | Code coverage collection |
| Reqnroll.Autofac | 2.2.1 | Autofac integration for Reqnroll |
| Reqnroll.NUnit | 2.2.1 | NUnit integration for Reqnroll |

### Package Management

- **Central Package Management**: Enabled via `Directory.Packages.props`
- All package versions defined centrally, not in individual `.csproj` files
- Projects reference packages without version numbers

---

## Architecture & Design Patterns

### 1. Driver Pattern

All API interactions are abstracted through Driver classes with interfaces:

**Location**: `/tests/RestfulBookerTestFramework.Tests.Commons/Drivers/`

```
Drivers/
├── AuthToken/
│   └── IAuthTokenDriver.cs, AuthTokenDriver.cs
├── Booking/
│   ├── ICreateBookingDriver.cs, CreateBookingDriver.cs
│   ├── IDeleteBookingDriver.cs, DeleteBookingDriver.cs
│   ├── IGetBookingDriver.cs, GetBookingDriver.cs
│   ├── IGetBookingsIdsDriver.cs, GetBookingsIdsDriver.cs
│   ├── IPatchUpdateBookingDriver.cs, PatchUpdateBookingDriver.cs
│   └── IPutUpdateBookingDriver.cs, PutUpdateBookingDriver.cs
├── HealthCheck/
│   └── IHealthCheckDriver.cs, HealthCheckDriver.cs
├── Request/
│   └── IRequestDriver.cs, RequestDriver.cs
└── Validation/
    └── IValidationDriver.cs, ValidationDriver.cs
```

**Purpose**:
- Encapsulates HTTP request/response logic
- Provides clean interface for step definitions
- Uses RestSharp for API calls (or NBomber for performance tests)

**Example**:
```csharp
public interface ICreateBookingDriver
{
    Task<RestResponse<BookingResponse>> CreateBookingWithFullBody(Booking booking);
    Task<RestResponse<Booking>> CreateBookingWithPartialBody<T>(T partialBooking);
}
```

### 2. Factory Pattern

Test data generation using Bogus library:

**Location**: `/tests/RestfulBookerTestFramework.Tests.Commons/Factories/`

```
Factories/
├── BookingFactory.cs
├── BookingDatesFactory.cs
├── PartiallyBookingFactory.cs
└── PartiallyBookingDatesFactory.cs
```

**Purpose**:
- Generates realistic fake data for tests
- Ensures consistent data creation
- Supports both complete and partial models

**Example**:
```csharp
public static Booking GetBooking()
{
    return new Faker<Booking>()
        .RuleFor(b => b.FirstName, f => f.Name.FirstName())
        .RuleFor(b => b.LastName, f => f.Name.LastName())
        .RuleFor(b => b.TotalPrice, f => f.Random.Int(100, 1000))
        .RuleFor(b => b.DepositPaid, f => f.Random.Bool())
        .RuleFor(b => b.BookingDates, BookingDatesFactory.GetBookingDates())
        .RuleFor(b => b.AdditionalNeeds, f => f.Lorem.Sentence())
        .Generate();
}
```

### 3. Helper Pattern

Business logic and utility functions:

**Location**: `/tests/RestfulBookerTestFramework.Tests.Commons/Helpers/`

**Key Helpers**:
- **EndpointsHelper**: Builds full URLs, extracts booking IDs from URIs
- **BookingHelper**: Creates multiple bookings, cleanup operations
- **AuthTokenDriverHelper / AuthTokenRequestHelper**: Authentication management
- **DateHelper**: Date formatting and manipulation
- **Schema Helpers**: JSON schema validation (JsonSchemaHelper, ObjectSchemaHelper, ArraySchemaHelper)
- **PerformanceHelper**: Creates HttpRequestMessage for NBomber scenarios

### 4. Extension Methods Pattern

Heavy use of extension methods for clean, fluent code:

**Location**: `/tests/RestfulBookerTestFramework.Tests.Commons/Extensions/`

**Key Extensions**:
- **SetScenarioContextExtensions**: Store data in ScenarioContext
- **GetScenarioContextExtensions**: Retrieve data from ScenarioContext
- **RestRequestExtensions**: Configure RestSharp requests
- **RestResponseExtensions**: Process RestSharp responses
- **HttpRequestMessageExtension**: Create NBomber HTTP requests
- **ResponseHttpResponseMessageExtension**: Process NBomber responses
- **BookingExtensions**: Booking-specific operations
- **DateOnlyExtensions**: Date formatting
- **StringExtensions**: String manipulation (e.g., `AddRequestPostFix()`)
- **DependencyExtensions**: DI registration helpers
- **ListExtensions**: List operations for performance tests

**Example**:
```csharp
public static class SetScenarioContextExtensions
{
    public static void SetBookingResponse(this ScenarioContext scenarioContext, BookingResponse? bookingResponse)
        => scenarioContext.Set(bookingResponse, Context.BookingResponse);
}
```

### 5. Dependency Injection Architecture

**Global Container** (Singleton scope):
- Configuration (AppSettings)
- IConfiguration
- Shared services

**Scenario Container** (Per-scenario scope):
- ScenarioContext
- Step definition classes
- Driver instances
- Helpers

**Setup Files**:
- `/tests/RestfulBookerTestFramework.Tests.Api/Support/SetupTestDependencies.cs`
- `/tests/RestfulBookerTestFramework.Tests.Contracts/Support/SetupTestDependencies.cs`
- `/tests/RestfulBookerTestFramework.Tests.Performance/Support/SetupTestDependencies.cs`

**Pattern**:
```csharp
[GlobalDependencies]
public static void SetupGlobalContainer(ContainerBuilder containerBuilder)
{
    containerBuilder.AddCommonDependenciesGlobalContainer();
    // Register global dependencies
}

[ScenarioDependencies]
public static void SetupScenarioContainer(ContainerBuilder containerBuilder)
{
    containerBuilder.AddCommonDependenciesScenarioContainer();
    containerBuilder.AddReqnrollBindings<ScenarioHook>();
    containerBuilder.AddReqnrollBindings<CreateBookingSteps>();
    // Register scenario dependencies
}
```

### 6. Constants Pattern

All magic strings are defined as constants:

**Location**: `/tests/RestfulBookerTestFramework.Tests.Commons/Constants/`

```
Constants/
├── Context.cs                    # ScenarioContext keys
├── DateConstants.cs              # Date format strings
├── Endpoints.cs                  # API endpoints
├── ErrorMessages.cs              # Expected error messages
├── FileNames.cs                  # File name constants
├── Parameters.cs                 # Query parameter names
├── PerformanceScenarioName.cs    # NBomber scenario names
└── RestRequestConstants.cs       # HTTP headers, content types
```

### 7. Hooks Pattern

Tag-driven test lifecycle management:

**Location**: `/tests/RestfulBookerTestFramework.Tests.Api/Hooks/`

**Before Scenario Hooks**:
- `@SetupOneBooking` - Creates 1 booking before test
- `@SetupMultipleBookings` - Creates 5 bookings before test
- `@AuthorizeRequest` - Obtains authentication token before test

**After Scenario Hooks**:
- `@CleanUpBooking` - Deletes created booking after test
- `@CleanUpPerformanceBookings` - Deletes all bookings created in performance tests
- `@SetupMultipleBookings` - Cleanup for multiple bookings

**Example**:
```csharp
[BeforeScenario("@SetupOneBooking", Order = 1)]
public async Task SetupOneBookingBeforeScenario()
{
    var bookingId = await _bookingHelper.CreateBookingForTestScenario();
    _scenarioContext.SetBookingId(bookingId);
}

[AfterScenario("@CleanUpBooking", Order = 1)]
public async Task CleanUpBookingAfterScenario()
{
    var bookingId = _scenarioContext.GetBookingId();
    await _bookingHelper.DeleteBookingAfterScenario(bookingId);
}
```

---

## Development Workflows

### Running Tests

**From Command Line**:
```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test tests/RestfulBookerTestFramework.Tests.Api/
dotnet test tests/RestfulBookerTestFramework.Tests.Contracts/
dotnet test tests/RestfulBookerTestFramework.Tests.Performance/

# Run with filter
dotnet test --filter "Category=HappyPath"
dotnet test --filter "FullyQualifiedName~CreateBooking"
```

**From IDE**:
- Visual Studio: Test Explorer
- Rider: Unit Tests window
- VS Code: .NET Test Explorer extension

### Adding a New API Test

1. **Create Feature File**: `/tests/RestfulBookerTestFramework.Tests.Api/Features/[HappyPaths|UnhappyPaths]/YourFeature.feature`

2. **Add Appropriate Tags**:
   ```gherkin
   @HappyPath @ApiIntegrationTest @BookingFeature @CleanUpBooking
   Feature: Your Feature Name
   ```

3. **Create Step Definitions**: `/tests/RestfulBookerTestFramework.Tests.Api/StepDefinitions/YourSteps.cs`
   ```csharp
   [Binding]
   public sealed class YourSteps(
       ScenarioContext scenarioContext,
       IYourDriver yourDriver)
   {
       [Given(@"given step")]
       public async Task GivenStep() { }
   }
   ```

4. **Create Driver if Needed**: `/tests/RestfulBookerTestFramework.Tests.Commons/Drivers/YourFeature/`

5. **Register in DI**: Update `/tests/RestfulBookerTestFramework.Tests.Api/Support/SetupTestDependencies.cs`
   ```csharp
   containerBuilder.AddReqnrollBindings<YourSteps>();
   ```

### Adding a New Contract Test

1. **Create JSON Schema**: `/tests/RestfulBookerTestFramework.Tests.Contracts/Schemas/your-schema.json`

2. **Create Feature File**: `/tests/RestfulBookerTestFramework.Tests.Contracts/Features/YourSchemaValidation.feature`
   ```gherkin
   @ContractTest @SchemaValidation
   Feature: Your Schema Validation
   ```

3. **Use Existing Schema Validation Steps**: Step definitions already exist in `SchemaValidationSteps.cs`

4. **Configure Schema Copy**: Update `.csproj` if needed:
   ```xml
   <None Update="Schemas/your-schema.json">
     <CopyToOutputDirectory>Always</CopyToOutputDirectory>
   </None>
   ```

### Adding a New Performance Test

1. **Create Feature File**: `/tests/RestfulBookerTestFramework.Tests.Performance/Features/[InjectFeatures|RampingInjectFeatures|InjectRandomFeatures]/YourPerformanceTest.feature`

2. **Add Tags**:
   ```gherkin
   @PerformanceTest @Inject @CleanUpPerformanceBookings
   Feature: Performance Test Your Endpoint
   ```

3. **Use Existing Performance Steps**: Step definitions handle Inject, RampingInject, InjectRandom

4. **Update PerformanceHelper if New Endpoint**: Add endpoint handling in `PerformanceHelper.cs`

### Adding a New Model

1. **Create DTO**: `/tests/RestfulBookerTestFramework.Tests.Commons/DTOs/Models/YourModel.cs`
   ```csharp
   #nullable enable
   public sealed class YourModel
   {
       [JsonPropertyName("propertyName")]
       public string? PropertyName { get; set; }
   }
   ```

2. **Create Factory**: `/tests/RestfulBookerTestFramework.Tests.Commons/Factories/YourModelFactory.cs`
   ```csharp
   public static class YourModelFactory
   {
       public static YourModel GetYourModel()
       {
           return new Faker<YourModel>()
               .RuleFor(m => m.PropertyName, f => f.Lorem.Word())
               .Generate();
       }
   }
   ```

3. **Create Request/Response DTOs**: `/tests/RestfulBookerTestFramework.Tests.Commons/Payloads/[Requests|Responses]/`

### Building the Solution

```bash
# Restore packages
dotnet restore

# Build solution
dotnet build

# Build specific project
dotnet build tests/RestfulBookerTestFramework.Tests.Commons/

# Clean build
dotnet clean && dotnet build
```

---

## Coding Conventions

### C# Language Features

**Enabled Features**:
- **Primary Constructors** (C# 12):
  ```csharp
  public sealed class CreateBookingSteps(
      ScenarioContext scenarioContext,
      ICreateBookingDriver createBookingDriver)
  {
      // Fields automatically generated from constructor parameters
  }
  ```

- **Nullable Reference Types**: Disabled globally (`<Nullable>disable</Nullable>`)
  - Enabled per-file where needed: `#nullable enable`
  - Models typically have nullable enabled

- **Implicit Usings**: Enabled (`<ImplicitUsings>enable</ImplicitUsings>`)

- **Sealed Classes**: Use `sealed` for classes that should not be inherited

- **Expression-Bodied Members**: Preferred for simple methods
  ```csharp
  public string GetFullName() => $"{FirstName} {LastName}";
  ```

### Naming Conventions

**Files**:
- **Drivers**: `*Driver.cs` with `I*Driver.cs` interfaces
- **Steps**: `*Steps.cs` with `[Binding]` attribute
- **Helpers**: `*Helper.cs`
- **Factories**: `*Factory.cs`
- **Extensions**: `*Extensions.cs`
- **Models**: Plain class names (e.g., `Booking.cs`)
- **Requests**: `*Request.cs`
- **Responses**: `*Response.cs`
- **Constants**: Static classes (e.g., `Endpoints.cs`, `Context.cs`)
- **Features**: Descriptive names ending with `.feature`

**Classes and Interfaces**:
- **Interfaces**: Prefix with `I` (e.g., `ICreateBookingDriver`)
- **Classes**: PascalCase (e.g., `CreateBookingDriver`)
- **Static Classes**: PascalCase (e.g., `BookingFactory`, `Endpoints`)

**Methods**:
- **Public**: PascalCase (e.g., `CreateBooking`)
- **Private**: PascalCase (e.g., `BuildRequest`)
- **Step Definitions**: Descriptive names matching regex
- **Async Methods**: Always return `Task` or `Task<T>`

**Properties**:
- PascalCase (e.g., `FirstName`, `BookingId`)
- JSON properties use `[JsonPropertyName("propertyName")]`

**Fields**:
- Private fields: `_camelCase` (when not using primary constructors)
- Constants: `PascalCase` (e.g., `public const string AuthEndpoint = "/auth";`)

**Variables**:
- Local variables: `camelCase`
- Parameters: `camelCase`

### JSON Serialization

**System.Text.Json** (Default):
```csharp
using System.Text.Json.Serialization;

[JsonPropertyName("firstName")]
public string? FirstName { get; set; }
```

**Custom Naming Policy**:
- Location: `/tests/RestfulBookerTestFramework.Tests.Commons/JsonNamingPolicy/LowerCaseNamingPolicy.cs`
- Converts property names to lowercase (e.g., `FirstName` → `firstname`)
- Used in NBomber performance tests

### File Organization

**Within Projects**:
```
ProjectName/
├── Configuration/      # Configuration classes
├── Constants/          # Constant definitions
├── Drivers/            # API drivers
├── DTOs/               # Data Transfer Objects
├── Extensions/         # Extension methods
├── Factories/          # Object factories
├── Features/           # Gherkin feature files
├── Helpers/            # Helper classes
├── Hooks/              # Reqnroll hooks
├── StepDefinitions/    # Step implementations
├── Support/            # DI and test setup
└── appsettings.json    # Configuration file
```

### Code Style

**Preferred Patterns**:
```csharp
// ✅ Good: Primary constructor
public sealed class MyClass(IDependency dependency)
{
    public void Method() => dependency.DoSomething();
}

// ✅ Good: Extension method for ScenarioContext
public static void SetBookingId(this ScenarioContext context, int id)
    => context.Set(id, Context.BookingId);

// ✅ Good: Const string in static class
public static class Endpoints
{
    public const string BookingEndpoint = "/booking";
}

// ✅ Good: Async/await for I/O
public async Task<RestResponse> CreateBooking(Booking booking)
{
    var response = await _client.ExecuteAsync(request);
    return response;
}

// ✅ Good: FluentAssertions
response.StatusCode.Should().Be(HttpStatusCode.OK);
response.Data.Should().NotBeNull();
```

**Anti-Patterns to Avoid**:
```csharp
// ❌ Bad: Magic strings
context.Set(id, "BookingId");  // Use Context.BookingId constant

// ❌ Bad: Hardcoded values
var url = "https://restful-booker.herokuapp.com/booking";  // Use configuration

// ❌ Bad: Synchronous I/O
var response = _client.Execute(request);  // Use ExecuteAsync

// ❌ Bad: No interface
public class MyDriver { }  // Should have IMyDriver interface
```

---

## Working with Tests

### Test Tags Reference

**Test Categories**:
- `@HappyPath` - Positive test scenarios
- `@UnhappyPath` - Negative test scenarios
- `@ApiIntegrationTest` - API functional tests
- `@ContractTest` - Schema validation tests
- `@PerformanceTest` - Load/performance tests

**Feature-Specific**:
- `@BookingCreationFeature`
- `@BookingUpdateFeature`
- `@BookingDeletionFeature`
- `@AuthFeature`
- `@HealthCheckFeature`

**Hook Triggers**:
- `@SetupOneBooking` - Creates 1 booking before scenario
- `@SetupMultipleBookings` - Creates 5 bookings before scenario
- `@AuthorizeRequest` - Gets auth token before scenario
- `@CleanUpBooking` - Deletes booking after scenario
- `@CleanUpPerformanceBookings` - Deletes performance test bookings after scenario

**Load Simulation**:
- `@Inject` - Constant rate injection
- `@RampingInject` - Ramping injection
- `@InjectRandom` - Random interval injection

**Special**:
- `@ignore` - Skips test (used for known API issues)

### API Endpoints Under Test

**Base URL**: `https://restful-booker.herokuapp.com`

**Endpoints** (defined in `/tests/RestfulBookerTestFramework.Tests.Commons/Constants/Endpoints.cs`):
- `POST /auth` - Create authentication token
- `GET /ping` - Health check
- `POST /booking` - Create booking
- `GET /booking/{id}` - Get specific booking
- `GET /booking` - Get booking IDs (with optional filters)
- `PUT /booking/{id}` - Full update of booking (requires auth)
- `PATCH /booking/{id}` - Partial update of booking (requires auth)
- `DELETE /booking/{id}` - Delete booking (requires auth)

### ScenarioContext Usage

ScenarioContext is used to share data between steps. Always use extension methods:

**Storing Data**:
```csharp
// In step definition
_scenarioContext.SetBookingResponse(bookingResponse);
_scenarioContext.SetAuthToken(token);
_scenarioContext.SetBookingId(id);
```

**Retrieving Data**:
```csharp
// In step definition
var bookingResponse = _scenarioContext.GetBookingResponse();
var token = _scenarioContext.GetAuthToken();
var bookingId = _scenarioContext.GetBookingId();
```

**Extension Methods**: Defined in `/tests/RestfulBookerTestFramework.Tests.Commons/Extensions/`
- `SetScenarioContextExtensions.cs` - Set methods
- `GetScenarioContextExtensions.cs` - Get methods

**Context Keys**: Defined in `/tests/RestfulBookerTestFramework.Tests.Commons/Constants/Context.cs`

### Test Data Generation

**Using Bogus Factories**:
```csharp
// Generate complete booking
var booking = BookingFactory.GetBooking();

// Generate booking dates
var bookingDates = BookingDatesFactory.GetBookingDates();

// Generate partial booking (for negative tests)
var partialBooking = PartiallyBookingFactory.GetBookingWithoutFirstName();
```

**Factories Location**: `/tests/RestfulBookerTestFramework.Tests.Commons/Factories/`

### Assertions with FluentAssertions

**Status Code Assertions**:
```csharp
response.StatusCode.Should().Be(HttpStatusCode.OK);
response.StatusCode.Should().Be(HttpStatusCode.Created);
response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
```

**Data Assertions**:
```csharp
response.Data.Should().NotBeNull();
response.Data!.BookingId.Should().BeGreaterThan(0);
response.Data!.Booking.FirstName.Should().Be(expectedBooking.FirstName);
```

**Collection Assertions**:
```csharp
bookingIds.Should().NotBeEmpty();
bookingIds.Should().HaveCountGreaterThan(0);
bookingIds.Should().Contain(expectedId);
```

### Schema Validation

**Schema Files**: Located in `/tests/RestfulBookerTestFramework.Tests.Contracts/Schemas/`

**Schema Validation Drivers**:
- `ObjectSchemaHelper` - Validates single objects
- `ArraySchemaHelper` - Validates arrays

**Usage in Tests**:
```csharp
// In step definition
var isValid = await _schemaValidationDriver.ValidateObjectAgainstJsonSchema(
    response.Content!,
    "booking-schema.json"
);
isValid.Should().BeTrue();
```

### Performance Testing with NBomber

**Load Simulation Patterns**:

**1. Inject (Constant Rate)**:
```gherkin
When run inject performance scenario: 'Create booking (inject)'
  for 'POST' method and '/booking' endpoint
  with Rate: 5, Interval in seconds: 1 and During in seconds: 5
```
- Rate: Requests per interval
- Interval: Time interval in seconds
- During: Total duration in seconds

**2. Ramping Inject**:
```gherkin
When run ramping inject performance scenario: 'Auth (ramping inject)'
  for 'POST' method and '/auth' endpoint
  with From copies: 1, To copies: 5, During in seconds: 5
```
- From copies: Starting request rate
- To copies: Ending request rate
- During: Ramp duration

**3. Inject Random**:
```gherkin
When run inject random performance scenario: 'Create booking (inject random)'
  for 'POST' method and '/booking' endpoint
  with Min rate: 2, Max rate: 6, Interval in seconds: 1 and During in seconds: 5
```
- Min rate: Minimum requests per interval
- Max rate: Maximum requests per interval

**Cleanup**: Performance tests use `@CleanUpPerformanceBookings` to delete all created bookings

---

## Configuration Management

### Configuration Files

**appsettings.json** (identical in Api, Contracts, Performance projects):
```json
{
  "AppSettings": {
    "Urls": {
      "RestfulBookerUrl": "https://restful-booker.herokuapp.com"
    },
    "Credentials": {
      "UserName": "YOUR_USERNAME",
      "Password": "YOUR_PASSWORD"
    }
  }
}
```

**File Location**:
- `/tests/RestfulBookerTestFramework.Tests.Api/appsettings.json`
- `/tests/RestfulBookerTestFramework.Tests.Contracts/appsettings.json`
- `/tests/RestfulBookerTestFramework.Tests.Performance/appsettings.json`

### Configuration Classes

**Location**: `/tests/RestfulBookerTestFramework.Tests.Commons/Configuration/`

```csharp
public class AppSettings
{
    public Urls Urls { get; set; }
    public Credentials Credentials { get; set; }
}

public class Urls
{
    public string RestfulBookerUrl { get; set; }
}

public class Credentials
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
```

### User Secrets

**User Secrets ID**: `94171d59-b230-4880-aae9-6fd68e29f44f`

**Purpose**: Store sensitive credentials outside of source control

**Configuration**:
```xml
<UserSecretsId>94171d59-b230-4880-aae9-6fd68e29f44f</UserSecretsId>
```

**Loading Configuration**:
```csharp
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<TestBaseSetup>()  // Overrides appsettings.json values
    .Build();
```

**Setting User Secrets** (Command Line):
```bash
# Set username
dotnet user-secrets set "AppSettings:Credentials:UserName" "admin" \
  --project tests/RestfulBookerTestFramework.Tests.Api/

# Set password
dotnet user-secrets set "AppSettings:Credentials:Password" "password123" \
  --project tests/RestfulBookerTestFramework.Tests.Api/

# List secrets
dotnet user-secrets list \
  --project tests/RestfulBookerTestFramework.Tests.Api/
```

### Accessing Configuration in Code

**Via Dependency Injection**:
```csharp
public sealed class MyDriver(AppSettings appSettings)
{
    private readonly string _baseUrl = appSettings.Urls.RestfulBookerUrl;
    private readonly string _username = appSettings.Credentials.UserName;
    private readonly string _password = appSettings.Credentials.Password;
}
```

**Configuration is Registered in DI**:
See `/tests/RestfulBookerTestFramework.Tests.Api/Support/SetupTestDependencies.cs`

---

## Common Tasks

### Task 1: Add a New API Endpoint Test

**Scenario**: Add tests for a new hypothetical endpoint `GET /rooms`

1. **Add Endpoint Constant**:
   ```csharp
   // File: /tests/RestfulBookerTestFramework.Tests.Commons/Constants/Endpoints.cs
   public const string RoomsEndpoint = "/rooms";
   ```

2. **Create Model**:
   ```csharp
   // File: /tests/RestfulBookerTestFramework.Tests.Commons/DTOs/Models/Room.cs
   #nullable enable
   public sealed class Room
   {
       [JsonPropertyName("roomId")]
       public int? RoomId { get; set; }

       [JsonPropertyName("roomNumber")]
       public string? RoomNumber { get; set; }
   }
   ```

3. **Create Driver**:
   ```csharp
   // File: /tests/RestfulBookerTestFramework.Tests.Commons/Drivers/Room/IRoomDriver.cs
   public interface IRoomDriver
   {
       Task<RestResponse<List<Room>>> GetRooms();
   }

   // File: /tests/RestfulBookerTestFramework.Tests.Commons/Drivers/Room/RoomDriver.cs
   public sealed class RoomDriver(IRequestDriver requestDriver) : IRoomDriver
   {
       public async Task<RestResponse<List<Room>>> GetRooms()
       {
           var request = new RestRequest(Endpoints.RoomsEndpoint, Method.Get);
           return await requestDriver.SendRequestAsync<List<Room>>(request);
       }
   }
   ```

4. **Create Feature File**:
   ```gherkin
   # File: /tests/RestfulBookerTestFramework.Tests.Api/Features/HappyPaths/GetRoomsHappyPath.feature
   @HappyPath @ApiIntegrationTest @RoomFeature
   Feature: Get Rooms Happy Path

   Scenario: Get all rooms successfully
       When I send a GET request to the rooms endpoint
       Then the response status code should be 200
       And the response should contain a list of rooms
   ```

5. **Create Step Definitions**:
   ```csharp
   // File: /tests/RestfulBookerTestFramework.Tests.Api/StepDefinitions/GetRoomsSteps.cs
   [Binding]
   public sealed class GetRoomsSteps(
       ScenarioContext scenarioContext,
       IRoomDriver roomDriver)
   {
       [When(@"I send a GET request to the rooms endpoint")]
       public async Task WhenISendGetRequestToRoomsEndpoint()
       {
           var response = await roomDriver.GetRooms();
           scenarioContext.Set(response, "RoomsResponse");
       }

       [Then(@"the response should contain a list of rooms")]
       public void ThenResponseShouldContainListOfRooms()
       {
           var response = scenarioContext.Get<RestResponse<List<Room>>>("RoomsResponse");
           response.Data.Should().NotBeNull();
           response.Data.Should().NotBeEmpty();
       }
   }
   ```

6. **Register in DI**:
   ```csharp
   // File: /tests/RestfulBookerTestFramework.Tests.Api/Support/SetupTestDependencies.cs
   [ScenarioDependencies]
   public static void SetupScenarioContainer(ContainerBuilder containerBuilder)
   {
       // ... existing registrations
       containerBuilder.AddReqnrollBindings<GetRoomsSteps>();
   }
   ```

### Task 2: Add Missing Property Validation Test

**Scenario**: Test creating booking without `TotalPrice` property

1. **Create Partial Request Model**:
   ```csharp
   // File: /tests/RestfulBookerTestFramework.Tests.Commons/Payloads/Requests/Partial/MultipleProperties/BookingWithoutTotalPrice.cs
   #nullable enable
   public sealed class BookingWithoutTotalPrice
   {
       [JsonPropertyName("firstname")]
       public string? FirstName { get; init; }

       [JsonPropertyName("lastname")]
       public string? LastName { get; init; }

       [JsonPropertyName("depositpaid")]
       public bool? DepositPaid { get; init; }

       [JsonPropertyName("bookingdates")]
       public BookingDates? BookingDates { get; init; }

       [JsonPropertyName("additionalneeds")]
       public string? AdditionalNeeds { get; init; }
   }
   ```

2. **Add Factory Method**:
   ```csharp
   // File: /tests/RestfulBookerTestFramework.Tests.Commons/Factories/PartiallyBookingFactory.cs
   public static BookingWithoutTotalPrice GetBookingWithoutTotalPrice()
   {
       return new Faker<BookingWithoutTotalPrice>()
           .RuleFor(b => b.FirstName, f => f.Name.FirstName())
           .RuleFor(b => b.LastName, f => f.Name.LastName())
           .RuleFor(b => b.DepositPaid, f => f.Random.Bool())
           .RuleFor(b => b.BookingDates, BookingDatesFactory.GetBookingDates())
           .RuleFor(b => b.AdditionalNeeds, f => f.Lorem.Sentence())
           .Generate();
   }
   ```

3. **Add Scenario to Existing Feature**:
   ```gherkin
   # File: /tests/RestfulBookerTestFramework.Tests.Api/Features/UnhappyPaths/CreateBookingUnhappyPathWithMissingBodyProperites.feature
   Scenario: Create booking without total price
       Given I have a booking without total price property
       When I send a POST request to create the booking
       Then the response status code should be 500
   ```

4. **Add Step Definition**:
   ```csharp
   // In existing CreateBookingSteps.cs or new file
   [Given(@"I have a booking without total price property")]
   public void GivenIHaveBookingWithoutTotalPrice()
   {
       var booking = PartiallyBookingFactory.GetBookingWithoutTotalPrice();
       _scenarioContext.Set(booking, "PartialBooking");
   }
   ```

### Task 3: Add Performance Test for New Endpoint

**Scenario**: Add performance test for `DELETE /booking/{id}`

1. **Check if PerformanceHelper Supports Endpoint**:
   - File: `/tests/RestfulBookerTestFramework.Tests.Performance/Helpers/PerformanceHelper.cs`
   - Verify `DeleteEndpoints` case exists in switch statement

2. **Create Feature File**:
   ```gherkin
   # File: /tests/RestfulBookerTestFramework.Tests.Performance/Features/InjectFeatures/PerformanceTestInjectDeleteBooking.feature
   @PerformanceTest @Inject @CleanUpPerformanceBookings @AuthorizeRequest
   Feature: Performance Test Inject - Delete Booking

   Scenario: Delete booking with inject load simulation
       When run inject performance scenario: 'Delete booking (inject)' for 'DELETE' method and '/booking/{idToDelete}' endpoint with Rate: 5, Interval in seconds: 1 and During in seconds: 5
   ```

3. **Verify Step Definition Exists**:
   - File: `/tests/RestfulBookerTestFramework.Tests.Performance/StepDefinitions/PerformanceInjectLoadSimulationSteps.cs`
   - The generic step definition should handle DELETE endpoint

4. **Run Test**: The existing infrastructure handles DELETE with special logic (creates booking then deletes it)

### Task 4: Update Configuration URL

**Scenario**: Change API base URL for testing against different environment

**Option 1: Update appsettings.json** (affects all users):
```json
{
  "AppSettings": {
    "Urls": {
      "RestfulBookerUrl": "https://staging.restful-booker.herokuapp.com"
    }
  }
}
```

**Option 2: Use User Secrets** (recommended for personal/local changes):
```bash
dotnet user-secrets set "AppSettings:Urls:RestfulBookerUrl" "https://staging.restful-booker.herokuapp.com" \
  --project tests/RestfulBookerTestFramework.Tests.Api/
```

### Task 5: Add Custom Extension Method

**Scenario**: Add extension to extract custom header from response

```csharp
// File: /tests/RestfulBookerTestFramework.Tests.Commons/Extensions/RestResponseExtensions.cs
public static class RestResponseExtensions
{
    public static string? GetCustomHeader(this RestResponse response, string headerName)
    {
        var header = response.Headers?.FirstOrDefault(h =>
            h.Name?.Equals(headerName, StringComparison.OrdinalIgnoreCase) == true);
        return header?.Value?.ToString();
    }
}
```

**Usage**:
```csharp
var customValue = response.GetCustomHeader("X-Custom-Header");
```

---

## Important File Locations

### Configuration Files
- **Solution**: `/RestfulBookerTestFramework.sln`
- **Package Management**: `/Directory.Packages.props`
- **App Settings (Api)**: `/tests/RestfulBookerTestFramework.Tests.Api/appsettings.json`
- **App Settings (Contracts)**: `/tests/RestfulBookerTestFramework.Tests.Contracts/appsettings.json`
- **App Settings (Performance)**: `/tests/RestfulBookerTestFramework.Tests.Performance/appsettings.json`

### Commons Project Files
- **Constants**: `/tests/RestfulBookerTestFramework.Tests.Commons/Constants/`
  - `Endpoints.cs` - API endpoints
  - `Context.cs` - ScenarioContext keys
  - `ErrorMessages.cs` - Expected error messages
  - `DateConstants.cs` - Date formats
- **Models**: `/tests/RestfulBookerTestFramework.Tests.Commons/DTOs/Models/`
  - `Booking.cs`
  - `BookingDates.cs`
  - `BookingIdentifier.cs`
- **Drivers**: `/tests/RestfulBookerTestFramework.Tests.Commons/Drivers/`
- **Factories**: `/tests/RestfulBookerTestFramework.Tests.Commons/Factories/`
- **Helpers**: `/tests/RestfulBookerTestFramework.Tests.Commons/Helpers/`
- **Extensions**: `/tests/RestfulBookerTestFramework.Tests.Commons/Extensions/`

### API Test Files
- **Happy Path Features**: `/tests/RestfulBookerTestFramework.Tests.Api/Features/HappyPaths/`
- **Unhappy Path Features**: `/tests/RestfulBookerTestFramework.Tests.Api/Features/UnhappyPaths/`
- **Step Definitions**: `/tests/RestfulBookerTestFramework.Tests.Api/StepDefinitions/`
- **Hooks**: `/tests/RestfulBookerTestFramework.Tests.Api/Hooks/`
- **DI Setup**: `/tests/RestfulBookerTestFramework.Tests.Api/Support/SetupTestDependencies.cs`

### Contract Test Files
- **Features**: `/tests/RestfulBookerTestFramework.Tests.Contracts/Features/`
- **JSON Schemas**: `/tests/RestfulBookerTestFramework.Tests.Contracts/Schemas/`
- **Step Definitions**: `/tests/RestfulBookerTestFramework.Tests.Contracts/StepDefinitions/`
- **Schema Driver**: `/tests/RestfulBookerTestFramework.Tests.Contracts/Drivers/SchemaValidationDriver.cs`

### Performance Test Files
- **Inject Features**: `/tests/RestfulBookerTestFramework.Tests.Performance/Features/InjectFeatures/`
- **Ramping Inject Features**: `/tests/RestfulBookerTestFramework.Tests.Performance/Features/RampingInjectFeatures/`
- **Inject Random Features**: `/tests/RestfulBookerTestFramework.Tests.Performance/Features/InjectRandomFeatures/`
- **Performance Helper**: `/tests/RestfulBookerTestFramework.Tests.Performance/Helpers/PerformanceHelper.cs`
- **Step Definitions**: `/tests/RestfulBookerTestFramework.Tests.Performance/StepDefinitions/`

### Project Files (.csproj)
- **Commons**: `/tests/RestfulBookerTestFramework.Tests.Commons/RestfulBookerTestFramework.Tests.Commons.csproj`
- **Api**: `/tests/RestfulBookerTestFramework.Tests.Api/RestfulBookerTestFramework.Tests.Api.csproj`
- **Contracts**: `/tests/RestfulBookerTestFramework.Tests.Contracts/RestfulBookerTestFramework.Tests.Contracts.csproj`
- **Performance**: `/tests/RestfulBookerTestFramework.Tests.Performance/RestfulBookerTestFramework.Tests.Performance.csproj`

---

## Testing Guidelines

### When Adding New Tests

1. **Choose the Right Test Type**:
   - **API Tests**: Functional behavior, CRUD operations
   - **Contract Tests**: API response structure validation
   - **Performance Tests**: Load, stress, scalability

2. **Use Appropriate Tags**:
   - Always tag with test category (`@HappyPath`, `@UnhappyPath`, `@ContractTest`, `@PerformanceTest`)
   - Add cleanup tags (`@CleanUpBooking`, `@CleanUpPerformanceBookings`)
   - Add setup tags if needed (`@SetupOneBooking`, `@AuthorizeRequest`)

3. **Follow BDD Best Practices**:
   - Features should be user-focused and describe business value
   - Scenarios should be independent and atomic
   - Use Given-When-Then structure consistently
   - Keep scenarios readable and maintainable

4. **Data Management**:
   - Use factories for test data generation
   - Don't hardcode test data in steps
   - Clean up test data after scenarios (use hooks)

5. **Assertions**:
   - Use FluentAssertions for readable assertions
   - Assert on both status codes and response data
   - Validate error messages in negative tests

### Test Organization

**HappyPath Tests** (Positive scenarios):
- Test successful operations
- Validate correct responses
- Verify expected behavior

**UnhappyPath Tests** (Negative scenarios):
- Test error conditions
- Validate error responses
- Test missing/invalid data
- Test authorization failures

**Contract Tests**:
- Validate JSON schema compliance
- Ensure API contract stability
- Test all response structures

**Performance Tests**:
- Validate system under load
- Test scalability
- Identify performance bottlenecks

### Known Issues

Some tests use `@ignore` tag for known API issues:
- Check feature files for `@ignore` tags and comments explaining the issue
- Document any new issues discovered
- Re-enable tests when API issues are fixed

### Test Execution Best Practices

1. **Run Tests in Isolation**: Each scenario should be independent
2. **Use Tags for Selective Execution**: Run specific test suites as needed
3. **Monitor Test Data**: Ensure cleanup hooks are working
4. **Check Performance Test Results**: Review NBomber output for insights
5. **Review Failed Tests**: Check logs and responses for debugging

---

## Git Workflow

### Branch Strategy

**Development Branch**: `claude/claude-md-mi3w2opfe2i745qc-01G45okxaaVNg1SLnbzo8tWi`

**Important**:
- All development happens on feature branches starting with `claude/`
- Branch names must end with matching session ID
- Push failures with 403 error indicate branch naming issues

### Git Commands

**Pushing Changes**:
```bash
# Always use -u flag for new branches
git push -u origin claude/your-branch-name

# Retry on network errors with exponential backoff:
# Wait 2s, then 4s, then 8s, then 16s between retries (max 4 retries)
```

**Fetching Updates**:
```bash
# Fetch specific branch
git fetch origin claude/your-branch-name

# Pull specific branch
git pull origin claude/your-branch-name
```

**Creating Commits**:
```bash
# Check status
git status

# Stage changes
git add .

# Commit with message
git commit -m "type(scope): description"
```

**Commit Message Format**:
```
type(scope): Short description

- Detailed change 1
- Detailed change 2
```

**Types**:
- `feat`: New feature
- `fix`: Bug fix
- `refactor`: Code refactoring
- `test`: Adding/updating tests
- `docs`: Documentation changes
- `chore`: Maintenance tasks
- `perf`: Performance improvements

**Scopes** (examples):
- `api`: API test changes
- `contracts`: Contract test changes
- `performance`: Performance test changes
- `commons`: Commons library changes
- `config`: Configuration changes
- `di`: Dependency injection changes

### Pre-Commit Checklist

Before committing changes:

1. ✅ All tests pass: `dotnet test`
2. ✅ Code builds successfully: `dotnet build`
3. ✅ No hardcoded secrets in code
4. ✅ Appropriate tags on new features
5. ✅ DI registrations updated if new classes added
6. ✅ Extension methods added for new ScenarioContext data
7. ✅ Constants used instead of magic strings
8. ✅ Cleanup hooks added for new test data

### Pull Request Guidelines

**PR Title Format**:
```
type(scope): Brief description of changes
```

**PR Description Template**:
```markdown
## Summary
- Bullet point summary of changes
- What was added/changed/fixed

## Test Plan
- [ ] All existing tests pass
- [ ] New tests added for new functionality
- [ ] Manual testing completed for X scenario
- [ ] Performance tests validated (if applicable)

## Changes
- Detailed list of file changes
- Architectural decisions made
- Dependencies added/updated
```

**PR Best Practices**:
- Keep PRs focused and reasonably sized
- Include tests for all new functionality
- Update this CLAUDE.md if architectural changes made
- Ensure CI/CD passes before requesting review

---

## Troubleshooting

### Common Issues

#### Issue: Tests Fail with "Configuration not found"

**Cause**: Missing or incorrect `appsettings.json` or user secrets

**Solution**:
1. Verify `appsettings.json` exists in project directory
2. Check file is set to `<CopyToOutputDirectory>Always</CopyToOutputDirectory>`
3. Set user secrets if using sensitive credentials:
   ```bash
   dotnet user-secrets set "AppSettings:Credentials:UserName" "admin" \
     --project tests/RestfulBookerTestFramework.Tests.Api/
   ```

#### Issue: Dependency Injection Errors

**Cause**: Missing DI registration

**Solution**:
1. Check `SetupTestDependencies.cs` in respective project
2. Ensure new classes are registered:
   ```csharp
   containerBuilder.AddReqnrollBindings<YourNewSteps>();
   ```
3. Verify driver interfaces are registered in Commons DI extensions

#### Issue: Feature File Not Found/Not Executing

**Cause**: Feature file not configured correctly in `.csproj`

**Solution**:
1. Check `.csproj` has Reqnroll configuration:
   ```xml
   <Reqnroll>
     <Generator>
       <AllowDebugGeneratedFiles>false</AllowDebugGeneratedFiles>
     </Generator>
   </Reqnroll>
   ```
2. Verify feature files have:
   ```xml
   <SpecFlowFeatureFiles Include="Features\**\*.feature" />
   ```

#### Issue: JSON Serialization Errors

**Cause**: Missing `[JsonPropertyName]` attributes or incorrect naming

**Solution**:
1. Add `[JsonPropertyName("propertyName")]` to all DTO properties
2. Ensure property names match API expectations (usually lowercase)
3. For performance tests, verify `LowerCaseNamingPolicy` is used

#### Issue: ScenarioContext Data Not Found

**Cause**: Incorrect key used or data not set

**Solution**:
1. Use extension methods instead of raw ScenarioContext:
   ```csharp
   // ✅ Good
   _scenarioContext.SetBookingId(id);
   var id = _scenarioContext.GetBookingId();

   // ❌ Bad
   _scenarioContext.Set(id, "BookingId");
   var id = _scenarioContext.Get<int>("BookingId");
   ```
2. Use constants from `Context.cs`:
   ```csharp
   _scenarioContext.Set(id, Context.BookingId);
   ```

#### Issue: Performance Tests Failing

**Cause**: NBomber configuration or endpoint issues

**Solution**:
1. Check `PerformanceHelper.cs` has case for the endpoint
2. Verify HttpMethod is correct (GET, POST, DELETE, etc.)
3. For DELETE tests, ensure `@AuthorizeRequest` tag is present
4. Check NBomber scenario configuration (rate, duration, etc.)

#### Issue: Schema Validation Failing

**Cause**: Schema file not found or incorrect schema

**Solution**:
1. Verify schema file exists in `/tests/RestfulBookerTestFramework.Tests.Contracts/Schemas/`
2. Check `.csproj` has:
   ```xml
   <None Update="Schemas\*.json">
     <CopyToOutputDirectory>Always</CopyToOutputDirectory>
   </None>
   ```
3. Validate schema JSON is correct
4. Ensure schema filename matches what's used in step definition

#### Issue: Authentication Token Errors

**Cause**: Invalid credentials or missing `@AuthorizeRequest` tag

**Solution**:
1. Add `@AuthorizeRequest` tag to scenarios requiring auth
2. Verify credentials in user secrets or `appsettings.json`
3. Check AuthTokenDriver is working:
   ```csharp
   var token = await _authTokenDriver.CreateAuthToken();
   token.Should().NotBeNullOrEmpty();
   ```

#### Issue: Cleanup Hooks Not Running

**Cause**: Missing cleanup tag or hook not registered

**Solution**:
1. Add appropriate cleanup tag:
   - `@CleanUpBooking` for single booking
   - `@CleanUpPerformanceBookings` for performance tests
2. Verify hooks are registered in DI:
   ```csharp
   containerBuilder.AddReqnrollBindings<ScenarioHook>();
   ```

#### Issue: Build Errors After Adding NuGet Package

**Cause**: Package version conflict or missing central package management

**Solution**:
1. Add package to `Directory.Packages.props`:
   ```xml
   <PackageVersion Include="YourPackage" Version="1.0.0" />
   ```
2. Reference in `.csproj` WITHOUT version:
   ```xml
   <PackageReference Include="YourPackage" />
   ```
3. Run `dotnet restore`

#### Issue: Git Push Fails with 403 Error

**Cause**: Branch name doesn't match required pattern

**Solution**:
1. Ensure branch starts with `claude/`
2. Ensure branch ends with session ID
3. Example: `claude/feature-name-sessionId123`
4. Retry up to 4 times with exponential backoff for network errors

---

## Additional Resources

### Reqnroll Documentation
- Official Docs: https://docs.reqnroll.net/
- Migration from SpecFlow: https://docs.reqnroll.net/latest/guides/migrating-from-specflow.html

### NBomber Documentation
- Official Docs: https://nbomber.com/docs/overview
- HTTP Plugin: https://nbomber.com/docs/plugins-http

### RestSharp Documentation
- Official Docs: https://restsharp.dev/

### FluentAssertions Documentation
- Official Docs: https://fluentassertions.com/

### Bogus Documentation
- GitHub: https://github.com/bchavez/Bogus
- API Reference: https://github.com/bchavez/Bogus#api

### Autofac Documentation
- Official Docs: https://autofac.readthedocs.io/

---

## Changelog

### 2025-11-18
- Initial CLAUDE.md creation
- Comprehensive codebase analysis completed
- Documented all major patterns, conventions, and workflows
- Added troubleshooting guide and common tasks
- Included detailed architecture and design pattern documentation

---

## Notes for AI Assistants

### Key Principles When Working with This Codebase

1. **Always Use Interfaces**: Every driver, helper, and major component should have an interface
2. **Extension Methods for ScenarioContext**: Never use raw ScenarioContext.Set/Get
3. **Constants Over Magic Strings**: All endpoints, keys, messages should be constants
4. **DI Registration Required**: New classes must be registered in `SetupTestDependencies.cs`
5. **Cleanup is Mandatory**: All tests creating data must have cleanup hooks
6. **Async All The Way**: All I/O operations must be async
7. **Tag Your Features**: Every feature needs appropriate tags for execution and hooks
8. **FluentAssertions Preferred**: Use FluentAssertions for all assertions
9. **Factories for Data**: Use Bogus factories, never hardcode test data
10. **Follow Existing Patterns**: Before creating new patterns, check if existing patterns apply

### When Making Changes

1. **Read Existing Code First**: Understand current implementation before modifying
2. **Follow Existing Structure**: Match the organization and patterns already in place
3. **Update DI Configuration**: Register new classes in appropriate DI setup
4. **Add Tests**: New functionality requires new tests
5. **Update Documentation**: Update this CLAUDE.md if architectural changes made
6. **Check All Test Projects**: Changes in Commons affect all test projects
7. **Verify Build**: Run `dotnet build` before committing
8. **Run Tests**: Run `dotnet test` before committing

### Questions to Ask Before Changes

1. Does this follow the existing architectural patterns?
2. Is there already a helper/extension for this functionality?
3. Should this be in Commons (shared) or specific test project?
4. Do I need to update DI registration?
5. Are constants being used instead of magic strings?
6. Is cleanup needed for this test data?
7. Are appropriate tags applied?
8. Is the code async where it should be?

---

**End of CLAUDE.md**

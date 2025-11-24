![DotNet](https://img.shields.io/badge/-.NET%208.0-darkviolet?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![Reqnroll](https://img.shields.io/badge/SpecFlow-lightgreen.svg?style=for-the-badge&logo=specflow&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)
![RestSharp](https://img.shields.io/badge/RestSharp-darkgreen?style=for-the-badge&logo=restsharp&logoColor=white)
![Autofac](https://img.shields.io/badge/Autofac-lightgreen.svg?style=for-the-badge&logo=autofac&logoColor=white)
![Schema Testing](https://img.shields.io/badge/Schema_Testing-lightblue.svg?style=for-the-badge&logo=schematesting&logoColor=white)
![NBomber](https://img.shields.io/badge/NBomber-blue.svg?style=for-the-badge&logo=nbomber&logoColor=white)

# RestfulBookerTestFramework

A comprehensive test automation framework for the Restful Booker API, featuring API integration tests, contract/schema validation tests, and performance tests using NBomber.

## Configuration

### Credentials Setup

The test framework requires credentials to authenticate with the Restful Booker API. The framework supports multiple configuration sources in the following precedence order (highest to lowest):

1. **Environment Variables** (Recommended for CI/CD)
2. **User Secrets** (Recommended for local development)
3. **appsettings.json** (Base configuration with placeholders)

#### Option 1: Environment Variables

Set the following environment variables:

```bash
export AppSettings__Credentials__UserName="your_username"
export AppSettings__Credentials__Password="your_password"
```

For Windows PowerShell:
```powershell
$env:AppSettings__Credentials__UserName="your_username"
$env:AppSettings__Credentials__Password="your_password"
```

#### Option 2: User Secrets (Recommended for Local Development)

For local development, use .NET User Secrets to keep credentials out of source control:

```bash
# Navigate to the test project directory
cd tests/RestfulBookerTestFramework.Tests.Api

# Set the credentials
dotnet user-secrets set "AppSettings:Credentials:UserName" "your_username"
dotnet user-secrets set "AppSettings:Credentials:Password" "your_password"
```

Repeat for other test projects (Tests.Contracts, Tests.Performance).

#### Option 3: appsettings.json (Not Recommended)

While you can modify `appsettings.json` files directly, this is **not recommended** as credentials should never be committed to source control.

### CI/CD Configuration with GitHub Secrets

The GitHub Actions workflows are configured to use GitHub Secrets for credential management. To set up:

1. Navigate to your repository on GitHub
2. Go to **Settings** → **Secrets and variables** → **Actions**
3. Click **New repository secret**
4. Add the following secrets:
   - Name: `RESTFUL_BOOKER_USERNAME`, Value: your API username
   - Name: `RESTFUL_BOOKER_PASSWORD`, Value: your API password

The workflows reference these secrets as:
```yaml
env:
  AppSettings__Credentials__UserName: ${{ secrets.RESTFUL_BOOKER_USERNAME }}
  AppSettings__Credentials__Password: ${{ secrets.RESTFUL_BOOKER_PASSWORD }}
```

**Important**: Never commit actual credentials to source control. Always use secrets management for CI/CD pipelines.

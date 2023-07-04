# Tests-NUnit-BitBar-Sample

Created this NUnit Test project based on the official example from [Bitbar for CSharp](https://github.com/bitbar/test-samples/tree/master/samples/testing-frameworks/appium/client-side/csharp/sample-test).
Was able to successfully trigger test run as *client-side Appium*.

Useful [documentation](https://support.smartbear.com/bitbar/docs/testing-with-bitbar/automated-testing/appium/running-client-side-appium-tests.html) to be able to run this client side setup.

# How the repository was setup
1. NUnit test project created with
```
dotnet new nunit
```

2. Install `Appium.Webdriver` package
```
dotnet add package Appium.WebDriver --version 4.4.0
```

# Pre-requisites to be able to run tests
1. Upload `<app_file>.apk` in cloud
2. Get the Bitbar API key from My Account > My Integrations > API access and set it as environment variable `BITBAR_APIKEY`
3. Get the App id and set it as environment variable `BITBAR_APP_ID` from Files Library

# Run tests (trigger test run in BitBar cloud)
1. Set environment variables `BITBAR_APIKEY` and `BITBAR_APP_ID`
2. Run tests with:
```
dotnet test
```

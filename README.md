# Moneybird.Net

[![.NET Standard](https://img.shields.io/badge/.NET%20Standard-2.0-purple)](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)
[![build](https://github.com/VincentVrijburg/moneybird-dotnet/actions/workflows/build.yml/badge.svg)](https://github.com/VincentVrijburg/moneybird-dotnet/actions/workflows/build.yml)
[![codecov](https://codecov.io/gh/VincentVrijburg/moneybird-dotnet/branch/develop/graph/badge.svg?token=3ESKQK1JUZ)](https://codecov.io/gh/VincentVrijburg/moneybird-dotnet)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Moneybird.Net)](https://www.nuget.org/packages/Moneybird.Net/)

Moneybird client for .NET Framework and .NET (Core).

## Table of Contents
<!-- TOC -->

- [Moneybird.Net](#moneybirdnet)
  - [Table of Contents](#table-of-contents)
  - [Installation](#installation)
  - [Usage](#usage)
    - [Configuration](#configuration)
      - [Option 1](#option-1)
      - [Option 2](#option-2)
    - [Authenticator](#authenticator)
      - [Request token uri](#request-token-uri)
      - [Request access token](#request-access-token)
      - [Refresh access token](#refresh-access-token)
    - [Client](#client)
      - [Create singleton entry point](#create-singleton-entry-point)
      - [Create disposable entry point](#create-disposable-entry-point)
      - [Request data](#request-data)
      - [Supported data classes](#supported-data-classes)
  - [Roadmap](#roadmap)
  - [Versioning](#versioning)
  - [License](#license)
  - [Disclaimer](#disclaimer)

<!-- /TOC -->

## Installation
*Installation instructions will get updated as the project matures*

Install `Moneybird.Net` through NuGet:
```
PM> Install-Package Moneybird.Net
```

## Usage
*Usage instructions will get updated as the project matures*

### Configuration
For both the authenticator and the client, an instance of the moneybird configuration is required.

*Note: both options will create an instance with the default api url and default authentication url values assigned.*

#### Option 1
In case you DO NOT need to use the OAuth functionality, you can create the default config as follows.

```csharp
var moneybirdConfig = new MoneybirdConfig();
```

#### Option 2
In case you DO need to use the OAuth functionality, you can create a custom config as follows.

```csharp
var moneybirdConfig = new MoneybirdConfig("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET", "YOUR_REDIRECT_URI");
```

### Authenticator
In order to access the resources of foreign administrations, you first need to authenticate the user.

The main entry point to the authentication endpoint can be established as follows
```csharp
using var authenticator = new MoneybirdAuthenticator(moneybirdConfig);
```

#### Request token uri
```csharp
// An array of scopes you need access to.
var scopes = new[] {AuthScope.SalesInvoices, AuthScope.Bank};
var uri = authenticator.GetRequestTokenUri(scopes);
```

Redirect the user to this uri to get the actual request token.

#### Request access token
```csharp
// Pass the request token to request the access token.
var accessToken = await authenticator.GetAccessTokenAsync(requestToken);
```

#### Refresh access token
```csharp
// Pass the refresh token from the access token object to refresh the access token.
var accessToken = await authenticator.RefreshAccessTokenAsync(refreshToken);
```

### Client

In order to access the API, an instance of the moneybird configuration is required.

#### Create singleton entry point
```csharp

var client = MoneybirdClient.GetInstance(config);

```

#### Create disposable entry point
```csharp

using var moneybirdClient = new MoneybirdClient(config);
using var moneybirdClient = new MoneybirdClient(config, httpClient);

```

#### Request data

See the example below to learn how to request a list of administrations.

```csharp

try
{
  var administrations = await client.Administration.GetAdministrationsAsync("{ACCESS_TOKEN}");
  var id = administrations[0].Id;
  var name = administrations[0].Name;
  var language = administrations[0].Language;
  var currency = administrations[0].Currency;
}
catch (MoneybirdException ex)
{
  // Handle the exception however you want.
}

```

#### Supported endpoints

We're continuously working on expanding this library to include additional endpoints, giving you even more options and functionality.

To see the full list of currently supported endpoints, and get a glimpse of what's coming next, head over to our [roadmap](ROADMAP.md).

## Roadmap
See our [roadmap](ROADMAP.md) for an overview of what we are planning to work on and in what time frame.

## Versioning
This project uses [Semver v2.0](https://semver.org/spec/v2.0.0.html) and is currently in initial development.

## License
Copyright (c) 2021 Vincent Vrijburg  
Licensed under the MIT license.

## Disclaimer

This package is not an official library for the Moneybird API and doesn't reflect the views or opinions of Moneybird B.V. or anyone officially involved in producing or managing Moneybird.

Not all endpoints are implemented and/or tested. Use at your own risk.

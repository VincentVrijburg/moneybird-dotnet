# Roadmap

This document aims to provide a clear overview of what we are planning to work on and in what time frame.

## v0.x.x

This version is solely for initial development and should not be considered "stable" and/or "complete" by any means.
Hence the decision to label each release within this version pattern as a "pre-release".

## v1.x.x

The goal is to provide a stable version that has the basic functionality to interact with the Moneybird API.

- [x] Support for custom configuration
- [x] Support for the authentication (OAuth2) endpoint
  - [x] Retrieving the request token
  - [x] Requesting the access token
  - [x] Refreshing the access token
- [x] Support for pagination 
- [ ] Support for the resource endpoints
  - [x] Administration
  - [x] Contacts
  - [x] Custom fields
  - [x] Document styles
  - [ ] Documents: General documents
  - [ ] Documents: General journal documents
  - [ ] Documents: Purchase invoices
  - [ ] Documents: Receipts
  - [ ] Documents: Typeless documents
  - [ ] Estimates
  - [x] External sales invoices (limited)
  - [x] Financial accounts
  - [ ] Financial mutations
  - [x] Financial statements
  - [x] Identities
  - [ ] Import mappings
  - [x] Ledger accounts
  - [x] Payments
  - [x] Products
  - [x] Projects
  - [ ] Recurring sales invoices
  - [x] Sales invoices (limited)
  - [ ] Subscriptions
  - [x] Tax rates
  - [x] Time entries
  - [x] Users
  - [x] Verifications
  - [x] Webhooks
  - [x] Workflows 

Once the features above are implemented (and ticked-off) we will release the first version in this range (i.e. v1.0.0).

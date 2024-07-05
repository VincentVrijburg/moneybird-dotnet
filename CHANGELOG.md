# Changelog

## 0.13.3 | 2024-07-05
* Fix deserialization for id in CustomFieldAttribute entity.

## 0.13.2 | 2024-06-26
* Fix deserialization for sales_invoice in `CustomFieldSource` enum.

## 0.13.1 | 2023-11-28
* Fix deserialization for discount in `SalesInvoice` entity.

## 0.13.0 | 2023-10-02
* Add support for `Financial account` endpoint.
* Add support for `Financial statement` endpoint.

## 0.12.0 | 2023-09-17
* Add support for `Projects` endpoint.

## 0.11.0 | 2023-07-13
* Add support for `Webhooks` endpoint.

## 0.10.1 | 2023-07-08
* Fix deserialization for percentage in `TaxRate` entity.

## 0.10.0 | 2023-06-29
* Add support for `Products` endpoint.

## 0.9.0 | 2023-06-04
* Add support for `Tax rates` endpoint.
* Add support for `Ledger account` endpoint.
* Add support for `Sales invoices endpoint` endpoint (limited operations).
* Add support for `External sales invoices` endpoint (limited operations).
* Change names (classes, enums, interfaces) and their namespaces.

## 0.8.1 | 2023-02-22
* Fix race condition for configurations.
* Add public constructor with optional argument for HttpClient.

## 0.8.0 | 2023-02-06
* Add support for `Payments` endpoint.

## 0.7.0 | 2023-02-04
* Add support for `Verifications` endpoint.

## 0.6.0 | 2023-01-30
* Add support for `Users` endpoint.
* Add `Macross.Json.Extensions` dependency for enum conversions.

## 0.5.0 | 2022-12-20
* Add support for `Workflows` endpoint.

## 0.4.1 | 2022-02-15
* Fix access for `Document styles` endpoint.

## 0.4.0 | 2022-02-11
* Add support for `Document styles` endpoint.

## 0.3.0 | 2022-01-14
* Add support for `Custom fields` endpoint.

## 0.2.0 | 2022-01-02
* Add support for `Contacts` endpoint.
* Change namespaces of models and entities.

## 0.1.3 | 2021-12-23
* Revise authenticator namespace (bugfix).

## 0.1.2 | 2021-12-08
* Revise administration model object (bugfix).

## 0.1.1 | 2021-12-08
* Add testing for the administrations endpoint.
* Improve paths for test response objects.
* Revise administration list object (bugfix).

## 0.1.0 | 2021-11-29
* Add OAuth2 authentication client.
* Add client to interact with the API.
* Add support for `Administrations` endpoint.

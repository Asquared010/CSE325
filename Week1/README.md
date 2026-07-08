# CSE 325 Week 1 - Build .NET Applications with C#

## Overview

This repository contains my Week 1 assignment for CSE 325: .NET Software Development at BYU-Idaho.

The assignment covered:

* Introduction to .NET
* Creating and managing .NET projects
* Working with NuGet dependencies
* Debugging .NET applications
* Working with files and directories
* Creating a RESTful Web API with ASP.NET Core
* Implementing CRUD operations
* Generating sales summary reports from JSON data

## Project 1: Work with Files and Directories

This console application:

* Searches directories and subdirectories for sales data files
* Reads and parses JSON sales files
* Calculates total sales across all stores
* Creates a sales totals file
* Generates a detailed sales summary report

### Generated Files

* `salesTotalDir/totals.txt`
* `salesTotalDir/salesReport.txt`

### Example Sales Report

```text
Sales Summary
----------------------------
Details:
stores\sales.json: $88.88
201\sales.json: $501.22
202\sales.json: $1,234.22
203\sales.json: $99.00
204\sales.json: $88.88

Total Sales: $2,012.20
```

## Project 2: ASP.NET Core Pizza API

This project implements a RESTful Web API using ASP.NET Core Controllers.

### Supported CRUD Operations

| Operation | HTTP Verb | Endpoint    |
| --------- | --------- | ----------- |
| Create    | POST      | /pizza      |
| Read All  | GET       | /pizza      |
| Read One  | GET       | /pizza/{id} |
| Update    | PUT       | /pizza/{id} |
| Delete    | DELETE    | /pizza/{id} |

### Additional Pizza Record

```csharp
new Pizza { Id = 3, Name = "Pepperoni", IsGlutenFree = false }
```

## Technologies Used

* C#
* .NET 8 LTS
* ASP.NET Core
* Newtonsoft.Json
* Visual Studio Code
* Git & GitHub

## Author

Aaron

CSE 325 - BYU Idaho

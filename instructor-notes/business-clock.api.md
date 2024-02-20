# Business Clock API

Need to show how to get support. 

If we are open, then you call this person at this number,
If we are closed, then you call this third-party support company at this number.

- we need to express in this api support information.

If we are open, it's Graham and his number 555-1212
If we are closed, it's TechSupportPros at 800-STUF-BROKE


## What is the "Resource"

"An important thingy you want to expose through your API"

Resources are identified through URI (Uniform Resource Indicator)

Example:

```
https://www.somesever.com/api/v1/employees
```

```
[scheme]://origin-server[:port]/path
```

Scheme:
    - http - port 80 by default.
    - https - "transport layer security" - port 443 by default.

Origin Server - 
    The DNS name or IP address of the server running an HTTP server.
    "authority" - sometimes called this.

Path -
    /api/v1/employees
    The "path to the resource"

## Methods

- GET - is used by the client (user agent) to retrieve a representation of a resource.
- POST - Append this representation to a collection resource or submit this entity for processing.
- PUT - replace the resource at this URI with this new representation
- DELETE - remove this representation


- Status Codes
- 200 - 299 - This probably worked like you expected. This are all "Success Status Codes"
- 300 - 399 - "Need more information, or redirects"
- 400 - 499 - The client (User agent) screwed up.
- 500 - 599 - We (the developer of the API) screwed up.
    - blammo. We want to avoid these. ;)

## Representations

A representation is a POINT IN TIME snapshot of a resource, and therefore should not be trusted.

How it is tranmitted to or from a server.

Could be JSON, XML, images, whatever.
(ASP.NET Core does JSON by default, but you can "plug in" other formatters or create your own.)


## What's our API

- The Resource
    http://localhost:1337/support-info
- The Method
    GET
- The Representation

```json
{
    "name": "Graham",
    "phone": "555-1212"
}

```

OR
```json
{
    "name": "TechSupportPros",
    "phone": "800-STUF-BROKE"
}

```

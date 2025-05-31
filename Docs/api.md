# BuberDinner API Documentation

## Overview

The BuberDinner API is a RESTful service that provides endpoints for managing restaurant operations. This API follows REST principles and uses standard HTTP response codes, authentication, and verbs.

## Base URL

```
http://localhost:5036
```

## Authentication

All API endpoints require authentication using JWT (JSON Web Tokens). Include the token in the Authorization header:

```
Authorization: Bearer <your_token>
```

## API Endpoints

### Authentication

#### Register User

```http
POST /api/auth/register
```

Request body:

```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "password": "string"
}
```

Response: `201 Created`

```json
{
  "id": "string",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "token": "string"
}
```

#### Login

```http
POST /api/auth/login
```

Request body:

```json
{
  "email": "string",
  "password": "string"
}
```

Response: `200 OK`

```json
{
  "id": "string",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "token": "string"
}
```

### Menus

#### Get All Menus

```http
GET /api/menus
```

Response: `200 OK`

```json
[
  {
    "id": "string",
    "name": "string",
    "description": "string",
    "averageRating": "number",
    "sections": [
      {
        "id": "string",
        "name": "string",
        "description": "string",
        "items": [
          {
            "id": "string",
            "name": "string",
            "description": "string",
            "price": "number"
          }
        ]
      }
    ]
  }
]
```

#### Create Menu

```http
POST /api/menus
```

Request body:

```json
{
  "name": "string",
  "description": "string",
  "sections": [
    {
      "name": "string",
      "description": "string",
      "items": [
        {
          "name": "string",
          "description": "string",
          "price": "number"
        }
      ]
    }
  ]
}
```

Response: `201 Created`

```json
{
  "id": "string",
  "name": "string",
  "description": "string",
  "sections": [
    {
      "id": "string",
      "name": "string",
      "description": "string",
      "items": [
        {
          "id": "string",
          "name": "string",
          "description": "string",
          "price": "number"
        }
      ]
    }
  ]
}
```

### Reservations

#### Get All Reservations

```http
GET /api/reservations
```

Response: `200 OK`

```json
[
  {
    "id": "string",
    "guestCount": "number",
    "reservationDateTime": "string",
    "status": "string",
    "menuId": "string",
    "userId": "string"
  }
]
```

#### Create Reservation

```http
POST /api/reservations
```

Request body:

```json
{
  "guestCount": "number",
  "reservationDateTime": "string",
  "menuId": "string"
}
```

Response: `201 Created`

```json
{
  "id": "string",
  "guestCount": "number",
  "reservationDateTime": "string",
  "status": "string",
  "menuId": "string",
  "userId": "string"
}
```

## Error Responses

The API uses standard HTTP status codes to indicate the success or failure of requests:

- `200 OK`: The request was successful
- `201 Created`: The resource was successfully created
- `400 Bad Request`: The request was invalid
- `401 Unauthorized`: Authentication is required
- `403 Forbidden`: The authenticated user doesn't have permission
- `404 Not Found`: The requested resource doesn't exist
- `500 Internal Server Error`: An error occurred on the server

Error response format:

```json
{
  "error": {
    "code": "string",
    "message": "string",
    "details": [
      {
        "field": "string",
        "message": "string"
      }
    ]
  }
}
```

## Rate Limiting

The API implements rate limiting to ensure fair usage. The current limits are:

- 100 requests per minute per IP address
- 1000 requests per hour per authenticated user

## Versioning

The API is versioned using the URL path. The current version is v1, which is included in all endpoints.

## Support

For API support or to report issues, please contact the development team at support@buberdinner.com

## API Testing Examples

### Authentication Tests

#### Register User

```bash
curl -X POST http://localhost:5036/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@example.com",
    "password": "SecurePass123!"
  }'
```

Expected Response (201 Created):

```json
{
  "id": "550e8400-e29b-41d4-a716-446655440000",
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

#### Login

```bash
curl -X POST http://localhost:5036/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "john.doe@example.com",
    "password": "SecurePass123!"
  }'
```

Expected Response (200 OK):

```json
{
  "id": "550e8400-e29b-41d4-a716-446655440000",
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Menu Tests

#### Create Menu

```bash
curl -X POST http://localhost:5036/api/menus \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..." \
  -d '{
    "name": "Summer Special Menu",
    "description": "Fresh seasonal dishes for summer",
    "sections": [
        {
            "name": "Appetizers",
            "description": "Light starters",
            "items": [
                {
                    "name": "Summer Salad",
                    "description": "Fresh mixed greens with seasonal fruits",
                    "price": 12.99
                }
            ]
        }
    ]
}'
```

Expected Response (201 Created):

```json
{
  "id": "7c9e6679-7425-40de-944b-e07fc1f90ae7",
  "name": "Summer Special Menu",
  "description": "Fresh seasonal dishes for summer",
  "sections": [
    {
      "id": "8c9e6679-7425-40de-944b-e07fc1f90ae8",
      "name": "Appetizers",
      "description": "Light starters",
      "items": [
        {
          "id": "9c9e6679-7425-40de-944b-e07fc1f90ae9",
          "name": "Summer Salad",
          "description": "Fresh mixed greens with seasonal fruits",
          "price": 12.99
        }
      ]
    }
  ]
}
```

#### Get All Menus

```bash
curl -X GET http://localhost:5036/api/menus \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

Expected Response (200 OK):

```json
[
  {
    "id": "7c9e6679-7425-40de-944b-e07fc1f90ae7",
    "name": "Summer Special Menu",
    "description": "Fresh seasonal dishes for summer",
    "averageRating": 4.5,
    "sections": [
      {
        "id": "8c9e6679-7425-40de-944b-e07fc1f90ae8",
        "name": "Appetizers",
        "description": "Light starters",
        "items": [
          {
            "id": "9c9e6679-7425-40de-944b-e07fc1f90ae9",
            "name": "Summer Salad",
            "description": "Fresh mixed greens with seasonal fruits",
            "price": 12.99
          }
        ]
      }
    ]
  }
]
```

### Reservation Tests

#### Create Reservation

```bash
curl -X POST http://localhost:5036/api/reservations \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..." \
  -d '{
    "guestCount": 4,
    "reservationDateTime": "2024-03-20T19:00:00Z",
    "menuId": "7c9e6679-7425-40de-944b-e07fc1f90ae7"
  }'
```

Expected Response (201 Created):

```json
{
  "id": "1c9e6679-7425-40de-944b-e07fc1f90ae1",
  "guestCount": 4,
  "reservationDateTime": "2024-03-20T19:00:00Z",
  "status": "Pending",
  "menuId": "7c9e6679-7425-40de-944b-e07fc1f90ae7",
  "userId": "550e8400-e29b-41d4-a716-446655440000"
}
```

#### Get All Reservations

```bash
curl -X GET http://localhost:5036/api/reservations \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

Expected Response (200 OK):

```json
[
  {
    "id": "1c9e6679-7425-40de-944b-e07fc1f90ae1",
    "guestCount": 4,
    "reservationDateTime": "2024-03-20T19:00:00Z",
    "status": "Pending",
    "menuId": "7c9e6679-7425-40de-944b-e07fc1f90ae7",
    "userId": "550e8400-e29b-41d4-a716-446655440000"
  }
]
```

### Error Response Examples

#### Invalid Request (400 Bad Request)

```bash
curl -X POST http://localhost:5036/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "John",
    "lastName": "Doe",
    "email": "invalid-email",
    "password": "123"
  }'
```

Expected Response (400 Bad Request):

```json
{
  "error": {
    "code": "ValidationError",
    "message": "The request contains invalid data",
    "details": [
      {
        "field": "email",
        "message": "Invalid email format"
      },
      {
        "field": "password",
        "message": "Password must be at least 8 characters long"
      }
    ]
  }
}
```

#### Unauthorized Access (401 Unauthorized)

```bash
curl -X GET http://localhost:5036/api/menus
```

Expected Response (401 Unauthorized):

```json
{
  "error": {
    "code": "Unauthorized",
    "message": "Authentication is required",
    "details": []
  }
}
```

#### Resource Not Found (404 Not Found)

```bash
curl -X GET http://localhost:5036/api/menus/99999999-9999-9999-9999-999999999999 \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

Expected Response (404 Not Found):

```json
{
  "error": {
    "code": "NotFound",
    "message": "Menu with ID 99999999-9999-9999-9999-999999999999 not found",
    "details": []
  }
}
```

### Testing Tools

You can use these tools to test the API:

1. **cURL** (Command Line)

   - All examples above use cURL
   - Available on most operating systems
   - Good for quick tests and automation

2. **Postman**

   - Import this collection:

   ```json
   {
     "info": {
       "name": "BuberDinner API",
       "schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
     },
     "item": [
       {
         "name": "Authentication",
         "item": [
           {
             "name": "Register",
             "request": {
               "method": "POST",
               "url": "http://localhost:5036/api/auth/register",
               "body": {
                 "mode": "raw",
                 "raw": "{\n    \"firstName\": \"John\",\n    \"lastName\": \"Doe\",\n    \"email\": \"john.doe@example.com\",\n    \"password\": \"SecurePass123!\"\n}",
                 "options": {
                   "raw": {
                     "language": "json"
                   }
                 }
               }
             }
           }
         ]
       }
     ]
   }
   ```

3. **Swagger UI**
   - Available at `http://localhost:5036/swagger`
   - Interactive API documentation
   - Test endpoints directly from the browser

### Testing Best Practices

1. **Environment Setup**

   - Use a separate test database
   - Clear test data before each test
   - Use environment variables for configuration

2. **Test Data**

   - Use realistic but test-specific data
   - Avoid using production data
   - Clean up test data after tests

3. **Authentication**

   - Store test tokens securely
   - Test both authenticated and unauthenticated scenarios
   - Test token expiration and refresh

4. **Error Handling**

   - Test all error scenarios
   - Verify error messages and codes
   - Test rate limiting

5. **Performance**
   - Test response times
   - Monitor resource usage
   - Test under load

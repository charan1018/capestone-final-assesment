# Fracto Appointment System - API Documentation

## Overview
The Fracto Appointment System provides a comprehensive REST API for managing doctor appointments, user authentication, and healthcare services.

## Base URL
```
https://localhost:7001/api
```

## Authentication
The API uses JWT (JSON Web Token) authentication. Include the token in the Authorization header:
```
Authorization: Bearer <your-jwt-token>
```

## Endpoints

### Authentication

#### POST /auth/login
User login endpoint.

**Request Body:**
```json
{
  "email": "user@example.com",
  "password": "password123"
}
```

**Response:**
```json
{
  "isSuccess": true,
  "message": "Login successful",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiresAt": "2024-01-01T12:00:00Z",
  "user": {
    "id": "user-id",
    "firstName": "John",
    "lastName": "Doe",
    "email": "user@example.com",
    "roles": ["User"]
  }
}
```

#### POST /auth/register
User registration endpoint.

**Request Body:**
```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "user@example.com",
  "password": "Password123!",
  "confirmPassword": "Password123!",
  "address": "123 Main St",
  "city": "New York",
  "phoneNumber": "+1234567890",
  "dateOfBirth": "1990-01-01T00:00:00Z"
}
```

#### POST /auth/register-doctor
Doctor registration endpoint (Admin only).

**Request Body:**
```json
{
  "firstName": "Dr. Jane",
  "lastName": "Smith",
  "email": "doctor@example.com",
  "password": "Password123!",
  "confirmPassword": "Password123!",
  "licenseNumber": "MD123456",
  "biography": "Experienced cardiologist",
  "hospital": "City Hospital",
  "clinic": "Heart Care Clinic",
  "consultationFee": 150.00,
  "experienceYears": 10,
  "startTime": "09:00:00",
  "endTime": "17:00:00",
  "specializationId": 1
}
```

#### GET /auth/profile
Get current user profile (Authenticated).

#### POST /auth/logout
User logout (Authenticated).

### Doctors

#### GET /doctors
Get list of doctors with search and pagination.

**Query Parameters:**
- `city` (optional): Filter by city
- `specializationId` (optional): Filter by specialization
- `maxFee` (optional): Maximum consultation fee
- `minRating` (optional): Minimum rating
- `availableDate` (optional): Available date
- `page`: Page number (default: 1)
- `pageSize`: Items per page (default: 10)

**Response:**
```json
{
  "doctors": [
    {
      "id": "doctor-id",
      "firstName": "Dr. Jane",
      "lastName": "Smith",
      "email": "doctor@example.com",
      "specialization": {
        "id": 1,
        "name": "Cardiology"
      },
      "consultationFee": 150.00,
      "averageRating": 4.5,
      "totalRatings": 25
    }
  ],
  "totalCount": 50,
  "page": 1,
  "pageSize": 10,
  "totalPages": 5
}
```

#### GET /doctors/{id}
Get doctor details by ID.

#### POST /doctors
Create new doctor (Admin only).

#### PUT /doctors/{id}
Update doctor (Admin or Doctor).

#### DELETE /doctors/{id}
Delete doctor (Admin only).

#### GET /doctors/{id}/time-slots
Get available time slots for a doctor on a specific date.

**Query Parameters:**
- `date`: Date in YYYY-MM-DD format

#### GET /doctors/specializations
Get list of specializations.

### Appointments

#### GET /appointments
Get appointments with search and pagination (Authenticated).

**Query Parameters:**
- `patientId` (optional): Filter by patient
- `doctorId` (optional): Filter by doctor
- `status` (optional): Filter by status
- `fromDate` (optional): Filter from date
- `toDate` (optional): Filter to date
- `page`: Page number
- `pageSize`: Items per page

#### GET /appointments/{id}
Get appointment details (Authenticated).

#### POST /appointments
Create new appointment (Authenticated).

**Request Body:**
```json
{
  "doctorId": 1,
  "timeSlotId": 1,
  "appointmentDate": "2024-01-15T00:00:00Z",
  "appointmentTime": "10:00:00",
  "symptoms": "Chest pain",
  "notes": "Mild discomfort"
}
```

#### PUT /appointments/{id}
Update appointment (Authenticated).

#### DELETE /appointments/{id}
Cancel appointment (Authenticated).

#### POST /appointments/{id}/confirm
Confirm appointment (Doctor or Admin).

#### POST /appointments/{id}/complete
Complete appointment (Doctor or Admin).

### Ratings

#### GET /ratings
Get ratings with optional doctor filter.

#### GET /ratings/{id}
Get rating details.

#### POST /ratings
Create new rating (Authenticated).

**Request Body:**
```json
{
  "doctorId": 1,
  "appointmentId": 1,
  "ratingValue": 5,
  "review": "Excellent doctor, very professional"
}
```

#### PUT /ratings/{id}
Update rating (Authenticated).

#### DELETE /ratings/{id}
Delete rating (Authenticated or Admin).

#### GET /ratings/doctor/{doctorId}/stats
Get rating statistics for a doctor.

#### GET /ratings/my-ratings
Get current user's ratings (Authenticated).

## Data Models

### User
```json
{
  "id": "string",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "phoneNumber": "string",
  "address": "string",
  "city": "string",
  "dateOfBirth": "date",
  "profileImagePath": "string",
  "roles": ["string"]
}
```

### Doctor (extends User)
```json
{
  "licenseNumber": "string",
  "biography": "string",
  "hospital": "string",
  "clinic": "string",
  "consultationFee": "decimal",
  "experienceYears": "number",
  "isAvailable": "boolean",
  "startTime": "time",
  "endTime": "time",
  "specializationId": "number",
  "specialization": "Specialization",
  "averageRating": "number",
  "totalRatings": "number"
}
```

### Appointment
```json
{
  "id": "number",
  "patientId": "string",
  "patientName": "string",
  "doctorId": "string",
  "doctorName": "string",
  "specializationName": "string",
  "appointmentDate": "date",
  "appointmentTime": "time",
  "symptoms": "string",
  "notes": "string",
  "status": "AppointmentStatus",
  "createdAt": "datetime",
  "consultationFee": "decimal"
}
```

### AppointmentStatus Enum
- `0`: Pending
- `1`: Confirmed
- `2`: Completed
- `3`: Cancelled
- `4`: NoShow

## Error Responses

### Standard Error Format
```json
{
  "message": "Error description",
  "error": "Detailed error information"
}
```

### HTTP Status Codes
- `200`: Success
- `201`: Created
- `400`: Bad Request
- `401`: Unauthorized
- `403`: Forbidden
- `404`: Not Found
- `500`: Internal Server Error

## Rate Limiting
Currently, no rate limiting is implemented. Consider implementing rate limiting for production use.

## CORS
CORS is enabled for the following origins:
- http://localhost:4200
- https://localhost:4200

## Security
- JWT tokens expire after 24 hours
- Passwords must meet complexity requirements
- All sensitive endpoints require authentication
- Role-based access control implemented

## Testing
Use the integrated Swagger UI at `/swagger` for testing the API endpoints.









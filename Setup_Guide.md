# Fracto Appointment System - Setup Guide

## Prerequisites

Before you begin, ensure you have the following installed:

- **.NET 8.0 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Node.js 18+** - [Download here](https://nodejs.org/)
- **SQL Server** - LocalDB (comes with Visual Studio) or SQL Server Express
- **Visual Studio 2022** or **VS Code** with C# extension
- **Angular CLI** - Install with `npm install -g @angular/cli`

## Project Structure

```
fracto-appointment-system/
├── Backend/                 # ASP.NET Core Web API
│   ├── Fracto.API/         # Main API project
│   ├── Fracto.Core/        # Business logic & entities
│   ├── Fracto.Infrastructure/ # Data access & EF Core
│   └── Fracto.sln          # Solution file
├── Frontend/                # Angular application
│   ├── src/
│   ├── package.json
│   └── angular.json
├── Database/                # SQL scripts
└── Documentation/           # API docs & setup guides
```

## Backend Setup

### 1. Database Setup

1. **Create Database:**
   - Open SQL Server Management Studio or Azure Data Studio
   - Run the script: `Database/CreateDatabase.sql`
   - This creates the database and admin user

2. **Update Connection String:**
   - Open `Backend/Fracto.API/appsettings.json`
   - Update the `DefaultConnection` string to match your SQL Server instance

### 2. Build and Run Backend

1. **Open Solution:**
   ```bash
   cd Backend
   # Open Fracto.sln in Visual Studio
   # OR use command line:
   dotnet restore
   ```

2. **Run Migrations:**
   ```bash
   cd Fracto.API
   dotnet ef database update
   ```

3. **Start the API:**
   ```bash
   dotnet run
   ```

4. **Verify:**
   - API should be running at: `https://localhost:7001`
   - Swagger UI available at: `https://localhost:7001/swagger`

### 3. Backend Configuration

The backend is pre-configured with:
- JWT authentication
- CORS for Angular frontend
- Entity Framework Core
- Identity framework
- Swagger documentation

## Frontend Setup

### 1. Install Dependencies

```bash
cd Frontend
npm install
```

### 2. Configure Environment

1. **Update API URL:**
   - Open `src/environments/environment.ts`
   - Ensure `apiUrl` points to your backend: `https://localhost:7001/api`

### 3. Start Frontend

```bash
ng serve
```

- Frontend will be available at: `http://localhost:4200`

## Initial Setup

### 1. Create Admin User

1. **Register Admin:**
   - Use the API endpoint: `POST /auth/register-doctor`
   - Or create directly in database using the seed script

2. **Default Admin Credentials:**
   - Email: `admin@fracto.com`
   - Password: `Admin123!`

### 2. Test the System

1. **Backend Health Check:**
   - Visit: `https://localhost:7001/swagger`
   - Test authentication endpoints

2. **Frontend Navigation:**
   - Visit: `http://localhost:4200`
   - Navigate through the application

## Development Workflow

### Backend Development

1. **Add New Entities:**
   - Create models in `Fracto.Core/Entities/`
   - Add DbSet in `ApplicationDbContext`
   - Create migrations: `dotnet ef migrations add MigrationName`

2. **Add New Controllers:**
   - Create in `Fracto.API/Controllers/`
   - Follow existing patterns for authentication and authorization

3. **Add New Services:**
   - Create in `Fracto.API/Services/`
   - Register in `Program.cs` if needed

### Frontend Development

1. **Add New Components:**
   ```bash
   ng generate component features/feature-name/component-name
   ```

2. **Add New Services:**
   ```bash
   ng generate service core/services/service-name
   ```

3. **Add New Models:**
   - Create in `src/app/core/models/`

## Testing

### Backend Testing

```bash
cd Backend
dotnet test
```

### Frontend Testing

```bash
cd Frontend
ng test
```

## Deployment

### Backend Deployment

1. **Build for Production:**
   ```bash
   dotnet publish -c Release
   ```

2. **Deploy Options:**
   - Azure App Service
   - Docker containers
   - IIS on Windows Server

### Frontend Deployment

1. **Build for Production:**
   ```bash
   ng build --configuration production
   ```

2. **Deploy Options:**
   - Azure Static Web Apps
   - Netlify
   - Vercel
   - IIS

## Troubleshooting

### Common Issues

1. **Database Connection:**
   - Verify SQL Server is running
   - Check connection string in `appsettings.json`
   - Ensure database exists

2. **CORS Issues:**
   - Check CORS configuration in `Program.cs`
   - Verify frontend URL is in allowed origins

3. **JWT Issues:**
   - Check JWT secret key in `appsettings.json`
   - Verify token expiration settings

4. **Angular Build Issues:**
   - Clear node_modules: `rm -rf node_modules && npm install`
   - Clear Angular cache: `ng cache clean`

### Logs

- Backend logs: Check console output or application logs
- Frontend logs: Check browser console
- Database logs: Check SQL Server logs

## Security Considerations

1. **JWT Secret:**
   - Change the default JWT secret in production
   - Use strong, unique secrets

2. **Database:**
   - Use connection string encryption
   - Implement proper user permissions

3. **HTTPS:**
   - Always use HTTPS in production
   - Configure SSL certificates

4. **Input Validation:**
   - All inputs are validated on both frontend and backend
   - SQL injection protection via Entity Framework

## Performance Optimization

1. **Database:**
   - Add appropriate indexes
   - Use pagination for large datasets
   - Implement caching where appropriate

2. **API:**
   - Use async/await patterns
   - Implement response compression
   - Consider API versioning

3. **Frontend:**
   - Lazy load modules
   - Implement virtual scrolling for large lists
   - Use Angular OnPush change detection strategy

## Support

For additional support:
1. Check the API documentation
2. Review the code comments
3. Check existing issues in the repository
4. Create new issues with detailed descriptions

## Next Steps

After successful setup:
1. Explore the Swagger API documentation
2. Test user registration and login
3. Create sample doctors and appointments
4. Customize the UI and business logic
5. Add additional features as needed









# Northfield College Management System (CP-CMS) Implementation Summary

## 📁 Clean Folder Structure

```
CP-CMS-main/
├── backend/
│   └── NorthfieldCMS.API/
│       ├── Controllers/
│       │   ├── AuthController.cs          # Login, Register, Profile endpoints
│       │   ├── ChatbotController.cs       # Gemini AI endpoint (/api/chatbot/chat)
│       │   └── DataControllers.cs        # Users, Faculty, Students, Courses, Exams, Marks, Fees, Notifications, Materials
│       ├── Data/
│       │   └── ApplicationDbContext.cs    # EF Core DbContext with seed data
│       ├── DTOs/
│       │   └── AllDTOs.cs                 # Auth, User, Faculty, Student, Course, Exam, Fee, Chat DTOs
│       ├── Models/
│       │   └── DomainModels.cs            # Domain entities
│       ├── Services/
│       │   ├── IAuthService.cs & AuthService.cs              # JWT Token generation & BCrypt Password Hashing
│       │   └── IChatbotService.cs & GeminiChatbotService.cs  # Gemini API integration
│       ├── appsettings.json               # JWT Secret, Database Connection, and Gemini API Key
│       ├── Program.cs                     # Builder Services, EF Core, JWT Bearer, Swagger UI, CORS
│       └── NorthfieldCMS.API.csproj
│
└── frontend/
    ├── attendance.html
    ├── courses.html
    ├── dashboard.html
    ├── departments.html
    ├── exams.html
    ├── faculty.html
    ├── fees.html
    ├── login.html
    ├── marks-results.html
    ├── materials.html
    ├── notifications.html
    ├── profile.html
    ├── reports.html
    ├── settings.html
    ├── students.html
    ├── users.html
    └── js/
        ├── api.js                         # Centralized AJAX API client & JWT Token storage
        └── chatbot.js                     # Floating Gemini AI Chatbot Widget UI
```

---

## 🔑 Key Features Implemented

1. **ASP.NET Core Web API (.NET 10)**
   - High performance RESTful Web API project in `backend/NorthfieldCMS.API`.
   - Clean Architecture separation (Controllers, Services, Models, DTOs, Data).

2. **BCrypt Password Hashing + Salt**
   - Hashing passwords securely using `BCrypt.Net-Next` (`BCrypt.HashPassword` and `BCrypt.Verify`).

3. **JWT Authentication & Role-Based Authorization**
   - Signed JWT Bearer token generation with claims for **Admin**, **Faculty**, and **Student** roles.
   - Endpoint protection using `[Authorize]` and `[Authorize(Roles = "Admin,Faculty")]`.

4. **Entity Framework Core & Database Migration Setup**
   - `ApplicationDbContext` configured with EF Core.
   - Pre-seeded initial data for Admin, Faculty, Student, Courses, Departments, Exams, Fees, Notifications, and Materials.
   - ⚠️ **Migration commands were NOT executed** as requested, but EF Core context and models are 100% prepared for whenever you decide to run migration commands (`dotnet ef migrations add InitialCreate`).

5. **Swagger & Builder Services**
   - OpenAPI Swagger documentation enabled at `/swagger`.
   - Includes **Authorize** button in Swagger UI to test Bearer JWT tokens interactively.

6. **Gemini AI Chatbot Integration**
   - Gemini API Key configured in `appsettings.json`.
   - `GeminiChatbotService.cs` calls Google Gemini endpoint (`POST /api/chatbot/chat`).
   - Floating glassmorphism Chatbot widget UI embedded in `frontend/js/chatbot.js`.

7. **Dynamic Front-End AJAX Client**
   - `frontend/js/api.js` connects HTML pages dynamically to backend Web API endpoints via AJAX.
   - Stores JWT token in `localStorage`.

---

## 🚀 How to Run the Backend Web API

1. Open your terminal in the backend directory:
   ```bash
   cd backend/NorthfieldCMS.API
   ```
2. Start the ASP.NET Core Web API server:
   ```bash
   dotnet run
   ```
3. Access Swagger UI in your browser:
   ```
   http://localhost:5000/swagger
   ```

## 🔐 Pre-configured Demo Accounts (BCrypt Hashed)
- **Admin**: `admin@northfield.edu` / `admin123`
- **Faculty**: `meera.shah@northfield.edu` / `faculty123`
- **Student**: `riya.mehta@northfield.edu` / `student123`

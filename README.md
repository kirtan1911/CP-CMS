<div align="center">

  <!-- GLOWING TOP BANNER CARD -->
  <a href="https://github.com/kirtan1911/CP-CMS">
    <img src="https://capsule-render.vercel.app/api?type=waving&color=gradient&customColorList=14,24,34&height=220&section=header&text=Northfield%20CMS%20&fontSize=48&fontColor=ffffff&animation=twinkling&desc=Next-Gen%20AI-Powered%20Academic%20%26%20College%20ERP%20Portal&descSize=18&descAlignY=66" width="100%" alt="Northfield CMS Banner" />
  </a>

  <br><br>

  <!-- TECH STACK BADGES MATRIX -->
  <p align="center">
    <a href="https://dotnet.microsoft.com/"><img src="https://img.shields.io/badge/.NET-10.0-7c3aed?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 10"></a>
    <a href="https://dotnet.microsoft.com/"><img src="https://img.shields.io/badge/ASP.NET_Core-Web_API-22d3ee?style=for-the-badge&logo=dotnet&logoColor=black" alt="ASP.NET Core"></a>
    <a href="https://learn.microsoft.com/ef/core/"><img src="https://img.shields.io/badge/EF_Core-SQLite_DB-22c55e?style=for-the-badge&logo=sqlite&logoColor=white" alt="EF Core"></a>
    <a href="https://ai.google.dev/"><img src="https://img.shields.io/badge/Google_Gemini-AI_2.5-f59e0b?style=for-the-badge&logo=googlegemini&logoColor=white" alt="Gemini AI"></a>
    <a href="https://swagger.io/"><img src="https://img.shields.io/badge/Swagger-OpenAPI_v1-85EA2D?style=for-the-badge&logo=swagger&logoColor=black" alt="Swagger"></a>
    <a href="https://github.com/kirtan1911/CP-CMS"><img src="https://img.shields.io/badge/License-MIT-ef4444?style=for-the-badge" alt="MIT License"></a>
  </p>

  <!-- QUICK NAVIGATION PILLS -->
  <p align="center">
    <a href="#-overview"><b>✨ Overview</b></a> •
    <a href="#-key-features"><b>🚀 Features</b></a> •
    <a href="#-demo-credentials"><b>🔑 Demo Credentials</b></a> •
    <a href="#-architecture--end-to-end-request-lifecycle"><b>🏛 Architecture</b></a> •
    <a href="#-swagger-api-matrix"><b>📖 Swagger API</b></a> •
    <a href="#-gemini-ai-assistant"><b>🤖 AI Assistant</b></a> •
    <a href="#-quick-start-guide"><b>⚡ Quick Start</b></a>
  </p>

</div>

---

<a id="-overview"></a>
## ✨ Overview

> **Northfield College Management System (CP-CMS)** is a premium, full-stack Academic ERP platform designed for modern universities and colleges. Built with a high-performance **ASP.NET Core (.NET 10) RESTful Web API** backend, **Entity Framework Core with SQLite**, **JWT Bearer Authentication**, and an **Apple-inspired Liquid Glassmorphism UI**, CP-CMS includes a **Google Gemini-powered AI Chatbot** for instant academic Q&A.

<br>

<a id="-key-features"></a>
## 🚀 Key Features

<table width="100%">
  <tr>
    <td width="50%" valign="top">
      <div align="left">
        <h3>🔐 Authentication & Role Security</h3>
        <ul>
          <li><b>BCrypt Hashing:</b> Passwords hashed using salted BCrypt encryption.</li>
          <li><b>JWT Bearer Tokens:</b> Signed JWT tokens with role claims & 24h expiration.</li>
          <li><b>3-Role Access Control:</b> Tailored views for <b>Admin</b>, <b>Faculty</b>, and <b>Students</b>.</li>
        </ul>
      </div>
    </td>
    <td width="50%" valign="top">
      <div align="left">
        <h3>🤖 Google Gemini AI Assistant</h3>
        <ul>
          <li><b>Gemini 2.5 Flash API Integration:</b> Natural language response generation.</li>
          <li><b>Dedicated AI Page:</b> Fullscreen <code>chatbot.html</code> & floating widget.</li>
          <li><b>Context-Aware Engine:</b> Intelligent fallback responses for offline/demo modes.</li>
        </ul>
      </div>
    </td>
  </tr>
  <tr>
    <td width="50%" valign="top">
      <div align="left">
        <h3>📊 Academic & Operational ERP</h3>
        <ul>
          <li><b>Student & Faculty Management:</b> Real-time user directory & status tracking.</li>
          <li><b>Attendance & Exam Management:</b> Threshold checks, timetables, and results.</li>
          <li><b>Tuition Fee System:</b> Paid vs Pending fee breakdown per course.</li>
        </ul>
      </div>
    </td>
    <td width="50%" valign="top">
      <div align="left">
        <h3>🎨 Liquid Glassmorphism UI</h3>
        <ul>
          <li><b>Modern Glass Skins:</b> Translucent blurred panels, ambient glowing drifting light.</li>
          <li><b>Dynamic AJAX Client:</b> Centralized <code>api.js</code> connecting UI directly to Web API.</li>
          <li><b>Fully Responsive:</b> Mobile drawer sidebar & desktop dashboard.</li>
        </ul>
      </div>
    </td>
  </tr>
</table>

<br>

<a id="-demo-credentials"></a>
## 🔑 Pre-Seeded Demo Accounts

Test the system instantly using any of the pre-configured accounts below:

| Role | Full Name | Email Address | Password | Privileges & Capabilities |
| :--- | :--- | :--- | :--- | :--- |
| <img src="https://img.shields.io/badge/ADMIN-7c3aed?style=for-the-badge&logoColor=white" alt="Admin Badge"> | **Prof. Rajesh Kumar** | `admin@northfield.edu` | `admin123` | Full system control, user creation, course & department setup |
| <img src="https://img.shields.io/badge/FACULTY-22d3ee?style=for-the-badge&logoColor=black" alt="Faculty Badge"> | **Dr. Meera Shah** | `meera.shah@northfield.edu` | `faculty123` | Exam scheduling, attendance marking, student result entry |
| <img src="https://img.shields.io/badge/STUDENT-22c55e?style=for-the-badge&logoColor=white" alt="Student Badge"> | **Riya Mehta** | `riya.mehta@northfield.edu` | `student123` | View enrolled courses, check attendance %, fee dues & exam dates |

<br>

<a id="-architecture--end-to-end-request-lifecycle"></a>
## 🏛 Architecture & End-to-End Request Lifecycle

### 1️⃣ High-Level System Architecture

```mermaid
flowchart LR
    classDef client fill:#1e1b4b,stroke:#7c3aed,stroke-width:2px,color:#fff;
    classDef api fill:#083344,stroke:#22d3ee,stroke-width:2px,color:#fff;
    classDef auth fill:#14532d,stroke:#22c55e,stroke-width:2px,color:#fff;
    classDef db fill:#451a03,stroke:#f59e0b,stroke-width:2px,color:#fff;
    classDef ai fill:#701a75,stroke:#e879f9,stroke-width:2px,color:#fff;

    Client["🎨 Web Frontend<br>(HTML5 / CSS3 / JS / AJAX)"]:::client
    API["⚡ ASP.NET Core 10 Web API<br>(NorthfieldCMS.API)"]:::api
    Auth["🔐 AuthService<br>(BCrypt + JWT Bearer)"]:::auth
    EF["🗄️ EF Core DbContext<br>(SQLite Engine)"]:::db
    Gemini["🤖 GeminiChatbotService<br>(Google Gemini API)"]:::ai

    Client -->|AJAX JSON Request| API
    API -->|Authenticate Claims| Auth
    API -->|Query / Mutate| EF
    API -->|Send Prompt| Gemini
```

<br>

### 2️⃣ Step-by-Step Request & Response Sequence Flow

```mermaid
sequenceDiagram
    autonumber
    actor User as 👤 Client (Browser)
    participant UI as 🎨 AJAX Client (api.js)
    participant API as ⚡ Web API (.NET 10)
    participant JWT as 🔐 Auth & Claims
    participant EF as 🗄️ EF Core (SQLite)
    participant AI as 🤖 Gemini AI Service

    Note over User, AI: 🔄 PHASE 1: Authentication & Token Generation (POST Request)
    User->>UI: Submit Login Form (Email & Password)
    UI->>API: 📩 POST /api/auth/login { email, password }
    API->>JWT: Validate Credentials & Verify BCrypt Hash
    JWT-->>API: Issue Signed JWT Token (24h Expiry)
    API-->>UI: 📤 200 OK Response { token: "eyJhbG...", role: "Student" }
    UI->>UI: Store Token in LocalStorage

    Note over User, AI: 🔄 PHASE 2: Data Fetching with Bearer Token (GET Request)
    User->>UI: Navigate to Courses / Exam Schedule
    UI->>API: 📩 GET /api/courses (Header: Authorization: Bearer <Token>)
    API->>JWT: Validate JWT Signature & Roles
    API->>EF: Query Courses DbSet from SQLite
    EF-->>API: Return IEnumerable<Course>
    API-->>UI: 📤 200 OK Response [ { code: "CS501", name: "DBMS" } ]
    UI->>User: Render Glassmorphism Data Cards

    Note over User, AI: 🔄 PHASE 3: AI Chatbot Query Stream (POST Request)
    User->>UI: Ask: "When do Mid-Semester exams start?"
    UI->>API: 📩 POST /api/chatbot/chat { message, context }
    API->>AI: Send Prompt to Gemini 2.5 API
    AI-->>API: Return AI Reply Text
    API-->>UI: 📤 200 OK Response { reply: "Mid-Semester exams begin Aug 20, 2026..." }
    UI->>User: Stream Live Chat Bubble
```

<br>

<a id="-swagger-api-matrix"></a>
## 📖 Swagger API Matrix

Explore and test all RESTful Web API endpoints interactively at `http://localhost:5116/swagger`:

| Method | Endpoint | Authorization | Description |
| :---: | :--- | :---: | :--- |
| <img src="https://img.shields.io/badge/POST-7c3aed?style=for-the-badge" alt="POST"> | `/api/auth/login` | Public | Authenticates user & issues signed JWT Token |
| <img src="https://img.shields.io/badge/POST-7c3aed?style=for-the-badge" alt="POST"> | `/api/auth/register` | Public | Registers new system user account |
| <img src="https://img.shields.io/badge/GET-22c55e?style=for-the-badge" alt="GET"> | `/api/auth/me` | <img src="https://img.shields.io/badge/Bearer_JWT-22d3ee?style=flat" alt="JWT"> | Returns current authenticated user claims |
| <img src="https://img.shields.io/badge/GET-22c55e?style=for-the-badge" alt="GET"> | `/api/users` | Public | Retrieves system users list |
| <img src="https://img.shields.io/badge/POST-7c3aed?style=for-the-badge" alt="POST"> | `/api/users` | <img src="https://img.shields.io/badge/Admin-7c3aed?style=flat" alt="Admin"> | Creates new system user |
| <img src="https://img.shields.io/badge/GET-22c55e?style=for-the-badge" alt="GET"> | `/api/students` | Public | Retrieves enrolled students list |
| <img src="https://img.shields.io/badge/GET-22c55e?style=for-the-badge" alt="GET"> | `/api/faculty` | Public | Retrieves faculty members list |
| <img src="https://img.shields.io/badge/GET-22c55e?style=for-the-badge" alt="GET"> | `/api/courses` | Public | Retrieves academic courses catalog |
| <img src="https://img.shields.io/badge/GET-22c55e?style=for-the-badge" alt="GET"> | `/api/departments` | Public | Retrieves college departments |
| <img src="https://img.shields.io/badge/GET-22c55e?style=for-the-badge" alt="GET"> | `/api/exams` | Public | Retrieves examination timetables |
| <img src="https://img.shields.io/badge/GET-22c55e?style=for-the-badge" alt="GET"> | `/api/fees` | Public | Retrieves student fee payment status |
| <img src="https://img.shields.io/badge/GET-22c55e?style=for-the-badge" alt="GET"> | `/api/materials` | Public | Retrieves uploaded course study materials |
| <img src="https://img.shields.io/badge/POST-7c3aed?style=for-the-badge" alt="POST"> | `/api/chatbot/chat` | Public | Submits prompt to Gemini AI Chatbot |

<br>

<a id="-gemini-ai-assistant"></a>
## 🤖 Dedicated Gemini AI Assistant Page

Access the dedicated AI Chatbot interface at `frontend/chatbot.html`:

- **Quick Action Prompt Chips:** Instant answers for Exam Timetables, Attendance Percentage, Fee Payments, and Faculty Info.
- **Typing Indicators:** Visual animated loading state during response generation.
- **Smart Fallback Engine:** Offline context processing ensuring uninterrupted uptime even without active network keys.

<br>

<a id="-quick-start-guide"></a>
## ⚡ Quick Start Guide

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/kirtan1911/CP-CMS.git
cd CP-CMS
```

### 2️⃣ Run ASP.NET Core Web API
```bash
cd backend/NorthfieldCMS.API
dotnet run --urls "http://localhost:5116"
```

### 3️⃣ Launch Web App & Swagger
- **Swagger Documentation:** Open `http://localhost:5116/swagger`
- **Web Frontend:** Open `frontend/login.html` or `frontend/dashboard.html`
- **Dedicated AI Chatbot:** Open `frontend/chatbot.html`

<br>

<a id="-project-structure"></a>
## 📁 Project Folder Structure

```
CP-CMS/
├── backend/
│   └── NorthfieldCMS.API/
│       ├── Controllers/          # Auth, Chatbot & Data Controllers
│       ├── Data/                 # EF Core DbContext & Seed Data
│       ├── DTOs/                 # Request & Response Data Transfer Objects
│       ├── Models/               # Domain Models & Entities
│       ├── Services/             # AuthService & GeminiChatbotService
│       ├── Properties/           # launchSettings.json
│       ├── Program.cs            # Builder Services, Middleware & Swagger Setup
│       └── appsettings.json      # JWT Secret & Connection Config
│
├── frontend/
│   ├── login.html                # Auth Screen (Login & Register)
│   ├── dashboard.html            # Main Overview Dashboard
│   ├── chatbot.html              # Dedicated Gemini AI Assistant Page
│   ├── students.html             # Student Management
│   ├── faculty.html              # Faculty Management
│   ├── courses.html              # Course Management
│   ├── attendance.html           # Attendance Tracking
│   ├── exams.html                # Exam Timetable & Schedule
│   ├── marks-results.html        # Academic Marks & Results
│   ├── fees.html                 # Tuition Fee Records
│   ├── materials.html            # Study Materials Repository
│   ├── notifications.html        # System Notices & Alerts
│   └── js/
│       ├── api.js                # Centralized AJAX Client
│       └── chatbot.js            # Floating Chatbot Widget UI
│
├── .gitignore                    # Git Ignore Rules
└── README.md                     # Documentation
```

---

<div align="center">
  <br>
  <p>Crafted with ❤️ by <b>Kirtan Barot</b></p>
  <p><a href="https://github.com/kirtan1911/CP-CMS">⭐ <b>Star CP-CMS on GitHub</b></a> if you love this project!</p>
  <br>
</div>

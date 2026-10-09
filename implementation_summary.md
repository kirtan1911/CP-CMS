# 🚀 Northfield CMS — Electron Desktop Application & OTP Authentication

## 📌 Implementation Summary

### 1️⃣ Electron Windows Desktop Executable (`.exe`)
The application has been packaged into standalone Microsoft Windows executable `.exe` files:

* 📦 **Setup Installer:** [`dist/Northfield CMS Setup 1.0.0.exe`](file:///c:/Users/kirtan%20barot/Downloads/CP-CMS-main/CP-CMS-main/dist/Northfield%20CMS%20Setup%201.0.0.exe)
* 🚀 **Portable Standalone Executable:** [`dist/Northfield CMS 1.0.0.exe`](file:///c:/Users/kirtan%20barot/Downloads/CP-CMS-main/CP-CMS-main/dist/Northfield%20CMS%201.0.0.exe)
* 📁 **Unpacked Executable Directory:** [`dist/win-unpacked/Northfield CMS.exe`](file:///c:/Users/kirtan%20barot/Downloads/CP-CMS-main/CP-CMS-main/dist/win-unpacked/Northfield%20CMS.exe)

#### Features of the Electron Desktop App:
1. **Self-Contained Backend (.NET 10 API):** Embeds `NorthfieldCMS.API.exe` inside `electron-app/bin/backend/` compiled for `win-x64`. No pre-installed .NET SDK required on target Windows machines.
2. **Auto Process Lifecycle Management:** When the Electron app starts, `main.js` automatically spawns the background API on port `5116`, waits for healthcheck verification, and terminates the background process on exit.
3. **Native Windows Integration:** Custom app window, native menus, icon branding, DevTools toggle (`F12`), and Swagger API view shortcut.

---

### 2️⃣ OTP-Based Authentication & Forgot Password
Extracted & integrated OTP Password Reset flow from `FrontEnd-CM` and `CollegeManagement`:

* 🗄️ **Database Model:** [`PasswordResetOtp.cs`](file:///c:/Users/kirtan%20barot/Downloads/CP-CMS-main/CP-CMS-main/backend/NorthfieldCMS.API/Models/PasswordResetOtp.cs) for storing 6-digit OTP codes with 5-minute expiration windows.
* 📩 **DTO Contracts:** [`OtpDtos.cs`](file:///c:/Users/kirtan%20barot/Downloads/CP-CMS-main/CP-CMS-main/backend/NorthfieldCMS.API/DTOs/OtpDtos.cs) (`ForgotPasswordDto`, `VerifyOtpDto`, `ResetPasswordDto`, `ResendOtpDto`).
* ⚡ **Web API Endpoints:** [`AuthController.cs`](file:///c:/Users/kirtan%20barot/Downloads/CP-CMS-main/CP-CMS-main/backend/NorthfieldCMS.API/Controllers/AuthController.cs):
  - `POST /api/auth/forgot-password` (Generates random 6-digit OTP code)
  - `POST /api/auth/verify-otp` (Validates non-expired OTP code)
  - `POST /api/auth/reset-password` (Hashes and updates BCrypt password)
  - `POST /api/auth/resend-otp` (Triggers fresh OTP dispatch)
* 🎨 **AJAX Client Integration:** [`api.js`](file:///c:/Users/kirtan%20barot/Downloads/CP-CMS-main/CP-CMS-main/frontend/js/api.js) supporting seamless background AJAX queries.

---

### ⚡ Quick Commands

#### Run Electron App in Development:
```powershell
npm start
```

#### Re-build Windows Executable Setup:
```powershell
npm run dist
```

# ThesisMate 🎓

**ThesisMate** is a web-based Research Proposal Management System designed to streamline the process of proposal submission, review, and approval between students and academic supervisors. The platform offers secure role-based access and user-friendly interfaces for managing academic research workflows efficiently.

---

## 📌 Project Description

ThesisMate bridges the gap between students and supervisors by providing a centralized system for handling research proposals. Students can upload, view, and track the status of their proposals, while supervisors can review, accept, or reject submissions through a simple and intuitive dashboard.

---

## ✨ Features

### 🔐 Authentication & Authorization
- Session-based authentication
- Custom `RoleAuthorization("Admin")` attribute for secure role access
- Role types: **Admin**, **Supervisor**, **Student**

### 📥 Proposal Management
- Students can:
  - Submit proposals (PDF format)
  - View current status: Pending, Accepted, or Denied
- Supervisors can:
  - View proposals from assigned students
  - Accept or reject proposals
  - Provide proposal status updates

### 🧾 PDF Viewing
- In-browser proposal preview using **PDF.js**
- Modal-based proposal viewer for seamless UX

### 👩‍🏫 Supervisor Dashboard
- List of supervised students
- Easy access to student profiles and proposals

### 📊 Admin Panel
- Manage users and roles
- Restricted access using role-based authorization

---

## 🛠 Tech Stack

### ⚙️ Backend
- ASP.NET Core MVC (C#)
- Entity Framework Core
- SQL Server

### 🖼 Frontend
- Bootstrap 5
- JavaScript & jQuery
- Razor Pages

### 📦 Libraries & Tools
- PDF.js (for rendering PDF proposals in-browser)
- SweetAlert (optional: for confirmation alerts)

---

## 🚀 Future Features

- ✅ Email notifications on proposal status changes
- 📝 Comment section for proposal feedback
- 📄 Proposal versioning and history
- 🔎 Search and filter proposals
- 🌍 Support for multiple institutions
- 📊 Dashboard with proposal analytics and graphs
- 🔐 OAuth / IdentityServer for scalable auth

---



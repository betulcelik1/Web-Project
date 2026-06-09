#  GAMBL — Online Learning Management System

> A full-stack web application for online education, built with .NET Core MVC and Entity Framework.

---

## Overview

**GAMBL** is an online learning platform that connects students with instructors and courses. Users can register, browse courses, enroll, and track their learning progress — all through a clean and responsive web interface.

This project was developed as a university web programming assignment by a team of five students.

---

## Features

### For Students
- Register and log in securely via **.NET Core Identity**
- Browse all available courses on the homepage
- View detailed course pages with lesson listings and content
- Track enrollment status: *Start*, *Continue*, or *Completed*
- Personal account page with enrolled courses overview

### For Instructors
- Dedicated instructor profile pages
- Display of all courses offered by each instructor

### General
- Course and instructor image serving with automatic placeholder fallback
- Form validation for registration and enrollment (required fields, email format, password length)
- Dynamic content rendering with `ViewBag` and `ViewData`

---

##  Tech Stack

| Layer          | Technology                              |
|----------------|-----------------------------------------|
| Framework      | .NET Core MVC                           |
| ORM / Database | Entity Framework Core (Code-First)      |
| Database       | SQLite                                  |
| Authentication | .NET Core Identity                      |
| Frontend       | Razor Views, Bootstrap, JavaScript, CSS |
| Templating     | Tag Helpers                             |

---

##  Project Structure

```
Gambl/
├── Controllers/
│   ├── HomeController.cs        # Homepage, instructor list, image serving
│   ├── CourseController.cs      # Course listing, details, content
│   └── LoginController.cs       # Login & signup
├── Models/
│   ├── UserInfo.cs
│   ├── CourseInfo.cs
│   ├── LessonInfo.cs
│   ├── ContentInfo.cs
│   ├── InstructorCoursesViewModel.cs
│   ├── CouseBuy.cs
│   └── InstructorInfo.cs
├── Data/
│   └── DataContext.cs           # EF Core DbContext
├── Views/
│   ├── Home/                    # Index, Instructor, MyAccount...
│   ├── Course/                  # CourseContent, Details...
│   ├── Login/                   # Index, Singup, Admission 
│   └── Shared/                  # _Layout.cshtml
├── Migrations/
└── wwwroot/
    ├── css/
    ├── js/
    └── img/
```

---

## Database Schema

The application uses a **Code-First** approach with the following core tables:

| Table             | Description                  |
|-------------------|------------------------------|
| `UserInfos`       | Registered user accounts     |
| `CourseInfos`     | Course metadata and images   |
| `LessonInfos`     | Lessons linked to courses    |
| `ContentInfos`    | Content within each lesson   |
| `InstructorInfos` | Educator profiles and images |

---

## Getting Started

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download) or later
- Git

### Installation

```bash
# 1. Clone the repository
git clone https://github.com/betulcelik1/Web-Project.git
cd Web-Project

# 2. Restore dependencies
dotnet restore

# 3. Apply database migrations
dotnet ef database update

# 4. Run the application
dotnet run
```

Then open your browser and navigate to `https://localhost:5001` (or the port shown in your terminal).

---

## Key Controllers & Actions

### `HomeController`
| Action               | Route                           | Description                            |
|----------------------|---------------------------------|----------------------------------------|
| `Index`              | `/`                             | Homepage — lists all courses           |
| `MyAccount`          | `/Home/MyAccount`               | User profile & enrolled courses        |
| `InstructorList`     | `/Home/InstructorList`          | All instructors                        |
| `Instructor`         | `/Home/Instructor/{id}`         | Single instructor detail               |
| `GetCourseImage`     | `/Home/GetCourseImage/{id}`     | Serves course image or placeholder     |
| `GetInstructorImage` | `/Home/GetInstructorImage/{id}` | Serves instructor image or placeholder |

### `CourseController`
| Action          | Route                        | Description                |
|-----------------|------------------------------|----------------------------|
| `Index`         | `/Course`                    | All courses                |
| `Details`       | `/Course/Details/{id}`       | Course detail with lessons |
| `CourseContent` | `/Course/CourseContent/{id}` | Specific lesson content    |

### `LoginController`
| Action   | Route           | Description       |
|----------|-----------------|-------------------|
| `Login`  | `/Login`        | Login form        |
| `Signup` | `/Login/Signup` | Registration form |

---

## Team

| Name 
|------------------
| Leen Husseini 
| Ayşe Zeynep Turan 
| Mehmet Kerem Çay 
| Gökay Yılmaz 
| Betül Çelik 

---

## License

This project was developed for academic purposes. All rights reserved by the project team.

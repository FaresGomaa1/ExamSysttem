---

```markdown
# 📝 Online Exam System (Admin Panel & User Website)

This project is a **mini online exam system** built with **ASP.NET Core MVC**, **Entity Framework Core**, and **ASP.NET Identity**. It enables administrators to manage exams and questions, and allows users to take exams and view their results.

---

## 🚀 Features

### 👨‍💼 Admin Panel
- Secure login for administrators
- Create, edit, and delete exams
- Add, edit, and delete questions with 4 choices and one correct answer
- Manually add users to the system

### 👤 User Website
- Login with credentials (pre-added by admin)
- View list of available exams
- Take multiple-choice exams
- Submit answers via AJAX for a smooth experience
- View detailed results including:
  - Score percentage
  - Number of correct and incorrect answers
  - Pass/Fail status
  - Review of selected answers

### 🧠 Exam Evaluation Logic
- Each question is worth 1 point
- Final Score = `(Correct Answers / Total Questions) * 100`
- Passing threshold: **60%**

---

## 🧱 Tech Stack

- **Backend**: ASP.NET Core MVC (.NET 8+), Entity Framework Core, ASP.NET Identity
- **Frontend**: Razor Views, Bootstrap, jQuery/AJAX
- **Database**: SQL Server (LocalDB or full SQL Server)
- **Authentication**: ASP.NET Identity with pre-created users

---

## 📁 Project Structure

```
ExamSysttem/
├── Controllers/
├── Models/
├── Data/
│   └── ApplicationDbContext.cs
├── Views/
│   └── Admin, Exam, Account, Shared, etc.
├── wwwroot/
├── Migrations/
├── appsettings.json
└── Program.cs
```

---

## ⚙️ Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/online-exam-system.git
   cd online-exam-system
   ```

2. **Update the database**
   ```bash
   dotnet ef database update
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Login with predefined user**
   - Default admin/user credentials should be seeded manually or via migration

---

## 📌 Important Notes

- No user self-registration — all users are added manually by the admin
- The project uses clean architecture with a separation of concerns
- Cascading deletes are restricted to avoid multiple cascade paths in the database

---

## 📈 Future Enhancements

- Add roles for admin/user and role-based authorization
- Add question categories or tags
- Include exam time limits and timers
- Add PDF result export or printable certificates

---

## 📄 License

This project is open for learning and educational use. Free to use and extend.

---

**Made with ❤️ by Fares Gomaa**
```

---

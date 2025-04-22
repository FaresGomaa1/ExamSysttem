# Online Exam System

## Project Overview
This project is a mini online exam system consisting of two main sections:
1. **Admin Panel**: A secure area for administrators to manage exams and questions.
2. **User Website**: A public-facing section where registered users can log in, take exams, and view their scores.

The system is built using ASP.NET Core (MVC, Razor Pages, or Blazor) and Entity Framework Core, with authentication handled through ASP.NET Identity.

## Key Features
### Admin Panel
- **Authentication**: Admins log in using ASP.NET Identity.
- **Exam Management**: Create, edit, and delete exams.
- **Question Management**: Add, edit, and delete questions for each exam. Each question includes:
  - A title.
  - Four choices.
  - A correct answer.
- **User Management**: Manually add users to the database (no self-registration).

### User Website
- **Login**: Users log in with credentials manually added to the database.
- **Exam Selection**: View and select available exams.
- **Exam Participation**: Take exams by answering multiple-choice questions.
- **Score Viewing**: Submit exams and view scores.

### Exam Evaluation Criteria
- Each question is worth 1 point.
- The final score is calculated as:
  $$
  \text{Score} = \left(\frac{\text{Correct Answers}}{\text{Total Questions}}\right) \times 100
  $$
- Passing percentage is 60%. The evaluation screen displays:
  - Total score (in percentage).
  - Number of correct vs. incorrect answers.
  - Pass/Fail status.

## Technical Requirements
### Backend
- **Framework**: ASP.NET Core (MVC, Razor Pages, or Blazor).
- **Database Handling**: Entity Framework Core.
- **Authentication**: ASP.NET Identity.
- **Structure**: Repository Pattern (preferred).
- **Database Management**: Use Migrations.

### Frontend
- **UI Interactions**: JavaScript (Vanilla JS or jQuery).
- **Styling**: Bootstrap (or Tailwind CSS).
- **Form Submission**: AJAX for submitting exam answers without page reloads.

### Database
- **Type**: SQL Server (or In-Memory DB for simplicity).
- **Design**: Design the database structure based on the requirements.
- **Management**: Use EF Core Migrations.

## Installation
1. Clone the repository from GitHub:
   ```bash
   git clone https://github.com/yourusername/online-exam-system.git
   ```
2. Navigate to the project directory:
   ```bash
   cd online-exam-system
   ```
3. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```
4. Update the database using EF Core Migrations:
   ```bash
   dotnet ef database update
   ```
5. Run the project:
   ```bash
   dotnet run
   ```

## Usage
### Admin Panel
1. Log in using admin credentials.
2. Manage exams and questions through the admin interface.
3. Manually add users to the database.

### User Website
1. Log in using user credentials.
2. Select and take available exams.
3. Submit exams and view scores.

## Contributing
1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature-branch
   ```
3. Make your changes and commit them:
   ```bash
   git commit -m "Add new feature"
   ```
4. Push to the branch:
   ```bash
   git push origin feature-branch
   ```
5. Create a pull request.

## License
This project is licensed under the MIT License.

## Contact
For any questions or feedback, please contact [your email].

```

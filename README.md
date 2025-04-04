# GradeTracker

A **Grade Tracker** website built for **McMaster University's Software Engineering Level 3** students.  
Easily track, calculate, and manage your academic performance all in one place.

[Live Site](https://sfwreng3tracker.azurewebsites.net/)

---

## Features

- View and track grades across different courses
- Automatic GPA calculation
- Organized course management
- Simple, clean, and intuitive UI
- Deployed on Azure for live access

---

## Tech Stack

- **Frontend**:
    - HTML
    - CSS
    - JavaScript

- **Backend**:
    - C# (.NET Framework)

- **Hosting**:
    - Microsoft Azure

---

## Project Structure

```bash
GradeTracker/
├── .vs/               # Visual Studio specific files
├── GradeTracker/      # Main web project (pages, styles, logic)
│    ├── App_Code/     # Backend C# logic
│    ├── Styles/       # CSS stylesheets
│    ├── Scripts/      # JavaScript files
│    ├── Default.aspx  # Main landing page
│    └── ...           # Other .aspx pages
├── .gitignore         # Git ignored files
├── GradeTracker.sln   # Visual Studio solution file
└── .DS_Store          # (macOS file, can be ignored)
```

---

## Getting Started

### Prerequisites

- Visual Studio 2022 (or later) with .NET support
- Azure account (optional, for deployment)
- Git

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/zayedu/GradeTracker.git
   ```

2. Open the Solution:  
   Launch `GradeTracker.sln` in Visual Studio.

3. Run the project:  
   Press `F5` to build and run locally.

4. (Optional) Deploy to Azure:
    - Right-click the project → Publish → Azure App Service.

---

## Usage

- Access the home page
- Add your courses and grades
- View updated GPA and progress instantly

Designed for students who want a fast, simple way to monitor academic performance.

---

## Security and Data Storage

GradeTracker uses **browser cookies** to store grades and course information **locally** on the user's device.  
There is **no centralized database** and **no user authentication system** required.

Benefits of this approach:
- Users maintain full control over their data
- No sensitive academic information is transmitted or stored on external servers
- Simplifies deployment by removing the need for backend authentication or database management
- Reduces potential security risks associated with external data breaches

This design keeps the application lightweight, private, and user-friendly.

---

## Contributing

Contributions are welcome and appreciated.  
Feel free to open a pull request or submit an issue.

> Please ensure any pull requests follow clean code practices and include appropriate testing where necessary.

---

## Contact

For questions or suggestions:  
**Zayed** – [GitHub Profile](https://github.com/zayedu)

---

## Acknowledgements

- McMaster University
- Visual Studio and Azure teams
- Open-source community

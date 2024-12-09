# Bug Tracker (in-progress) 🐞

A full-stack bug-tracking application leveraging the ASP.NET Core MVC framework. This application streamlines project and ticket management, offering role-based access, real-time notifications, and a user-friendly interface tailored for efficient software issue tracking.

## Features

- **Project Management**: Create and manage multiple projects with associated tickets.
- **Ticket Management**: Add, edit, assign, and track bug tickets through various stages.
- **Role-Based Access Control**: Secure user access based on roles to ensure organized management. Supports 5 roles: Admin, Project Manager, Developer, Submitter, and Demo User.
- **Notifications**: Stay updated with in-app notifications for ticket updates.
- **File Uploads**: Attach files directly to tickets for better context.
- **Email Integration**: Send email notifications for important updates.
- **Customizable Priorities and Statuses**: Define ticket priorities (Low, Medium, High, Urgent) and statuses (New, Development, Testing, Resolved) to fit your workflow.

## Workflow Description

The Bug Tracker application is built using the ASP.NET Core MVC framework, adhering to the Model-View-Controller (MVC) pattern. The workflow is structured as follows:

### 1. Controller Layer
- Handles HTTP requests and routes them to specific actions.
- Maps incoming requests to appropriate controllers, such as `TicketsController`, `ProjectsController`, and `UsersController`.
- Implements CRUD operations for entities like tickets, projects, and notifications, ensuring modularity and maintainability.

### 2. Service Layer
Encapsulates business logic into modular services, simplifying controller responsibilities and enhancing testability. Examples include:

- **BTFileService**:
  - Validates, processes, and stores file attachments for tickets.
  - Ensures files meet size and format constraints before uploading.

- **BTEmailService**:
  - Sends automated email notifications for ticket assignments, project updates, and user invitations.

- **BTLookupService**:
  - Provides data-driven utilities for filtering tickets by priority, status, or assigned user.
  - Powers advanced search and dropdown functionalities in the user interface.

### 3. Model Layer
- Defines entity relationships and data structures for Users, Tickets, Projects, and Notifications.
- Uses Entity Framework Core to interact seamlessly with the PostgreSQL database.
- Models include validations and relationships such as foreign keys between tickets and their assigned users or projects.

### 4. View Layer
- Utilizes Razor Pages to render dynamic, responsive user interfaces.
- Displays ticket and project lists tailored to user roles. For example:
  - Developers see tickets assigned to them, while Admins have access to all data.
- Integrates Bootstrap for a user-friendly and visually consistent design.

### 5. Database Layer
- Powered by PostgreSQL, with schema optimized for high performance and scalability.
- Implements `UseQuerySplittingBehavior` to handle related data retrieval efficiently. This approach splits complex queries into smaller, manageable parts, reducing query execution time and improving performance for larger datasets.
- Indexed frequently queried fields, such as ticket priorities and project statuses, to further enhance query speed.
  - **Example**: Fetching 100 tickets, 5 projects, and 20+ users completes in under 10ms, ensuring a seamless user experience.

### 6. Role-Based Access Control
- Enforces secure and organized workflows by restricting access based on roles:
  - **Admin**: Full control over all modules, including managing users and projects.
  - **Project Manager**: Manages projects and assigns tickets.
  - **Developer**: Updates tickets assigned to them, adds comments, and uploads files.
  - **Submitter**: Creates and views tickets but cannot modify or delete them.
  - **Demo User**: Read-only access for exploring the application.
- Access is enforced dynamically at the controller and view levels, ensuring data security.

## Tech Stack

- **C#**
- **ASP.NET**
- **PostgreSQL**
- **JavaScript**

# EventHub

**EventHub** is a web application designed to manage events with role-based functionality. The system supports three types of users:

- **User** – can browse, participate in events, leave reviews, and report inappropriate content.
- **Event Organizer** – can create, edit, and manage their own events.
- **Admin** – has the authority to manage reported events and moderate content.

## Key Features

- User registration with email confirmation
- Role-based access control (Admin, Event Organizer, User)
- Event creation and management
- Event participation and reviews
- Reporting inappropriate events
- Admin moderation tools

## Technology Stack

- **ASP.NET Core MVC** – for building the web application using the Model-View-Controller pattern
- **Entity Framework Core** – for ORM and database access
- **SQL Server** – as the relational database
- **ASP.NET Identity** – for authentication and role management
- **SendGrid** – for sending email notifications (e.g., registration, role changes)
- **Bootstrap** – for responsive UI design

## Project Structure

- `Areas/` – Contains admin and event organizer specific views and controllers
- `Controllers/` – Handles the routing and logic for the main application
- `Data/` – Contains the database context, models, enums, and data seeders
- `Business/` – Contains the business logic layer interfaces and implementations
- `Views/` – Razor views for UI rendering

## Notes

- Make sure your SMTP (SendGrid) settings are correct to enable email verification.
- Admin and Event Organizer dashboards are located under the `Areas/Admin` and `Areas/EventOrganizer` routes.

## Future improvements
- Adding pagination
- Adding sorting, filtering and searching
- Adding external logins

---

*Developed as a portfolio project to demonstrate ASP.NET Core MVC development skills.*

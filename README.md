# ClaimFlow

ClaimFlow is a web application built with ASP.NET Core that streamlines the process of submitting and managing claims. Whether you're a user submitting claims or an administrator handling requests, ClaimFlow ensures your workflow is seamless, efficient, and organized.

## Features

- **Easy Claim Submission**: Submit your claims through an intuitive form interface.
- **Track Progress**: Monitor your claim's status with real-time updates.
- **Notifications & Reminders**: Get notified about important updates regarding your claims.
- **User Roles**: Different access levels for users and administrators to manage claims.
- **Security**: Built-in security features including email confirmation and password protection.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [License](#license)

## Installation

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6 or later)
- [Visual Studio](https://visualstudio.microsoft.com/) (optional but recommended for development)
- A database server (SQL Server, PostgreSQL, etc.) configured for the application

### Steps

1. **Clone the repository**:
    ```bash
    git clone https://github.com/ST10294145/ClaimFlow.git
    ```

2. **Navigate to the project directory**:
    ```bash
    cd claimflow
    ```

3. **Install the required packages**:
    ```bash
    dotnet restore
    ```

4. **Apply the database migrations**:
    ```bash
    dotnet ef database update
    ```

5. **Run the application**:
    ```bash
    dotnet run
    ```

    The application will be available at `https://localhost:5001` or `http://localhost:5000`.

## Usage

- **Create an account**: Go to the registration page and create a new user account.
- **Submit a claim**: After logging in, use the "Create" option to submit a new claim.
- **Track claim status**: View and update the status of claims through your dashboard.
- **Admin Dashboard**: If you have admin privileges, you can manage user roles and claim statuses.

## Technologies Used

- **ASP.NET Core 6.0**: The web framework powering the application.
- **Entity Framework Core**: ORM for database management.
- **Bootstrap 4**: Frontend CSS framework for responsive design.
- **SQL Server**: Used as the database backend (can be switched to another database like PostgreSQL).
- **Identity Framework**: Used for user authentication and authorization.

## Contributing

Contributions are welcome! If you want to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a feature branch.
3. Commit your changes.
4. Push to your fork and open a pull request.

Please make sure your changes pass existing tests and that the code follows the project's style guidelines.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.


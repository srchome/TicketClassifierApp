Ticket Classifier App - README
==============================

Overview:
---------
This is a simple ASP.NET Core MVC application that classifies support tickets into different categories (e.g., Billing, Support, Feature Request, etc.) using a machine learning model built with ML.NET.

The app allows users to:
- Input ticket title and description
- Predict the category of the ticket using a trained model
- Upload custom training data (CSV) via the Admin section
- Train a new model and view performance metrics (e.g., Accuracy, LogLoss, F1 Score)

NOTE: This application is designed as a learning tool. It uses synthetic/mock data for demonstration purposes only.

Technologies Used:
------------------
- **ASP.NET Core MVC** - For building the web application
- **ML.NET** - For machine learning model training and prediction
- **Bootstrap 5** - For responsive UI styling
- **C# .NET 8** - Backend language and framework
- **EF Core** - (Optional) For database context (included for extension)
- **Razor Views** - For page rendering
- **Form validation and ViewBag** - For client-side and server-side feedback

Application Structure:
----------------------
- **Controllers/**
  - `TicketController` – handles prediction functionality
  - `AdminController` – handles training functionality
- **Views/**
  - `Index.cshtml` – input form for prediction
  - `Result.cshtml` – shows prediction result
  - `Train.cshtml` – form to upload training data and retrain the model
- **MLModels/**
  - `ModelBuilder.cs` – contains the ML pipeline and training logic
  - `Predictor.cs` – loads and runs the trained model
- **wwwroot/**
  - Static files like Bootstrap CSS/JS, custom styles, and uploaded training files

How to Run:
-----------
1. Clone or download the project.
2. Build the solution in Visual Studio or via `dotnet build`.
3. Run the app via `dotnet run` or through Visual Studio.
4. Navigate to `/` to predict, or to `/Admin/Train` to train the model.

Sample Training Data Format:
----------------------------
Ensure the training CSV has a header and the following columns:
Title,Description,Category
"Cannot access dashboard","User unable to see dashboard after login","Support"
"Request invoice copy","Customer needs last month invoice","Billing"


Disclaimers:
------------
- This is a learning project and should not be used in production.
- The data used is synthetic and does not represent real-world users or tickets.
- The model performance may vary depending on the quality and quantity of data uploaded.

Author:
-------
Developed for educational and demonstration purposes.
Souvika Roychoudhury
5th June 2025

###  Overview:
         This repository contains a project developed as part of the ITI (Information Technology Institute) training program, 
         focusing on implementing the Model-View-Controller (MVC) architectural pattern.
         The project demonstrates the separation of concerns in a web application, with components organized into models, views, and controllers.


###  Day 11:
         - In this task we focused on implementing the core components of the Model-View-Controller (MVC) architecture. 
         - specifically controllers and views.. This session introduces how to handle user requests, process input, and render dynamic content to the user interface.

         # Topics Covered:
             - ** Controllers **: 
                    - Creating controller classes to manage user interactions.
                    - Handling HTTP requests (GET, POST) and routing.
                    - Passing data between controllers and views.

             - ** Views **:
                     - Designing dynamic views using templating engines (e.g., Razor for ASP.NET MVC).
                     - Rendering data passed from controllers.
                     - Implementing layouts and partial views for reusable UI components.

             - ** Routing **:
                     - Configuring routes to map URLs to controller actions.

             - ** Hands-on Exercise **:
                     - Building a simple MVC application with a controller to handle user input and a view to display results.
                     - Example: Creating a form to collect user data and displaying it on a separate page.


 ###  Day 12:
           - In this task we focused on models and database integration. This session covers how to define data models, 
             connect to a database, and perform CRUD (Create, Read, Update, Delete) operations within an MVC application.

           # Topics Covered:
                - ** Models **: 
                       - Defining data models to represent application entities (Employee , Department)
                       - Using data annotations for validation (e.g., [Required], [StringLength]).
                       - Defining generic repository pattern to manage entities of type T it is useful for CRUD operations.

                - ** Database Integration **: 
                       - Setting up a database context (e.g., Entity Framework for .NET).
                       - Configuring connection strings in the application.
                       - Performing migrations to create or update the database schema.

                - ** CRUD Operations **: 
                       - Implementing Create, Read, Update, and Delete functionality in controllers.
                       - Displaying data in views using models.
                       
                - ** Hands-on Exercise **:  
                       - Building an MVC application with a model for a specific entity
                       - Example: Creating a company management system with add, view, edit, and delete features.
                      
                       
   ###  Day13:
           - In this task, we focused on working with **Partial Views**, **Models**, and rendering structured data dynamically using MVC architecture.
             
           # Topics Covered:
                 - ** Partial Views and Layouts **:
                        - Implemented reusable UI components using **partial views**.
                        - Created `MovieCardPartial.cshtml` to render each movie's details (title, poster, year, etc.).
                        - Integrated Bootstrap for a clean and responsive card layout.

                - ** Model Binding and ViewModel **:
                        -  Defined a `Movie` model class representing movie data.
                        - Used a strongly typed View to pass the movie list to the view.
                        - Handled binding data from controller to view.

                - ** JSON Output Button **:
                        - Added a **button** that, when clicked, shows the movie list data in **JSON format**.
                        - Demonstrated how to switch between HTML and JSON representations within the app.


   ###  Day 14 - MVC with Web API:
             - This task focuses on building a Movie Management Application using ASP.NET Core MVC and a separate Web API. 
             - The project includes a frontend MVC application (`WebApp`) to display and manage movies, and a backend Web API (`Day14__WebAPI`)
               to provide data operations such as retrieving, adding, editing, and deleting movies.
             - The application uses a partial view (`_MovieCardPartial.cshtml`) to render movie cards dynamically.

             # Objectives:
                 - Implement an MVC application to display a list of movies.
                 - Connect the MVC app to a Web API for data retrieval.
                 - Use partial views and controllers to manage the UI and logic.
                 - Handle CRUD operations via the Web API.

                 
ك
   ###  Day 15 - Identity and CRUD Operations:
             - This task focuses on building an ASP.NET Core application with user authentication using ASP.NET Core Identity and CRUD (Create, Read, Update, Delete) operations for managing `Department`                  and `Employee` entities. 
             - The project includes:
                          - A Web API-like structure with controllers for `Department` and `Employee` management.
                          - User authentication and authorization using Identity, including login, two-factor authentication , and recovery code login.

             # Objectives:
                  - Implement CRUD operations for `Department` and `Employee` entities.
                  - Secure the application with ASP.NET Core Identity.
                  - Support login, and recovery code authentication.
                  - Use Entity Framework Core for database migrations and data persistence.














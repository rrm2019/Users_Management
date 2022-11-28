Description
Application to control user management through a REST API.

The functionalities exposed in the API are as follows
Register a new user in the system.

Users are persisted in a .txt file.

A swagger has also been added to make it easier to expose the API for testing.

Requirements
Visual Studio 2019
Swagger
.net MVC Web Api

Testing
Unit tests have been provided. 

To access the swagger api, just go to the following endpoint:
https://localhost:44353/swagger/index.html

Improvements
Due to lack of time, some functionalities that would be considered essential in a real application have been left unimplemented:

Add more tests.
Include authorisation and access control.
Secure access to the api.
Save data in memory to traverse the file as few times as possible.
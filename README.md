# Leave-Management-App

Objective:
Your task is to design and implement a Leave Management System that allows administrators to manage and approve leave requests submitted by employees. The system should be user-friendly, efficient, and secure. We would like for you to complete the assessment between 10-15 hours. 

Requirements:
User Roles:

Administrator: Responsible for managing and approving/rejecting leave requests.
Employee: Can submit leave requests and view their own requested leave with leave status.
Functionality:

Employee should be able to:
Log in using their credentials (username and password).
Submit a leave request with the following information:
Start and end dates of the leave.
Reason for the leave.
View the status of their submitted leave requests.
Administrator should be able to:
Log in using their credentials.
View a list of all leave requests from employees.
Approve or reject leave requests with comments.
View leave request statistics (e.g., total pending requests, approved requests, rejected requests).
 
Validation and Error Handling:
Validate that leave start date is before the end date.
Prevent leave requests for dates in the past.
Ensure that leave requests do not overlap with existing approved requests.
Implement appropriate error handling for invalid inputs and scenarios.

User Interface:
Design a user-friendly and responsive interface for both employees and administrators.
Use appropriate input fields, buttons, and notifications for a seamless user experience.

Data Storage:
Implement a data storage mechanism to store employee and leave request information. We recommend you use MS SQL. (Please remember to make a backup of the Database once assignment is completed)

Security:
Implement user authentication and authorization to ensure that only authorized users can access the system.

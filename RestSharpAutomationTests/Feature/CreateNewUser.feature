Feature: CreateNewUser

Create a user by giving name and job as inputs
and check if the user has been created.

@APITests
Scenario: Create new user 
	Given Create user using name as <name> and job as <job>
	Then Check if a user is created with name <name> and job <job>

Examples: 
| name     | job           |
| Nikhitha | QA Automation |
| Shreya   | QA Manual     |
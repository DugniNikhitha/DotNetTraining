Feature: UpdateUserInfo

Update an existing user's job and check if it is updated 

@APITests
Scenario: Update user info
	Given Update existing user with <name> job to <job>
	Then Check if the <job> has been updated

Examples: 
| name     | job |
| morpheus | QA  |

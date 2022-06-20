Feature: DeleteUser

Delete any existing user

@APITests
Scenario: Delete existing user 
	Given Delete a user using id 
	| id |
	| 2  |
	Then Check whether the user got deleted

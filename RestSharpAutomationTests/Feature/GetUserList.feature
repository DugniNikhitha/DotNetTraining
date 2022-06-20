Feature: GetUserList

Retrieve the list of users and validate the names

@APITests
Scenario: Get the list of users
	Given Get users list using Get API request
	Then Check whether the following names are present
	| Name    |
	| George  |
	| Janet   |
	| Emma    |
	| Eve     |
	| Charles |
	| Tracey  |

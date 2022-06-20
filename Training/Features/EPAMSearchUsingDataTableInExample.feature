Feature: EPAMSkillSearchTestUsingExample

This feature is to test the EPAM Search Page.
We will be testing the result count of respective skill

@UITests
Scenario Outline: Skillset in EPAM search using example
	Given I have entered the EPAM home 
	And I have navigated to the Search combo
	When I entered the SkillSet to search as <Skill>
	Then The record message of the search result should match the <Record>

Examples: 
	| Skill      | Record |
	| Automation | 394    |
	| Devops     | 237    |



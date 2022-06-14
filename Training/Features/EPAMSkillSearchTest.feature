Feature: EPAMSkillSearchTest

This feature is to test the EPAM Search Page.
We will be testing the result count of respective skill

@UITests
Scenario Outline: Skillset in EPAM search
	Given I have entered the EPAM home page
	And I have navigated to the Search panel
	When I entered the SkillSet to search as
	| Skill      | 
	| Automation |
	Then The record message of the search result should match
	| Record |
	| 392    |



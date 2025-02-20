Feature: ServicesSelectServiceCategory

As a Test Automation Engineer I want to
test for select a service category

Scenario: Verify that a user can select a service category and validate the title
	Given I navigate to the EPAM Services page
	When I select '<menuOption>'
	Then I verify that the '<menuOption>' is present in the page
	Examples: 
	| menuOption	   |
	| Responsible AI   |
	| Generative AI    |

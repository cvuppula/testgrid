Feature: To verify the Login page1
	
@Browser_Chrome
@Browser_Firefox
Scenario: Add a customer1
	Given I navigate to Home page
	When I add a customer with below data
	| Name     | Description                         | IsolationLevel | Size  |
	| TestName | This is a test description for test | Cluster        | Large |
	Then I verify customer data is added as "false"
	
@Browser_Chrome
@Browser_Firefox
Scenario: Basepage is Calculator1
	Given I navigated to /
	Then browser title is Calculator
	
@Browser_Chrome
@Browser_Firefox
Scenario: Add a customer2
	Given I navigate to Home page
	When I add a customer with below data
	| Name     | Description                         | IsolationLevel | Size  |
	| TestName | This is a test description for test | Cluster        | Large |
	Then I verify customer data is added as "true"

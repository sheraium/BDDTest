Feature: UpdateUserFeature
	In order to update a user by Id
	As on API Consumer
	I want to be able to update a user's information through the API

@mytag
Scenario: Updating a user with valid data
	Given that a user exists in the system
	When I request to update the user by Id with details
	| Name     | Surname     | Email     |
	| TestName | TestSurname | TestEmail |
	Then the user should be updated
	And the response status code is "200 OK"

Scenario: Updating a non-existing user
	Given that a user does not exist in the system
	When I request to update the user by Id with details Name: 'TestName' Surname: 'TestSurname' and Email: 'TestEmail'
	Then  the response status code is "404 Not Found"

Scenario Outline: Updating a user with invalid data
	Given that a user exists in the system
	When I request to update the user by Id with details Name:'<name>' Surname:'<surname>' and Email:'<email>'
	Then the response status code is "400 Bad Request"
	Examples: 
	| name     | surname     | email     |
	| TestName | TestSurname |           |
	| TestName |             | TestEmail |
	|          | TestSurname | TestEmail |
	|          |             | TestEmail |
	|          |             |           |
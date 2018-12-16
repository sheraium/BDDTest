﻿Feature: GetUserFeature
	In order to get user information from the API
	As a API consumer
	I want to be get users by ID

@mytag
Scenario: Get User by Id
	Given that a user exists in the system
	When I request to get the user by Id
	Then the user should be returned in the response
	And the response status code is "200 OK"

Scenario: Get non-existing user by Id
	Given that a user does not exist in the system
	When I request to get the user by Id
	Then no user should be returned in the response
	And the response status code is "404 Not Found"
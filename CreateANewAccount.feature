Feature: CreateANewAccount
	In order to confirm a new account is created
	As a person
	I want the Username to display after I complete the sign up form


@prod
Scenario: Create A New Account
	Given I am not logged in
	When I complete the sign up form 
	Then I am logged in
	And my username is displayed
 

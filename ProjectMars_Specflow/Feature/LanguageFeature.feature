Feature: LanguageFeature

As a user, 
I would like to add, edit and delete languages 
so that people seeking for languages can look at it	

@tag1
Scenario: Add language with valid details
	Given User logged in successfully
	When User add language to the language list
	Then Language should be added successfully


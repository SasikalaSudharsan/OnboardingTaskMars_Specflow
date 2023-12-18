Feature: LanguageFeature

As a user, 
I would like to add, edit and delete languages 
so that people seeking for languages can look at it	

@tag1
Scenario Outline: Add language with valid details
Given User logged into Mars URL successfully
When User add '<Language>' and '<Language Level>' to the language list
And The '<Language>' and '<Language Level>' should be added successfully

Examples: 
 | Language | Language Level |
 | French   | Fluent         |

Scenario Outline: Update an existing language 
    Given User logged into Mars URL successfully
	When  User update the '<Language>' and '<Language Level>' of an existing language
	And  The '<Language>' and '<Language Level>' should be updated successfully

Examples: 
 | Language  | Language Level |
 | Spanish   | Basic         |

Scenario Outline: Delete an existing language
    Given User logged into Mars URL successfully
	When User delete the '<Language>' of an existing language
	And The '<Language>' should be deleted successfully

Examples: 
 | Language  | 
 | Spanish   | 

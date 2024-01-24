Feature: LanguageFeature

As a user, 
I would like to add, edit and delete languages 
so that people seeking for languages can look at it	

Scenario Outline: 01 - Delete all records in the language list
        Given  User logged into Mars URL successfully
        When Delete all records in the language list 


Scenario Outline: 02 - Add language with valid details
        Given User logged into Mars URL successfully
        When User add '<Language>' and '<Language Level>' to the language list
        Then The '<Language>' and '<Language Level>' should be added successfully

Examples: 
        | Language | Language Level |
        | French   | Fluent         |
        | Chinese  | Basic          |


Scenario Outline: 03 - Update an existing language 
        Given User logged into Mars URL successfully
        When User edit an existing '<Existing Language>' and '<Existing Language Level>'
        Then The '<New Language>' and '<New Language Level>' should be updated successfully

Examples: 
        | Existing Language | Existing Language Level | New Language | New Language Level |
        | French            | Fluent                  | Spanish      | Basic              |


Scenario Outline: 04 - Delete an existing language
        Given User logged into Mars URL successfully
        When User delete an existing '<Language>'
        Then The '<Language>' should be deleted successfully

Examples: 
        | Language  | 
        | Spanish   | 


Scenario Outline: 05 - Add language with special characters
        Given User logged into Mars URL successfully
        When User add '<Language>' and '<Language Level>' to the language list
        Then The message '<Message>' should be displayed

Examples: 
        | Language | Language Level | Message                                                 |
        | @#$%^&   | Fluent         | Special charcters are not allowed in your language list |


Scenario Outline: 06 - Add language with language textbox as empty
        Given User logged into Mars URL successfully
        When User add '<Language>' and '<Language Level>' to the language list
        Then The message '<Message>' should be displayed

Examples: 
        | Language | Language Level | Message                         |
        |          | Fluent         | Please enter language and level |


Scenario Outline: 07 - Add existing language in language list
        Given User logged into Mars URL successfully
        When User add '<Language>' and '<Language Level>' to the language list
        Then The message '<Message>' should be displayed

Examples: 
        | Language | Language Level | Message                                               |
        | Chinese  | Basic          | This language is already exist in your language list. |



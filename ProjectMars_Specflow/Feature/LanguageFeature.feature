Feature: LanguageFeature

As a user, 
I would like to add, edit and delete languages 
so that people seeking for languages can look at it	

@tag1
Scenario Outline: Add language with valid details
Given User logged into Mars URL successfully
When User add '<Language>' and '<Language Level>' to the language list
Then The '<Language>' and '<Language Level>' should be added successfully

Examples: 
 | Language | Language Level |
 | French   | Fluent         |

Scenario Outline: Update an existing language 
Given User logged into Mars URL successfully
When User edit an existing '<Existing Language>' and '<Existing Language Level>'
Then The '<New Language>' and '<New Language Level>' should be updated successfully

Examples: 
| Existing Language | Existing Language Level | New Language | New Language Level |
| French            | Fluent                  | Spanish      | Basic              |

Scenario Outline: Delete an existing language
Given User logged into Mars URL successfully
When User delete an existing '<Language>'
Then The '<Language>' should be deleted successfully

Examples: 
 | Language  | 
 | Spanish   | 

 Scenario Outline: Add language with special characters
Given User logged into Mars URL successfully
When User add '<Language>' and '<Language Level>' to the language list
Then The message '<Message>' should be displayed

Examples: 
 | Language | Language Level | Message                                                 |
 | @#$%^&   | Fluent         | Special charcters are not allowed in your language list |

 Scenario Outline: Add language with language textbox as empty
Given User logged into Mars URL successfully
When User add '<Language>' and '<Language Level>' to the language list
Then The message '<Message>' should be displayed

Examples: 
 | Language | Language Level | Message                         |
 |          | Fluent         | Please enter language and level |

 Scenario Outline: Add existing language in language list
Given User logged into Mars URL successfully
When User add '<Language>' and '<Language Level>' to the language list
Then The message '<Message>' should be displayed

Examples: 
 | Language | Language Level | Message                                               |
 | Spanish  | Basic          | This language is already exist in your language list. |
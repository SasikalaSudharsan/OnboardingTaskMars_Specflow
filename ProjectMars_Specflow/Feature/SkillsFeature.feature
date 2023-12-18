Feature: SkillsFeature

As a user, 
I would like to add, edit and delete skills 
so that people seeking for skills can look at it	

@tag1
Scenario Outline: Add skills with valid details
	Given User logged into Mars URL successfully
	When User navigate to Skills tab
	When User add '<Skill>' and '<Skill Level>' to the skill list
	Then The '<Skill>' and '<Skill Level>' should be added successfully

Examples: 
 | Skill    | Skill Level  |
 | Specflow | Intermediate | 

 Scenario Outline: Update an existing skill
 Given User logged into Mars URL successfully
 When User navigate to Skills tab
 When User update the '<Skill>' and '<Skill Level>' of an existing skill
 Then The '<Skill>' and '<Skill Level>' should be updated successfully

 Examples: 
 | Skill  | Skill Level  |
 | Java   | Expert       | 

 Scenario Outline: Delete an existing skill
 Given User logged into Mars URL successfully
 When User navigate to Skills tab
 When User delete the '<Skill>' of an existing skill
 Then The '<Skill>' should be deleted successfully

  Examples: 
 | Skill  | 
 | Java   |  
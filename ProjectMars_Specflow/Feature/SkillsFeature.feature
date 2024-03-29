﻿Feature: SkillsFeature

As a user, 
I would like to add, edit and delete skills 
so that people seeking for skills can look at it	


Scenario Outline: 01 - Delete all records in the skill list
        Given User logged into Mars URL successfully
        When User navigate to Skills tab
        And Delete all records in the skill list


Scenario Outline: 02 - Add skills with valid details
	    Given User logged into Mars URL successfully
	    When User navigate to Skills tab
	    When User add '<Skill>' and '<Skill Level>' to the skill list
	    Then The '<Skill>' and '<Skill Level>' added successfully

Examples: 
        | Skill    | Skill Level  |
        | Specflow | Intermediate |
        | Selenium | Expert       |


Scenario Outline: 03 - Update an existing skill
        Given User logged into Mars URL successfully
        When User navigate to Skills tab
        When User update an existing '<Existing Skill>' and '<Existing Skill Level>'
        Then The '< New Skill>' and '<New Skill Level>' updated successfully

Examples: 
        | Existing Skill | Existing Skill Level | New Skill | New Skill Level |
        | Specflow       | Intermediate         | Java      | Expert          |


Scenario Outline: 04 - Delete an existing skill
        Given User logged into Mars URL successfully
        When User navigate to Skills tab
        And User delete the '<Skill>' of an existing skill
        Then The '<Skill>' deleted successfully

Examples: 
        | Skill  | 
        | Java   |  


Scenario Outline: 05 - Add skill with skill textbox as empty
        Given User logged into Mars URL successfully
        When User navigate to Skills tab
        When User add '<Skill>' and '<Skill Level>' to the skill list
        Then The skill message '<Message>' should be displayed

Examples: 
        | Skill | Skill Level | Message                                 |
        |       | Expert      | Please enter skill and experience level |


Scenario Outline: 06 - Add existing skill in skill list
        Given User logged into Mars URL successfully
        When User navigate to Skills tab
        When User add '<Skill>' and '<Skill Level>' to the skill list
        Then The message '<Message>' should be displayed

Examples: 
        | Skill     | Skill Level | Message                                         |
        | Selenium  | Expert      | This skill is already exist in your skill list. |
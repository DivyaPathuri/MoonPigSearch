@firefox
Feature: MoonPigSearch
Verifying the search functionality for MoonPig

Scenario: Check general search function
Given I am on MoonPig home page
When I click search icon
Then I should see search box displayed and enabled on page

Scenario Outline: Search for different types of greeting cards
Given I am on MoonPig home page
When I click search icon
And I enter "<Occasion>" in to search field
And I click Search button
Then the url should contain "<Occasion>"
And "<Occasion>" should be displayed next to search box 

Examples: Search input
| Occasion    |
| Birthday    |
| Wedding     |
| Boyfriend   |
| Celebration |
| Christmas   |
| Fiancee     |
| Sister      |
Scenario Outline: Verifying results for invalid searches 
Given I am on MoonPig home page
When I click search icon
And I enter "<Occasion>" in to search field
And I click Search button
Then I should see "Sorry we've really tried, but can't find any cards for:" error message on the page
And I should see "<Occasion>" displayed below the error message
And I should see two suggestions on the page

Examples: Search input
| Occasion      |
| ?!!!!!7899dhh |
| dghgdhdhdghg  |
| ABCDEFGH      |
| 1234567       |


#I wanted to verify the below scenario but the functionality is not allowing me to click the search button with empty input. But I have written the code for this test. Since there is no requirement I am not sure if this is a bug or not.

#Scenario:Verifying results for empty search 
#Given I am on MoonPig home page
#When I click search icon
#And I enter no value in to search field
#And I click Search button
#Then I should see "Sorry we've really tried, but can't find any cards for:" error message on the page


Feature: Interactions
  As a demoqa.com user
  I want to select items on the page
  In order to work with several items at once

Background:
	Given the user opens the 'Interactions' category

@selectable
Scenario: Selected grid squares hold the expected values
	Given the user opens the 'Selectable' section
	And the user switches to the 'Grid' tab
	When the user selects the following grid squares
		| Square |
		|      1 |
		|      3 |
		|      5 |
		|      7 |
		|      9 |
	Then the selected grid squares contain the following values
		| Value |
		| One   |
		| Three |
		| Five  |
		| Seven |
		| Nine  |
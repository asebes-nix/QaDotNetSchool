Feature: Elements
  As a demoqa.com user
  I want to use the controls of the Elements category
  In order to check that they handle user input correctly

Background:
	Given the user opens the 'Elements' category

@textbox
Scenario: Submitted Text Box data is displayed in the output
	Given the user opens the 'Text Box' section
	When the user submits the Text Box form with the following data
		| Field             | Value                    |
		| Full Name         | Gizi Teszt               |
		| Email             | gizi.teszt@example.com   |
		| Current Address   | Budapest, Bug utca 404   |
		| Permanent Address | Szeged, Regression ter 1 |
	Then the output shows the submitted data

@checkbox
Scenario: Selected Check Box items are listed in the result
	Given the user opens the 'Check Box' section
	When the user expands the 'Home' folder
	And the user checks the 'Desktop' item
	And the user expands the 'Documents' folder
	And the user expands the 'WorkSpace' folder
	And the user checks the 'Angular' item
	And the user checks the 'Veu' item
	And the user expands the 'Office' folder
	And the user checks the following items
		| Item       |
		| Public     |
		| Private    |
		| Classified |
		| General    |
	And the user expands the 'Downloads' folder
	And the user checks the 'Downloads' item
	Then the Check Box result shows 'You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile'

# Known issue: demoqa.com no longer sorts Web Tables by header click.
# Expected to fail (agreed with mentor).
@webtables
Scenario: Salary column is sorted in ascending order after clicking its header
	Given the user opens the 'Web Tables' section
	When the user clicks the 'Salary' column header
	Then the values in the 'Salary' column are in ascending order

@webtables
Scenario: Deleted row is removed from the table
	Given the user opens the 'Web Tables' section
	When the user deletes the row of 'Alden'
	Then the table has 2 rows
	And the 'Department' column does not contain 'Compliance'

@buttons
Scenario Outline: Clicking a button in its required way shows the matching message
	Given the user opens the 'Buttons' section
	When the user clicks the '<button>' button
	Then only the message '<message>' is displayed

Examples:
	| button          | message                       |
	| Double Click Me | You have done a double click  |
	| Right Click Me  | You have done a right click   |
	| Click Me        | You have done a dynamic click |
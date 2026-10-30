Feature: Forms
  As a demoqa.com user
  I want to fill in and submit the student registration form
  In order to register as a student

Background:
	Given the user opens the 'Forms' category

@practiceform
Scenario: Submitted Practice Form data is shown in the confirmation modal
	Given the user opens the 'Practice Form' section
	When the user fills in all text fields with random data
	And the user selects the 'Female' gender
	And the user enters '15 Mar 1990' as date of birth
	And the user adds the following subjects
		| Subject |
		| Physics |
		| Maths   |
	And the user selects the following hobbies
		| Hobby   |
		| Reading |
		| Music   |
	And the user selects the 'Uttar Pradesh' state
	And the user types 'Merrut' into the city field and presses Enter
	And the user submits the Practice Form
	Then the confirmation modal shows the entered text field data
	And the confirmation modal shows the following values
		| Label          | Value                |
		| Gender         | Female               |
		| Date of Birth  | 15 March,1990        |
		| Subjects       | Physics, Maths       |
		| Hobbies        | Reading, Music       |
		| State and City | Uttar Pradesh Merrut |
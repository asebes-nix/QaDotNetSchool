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
    | Field             | Value                     |
    | Full Name         | Gizi Teszt                |
    | Email             | gizi.teszt@example.com    |
    | Current Address   | Budapest, Bug utca 404    |
    | Permanent Address | Szeged, Regression ter 1  |
  Then the output shows the submitted data
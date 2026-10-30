Feature: Widgets
  As a demoqa.com user
  I want to use interactive widgets
  In order to enter data and follow progress conveniently

Background:
  Given the user opens the 'Widgets' category

@autocomplete
Scenario: Typing a letter offers only matching color suggestions
  Given the user opens the 'Auto Complete' section
  When the user types 'g' into the multiple color names field
  Then 3 color suggestions are offered
    And every color suggestion contains 'g'

@autocomplete
Scenario: Removed colors disappear from the multiple color names field
  Given the user opens the 'Auto Complete' section
  When the user adds the following colors
    | Color  |
    | Red    |
    | Yellow |
    | Green  |
    | Blue   |
    | Purple |
    And the user removes the following colors
    | Color  |
    | Yellow |
    | Purple |
  Then the multiple color names field contains exactly
    | Color |
    | Red   |
    | Green |
    | Blue  |

@progressbar
Scenario: Progress bar can be completed and reset
  Given the user opens the 'Progress Bar' section
  When the user starts the progress bar and waits until it reaches 100%
  Then the progress bar button shows 'Reset'
  When the user resets the progress bar
  Then the progress bar button shows 'Start'
    And the progress bar shows '0%'
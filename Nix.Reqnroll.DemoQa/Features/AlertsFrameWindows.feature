Feature: Alerts, Frame & Windows
  As a demoqa.com user
  I want to open pages in new tabs and windows
  In order to work with several pages at the same time

Background:
  Given the user opens the 'Alerts, Frame & Windows' category
    And the user opens the 'Browser Windows' section

@browserwindows
Scenario Outline: Button opens the sample page in a new browser window
  When the user opens a new window with the '<button>' button
  Then the new window shows the heading 'This is a sample page'

Examples:
  | button     |
  | New Tab    |
  | New Window |
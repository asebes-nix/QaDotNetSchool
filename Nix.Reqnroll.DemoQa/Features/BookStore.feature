Feature: Book Store Application
  As a demoqa.com user
  I want to sort the book list by its columns
  In order to find books more easily

Background:
	Given the user opens the 'Book Store Application' category

@bookstore
Scenario Outline: Book list is sorted by the clicked column
	When the user sorts the book list by '<column>' in <direction> order
	Then the book list is sorted by '<column>' in <direction> order

Examples:
	| column    | direction  |
	| Title     | ascending  |
	| Title     | descending |
	| Author    | ascending  |
	| Publisher | ascending  |
﻿Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Add two numbers
	Given I have entered <a> an <b> into the calculator
	When I press add
	Then the result should be <result> on the screen

Examples: 
	| a   | b  | result |
	| 1   | 2  | 3      |
	| 50  | 70 | 120    |
	| -11 | 11 | 0      |

Feature: Addition
    In order to avoid silly mistakes
    As a math idiot
    I want to be told the sum of two numbers
    
@important
Scenario: Add two numbers
    Given I have entered "50" into the calculator
    And I have entered "70" into the calculator
    When I press add
    Then the result should be "120" on the screen

@important
Scenario: Get a Pokemon
    Given the Pokedex is working
    When I have entered ID "1" into the Pokedex
    Then the result should return a Pokemon with ID "1"

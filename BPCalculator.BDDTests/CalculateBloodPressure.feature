
Feature: CalculateBloodPressure

Scenario: BloodPressureIdeal
    Given a patient with blood pressure readings of 90 mm Hg systolic and 60 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered Low

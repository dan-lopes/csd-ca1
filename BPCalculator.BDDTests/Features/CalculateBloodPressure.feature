Feature: CalculateBloodPressureFeature

Scenario: BloodPressureLow1
    Given a patient with blood pressure readings of 70 mm Hg systolic and 40 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered Low

Scenario: BloodPressureLow2
    Given a patient with blood pressure readings of 90 mm Hg systolic and 60 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered Low

Scenario: BloodPressureIdeal1
    Given a patient with blood pressure readings of 91 mm Hg systolic and 61 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered Ideal

Scenario: BloodPressureIdeal2
    Given a patient with blood pressure readings of 120 mm Hg systolic and 80 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered Ideal

Scenario: BloodPressurePreHigh1
    Given a patient with blood pressure readings of 121 mm Hg systolic and 81 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered PreHigh

Scenario: BloodPressurePreHigh2
    Given a patient with blood pressure readings of 140 mm Hg systolic and 90 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered PreHigh

Scenario: BloodPressureHigh1
    Given a patient with blood pressure readings of 141 mm Hg systolic and 91 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered High

Scenario: BloodPressureHigh2
    Given a patient with blood pressure readings of 190 mm Hg systolic and 100 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered High


Feature: CalculateBloodPressureFeature

Scenario: BloodPressure70SystolicAnd40DiastolicIsLow
    Given a patient with blood pressure readings of 70 mm Hg systolic and 40 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered Low

Scenario: BloodPressure90SystolicAnd60DiastolicIsLow
    Given a patient with blood pressure readings of 90 mm Hg systolic and 60 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered Low

Scenario: BloodPressure91SystolicAnd61DiastolicIsIdeal
    Given a patient with blood pressure readings of 91 mm Hg systolic and 61 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered Ideal

Scenario: BloodPressure120SystolicAnd80DiastolicIsIdeal
    Given a patient with blood pressure readings of 120 mm Hg systolic and 80 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered Ideal

Scenario: BloodPressure121SystolicAnd81DiastolicIsPreHigh
    Given a patient with blood pressure readings of 121 mm Hg systolic and 81 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered PreHigh

Scenario: BloodPressure140SystolicAnd90DiastolicIsPreHigh
    Given a patient with blood pressure readings of 140 mm Hg systolic and 90 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered PreHigh

Scenario: BloodPressure141SystolicAnd91DiastolicIsHigh
    Given a patient with blood pressure readings of 141 mm Hg systolic and 91 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered High

Scenario: BloodPressure190SystolicAnd100DiastolicIsHigh
    Given a patient with blood pressure readings of 190 mm Hg systolic and 100 mm Hg diastolic
    When I request the blood pressure calculation
    Then the blood pressure is considered High
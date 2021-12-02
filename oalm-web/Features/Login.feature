Feature: Login

    Scenario: Login with valid credentials
        Given the user goes to the login page
        When the user logins with valid credentials
        Then verifies that the Home page is displayed
        And verifies that the username is displayed in the Main Navigation bar
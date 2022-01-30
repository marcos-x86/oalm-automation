Feature: Login

    @logout
    Scenario: Login with valid credentials
        Given the user goes to the login page
        When the user logins with valid credentials
        And the user selects 'bankofakron_47' database
        Then verifies that the Home page is displayed
        And verifies that the username is displayed in the Main Navigation bar

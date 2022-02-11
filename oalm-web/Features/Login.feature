Feature: Login

    @logout
    Scenario: Login with valid credentials
        Given the user goes to the login page
        When the user logins with valid credentials
        And the user selects 'bankofakron_47' database
        Then verifies that the Home page is displayed
        And verifies that the username is displayed in the Main Navigation bar

    Scenario: Login with invalid credentials
        Given the user goes to the login page
        When the user logins with the 'some_invalid_user' username
        Then verifies that a error message modal is displayed with the following text
        """
        Your username is incorrect.
        Please try again or contact OALM support for username assistance.
        """

     @logout
     Scenario: Login with invalid credentials and retry login with valid credentials
        Given the user goes to the login page
        When the user logins with the 'some_invalid_user' username
        Then verifies that a error message modal is displayed with the following text
        """
        Your username is incorrect.
        Please try again or contact OALM support for username assistance.
        """
        When the user clicks on OK
        And the user logins with valid credentials
        And the user selects 'bankofakron_47' database
        Then verifies that the Home page is displayed
        And verifies that the username is displayed in the Main Navigation bar

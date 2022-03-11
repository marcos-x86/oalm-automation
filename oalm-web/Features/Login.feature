﻿Feature: Login

    Scenario: Login with valid credentials
        Given the user logins with valid credentials
        And the user selects 'bankofakron_47' database
        Then verifies that the Home page is displayed
        And verifies that the username is displayed in the Main Navigation bar

#    Scenario: Login with invalid credentials
#        Given the user goes to the login page
#        When the user logins with the 'some_invalid_user' username
#        Then verifies that a error message modal is displayed with the following text
#        """
#        Your username is incorrect.
#        Please try again or contact OALM support for username assistance.
#        """
#
#     Scenario: Login with invalid credentials and retry login with valid credentials
#        Given the user goes to the login page
#        When the user logins with the 'some_invalid_user' username
#        Then verifies that a error message modal is displayed with the following text
#        """
#        Your username is incorrect.
#        Please try again or contact OALM support for username assistance.
#        """
#        When the user clicks on OK
#        And the user logins with valid credentials
#        And the user selects 'bankofakron_47' database
#        Then verifies that the Home page is displayed
#        And verifies that the username is displayed in the Main Navigation bar
        
    Scenario: Verify the all the UI options are available for Yield Curve Analysis
        Given the user logins with valid credentials
        And the user selects 'bankofakron_47' database
        Then verifies that the Home page is displayed
        When the user clicks on 'MARKET' menu in the navigation bar
        And the user clicks the 'Rate Analysis' menu item button
        Then verifies that the 'Yield Curve Analysis' tab is present in Rate Analysis page
        When the user clicks on 'Task' dropdown in the Yield Curve Settings section
        Then verifies that the following options are displayed for 'Task' dropdown in the Yield Curve Settings section
          | Options                   |
          | Single Curve              |
          | Single Curve Time Series  |
          | Single Curve Comparison   |
          | Multiple Curve Comparison |
        When the user clicks on 'Task' dropdown in the Yield Curve Settings section
        Then verifies that the 'Market Data' dropdown is present in the Yield Curve Settings section
        And verifies that the 'CurveID' dropdown is present in the Yield Curve Settings section
        When the user clicks on 'View' dropdown in the Yield Curve Settings section
        Then verifies that the following options are displayed for 'View' dropdown in the Yield Curve Settings section
          | Options          |
          | Yield Curve      |
          | Discount Factors |
        When the user clicks on 'View' dropdown in the Yield Curve Settings section
        Then the user verifies that the REFRESH button is present in the Yield Curve Settings section
        And the user verifies that the EXPORT TO EXCEL button is present in the Yield Curve Settings section
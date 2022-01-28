Feature: Table data edit

    Scenario: Verify that's possible to update a cell over a table
        Given the user goes to the login page
        When the user logins with valid credentials
        And the user selects 'bankofakron_47' database
        Then verifies that the Home page is displayed
        When the user clicks on 'MARKET' menu in the navigation bar
        And the user clicks the 'Market Structure' menu item button
        And the user sets the '2' value to the '1' row of the 'Maturity' column in the PV Curve table
        Then verifies that the '2' value is displayed in the '1' row of the 'Maturity' column in the PV Curve table
        And the user logs out

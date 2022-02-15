Feature: Market Structure

    @logout
    Scenario: Verify the all the UI options are available for Market Structure
        Given the user goes to the login page
        When the user logins with valid credentials
        And the user selects 'bankofakron_47' database
        Then verifies that the Home page is displayed
        When the user clicks on 'MARKET' menu in the navigation bar
        And the user clicks the 'Market Structure' menu item button
        And the user clicks on 'Protection' dropdown in the PV Curve Settings section
        Then verifies that the following options are displayed for 'Protection' dropdown in the PV Curve Settings section
          | Options |
          | False   |
          | True    |
        When the user clicks on 'Protection' dropdown in the PV Curve Settings section
        And the user clicks on 'Allow Negative' dropdown in the PV Curve Settings section
        Then verifies that the following options are displayed for 'Allow Negative' dropdown in the PV Curve Settings section
          | Options |
          | False   |
          | True    |
        When the user clicks on 'Allow Negative' dropdown in the PV Curve Settings section
        Then verifies that Maturity Point PV Curve Setting is displayed
        And verifies that SAVE button is displayed in PV Curve header section
        When the user clicks on More options button in PV Curve page
        Then verifies that the following items are displayed for More options menu
          | Options         |
          | Export to Excel |
          | Add Curve       |
          | Copy Curve      |
          | Delete Curve    |
Feature: Market Structure

    Background:
        Given the user logins with valid credentials using the 'bankofakron_47' database
        Then verifies that the Home page is displayed

    @closeMarketStructureTab @runThis
    Scenario: Verify the all the UI options are available for Market Structure
        When the user clicks on 'MARKET' menu in the navigation bar
        And the user clicks the 'Market Structure' menu item button
        Then verifies that ID PV Curve Setting has the 'Equity Curve' value
        When the user clicks on 'Protection' dropdown in the PV Curve Settings section
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

    @deletePVCurveCreated @closeMarketStructureTab
    Scenario: Verify that's possible to 'Add Cruve' on Market Structure
        When the user clicks on 'MARKET' menu in the navigation bar
        And the user clicks the 'Market Structure' menu item button
        And the user clicks on More options button in PV Curve page
        And the user clicks on 'Add Curve' option in PV Curve page
        And the user enters 'New Test Curve' in the ID field of the Add PV Curve modal
        And the user clicks OK button in Add PV Curve modal
        Then verifies that the PV Curve Save success toast message is displayed
        And verifies that the PV Curve selected is 'New Test Curve'
        And verifies that ID PV Curve Setting has the 'New Test Curve' value

    @deletePVCurveCreated @closeMarketStructureTab
    Scenario: Verify that’s possible to Copy Curve on Market Structure
        When the user clicks on 'MARKET' menu in the navigation bar
        And the user clicks the 'Market Structure' menu item button
        And the user clicks on More options button in PV Curve page
        And the user clicks on 'Copy Curve' option in PV Curve page to create a copy of the current PV Curve
        Then verifies that the PV Curve Save success toast message is displayed
        And verifies that the PV Curve selected is 'Equity Curve - Copy'
        And verifies that ID PV Curve Setting has the 'Equity Curve - Copy' value
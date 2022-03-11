Feature: Export table data

    Scenario: Verify that’s possible to export an excel file from a data table
        Given the user logins with valid credentials
        And the user selects 'bankofakron_47' database
        Then verifies that the Home page is displayed
        When the user clicks on 'ASSUMPTIONS' menu in the navigation bar
        And the user clicks the 'Prepayment/Decay Tables' menu item button
        And the user clicks on More options icon button in Prepayment Decay page
        And the user clicks on 'Export Selector' option in Prepayment Decay page
        And the user clicks on OK button in Export Selector menu
        Then verifies that the file 'Prepayment_DecayTables.xlsx' is downloaded

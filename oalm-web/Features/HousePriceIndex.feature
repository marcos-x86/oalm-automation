Feature: House Price Index

    Background:
        Given the user logins with valid credentials using the 'bankofakron_47' database
        Then verifies that the Home page is displayed

    @closeHousePriceIndexTab
    Scenario: Verify the UI components are displayed on ‘House Price Index’ tab
        When the user clicks on 'MARKET' menu in the navigation bar
        And the user clicks the 'House Price Index' menu item button
        Then verifies that the 'House Price Index' tab is present
        Then verifies that the SAVE button is displayed in House Price Index page
        When the user clicks on More Options icon button in House Price Index page
        Then verifies that the following items are displayed for More Options menu in House Price Index page 
          | Options          |
          | Upload HPI Table |
          | Export to Excel  |
          | Add Row          |
          | Delete Row       |

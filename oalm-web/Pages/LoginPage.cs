﻿using System;
using oalm_web.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace oalm_web.Pages
{
    public class LoginPage
    {
        private By _usernameInput = By.CssSelector("#txtUsername");
        private By _passwordInput = By.CssSelector("#txtPassword");
        private By _continueButton = By.CssSelector("#btnCheckName");
        private By _loginButton = By.CssSelector("#btnLogin");
        private By _activeSessionModal = By.CssSelector("#layui-layer1");
        private By _activeSessionOkButton = By.CssSelector(".layui-layer-btn .layui-layer-btn1");
        private By _sessionSignOutModal = By.CssSelector(".layui-layer-dialog .fa-check-circle");
        private By _dropdownListDB = By.Id("dropdownlistContentselDatabases");
        private By _selectButtonDB = By.Id("btnSelectDatabase");
        public void SetUsername(String username)
        {
            WebDriverActions.SetText(_usernameInput, username);
        }

        public void SetPassword(String password)
        {
            WebDriverActions.SetText(_passwordInput, password);
        }

        public void ClickContinueButton()
        {
            WebDriverActions.Click(_continueButton);
        }

        public void ClickLoginButton()
        {
            WebDriverActions.Click(_loginButton);
        }

        public void AcceptActiveSessionModal()
        {
            if (WebDriverActions.IsDisplayed(_activeSessionModal, 2))
            {
                WebDriverActions.Click(_activeSessionOkButton);
                WebDriverActions.WaitUntilNotDisplayed(_sessionSignOutModal);
            }
        }

        public void LoginWithCredentials(String username, String password)
        {
            SetUsername(username);
            ClickContinueButton();
            SetPassword(password);
            ClickLoginButton();
            AcceptActiveSessionModal();
        }

        public void SelectDB(String dbName)
        {
            WebDriverActions.Click(_dropdownListDB);
        }

        public void ClickSelectDBButton() 
        {
            WebDriverActions.Click(_selectButtonDB);
        }
    }
}
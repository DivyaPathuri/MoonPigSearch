using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoonPig.BaseCode;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MoonPig.TestScenarios
{
    [Binding]
    public sealed class MoonPigSearch : BaseHelper
    {
        [Given(@"I am on MoonPig home page")]
        public void GivenIAmOnMoonPigHomePage()
        {
            CurrentDriver.Navigate().GoToUrl(BaseUrl);
        }

        [When(@"I click search icon")]
        public void WhenIClickSearchIcon()
        {
            CurrentDriver.WaitForElement(By.CssSelector("#menu-item-search")).Click();
        }

        [Then(@"I should see search box displayed and enabled on page")]
        public void ThenIShouldSeeSearchBoxDisplayedAndEnabledOnPage()
        {
            var searchboxCss =
                CurrentDriver.WaitForElement(By.CssSelector(".layout-wrapper.clearfix.search-container.search-open"));
            Assert.IsTrue(searchboxCss.Displayed && searchboxCss.Enabled);
        }

        [When(@"I enter ""(.*)"" in to search field")]
        public void WhenIEnterInToSearchField(string text)
        {
            CurrentDriver.WaitForElement(By.CssSelector("#search-box")).SendKeys(text);
        }

        [When(@"I click Search button")]
        public void WhenIClickSearchButton()
        {
            CurrentDriver.WaitForElement(By.CssSelector("#search-btn")).Click();
        }

        [Then(@"the url should contain ""(.*)""")]
        public void ThenTheUrlShouldContain(string text)
        {
            var geturl = CurrentDriver.Url.Trim().ToLower();
            Assert.IsTrue(geturl.Contains(text.ToLower()));
        }

        [Then(@"""(.*)"" should be displayed next to search box")]
        public void ThenShouldBeDisplyedNextToSearchbox(string tag)
        {
            var tagCssPath =
                CurrentDriver.WaitForElement(By.CssSelector(".facet-button.btn-large.selected.ng-scope.keyword-facet"));
            Assert.IsTrue(tagCssPath.Text.Trim().ToLower() == tag.ToLower());
        }

        [Then(@"I should see ""(.*)"" error message on the page")]
        public void ThenIShouldSeeErrorMessageOnThePage(string errorMessage)
        {
            var errorCssPath = CurrentDriver.WaitForElement(By.CssSelector("#noResultsMessage")).Text;
            Assert.IsTrue(errorCssPath.Trim().ToLower().Contains(errorMessage.ToLower()));
        }

        [Then(@"I should see ""(.*)"" displayed below the error message")]
        public void ThenIShouldSeeDisplayedBelowTheErrorMessage(string name)
        {
            var cssPath = CurrentDriver.WaitForElement(By.CssSelector(".ng-binding.ng-scope")).Text;
            Assert.IsTrue(cssPath.Trim() == name);
        }

        [Then(@"I should see two suggestions on the page")]
        public void ThenIShouldSeeTwoSuggestionsOnThePage()
        {
            var suggestionsCss = CurrentDriver.WaitForElement(By.CssSelector((".suggestions-panel.textLeft>ul>li")));
            Assert.IsTrue(suggestionsCss.Displayed);
        }

        [When(@"I enter no value in to search field")]
        public void WhenIEnterNoValueInToSearchField()
        {
            GeneralPageSteps.ClickByCss("#search-box");
        }
    }
}

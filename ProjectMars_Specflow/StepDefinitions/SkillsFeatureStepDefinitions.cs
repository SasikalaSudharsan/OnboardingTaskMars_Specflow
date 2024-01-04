using NUnit.Framework;
using ProjectMars_Specflow.Pages;
using System;
using System.Net.NetworkInformation;
using TechTalk.SpecFlow;

namespace ProjectMars_Specflow.StepDefinitions
{
    [Binding]
    public class SkillsFeatureStepDefinitions
    {
        HomePage homePageObj = new HomePage();
        SkillsPage skillsPageObj = new SkillsPage();

        [When(@"User navigate to Skills tab")]
        public void WhenUserNavigateToSkillsTab()
        {
            homePageObj.GoToSkillsPage();
        }

        [When(@"User add '([^']*)' and '([^']*)' to the skill list")]
        public void WhenUserAddAndToTheSkillList(string skill, string skillLevel)
        {
            skillsPageObj.Add_Skills(skill, skillLevel);
        }

        [Then(@"The '([^']*)' and '([^']*)' added successfully")]
        public void ThenTheAndAddedSuccessfully(string skill, string skillLevel)
        {
            string newSkill = skillsPageObj.getSkill(skill);
            string newSkillLevel = skillsPageObj.getSkillLevel(skillLevel);

            Assert.That(newSkill == skill, "Actual skill and expected skill do not match");
            Assert.That(newSkillLevel == skillLevel, "Actual skill level and expected skill level do not match");
        }

        [When(@"User update an existing '([^']*)' and '([^']*)'")]
        public void WhenUserUpdateAnExistingAnd(string existingSkill, string existingSkillLevel)
        {
            skillsPageObj.Edit_Skills(existingSkill, existingSkillLevel);
        }

        [Then(@"The '([^']*)' and '([^']*)' updated successfully")]
        public void ThenTheAndUpdatedSuccessfully(string skill, string skillLevel)
        {
            skillsPageObj.Update_Skills(skill, skillLevel);

            string updatedSkill = skillsPageObj.getSkill(skill);
            string updatedSkillLevel = skillsPageObj.getSkillLevel(skillLevel);

            Assert.That(updatedSkill == skill, "Updated skill and expected skill do not match");
            Assert.That(updatedSkillLevel == skillLevel, "Updated skill and expected skill do not match");
        }

        [When(@"User delete the '([^']*)' of an existing skill")]
        public void WhenUserDeleteTheOfAnExistingSkill(string skill)
        {
            skillsPageObj.Delete_Skills(skill);
        }

        [Then(@"The '([^']*)' deleted successfully")]
        public void ThenTheDeletedSuccessfully(string skill)
        {
            string deletedSkill = skillsPageObj.getDeletedSkill(skill);

            Assert.That(deletedSkill == null, "Expected skill has not been deleted");
        }

        [Then(@"The skill message '([^']*)' should be displayed")]
        public void ThenTheSkillMessageShouldBeDisplayed(string expectedMessage)
        {
            string actualMessage = skillsPageObj.getMessage();

            Assert.That(actualMessage == expectedMessage, "Actual message and expected message do not match");
        }

    }
}

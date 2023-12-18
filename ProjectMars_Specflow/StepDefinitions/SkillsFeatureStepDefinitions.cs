using NUnit.Framework;
using ProjectMars_Specflow.Pages;
using System;
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

        [Then(@"The '([^']*)' and '([^']*)' should be added successfully")]
        public void ThenTheAndShouldBeAddedSuccessfully(string skill, string skillLevel)
        {
            string newSkill = skillsPageObj.getSkill();
            string newSkillLevel = skillsPageObj.getSkillLevel();

            Assert.That(newSkill == skill, "Actual skill and expected skill do not match");
            Assert.That(newSkillLevel == skillLevel, "Actual skill level and expected skill level do not match");
        }

        [When(@"User update the '([^']*)' and '([^']*)' of an existing skill")]
        public void WhenUserUpdateTheAndOfAnExistingSkill(string skill, string skillLevel)
        {
            skillsPageObj.Update_Skills(skill, skillLevel);
        }

        [Then(@"The '([^']*)' and '([^']*)' should be updated successfully")]
        public void ThenTheAndShouldBeUpdatedSuccessfully(string skill, string skillLevel)
        {
            string updatedSkill = skillsPageObj.getSkill();
            string updatedSkillLevel = skillsPageObj.getSkillLevel();

            Assert.That(updatedSkill == skill, "Updated skill and expected skill do not match");
            Assert.That(updatedSkillLevel == skillLevel, "Updated skill and expected skill do not match");   
        }

        [When(@"User delete the '([^']*)' of an existing skill")]
        public void WhenUserDeleteTheOfAnExistingSkill(string skill)
        {
            skillsPageObj.Delete_Skills(skill);
        }

        [Then(@"The '([^']*)' should be deleted successfully")]
        public void ThenTheShouldBeDeletedSuccessfully(string skill)
        {
            string deletedSkill = skillsPageObj.getDeletedSkill();

            Assert.That(deletedSkill != skill, "Expected skill has not been deleted");
        }

    }
}

﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace GridDemo1.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("To verify the Login page1", SourceFile="Features\\Feature2.feature", SourceLine=0)]
    public partial class ToVerifyTheLoginPage1Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Feature2.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "To verify the Login page1", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Add a customer1", new string[] {
                "Browser_Chrome",
                "Browser_Firefox"}, SourceLine=4)]
        public virtual void AddACustomer1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a customer1", new string[] {
                        "Browser_Chrome",
                        "Browser_Firefox"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("I navigate to Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Description",
                        "IsolationLevel",
                        "Size"});
            table1.AddRow(new string[] {
                        "TestName",
                        "This is a test description for test",
                        "Cluster",
                        "Large"});
#line 7
 testRunner.When("I add a customer with below data", ((string)(null)), table1, "When ");
#line 10
 testRunner.Then("I verify customer data is added as \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Basepage is Calculator1", new string[] {
                "Browser_Chrome",
                "Browser_Firefox"}, SourceLine=13)]
        public virtual void BasepageIsCalculator1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basepage is Calculator1", new string[] {
                        "Browser_Chrome",
                        "Browser_Firefox"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("I navigated to /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.Then("browser title is Calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Add a customer2", new string[] {
                "Browser_Chrome",
                "Browser_Firefox"}, SourceLine=19)]
        public virtual void AddACustomer2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a customer2", new string[] {
                        "Browser_Chrome",
                        "Browser_Firefox"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("I navigate to Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Description",
                        "IsolationLevel",
                        "Size"});
            table2.AddRow(new string[] {
                        "TestName",
                        "This is a test description for test",
                        "Cluster",
                        "Large"});
#line 22
 testRunner.When("I add a customer with below data", ((string)(null)), table2, "When ");
#line 25
 testRunner.Then("I verify customer data is added as \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion


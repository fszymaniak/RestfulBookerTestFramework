﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RestfulBookerTestFramework.Tests.Performance.Features.InjectFeatures
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Performance test inject of deleting booking")]
    [NUnit.Framework.CategoryAttribute("PerformanceTest")]
    [NUnit.Framework.CategoryAttribute("Inject")]
    [NUnit.Framework.CategoryAttribute("DeleteBookingFeature")]
    [NUnit.Framework.CategoryAttribute("AuthorizeRequest")]
    public partial class PerformanceTestInjectOfDeletingBookingFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "PerformanceTest",
                "Inject",
                "DeleteBookingFeature",
                "AuthorizeRequest"};
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/InjectFeatures", "Performance test inject of deleting booking", "Description:\r\nAs RestfulBooker user\r\nI want to sent valid DELETE request with val" +
                "id booking id to the /booking endpoint\r\nSo that I will be able to sucessfully cr" +
                "eate delete entity (201 Created Status Code) and test performance of this endpoi" +
                "nt", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "PerformanceTestInjectDeleteBooking.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Performance Inject Delete Booking Endpoint")]
        public async System.Threading.Tasks.Task PerformanceInjectDeleteBookingEndpoint()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Performance Inject Delete Booking Endpoint", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 12
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 13
        await testRunner.GivenAsync("Prerequisite: API is running", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 14
        await testRunner.AndAsync("a new valid booking request is created", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 15
        await testRunner.WhenAsync("run inject delete performance scenario: \'Create and then delete booking (inject)\'" +
                        "  with Rate: 5, Interval in seconds: 1 and During in seconds: 5", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion

﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18063
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.Toolbox.FileAndFolder.Delete
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class DeleteFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Delete.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Delete", "In order to be able to Delete file\r\nas a Warewolf user\r\nI want a tool that Delete" +
                    " a file at a given location", ProgrammingLanguage.CSharp, new string[] {
                        "fileFeature"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Delete")))
            {
                Dev2.Activities.Specs.Toolbox.FileAndFolder.Delete.DeleteFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
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
        
        public virtual void DeleteFileAtLocation(string name, string source, string sourceLocation, string username, string password, string resultVar, string result, string errorOccured, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete file at location", exampleTags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("I have a source path \'{0}\' with value \'{1}\'", source, sourceLocation), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And(string.Format("source credentials as \'{0}\' and \'{1}\'", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And(string.Format("result as \'{0}\'", resultVar), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("the delete file tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then(string.Format("the result variable \'{0}\' will be \'{1}\'", resultVar, result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.And(string.Format("the execution has \"{0}\" error", errorOccured), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Path",
                        "Username",
                        "Password"});
            table1.AddRow(new string[] {
                        string.Format("{0} = {1}", source, sourceLocation),
                        string.Format("{0}", username),
                        "String"});
#line 15
 testRunner.And("the debug inputs as", ((string)(null)), table1, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table2.AddRow(new string[] {
                        string.Format("{0} = {1}", resultVar, result)});
#line 18
 testRunner.And("the debug output as", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete file at location")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("fileFeature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Local")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "Local")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:source", "[[path]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:sourceLocation", "c:\\filetodelete.txt")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:username", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:password", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:resultVar", "[[result]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "Success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:errorOccured", "NO")]
        public virtual void DeleteFileAtLocation_Local()
        {
            this.DeleteFileAtLocation("Local", "[[path]]", "c:\\filetodelete.txt", "\"\"", "\"\"", "[[result]]", "Success", "NO", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete file at location")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("fileFeature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "UNC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "UNC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:source", "[[path]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:sourceLocation", "\\\\RSAKLFSVRSBSPDC\\FileSystemShareTestingSite\\filetodelete.txt")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:username", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:password", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:resultVar", "[[result]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "Success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:errorOccured", "NO")]
        public virtual void DeleteFileAtLocation_UNC()
        {
            this.DeleteFileAtLocation("UNC", "[[path]]", "\\\\RSAKLFSVRSBSPDC\\FileSystemShareTestingSite\\filetodelete.txt", "\"\"", "\"\"", "[[result]]", "Success", "NO", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete file at location")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("fileFeature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "UNC Secure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "UNC Secure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:source", "[[path]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:sourceLocation", "\\\\RSAKLFSVRSBSPDC\\FileSystemShareTestingSite\\Secure\\filetodelete.txt")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:username", "dev2.local\\IntegrationTester")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:password", "I73573r0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:resultVar", "[[result]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "Success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:errorOccured", "NO")]
        public virtual void DeleteFileAtLocation_UNCSecure()
        {
            this.DeleteFileAtLocation("UNC Secure", "[[path]]", "\\\\RSAKLFSVRSBSPDC\\FileSystemShareTestingSite\\Secure\\filetodelete.txt", "dev2.local\\IntegrationTester", "I73573r0", "[[result]]", "Success", "NO", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete file at location")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("fileFeature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "FTP")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "FTP")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:source", "[[path]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:sourceLocation", "ftp://rsaklfsvrsbspdc:1001/FORTESTING/filetodelete.txt")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:username", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:password", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:resultVar", "[[result]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "Success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:errorOccured", "NO")]
        public virtual void DeleteFileAtLocation_FTP()
        {
            this.DeleteFileAtLocation("FTP", "[[path]]", "ftp://rsaklfsvrsbspdc:1001/FORTESTING/filetodelete.txt", "\"\"", "\"\"", "[[result]]", "Success", "NO", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete file at location")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("fileFeature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "FTPS")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "FTPS")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:source", "[[path]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:sourceLocation", "ftp://rsaklfsvrsbspdc:1002/FORTESTING/filetodele.txt")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:username", "IntegrationTester")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:password", "I73573r0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:resultVar", "[[result]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "Success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:errorOccured", "NO")]
        public virtual void DeleteFileAtLocation_FTPS()
        {
            this.DeleteFileAtLocation("FTPS", "[[path]]", "ftp://rsaklfsvrsbspdc:1002/FORTESTING/filetodele.txt", "IntegrationTester", "I73573r0", "[[result]]", "Success", "NO", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete file at location")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("fileFeature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "SFTP")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "SFTP")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:source", "[[path]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:sourceLocation", "sftp://localhost/filetodelete.txt")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:username", "dev2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:password", "Q/ulw&]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:resultVar", "[[result]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "Success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:errorOccured", "NO")]
        public virtual void DeleteFileAtLocation_SFTP()
        {
            this.DeleteFileAtLocation("SFTP", "[[path]]", "sftp://localhost/filetodelete.txt", "dev2", "Q/ulw&]", "[[result]]", "Success", "NO", ((string[])(null)));
        }
    }
}
#pragma warning restore
#endregion

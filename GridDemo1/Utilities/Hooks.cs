using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using GridDemo1.Utilities;
//using NUnit.Framework;

namespace GridDemo1.Utilities
{
    [Binding]
    public sealed class Hooks : BaseTest
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly IObjectContainer _objectContainer;       
        new IWebDriver _webDriver;
        WebDriverHelper Driver;
        /*private static ExtentReports extentReport;
        private static ExtentTest featureName;
        private static ExtentTest scenario;*/
        //private static ExtentKlovReporter klov;

        public Hooks(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;          
        }

        //[BeforeTestRun]
        //public static void InitializeReport()
        //{
        //    //To obtain the current solution path/project path
        //    string pth = System.Reflection.Assembly.GetExecutingAssembly().Location;
        //    string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        //    string projectPath = new Uri(actualPath).LocalPath;

        //    //string projectPath = AppDomain.CurrentDomain.BaseDirectory;

        //    //Append the html report file to current project path
        //    string reportPath = projectPath + "Reports\\ExtentReport.html";
        //    var htmlReporter = new ExtentHtmlReporter(reportPath);
        //    htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

        //    //Attaching the reporter to report
        //    extentReport = new ExtentReports();
        //    extentReport.AddSystemInfo("Environment", "CAP QE Automation Report");
        //    extentReport.AddSystemInfo("User Name", System.Environment.MachineName);
        //    extentReport.AttachReporter(htmlReporter);

        //    /*klov = new ExtentKlovReporter();
        //    klov.InitMongoDbConnection("localhost", 8080);
        //    klov.ProjectName = "CAP QE Automation Report";
        //    klov.ReportName = System.Environment.UserName;
        //    extent.AttachReporter(htmlReporter, klov);*/
        //}

        ///// To capture the screenshot for extent report and return actual file path
        //private string Capture(IWebDriver driver, string screenShotName)
        //{
        //    string localpath = "";
        //    try
        //    {
        //        Thread.Sleep(2000);
        //        ITakesScreenshot ts = (ITakesScreenshot)driver;
        //        Screenshot screenshot = ts.GetScreenshot();
        //        string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        //        var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
        //        DirectoryInfo di = Directory.CreateDirectory(dir + "\\Defect_Screenshots\\");
        //        DirectorySecurity dSecurity = di.GetAccessControl();
        //        var currentUserIdentity = WindowsIdentity.GetCurrent();
        //        var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
        //                                                      FileSystemRights.Read,
        //                                                      InheritanceFlags.ObjectInherit |
        //                                                      InheritanceFlags.ContainerInherit,
        //                                                      PropagationFlags.None,
        //                                                      AccessControlType.Allow);

        //        dSecurity.AddAccessRule(fileSystemRule);
        //        di.SetAccessControl(dSecurity);
        //        string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Defect_Screenshots/" + screenShotName + ".png";
        //        localpath = new Uri(finalpth).LocalPath;
        //        screenshot.SaveAsFile(localpath);
        //    }
        //    catch (Exception e)
        //    {
        //        throw (e);
        //    }
        //    return localpath;
        //}



        //[AfterTestRun]
        //public static void TearDownReport()
        //{
        //    //Flush report once test completes
        //    extentReport.Flush();
        //}

        //[BeforeFeature]
        //public static void BeforeFeature()
        //{
        //    //Create dynamic feature name
        //    featureName = extentReport.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        //}

        //[AfterStep]
        //public void InsertReportingSteps()
        //{
        //    var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
        //    PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
        //    MethodInfo mInfo = pInfo.GetGetMethod(true);
        //    object TestResult = mInfo.Invoke(ScenarioContext.Current, null);

        //    if (ScenarioContext.Current.TestError == null) // ==> Means there is NO ERROR, ALL are PASSED
        //    {
        //        if (stepType == "Given")
        //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "Then")
        //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "And")
        //            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
        //        /*else if(stepType == "StepDefinition")
        //            scenario.CreateNode<StepDefinition>(ScenarioStepContext.Current.StepInfo.Text)*/
        //    }

        //    else if (ScenarioContext.Current.TestError != null) // ==> Means there is ERROR in the testcase.
        //    {
        //        if (stepType == "Given")
        //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException)
        //                .Fail(Capture(_webDriver, "Screenshot_" + DateTime.Now.ToString("MM_dd_yyyy HH-mm-ss-tt")));
        //        if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException)
        //                .Fail(Capture(_webDriver, "Screenshot_" + DateTime.Now.ToString("MM_dd_yyyy HH-mm-ss-tt")));
        //        if (stepType == "Then")
        //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message)
        //                .Fail(Capture(_webDriver, "Screenshot_" + DateTime.Now.ToString("MM_dd_yyyy HH-mm-ss-tt")));
        //        if (stepType == "And")
        //            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException)
        //                .Fail(Capture(_webDriver, "Screenshot_" + DateTime.Now.ToString("MM_dd_yyyy HH-mm-ss-tt")));


        //        /*string pth = System.Reflection.Assembly.GetExecutingAssembly().Location;
        //        string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        //        string projectPath = new Uri(actualPath).LocalPath;

        //        //string projectPath = AppDomain.CurrentDomain.BaseDirectory;

        //        //Append the html report file to current project path
        //        string reportPath = projectPath + "Reports";
        //        ITakesScreenshot screenshotDriver = webDriver as ITakesScreenshot;
        //        Screenshot screenshot = screenshotDriver.GetScreenshot();
        //        screenshot.SaveAsFile(reportPath, ScreenshotImageFormat.Jpeg);

        //        //string imagePath = @"reportPath";*/
        //        //scenario.AddScreenCaptureFromPath(Capture(webDriver, "Screenshot_" + DateTime.Now.ToString("MM_dd_yyyy HH-mm-ss-tt")));

        //        /*if (stepType == "Given")
        //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(Capture(webDriver, "Screenshot_" + DateTime.Now.ToString("h_mm_ss_tt")));

        //        if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(Capture(webDriver, "Screenshot" + DateTime.Now.ToString("h_mm_ss_tt")));

        //        if (stepType == "Then")
        //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(Capture(webDriver, "Screenshot" + DateTime.Now.ToString("h_mm_ss_tt")));

        //        if (stepType == "And")
        //            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(Capture(webDriver, "Screenshot" + DateTime.Now.ToString("h_mm_ss_tt")));*/
        //    }

        //    // Below code is for - When there is Pending Step Definition, report should show as SKIPPED.
        //    if (TestResult.ToString() == "StepDefinitionPending")
        //    {
        //        if (stepType == "Given")
        //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition is Pending. Please implement it.");
        //        if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition is Pending. Please implement it.");
        //        if (stepType == "Then")
        //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition is Pending. Please implement it.");
        //        if (stepType == "And")
        //            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition is Pending. Please implement it.");
        //    }

        //}


        //[BeforeScenario(Order = 1)]
        //public void BeforeScenario()
        //{
        //    scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        //}

        [BeforeScenario(Order = 0)]
        public void InitializeWebDriver()
        {           
            //webDriver = GetRemoteDriver(AppSetting("browser").ToString());
            _webDriver = GetDriver(AppSetting("browser").ToString());
            Driver = new WebDriverHelper(_webDriver);           
            _objectContainer.RegisterInstanceAs<IWebDriver>(_webDriver);
            Driver.Maximize();
            Driver.TurnOnWait(10);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Thread.Sleep(4000);
            Driver.CloseDriver();
        }
    }

    public abstract class BaseTest
    {
        protected IWebDriver _webDriver;

        /// <summary>
        /// Create and returns the WebDriver instance
        /// </summary>
        /// <param name="browserType">Browser key value which is specified in App.config file</param>
        /*// <param name="BaseUrl">Application / Test Env value which is specified in App.config file</param>*/
        /// <returns>IWebDriver instance</returns>
        public IWebDriver GetDriver(string browserType)
        {
            /*var capability = DesiredCapabilities.Chrome();
            if (_driver == null)
            {
                _driver = new RemoteWebDriver(new Uri("http://0.0.0.0:4444/wd/hub/"), capability, TimeSpan.FromSeconds(600));
            }

            return _driver;*/

            switch (browserType)
            {
                case "chrome":
                case "CHROME":
                case "Chrome":
                    ChromeOptions option = new ChromeOptions();
                    //option.AddArgument("--headless");
                    _webDriver = new ChromeDriver(option);
                    break;

                case "firefox":
                case "ff":
                case "FIREFOX":
                case "Firefox":
                case "Fire Fox":
                case "Fire fox":
                    /*var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;*/
                    _webDriver = new FirefoxDriver();
                    //_objectContainer.RegisterInstanceAs<RemoteWebDriver>(webDriver);
                    break;

                case "InternetExplorer":
                case "Internet Explorer":
                case "IE":
                case "INTERNETEXPLORER":
                case "INTERNET EXPLORER":
                    //var options = new IEOptions();
                    // options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    _webDriver = new InternetExplorerDriver();
                    break;

                default:
                    /*ChromeOptions options = new ChromeOptions();
                    //options.AddArgument("--headless");
                    _webDriver = new ChromeDriver(options);
                    break; */
                    throw new NotSupportedException($"{browserType} is not a supported browser. Please provide valid browser");
            }

            Thread.Sleep(2000);
            _webDriver.Manage().Window.Maximize();
            return _webDriver;
        }

        /// <summary>
        /// Create and returns the RemoteWebDriver instance
        /// </summary>
        /// <param name="browserType">Browser key value which is specified in App.config file</param>
        /*// <param name="BaseUrl">Application / Test Env value which is specified in App.config file</param>*/
        /// <returns>IWebDriver instance</returns>
        public IWebDriver GetRemoteDriver(string browserType)
        {
            /*var capability = DesiredCapabilities.Chrome();
            if (_driver == null)
            {
                _driver = new RemoteWebDriver(new Uri("http://0.0.0.0:4444/wd/hub/"), capability, TimeSpan.FromSeconds(600));
            }

            return _driver;*/

            switch (browserType)
            {
                case "chrome":
                case "CHROME":
                case "Chrome":
                    ChromeOptions ChromeOptions = new ChromeOptions();
                    //option.AddArgument("--headless");
                    //webDriver = new ChromeDriver(option);
                    _webDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), ChromeOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
                    break;

                case "firefox":
                case "ff":
                case "FIREFOX":
                case "Firefox":
                    /*var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;*/
                    FirefoxOptions FFOptions = new FirefoxOptions();                    
                    _webDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), FFOptions.ToCapabilities(), TimeSpan.FromSeconds(600));

                    //webDriver = new FirefoxDriver(service);
                    //_objectContainer.RegisterInstanceAs<RemoteWebDriver>(webDriver);
                    break;

                case "InternetExplorer":
                case "Internet Explorer":
                case "IE":
                case "INTERNETEXPLORER":
                case "INTERNET EXPLORER":
                    //var options = new IEOptions();
                    // options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    //webDriver = new InternetExplorerDriver();
                    break;

                default:
                    ChromeOptions DefaultChromeOptions = new ChromeOptions();
                    //options.AddArgument("--headless");
                    _webDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), DefaultChromeOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
                    break;
            }

            Thread.Sleep(4000);
            _webDriver.Manage().Window.Maximize();
            return _webDriver;
        }

        /// <summary>
        /// Looks up the application setting for the specified key. 
        /// If the setting is not specified the default value is returned.
        /// </summary>
        /// <param name="key">The key of the application setting</param>
        /// <param name="defaultValue">The default value of the application setting</param>
        /// <returns>A string that holds the value of the setting.</returns>
        public string AppSettingOrDefault(string key, string defaultValue)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(appSetting))
                appSetting = defaultValue;

            return appSetting;
        }

        /// <summary>
        /// Looks up the application setting for the specified key. 
        /// </summary>
        /// <param name="key">The key of the application setting</param>
        /// <returns>A string that holds the value of the setting.</returns>
        public string AppSetting(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            return appSetting;
        }

    }
}

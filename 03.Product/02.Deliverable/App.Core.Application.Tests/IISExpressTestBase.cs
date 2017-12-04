﻿//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Core.Application.Tests
//{
//    abstract class IISExpressTestBase {

//    const int IisPort = 2020;
//    private readonly string _applicationName;
//    private Process _iisProcess;
//    protected IISExpressTestBase(string applicationName)
//    {
//        _applicationName = applicationName;
//    }

//    public void TestInitialize()
//    {
//        // Start IISExpress
//        StartIIS();
//        Initialize();
//    }
//    [TestCleanup]
//    public void TestCleanup()
//    {
//        Cleanup();
//        // Ensure IISExpress is stopped
//        if (_iisProcess.HasExited == false)
//        {
//            _iisProcess.Kill();
//        }
//    }

//        private void StartIIS()
//    {
//        var applicationPath = GetApplicationPath(_applicationName);
//        var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
//        _iisProcess = new Process();
//        _iisProcess.StartInfo.FileName = programFiles + @"\IIS Express\iisexpress.exe";
//        _iisProcess.StartInfo.Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationPath, IisPort);
//        _iisProcess.Start();
//    }
//    protected virtual string GetApplicationPath(string applicationName)
//    {
//        var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
//        return Path.Combine(solutionFolder, applicationName);
//    }
//    public string GetAbsoluteUrl(string relativeUrl)
//    {
//        if (!relativeUrl.StartsWith("/"))
//        {
//            relativeUrl = "/" + relativeUrl;
//        }
//        return String.Format("http://localhost:{0}/{1}", IisPort, relativeUrl);
//    }
//}


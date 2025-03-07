﻿using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IFileDownloader _fileDownloader;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }
        //completes download and returns true
        //throws some exception and returns false
        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _fileDownloader.FileDownloader(string.Format("http://example.com/{0}/{1}", customerName, installerName), _setupDestinationFile);
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
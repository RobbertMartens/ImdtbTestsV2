using Domain.Enumerations;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.Helpers
{
    public class ConfigFileReader : IConfigFileReader
    {
        private readonly string[] _configFile;

        public ConfigFileReader()
        {
            try
            {
                var configFilePath = Constants.GetConfigFilePath();
                _configFile = File.ReadAllLines(configFilePath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new FileNotFoundException("config file not found! Be sure that test.config.txt is placed in Domain main folder!");
            }
        }

        public User GetCredentials()
        {
            var credentials = new User()
            {
                id = int.Parse(_configFile[0]),
                password = _configFile[1],
                username = _configFile[2]
            };
            return credentials;
        }

        public bool GetShouldLog()
        {
            if (_configFile[3].Replace(" ", "").ToLower().Equals("false"))
            {
                return false;
            }
            return true;
        }

        public Browser GetBrowser()
        {
            var browserString = _configFile[4];
            try
            {
                var browser = Enum.Parse<Browser>(browserString, true);
                return browser;
            }
            catch (ArgumentException)
            {
                var browserList = new List<Browser>();
                throw new ArgumentException($"{browserString} is not a valid browser. Please use: {PrintBrowsers()} in the config file");
            }
        }

        private string PrintBrowsers()
        {
            var browsersString = "";
            var browserList = new List<Browser>() {Browser.Chrome, Browser.Firefox, Browser.Edge, Browser.Ie};
            var builder = new StringBuilder();

            foreach (var browser in browserList)
            {
                browsersString = builder.Append(browser.ToString() + ", ").ToString();
            }
            return browsersString;
        }
    }
}

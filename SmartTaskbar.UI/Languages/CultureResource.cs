﻿using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace SmartTaskbar.UI.Languages
{
    public class CultureResource
    {
        private readonly ResourceManager _resourceManager =
            new("SmartTaskbar.UI.Languages.Resource", Assembly.GetExecutingAssembly());

        public CultureResource() { LanguageChange(); }

        public static void LanguageChange()
        {
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "zh-CN":
                case "en-US":
                case "de-DE":
                    break;
                default:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
            }
        }

        public string GetText(string name)
            => _resourceManager.GetString(name, Thread.CurrentThread.CurrentUICulture)
               ?? throw new InvalidOperationException("Failed to load Text.");
    }
}

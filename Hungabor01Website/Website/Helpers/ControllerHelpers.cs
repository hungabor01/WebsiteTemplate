﻿using Microsoft.AspNetCore.Mvc;

namespace Website.Helpers
{
    public static class ControllerHelpers
    {
        public static string GetControllerName<T>() where T : Controller
        {
            return typeof(T).Name.Replace(nameof(Controller), string.Empty).ToLower();
        }
    }
}

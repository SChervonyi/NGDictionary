﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Core
{
    public class ConfigurationManager
    {
        public string Hash { get; set; }

        public string ngAuthSecret { get; set; }

        public string AppSecret { get; set; }

        public string defaultAdminPsw { get; set; }

        public string ClientId { get; set; }

        public string ApiName { get; set; }
    }
}

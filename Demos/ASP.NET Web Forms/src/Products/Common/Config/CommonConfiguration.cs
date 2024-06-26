﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using GroupDocs.Annotation.AspNetWebForms.Products.Common.Util.Parser;
using Newtonsoft.Json;

namespace GroupDocs.Annotation.AspNetWebForms.Products.Common.Config
{
    public class CommonConfiguration : ConfigurationSection
    {
        [JsonProperty]
        public bool pageSelector { get; set; }

        [JsonProperty]
        public bool download { get; set; }

        [JsonProperty]
        public bool upload { get; set; }

        [JsonProperty]
        public bool print { get; set; }

        [JsonProperty]
        public bool browse { get; set; }

        [JsonProperty]
        public bool rewrite { get; set; }

        public bool enableRightClick { get; set; }

        private readonly NameValueCollection commonConfiguration = (NameValueCollection)ConfigurationManager.GetSection("commonConfiguration");

        /// <summary>
        /// Constructor
        /// </summary>
        public CommonConfiguration()
        {
            YamlParser parser = new YamlParser();
            dynamic configuration = parser.GetConfiguration("common");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);
            pageSelector = valuesGetter.GetBooleanPropertyValue("pageSelector", Convert.ToBoolean(commonConfiguration["isPageSelector"]));
            download = valuesGetter.GetBooleanPropertyValue("download", Convert.ToBoolean(commonConfiguration["isDownload"]));
            upload = valuesGetter.GetBooleanPropertyValue("upload", Convert.ToBoolean(commonConfiguration["isUpload"]));
            print = valuesGetter.GetBooleanPropertyValue("print", Convert.ToBoolean(commonConfiguration["isPrint"]));
            browse = valuesGetter.GetBooleanPropertyValue("browse", Convert.ToBoolean(commonConfiguration["isBrowse"]));
            rewrite = valuesGetter.GetBooleanPropertyValue("rewrite", Convert.ToBoolean(commonConfiguration["isRewrite"]));
            enableRightClick = valuesGetter.GetBooleanPropertyValue("enableRightClick", Convert.ToBoolean(commonConfiguration["enableRightClick"]));
        }
    }
}
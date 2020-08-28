﻿using System;
using System.Collections.Generic;

namespace OctoPatch.Descriptions
{
    /// <summary>
    /// Description for a single adapter
    /// </summary>
    public sealed class AdapterDescription : Description
    {
        /// <summary>
        /// Gets or sets the id of the related plugin
        /// </summary>
        public Guid PluginId { get; set; }

        /// <summary>
        /// Key for this type. Usually the type name (without namespace)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets a list of supported input/output combinations
        /// </summary>
        public List<(string input, string output)> SupportedTypeCombinations { get; }

        public AdapterDescription(Guid pluginId, string key, string displayName, string displayDescription) 
            : base(displayName, displayDescription)
        {
            PluginId = pluginId;
            Key = key;
            SupportedTypeCombinations = new List<(string input, string output)>();
        }
    }
}

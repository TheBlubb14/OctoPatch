﻿using System;
using OctoPatch.Descriptions;

namespace OctoPatch
{
    /// <summary>
    /// Common connector interface
    /// </summary>
    public interface IConnector
    {
        /// <summary>
        /// Gets the unique id of the current connector
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Returns the description
        /// </summary>
        ConnectorDescription Description { get; }
    }
}

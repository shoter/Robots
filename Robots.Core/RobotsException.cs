﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core
{
    /// <summary>
    /// Exception type used to signalize problems specific to Robots application.
    /// Main reason to create specific exception for application was to ease unit tests and only catch exceptions that I meant to catch to not have false positives/negatives in unit tests.
    /// </summary>
    public class RobotsException : Exception
    {
        public RobotsException()
        {
        }

        public RobotsException(string message) : base(message)
        {
        }

        public RobotsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RobotsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

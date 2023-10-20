using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Domain.Utilities
{
    public class LogEventsUtility
    {
        public EventId Create = new(1000, "Created");
        public EventId Read = new(1001, "Read");
        public EventId Update = new(1002, "Updated");
        public EventId Delete = new(1003, "Deleted");

        // These are also valid EventId instances, as there's
        // an implicit conversion from int to an EventId
        public const int Details = 3000;
        public const int Error = 3001;

        public EventId ReadNotFound = 4000;
        public EventId UpdateNotFound = 4001;
    }
}

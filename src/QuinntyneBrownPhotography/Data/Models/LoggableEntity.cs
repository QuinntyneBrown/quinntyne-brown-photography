using System;

namespace QuinntyneBrownPhotography.Data.Models
{
    public class LoggableEntity: ILoggable
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }
    }
}

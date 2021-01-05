using Castle.ActiveRecord;
using System;

namespace Base
{
    public enum Status
    {
        Waiting = 1,
        Querying = 2,
        Completed = 3,
    }
    [ActiveRecord("Request")]
    public class Request : ActiveRecordBase<Request>
    {
        [PrimaryKey(PrimaryKeyType.Assigned, "Id")]
        public virtual Guid Id { get; set; }

        [Property("CityName")]
        public virtual string CityName { get; set; }

        [Property("Status")]
        public virtual Status Status { get; set; }


        [Property("Date")]
        public virtual DateTime Date { get; set; }
    }
}

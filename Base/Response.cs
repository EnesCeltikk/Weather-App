using Castle.ActiveRecord;
using System;

namespace Base
{
   
    [ActiveRecord("Response")]
    public class Response : ActiveRecordBase<Response>
    {
        [PrimaryKey(PrimaryKeyType.Assigned, "Id")]
        public virtual Guid Id { get; set; }

        [Property("CityName")]
        public virtual string CityName { get; set; }

        [Property("cod")]
        public virtual int Cod { get; set; }

        [Property("temp")]
        public virtual double Temp { get; set; }

        [Property("temp_min")]
        public virtual double MinTemp { get; set; }

        [Property("temp_max")]
        public virtual double MaxTemp { get; set; }

        [Property("pressure")]
        public virtual int Pressure { get; set; }

        [Property("humidity")]
        public virtual int Humidity { get; set; }

        [Property("Date")]
        public virtual DateTime Date { get; set; }

        [Property("Status")]
        public virtual Status Status { get; set; }

        [BelongsTo("RequestId", Cascade = CascadeEnum.All)]
        public virtual Request Request { get; set; } = new Request();

    }
}

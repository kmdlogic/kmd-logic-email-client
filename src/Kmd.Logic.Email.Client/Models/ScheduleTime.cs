// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Logic.Email.Client.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ScheduleTime
    {
        /// <summary>
        /// Initializes a new instance of the ScheduleTime class.
        /// </summary>
        public ScheduleTime()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ScheduleTime class.
        /// </summary>
        public ScheduleTime(int year, int day, int month, int hour, int minute)
        {
            Year = year;
            Day = day;
            Month = month;
            Hour = hour;
            Minute = minute;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "day")]
        public int Day { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "month")]
        public int Month { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hour")]
        public int Hour { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "minute")]
        public int Minute { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Year > 9999)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Year", 9999);
            }
            if (Year < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Year", 0);
            }
            if (Day > 31)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Day", 31);
            }
            if (Day < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Day", 0);
            }
            if (Month > 12)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Month", 12);
            }
            if (Month < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Month", 0);
            }
            if (Hour > 23)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Hour", 23);
            }
            if (Hour < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Hour", 0);
            }
            if (Minute > 59)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Minute", 59);
            }
            if (Minute < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Minute", 0);
            }
        }
    }
}

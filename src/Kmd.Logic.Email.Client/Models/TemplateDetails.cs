// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Logic.Email.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class TemplateDetails
    {
        /// <summary>
        /// Initializes a new instance of the TemplateDetails class.
        /// </summary>
        public TemplateDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TemplateDetails class.
        /// </summary>
        public TemplateDetails(System.Guid? templateId = default(System.Guid?), object mergeData = default(object))
        {
            TemplateId = templateId;
            MergeData = mergeData;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "templateId")]
        public System.Guid? TemplateId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mergeData")]
        public object MergeData { get; set; }

    }
}

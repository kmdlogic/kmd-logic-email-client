// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Logic.Email.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class TemplateInformation
    {
        /// <summary>
        /// Initializes a new instance of the TemplateInformation class.
        /// </summary>
        public TemplateInformation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TemplateInformation class.
        /// </summary>
        public TemplateInformation(System.Guid? templateId = default(System.Guid?), string templateName = default(string), string createdDateTime = default(string))
        {
            TemplateId = templateId;
            TemplateName = templateName;
            CreatedDateTime = createdDateTime;
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
        [JsonProperty(PropertyName = "templateName")]
        public string TemplateName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdDateTime")]
        public string CreatedDateTime { get; set; }

    }
}
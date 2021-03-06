// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Logic.Email.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class EmailTemplate
    {
        /// <summary>
        /// Initializes a new instance of the EmailTemplate class.
        /// </summary>
        public EmailTemplate()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the EmailTemplate class.
        /// </summary>
        public EmailTemplate(System.Guid? templateId = default(System.Guid?), string templateName = default(string), bool? isDeleted = default(bool?), System.DateTime? createdDateTime = default(System.DateTime?), System.DateTime? deletedDateTime = default(System.DateTime?))
        {
            TemplateId = templateId;
            TemplateName = templateName;
            IsDeleted = isDeleted;
            CreatedDateTime = createdDateTime;
            DeletedDateTime = deletedDateTime;
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
        [JsonProperty(PropertyName = "isDeleted")]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdDateTime")]
        public System.DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deletedDateTime")]
        public System.DateTime? DeletedDateTime { get; set; }

    }
}

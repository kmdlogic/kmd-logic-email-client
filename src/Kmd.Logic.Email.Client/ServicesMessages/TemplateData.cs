using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class TemplateData
    {
        public TemplateData(Guid? templateId, JObject mergeData)
        {
            this.TemplateId = templateId;
            this.MergeData = mergeData;
        }

        public Guid? TemplateId { get; }

        public JObject MergeData { get; }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace TicketingSystem
{
    public class FormDefinition
    {
        List<FormField> formDefinition;

        public FormDefinition()
        {
            formDefinition = new List<FormField>()
            {
                new FormField()
                {
                    Name = "CreatedBy",
                    FieldType = typeof(System.String)
                },
                new FormField()
                {
                    Name = "Description",
                    FieldType = typeof(System.String)
                },
                new FormField()
                {
                    Name = "Severity",
                    FieldType = typeof(System.Int16)
                },
                new FormField()
                {
                    Name = "Status",
                    FieldType = typeof(TicketStatus)
                },
                new FormField()
                {
                    Name = "CancelledReason",
                    FieldType = typeof(CancelledReason),
                    IsConditionalField = true,
                    ConditionalFieldName = "Status",
                    ConditionalFieldValue = "Cancelled"
                },
                new FormField()
                {
                    Name = "CancelledOtherDescription",
                    FieldType = typeof(System.String),
                    IsConditionalField = true,
                    ConditionalFieldName = "CancelledReason",
                    ConditionalFieldValue = "Others"
                },
                new FormField()
                {
                    Name = "Comments",
                    FieldType = typeof(System.String),
                    IsConditionalField = true,
                    ConditionalFieldName = "Status",
                    ConditionalFieldValue = "Completed"
                }
            };
        }

        internal List<FormField> Get()
        {
            return formDefinition.Where(field => !field.IsConditionalField).ToList();
        }

        internal List<FormField> GetConditionalFields(FormField formField)
        {
            return formDefinition
                .Where(field => field.ConditionalFieldName == formField.Name && 
                                (string.IsNullOrEmpty(field.ConditionalFieldValue) || (field.ConditionalFieldValue.ToLower() == formField.Value.ToLower())))
                .ToList();
        }
    }
}

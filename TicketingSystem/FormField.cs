using System;

namespace TicketingSystem
{
    class FormField
    {
        public string Name { get; set; }

        public Type FieldType { get; set; }

        public string Value { get; set; }

        public bool IsConditionalField { get; set; }

        public string ConditionalFieldName { get; set; }

        public string ConditionalFieldValue { get; set; }

        public bool ValidateInput()
        {
            if (FieldType == typeof(string))
            {
                return !string.IsNullOrEmpty(Value);
            }
            else if (FieldType == typeof(Int16))
            {
                int number;
                return int.TryParse(Value, out number);
            }
            else if (FieldType == typeof(TicketStatus))
            {
                TicketStatus value;
                return Enum.TryParse(Value, out value);
            }
            else if (FieldType == typeof(CancelledReason))
            {
                CancelledReason value;
                return Enum.TryParse(Value, out value);
            }

            return false;
        }
    }
}

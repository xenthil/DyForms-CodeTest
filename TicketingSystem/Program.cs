using System;
using System.Collections.Generic;

namespace TicketingSystem
{
    class Program
    {
        static List<FormField> fields;
        static FormDefinition formDefinition;

        static void Main(string[] args)
        {
            ShowForm();

            Console.WriteLine("-------------- Form Values -----------------");

            var form = formDefinition.GetFormValues();
            foreach (var item in form)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }

            Console.ReadLine();
        }

        private static void GetInput(FormField field)
        {
            Console.WriteLine($"Enter {field.Name}: ");
            field.Value = Console.ReadLine();

            if (!field.ValidateInput())
            {
                Console.WriteLine("Invalid input; try again!");
                field.Value = null;
                GetInput(field);
            }
            else
            {
                var conditionalFields = formDefinition.GetConditionalFields(field);

                if (conditionalFields != null && conditionalFields.Count > 0)
                {
                    foreach (var conditionalField in conditionalFields)
                    {
                        GetInput(conditionalField);
                    }
                }
            }
        }

        private static void ShowForm()
        {
            formDefinition = new FormDefinition();
            fields = formDefinition.Get();

            foreach (var field in fields)
            {
                GetInput(field);
            }
        }
    }
}

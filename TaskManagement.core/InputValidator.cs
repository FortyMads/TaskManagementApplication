using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.core
{
    public static class InputValidator
    {
        public static bool ValidateTitle(string title)
        {
            return !string.IsNullOrWhiteSpace(title) && title.Length <= 100; 
        }

        public static bool ValidateDescription(string description)
        {
            return !string.IsNullOrWhiteSpace(description) && description.Length <= 500;
        }

        public static bool ValidateDueDate(string input, out DateTime dueDate)
        {
            return DateTime.TryParse(input, out dueDate) && dueDate >= DateTime.Now;
        }

        public static bool ValidatePriority(string input, out TaskPriority priority)
        {
            return Enum.TryParse(input, out priority) && Enum.IsDefined(typeof(TaskPriority), priority);
        }
    }
}

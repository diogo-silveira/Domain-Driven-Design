using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using Serko.Core.Domain.Entities;
using Serko.Core.Domain.Resources;

namespace Serko.Core.Domain.Scopes
{
    public static class EmployeeScope
    {
        private static ValidationContract Contract { get; set; }

        public static IReadOnlyCollection<Notification> ValidateBarcode(Employee employee)
        {
            Contract = new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(employee.Barcode.ToString(), "Barcode",
                    string.Format(Messages.ERROR_FIELD_ISNULL, "Barcode"))
                .IsNotNullOrEmpty(employee.Password, "Password",
                    string.Format(Messages.ERROR_FIELD_ISNULL, "Password"));

            return Contract.Notifications;
        }

        public static IReadOnlyCollection<Notification> ValidateUsername(Employee employee)
        {
            Contract = new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(employee.UserName, "Username",
                    string.Format(Messages.ERROR_FIELD_ISNULL, "Username"))
                .IsNotNullOrEmpty(employee.Password, "Password",
                    string.Format(Messages.ERROR_FIELD_ISNULL, "Password"));

            return Contract.Notifications;
        }
    }
}
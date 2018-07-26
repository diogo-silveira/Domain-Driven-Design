using System;
using System.Collections.Generic;
using System.Text;
using Serko.Core.Domain.Interfaces.Entity;

namespace Serko.Core.Domain.DTO.Request
{
    public class ExpenseEmailRequest:IEntity
    {
        public string EmailData { get; set; }
    }
}

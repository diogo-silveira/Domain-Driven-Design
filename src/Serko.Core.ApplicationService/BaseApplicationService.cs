using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using Serko.Core.Domain.Interfaces.ApplicationService;
using Serko.Core.Domain.Interfaces.UnitOfWork;
using Serko.Core.Domain.Resources;

namespace Serko.Core.ApplicationService
{
    public class BaseApplicationService : Notifiable, IBaseApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        protected BaseApplicationService(IUnitOfWork unitOfWork)
          => _unitOfWork = unitOfWork;

        public IEnumerable<Notification> ListNotifications()
          => Notifications;


        public bool Commit()
        {
            if (Notifications.Any())
            {
                AddNotification("Commit", Messages.ERROR_COMMIT);
                _unitOfWork.Dispose();
                return false;
            }

           _unitOfWork.Commit();
            return true;
           

        }
    }
}
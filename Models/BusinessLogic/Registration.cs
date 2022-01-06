using BuildingWorks.GlobalConstants;
using BuildingWorks.Models.BusinessLogic.Messages;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Registration;
using System;
using System.Linq;

namespace BuildingWorks.Models.BusinessLogic
{
    public class Registration
    {
        public Action UserRegistered;

        private readonly User _user;
        private readonly UserContext _userContext;

        public Registration(User user)
        {
            _user = user;
            _userContext = new UserContext();
        }

        public void Register(IMessageBehavior messagesBehavior)
        {
            if (CheckForCorrectUserCode())
            {
                if (CheckForCorrectPassword())
                {
                    UserRegistered?.Invoke();
                }
                else
                {
                    messagesBehavior.WriteMessage(RegistrationMessages.PasswordErrorRegistrationMessage);
                }
            }
            else
            {
                messagesBehavior.WriteMessage(RegistrationMessages.UniqueCodeErrorRegistrationMessage);
            }
        }

        private bool CheckForCorrectUserCode()
        {
            UnregisteredUserCode unregisteredCode = _userContext.UnregisteredUsersCodes
                .Where(user => _user.UserCode == user.Code)
                .FirstOrDefault();

            return unregisteredCode != null;
        }

        private bool CheckForCorrectPassword()
        {
            return true;
        }
    }
}

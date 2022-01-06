using BuildingWorks.GlobalConstants;
using BuildingWorks.Models.BusinessLogic.Messages;
using BuildingWorks.Models.Databasable.Contexts;
using BuildingWorks.Models.Databasable.Tables.Registration;
using System;
using System.Linq;

namespace BuildingWorks.Models.BusinessLogic
{
    public class Authentification
    {
        public Action UserEnteringAccount;

        private readonly UserContext _userContext = new UserContext();
        private readonly User _userToCheck;

        public Authentification(User userToCheck)
        {
            _userToCheck = userToCheck;
        }

        public void Authentificate(IMessageBehavior messagesBehavior)
        {
            if (CheckForExistingUserName())
            {
                if (CheckForCorrectPassword())
                {
                    UserEnteringAccount?.Invoke();
                }
                else
                {
                    messagesBehavior.WriteMessage(AuthentificationMessages.PasswordErrorAuthentificationMessage);
                }
            }
            else
            {
                messagesBehavior.WriteMessage(AuthentificationMessages.UserNameErrorAuthentificationMessage);
            }
        }

        private bool CheckForExistingUserName()
        {
            var user = _userContext.Users
                .Where(dbUserRecord => dbUserRecord.FullName == _userToCheck.FullName)
                .FirstOrDefault();

            return user != null;
        }

        private bool CheckForCorrectPassword()
        {
            var user = _userContext.Users
                .Where(dbUserRecord => dbUserRecord.Password == _userToCheck.Password)
                .FirstOrDefault();

            return user != null;
        }
    }
}

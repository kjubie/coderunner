using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Interfaces
{
    public interface IUserLogic
    {
        bool AuthenticateUser(string name, string password);
    }
}

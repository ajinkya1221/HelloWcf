using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Rpc.Dal;

namespace HelloWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private readonly IRpc _rpc;
        public Service1()
        {
            var _loginDb = new Rpc.Dal.Rpc();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string RegisterUser(string username, string password)
        {
            var isUserExists = _rpc.IsRecordExists(username);
            if (isUserExists)
            {
                return "Username already exists. Try a different one";
            }
            bool isSuccess = _rpc.SaveRecord(username, password);
            return isSuccess ? "Registration Successful" : "Registration failed";
        }

        public string LoginUser(string username)
        {
            var isUserExists = _rpc.IsRecordExists(username);
            if (isUserExists)
            {
                if (username.ToLower() == "admin")
                {
                    var count = _rpc.GetUsersCount();
                    var res = "Welcome admin. Number of registered users are " + count;
                    return res;
                }
                return "Welcome " + username + "!";
            }
            else
            {
                return "Login Failed";
            }
        }
    }
}

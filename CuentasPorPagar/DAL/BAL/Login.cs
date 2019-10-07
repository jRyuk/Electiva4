using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.BAL
{
    public class Login
    {
        private Login() { }

        public Usuarios LoginInfo = null;

        #region Bussines logic

        public bool LoginUser(string userName, string password) {


            var result = DbContext.Instance.Find<Usuarios>($"exec LoginUser '{userName}', '{password}'");

            if (result != default(Usuarios)) {

                LoginInfo = result;
                return true;
            }

            return false;

        }

        #endregion

        #region Singleton
        static Login _instance;

        public static Login Instance
        {
            get {

                _instance = _instance ?? new Login();

                return _instance;
            }
        }
        #endregion
    }
}

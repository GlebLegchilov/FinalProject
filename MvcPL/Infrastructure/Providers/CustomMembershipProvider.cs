﻿using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using BLLInterface.Entities;
using BLLInterface.Services;

namespace MvcPL.Infrastructure.Providers
{
    //провайдер членства помогает системе идентифицировать пользователя
    public class CustomMembershipProvider : MembershipProvider
    {

        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public MembershipUser CreateUser(string name, string password)
        {
            MembershipUser membershipUser = GetUser(name, false);

            if (membershipUser != null)
            {
                return null;
            }

            var user = new UserEntity
            {
                UserName = name,
                Password = Crypto.HashPassword(password),
                //http://msdn.microsoft.com/ru-ru/library/system.web.helpers.crypto(v=vs.111).aspx
                CreationDate = DateTime.Now
            };

            var role = roleService.GetAllRoles().FirstOrDefault(r => r.Name == "User");
            if (role != null)
            {
                user.RoleId = role.Id;
            }

            userService.CreateUser(user);
            membershipUser = GetUser(name, false);
            return membershipUser;
        }

        public override bool ValidateUser(string name, string password)
        {
            var user = userService.GetUserEntityByName(name);

            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
            //Определяет, соответствуют ли заданный хэш RFC 2898 и пароль друг другу
            {
                return true;
            }
            return false;
        }

        public override MembershipUser GetUser(string name, bool userIsOnline)
        {
            var user = userService.GetUserEntityByName(name);

            if (user == null) return null;

            var memberUser = new MembershipUser("CustomMembershipProvider", user.UserName,
                null, null, null, null,
                false, false, user.CreationDate,
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);

            return memberUser;
        }

        #region Stabs
        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        #endregion     
    }
}
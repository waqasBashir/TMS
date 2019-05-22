﻿// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="BALUsers.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using TMS.Business.Interfaces.TMS;
using TMS.DataObjects.Interfaces;
using TMS.DataObjects.Interfaces.Common.Groups;
using TMS.Library.Users;
using System.Linq;
using TMS.Common.Utilities;
using TMS.Library.TMS.Persons;
using TMS.Library.Entities.TMS.Program;

namespace TMS.Business.TMS
{
    /// <summary>
    /// Class BALUsers.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.TMS.IBALUsers" />
    public class BALUsers : IBALUsers
    {
        /// <summary>
        /// Gets or sets the dal.
        /// </summary>
        /// <value>The dal.</value>
        public IUserDAL _DAL { get; set; }
        private IGroupsDAL _GroupsDAL { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BALUsers"/> class.
        /// </summary>
        /// <param name="_UserDAL">The user dal.</param>
        /// <param name="DAL">The dal.</param>
        public BALUsers(IUserDAL _UserDAL,IGroupsDAL DAL)
        {
            _DAL = _UserDAL; this._GroupsDAL = DAL;
        }

        /// <summary>
        /// Logins the user bal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>Users.</returns>
        public Users LoginUserBAL(string Email)
        {
            return _DAL.LoginUserDAL(Email);
        }

        /// <summary>
        /// Updates the user locked out bal.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="UserID">The user identifier.</param>
        /// <param name="LockedOutAttempt">The locked out attempt.</param>
        /// <param name="IsLockedOut">if set to <c>true</c> [is locked out].</param>
        /// <returns>System.Int32.</returns>
        public int UpdateUserLockedOutBAL(string Email, long UserID, int LockedOutAttempt, bool IsLockedOut)
        {
            return _DAL.UpdateUserLockedOut(Email, UserID, LockedOutAttempt, IsLockedOut);
        }

        /// <summary>
        /// Updates the login user themes dal.
        /// </summary>
        /// <param name="theme">The theme.</param>
        /// <param name="UserId">The user identifier.</param>
        public void UpdateLoginUserThemesDAL(string theme, long UserId)
        {
            _DAL.UpdateLoginUserThemes(theme, UserId);
        }


       public void Create_UserHistoryBAL(UserHistory userlogin)
        {
            _DAL.Create_UserHistoryDAL(userlogin);
        }


        public void Update_UserHistoryBAL(UserHistory userlogin)
        {
            _DAL.Update_UserHistoryDAL(userlogin);
        }
        /// <summary>
        /// TMSs the users get all assigned security groups bal.
        /// </summary>
        /// <param name="UserID">The user identifier.</param>
        /// <returns>IList&lt;UserGroupsList&gt;.</returns>
        public IList<UserGroupsList> TMS_Users_GetAllAssignedSecurityGroupsBAL(long UserID)
        {
            return _DAL.TMS_Users_GetAllAssignedSecurityGroupsDAL(UserID);
        }

        #region"User CURD"
        public IList<LoginUsers> LoginUsers_GetAllBAL(string culture)
        {
            return _DAL.LoginUsers_GetAllDAL(culture);
        }
        public IList<LoginUsers> LoginUsersOrganization_GetAllBAL(string culture, string ID)
        {
            return _DAL.LoginUsersOrganization_GetAllDAL(culture, ID);
        }
        // With Search
        public IList<LoginUsers> LoginUsers_GetAllBAL(string culture,string SearchText)
        {
            return _DAL.LoginUsers_GetAllDAL(culture,SearchText);
        }
        public IList<LoginUsers> LoginUsersOrganization_GetAllBAL(string culture, string ID, string SearchText)
        {
            return _DAL.LoginUsersOrganization_GetAllDAL(culture, ID, SearchText);
        }
        /// <summary>
        /// Logins the users get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        public IList<LoginUsers> LoginUsers_GetAllBAL(string culture, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return _DAL.LoginUsers_GetAllDAL(culture, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <summary>
        /// Logins the users by Organization get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="culture">The Organization.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        public IList<LoginUsers> LoginUsersOrganization_GetAllBAL(string culture,string ID, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return _DAL.LoginUsersOrganization_GetAllDAL(culture,ID, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <summary>
        /// Logins the users create bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int64.</returns>
        public long LoginUsers_CreateBAL(ref LoginUsers _objUsers)
        {
            var UserID = _DAL.LoginUsers_CreateDAL(_objUsers);
            if (UserID != -1)
            {
                

                if (_objUsers.UserGroups != null)
                {
                    foreach (var grp in _objUsers.UserGroups)
                    {
                        
                        grp.Id = UserID;
                        grp.IsNew = false;
                       grp.MappingId= this._GroupsDAL.TMS_Users_TMS_GroupsMapping_CreateDAL(grp, _objUsers.CreatedBy);
                    }
                }
            }
            return UserID;// _DAL.LoginUsers_CreateDAL(_objUsers);
        }
        private  bool HandleSendEmailToUser(){
            return true;
        }
        /// <summary>
        /// Logins the users update bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_UpdateBAL(LoginUsers _objUsers)
        {

            if (_objUsers.GroupIds == null)
            {
                if (_objUsers.UserGroups != null)
                {
                    for (int i = 0; i < _objUsers.UserGroups.Count; i++)
                    {
                        if (_objUsers.UserGroups[i] != null)
                        {
                            _objUsers.UserGroups[i].Id = _objUsers.UserID;
                            _objUsers.UserGroups[i].IsNew = false;
                            _objUsers.UserGroups[i].MappingId=this._GroupsDAL.TMS_Users_TMS_GroupsMapping_CreateDAL(_objUsers.UserGroups[i], _objUsers.UpdatedBy);
                            _objUsers.GroupIds = _objUsers.GroupIds + _objUsers.UserGroups[i].GroupId.ToString();
                            if (_objUsers.UserGroups.Count - 1 != i)
                            {
                                _objUsers.GroupIds = _objUsers.GroupIds.ToString() + ",";
                            }
                        }
                    }
                }
            }
            else
            {
                char[] delimiters = new char[] { ',' };
                List<string> _GroupIds = _objUsers.GroupIds.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (_GroupIds.Count > 0)
                {
                    if (_objUsers.UserGroups == null)
                    {
                        for (int i = 0; i < _GroupIds.Count; i++)
                        {
                            LoginUserGroups _ObjTMS_Groups = new LoginUserGroups();
                            _ObjTMS_Groups.Id = _objUsers.UserID;
                            _ObjTMS_Groups.GroupId = Convert.ToInt64(_GroupIds[i]);
                            this._GroupsDAL.TMS_Users_TMS_GroupsMapping_DeleteDAL(_ObjTMS_Groups, _objUsers.UpdatedBy);
                        }
                        //delete all item from the Database
                        _objUsers.GroupIds = null;
                    }
                    else if (_objUsers.UserGroups.Count == 0)
                    {
                        for (int i = 0; i < _GroupIds.Count; i++)
                        {
                            LoginUserGroups _ObjTMS_Groups = new LoginUserGroups();
                            _ObjTMS_Groups.Id = _objUsers.UserID;
                            _ObjTMS_Groups.GroupId = Convert.ToInt64(_GroupIds[i]);
                            this._GroupsDAL.TMS_Users_TMS_GroupsMapping_DeleteDAL(_ObjTMS_Groups, _objUsers.UpdatedBy);
                        }
                        //delete all item from the Database
                        _objUsers.GroupIds = null;
                    }
                    else
                    {
                        //if (_objUsers.UserGroups.Count > _GroupIds.Count)
                        //{
                        //    for (int i = 0; i < _objUsers.UserGroups.Count; i++)
                        //    {
                        //        var _result = _GroupIds.FirstOrDefault(stringToCheck => stringToCheck.Contains(_objUsers.UserGroups[i].GroupId.ToString()));
                        //        if (string.IsNullOrEmpty(_result))
                        //        {
                        //            _objUsers.UserGroups[i].Id = _objUsers.UserID;
                        //            _objUsers.UserGroups[i].IsNew = false;
                        //            _objUsers.UserGroups[i].MappingId =this._GroupsDAL.TMS_Users_TMS_GroupsMapping_CreateDAL(_objUsers.UserGroups[i], _objUsers.UpdatedBy);
                        //            _objUsers.GroupIds = _objUsers.GroupIds + "," + _objUsers.UserGroups[i].GroupId.ToString();
                        //        }
                        //        else
                        //        {

                        //        }
                        //    }
                        //}
                        //else
                        //{
                            for (int i = 0; i < _GroupIds.Count; i++)
                            {
                                var _result = _objUsers.UserGroups.FirstOrDefault(s => s.GroupId == Convert.ToInt64(_GroupIds[i]));
                                if (_result == null)
                                {
                                    LoginUserGroups _ObjTMS_Groups = new LoginUserGroups();
                                    _ObjTMS_Groups.Id = _objUsers.UserID;
                                    _ObjTMS_Groups.GroupId = Convert.ToInt64(_GroupIds[i]);
                                    this._GroupsDAL.TMS_Users_TMS_GroupsMapping_DeleteDAL(_ObjTMS_Groups, _objUsers.UpdatedBy);
                                }
                                
                            }
                            foreach (var grop in _objUsers.UserGroups)
                            {
                                if (grop.IsNew)
                                {
                                    grop.IsNew = false;
                                    grop.Id = _objUsers.UserID;
                                    grop.MappingId = this._GroupsDAL.TMS_Users_TMS_GroupsMapping_CreateDAL(grop, _objUsers.UpdatedBy);
                                }
                            }
                            _objUsers.GroupIds = "";
                            for (int i = 0; i < _objUsers.UserGroups.Count; i++)
                            {
                                _objUsers.GroupIds = _objUsers.GroupIds + _objUsers.UserGroups[i].GroupId.ToString();
                                if (_objUsers.UserGroups.Count - 1 != i)
                                {
                                    _objUsers.GroupIds = _objUsers.GroupIds.ToString() + ",";
                                }
                            }
                        //}
                    }
                }
                else
                {
                }
            }


            return _DAL.LoginUsers_UpdateDAL(_objUsers);
        }

        /// <summary>
        /// Logins the users delete bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_DeleteBAL(LoginUsers _objUsers)
        {
            return _DAL.LoginUsers_DeleteDAL(_objUsers);
        }

        /// <summary>
        /// Logins the users update password bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_UpdatePasswordBAL(LoginUsers _objUsers)
        {
            return _DAL.LoginUsers_UpdatePasswordDAL(_objUsers);
        }

        /// <summary>
        /// Logins the users duplication check bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_DuplicationCheckBAL(LoginUsers _objUsers)
        {
            return _DAL.LoginUsers_DuplicationCheckDAL(_objUsers);
        }
        public int LoginPerson_DuplicationCheckBAL(Person objperson)
        {
            return _DAL.LoginPerson_DuplicationCheckDAL(objperson);
        }
        int DeletePerson_CheckBAL(ClassTrainerMapping classTrainerMapping)
        {
            return _DAL.DeletePerson_CheckDAL(classTrainerMapping);
        }
        /// <summary>
        /// Logins the users update profile image bal.
        /// </summary>
        /// <param name="_objUsers">The object users.</param>
        /// <returns>System.Int32.</returns>
        public int LoginUsers_UpdateProfileImageBAL(LoginUsers _objUsers)
        {
            return _DAL.LoginUsers_UpdateProfileImageDAL(_objUsers);
        }
        #endregion

        #region Trainer CURD
        /// <summary>
        /// Logins the users get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        public IList<LoginUsers> TrainerUsers_GetAllBAL(string culture)
        {

            return _DAL.TrainerUsers_GetAllDAL(culture);
        }

        int IBALUsers.DeletePerson_CheckBAL(ClassTrainerMapping classTrainerMapping)
        {
            return _DAL.DeletePerson_CheckDAL(classTrainerMapping);
        }
        #endregion
    }
}
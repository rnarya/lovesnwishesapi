using Lovesnwishes.DataBase;
using Lovesnwishes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lovesnwishes.BusniessLogic
{
    public class UserService
    {
        lovesnwishesEntities objlovesnwishesEntities = new lovesnwishesEntities();
        public UserResponse Registration(RequestUser req)
        {
            UserResponse objRes = new UserResponse();
            try
            {
                var query = objlovesnwishesEntities.tblUsers.Where(x => x.Email.ToLower() == req.Email.ToLower()).FirstOrDefault();
                if (query == null)
                {
                    tblUser objtblUser = new tblUser()
                    {
                        Email = req.Email,
                        FirstName = req.FirstName,
                        LastName = req.LastName,
                        MobileNo = req.MobileNo,
                        Password = req.Password,
                        ProfileImageUrl = req.PhotoUrl,
                    };
                    objlovesnwishesEntities.tblUsers.Add(objtblUser);
                    objlovesnwishesEntities.SaveChanges();
                    objRes.UserId = objtblUser.Id;
                }
                else
                {
                    objRes.UserId = 0;
                }

            }
            catch (Exception ex)
            {

            }
            return objRes;
        }

        public ResponseUser GetUserProfile(int userid)
        {
            ResponseUser objResponseUser = new ResponseUser();
            try
            {
                var query = objlovesnwishesEntities.tblUsers.Where(x => x.Id == userid).FirstOrDefault();
                if (query != null)
                {
                    objResponseUser = new ResponseUser()
                    {
                        UserId = query.Id,
                        Email = query.Email,
                        FirstName = query.FirstName,
                        LastName = query.LastName,
                        MobileNo = query.MobileNo,
                        Password = query.Password,
                        PhotoUrl = query.ProfileImageUrl
                    };

                }
            }
            catch (Exception ex)
            {

            }
            return objResponseUser;
        }


        public UserResponse UpdateProfile(RequestUser req)
        {
            UserResponse objRes = new UserResponse();
            try
            {
                var query = objlovesnwishesEntities.tblUsers.Where(x => x.Id == req.Id).FirstOrDefault();
                if (query != null)
                {
                    query.FirstName = req.FirstName;
                    query.LastName = req.LastName;
                    query.MobileNo = req.MobileNo;
                    objlovesnwishesEntities.SaveChanges();
                    objRes.UserId = query.Id;
                }
                else
                {
                    objRes.UserId = 0;
                }
            }
            catch (Exception ex)
            {

            }
            return objRes;
        }


        public UserResponse ChangePassword(RequestUser req)
        {
            UserResponse objRes = new UserResponse();
            try
            {
                var query = objlovesnwishesEntities.tblUsers.Where(x => x.Id == req.Id).FirstOrDefault();
                if (query != null)
                {
                    query.Password = req.Password;
                    objlovesnwishesEntities.SaveChanges();
                    objRes.UserId = query.Id;
                }
                else
                {
                    objRes.UserId = 0;
                }

            }
            catch (Exception ex)
            {

            }
            return objRes;
        }

        public UserResponse UpdateProfileImage(ProfileImage req)
        {
            UserResponse objRes = new UserResponse();
            try
            {
                var query = objlovesnwishesEntities.tblUsers.Where(x => x.Id == req.id).FirstOrDefault();
                if (query != null)
                {
                    query.ProfileImageUrl = req.profilepicurl;
                    objlovesnwishesEntities.SaveChanges();
                    objRes.UserId = query.Id;
                }
                else
                {
                    objRes.UserId = 0;
                }

            }
            catch (Exception ex)
            {

            }
            return objRes;
        }
        public ResponseUser Login(Login login)
        {
            ResponseUser objResponseUser = new ResponseUser();
            try
            {
                var query = objlovesnwishesEntities.tblUsers.Where(x => x.Email.Trim().ToLower() == login.Email.Trim().ToLower() && x.Password.Trim().ToLower() == login.Password.Trim().ToLower()).FirstOrDefault();
                if (query != null)
                {
                    objResponseUser = new ResponseUser()
                    {
                        UserId = query.Id,
                        Email = query.Email,
                        FirstName = query.FirstName,
                        LastName = query.LastName,
                        MobileNo = query.MobileNo,
                        Password = query.Password,
                        PhotoUrl = query.ProfileImageUrl
                    };

                }
            }
            catch (Exception ex)
            {

            }
            return objResponseUser;
        }
    }
}
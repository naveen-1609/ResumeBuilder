using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class tRegistrationDAL
    {
        #region Add data to database
        ResumeDbEntities dbcontext = new ResumeDbEntities();
        public bool SaveRegistrations(tRegistration reg)
        {
            if (reg != null)
            {
                dbcontext.tRegistrations.Add(reg);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion
        #region UPDATE data in database
        public bool update(tRegistration reg)
        {
            if (reg != null)
            {
                tRegistration ExistingUser = dbcontext.tRegistrations.Where(temp => temp.User_Name == reg.User_Name).FirstOrDefault();

                ExistingUser.Fname = reg.Fname;
                ExistingUser.Lname = reg.Lname;
                ExistingUser.dob = reg.dob;
                ExistingUser.User_Name = reg.User_Name;
                ExistingUser.Password = reg.Password;
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }



        }


        #endregion
        #region Delete User from Database
        public bool Delete(string User_Name)
        {
            if (User_Name != null)
            {
                tRegistration reg = dbcontext.tRegistrations.Find(User_Name);
                dbcontext.tRegistrations.Remove(reg);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Select User from Database
        public tRegistration Select(string User)
        {
            if (User != null)
            {
                tRegistration admin = dbcontext.tRegistrations.Where(temp => temp.User_Name == User).FirstOrDefault();
                return admin;
            }
            else
            {
                return null;
            }

        }
        #endregion
        #region List of Users in database
        public List<tRegistration> GetAllUsers()
        {
            var usrlist = dbcontext.tRegistrations.ToList();
            return usrlist;
        }
        #endregion
    }
}

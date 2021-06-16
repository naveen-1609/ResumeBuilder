using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class tALoginDAL
    {
        ResumeDbEntities dbcontext = new ResumeDbEntities();
        #region Add data to database
        public bool SaveAdmin(tALogin adm)
        {
            if (adm != null)
            {
                dbcontext.tALogins.Add(adm);
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
        public bool update(tALogin admin)
        {
            if (admin != null)
            {
                tALogin ExistingAdmin = dbcontext.tALogins.Where(temp => temp.Admin_Id == admin.Admin_Id).FirstOrDefault();

                ExistingAdmin.Admin_Id = admin.Admin_Id;
                ExistingAdmin.Password = admin.Password;
                
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }



        }


        #endregion
        #region Delete Admin from Database
        public bool Delete(string Admin_Id)
        {
            if (Admin_Id != null)
            {
                tALogin admin = dbcontext.tALogins.Find(Admin_Id);
                dbcontext.tALogins.Remove(admin);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Select Admin from Database
        public tALogin Select(string Id)
        {
            if (Id != null)
            {
                tALogin admin = dbcontext.tALogins.Where(temp => temp.Admin_Id == Id).FirstOrDefault();
                return admin;
            }
            else
            {
                return null;
            }

        }
        #endregion
        #region List of Admins in database
        public List<tALogin> GetAllAdmins()
        {
            var admlist = dbcontext.tALogins.ToList();
            return admlist;
        }
        #endregion
    }
}

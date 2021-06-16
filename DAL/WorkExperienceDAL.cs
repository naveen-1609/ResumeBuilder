using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class WorkExperienceDAL
    {

        ResumeDbEntities dbcontext = new ResumeDbEntities();
        #region Add data to database
        public bool SaveExperience(WorkExperience we)
        {
            if (we != null)
            {
                dbcontext.WorkExperiences.Add(we);
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
        public bool update(WorkExperience we)
        {
            if (we != null)
            {
                WorkExperience ExistingWE = dbcontext.WorkExperiences.Where(temp => temp.IDExp == we.IDExp).FirstOrDefault();

                ExistingWE.IDExp = we.IDExp;
                ExistingWE.Company = we.Company;
                ExistingWE.Title = we.Title;
                ExistingWE.Country = we.Country;
                ExistingWE.FromYear = we.FromYear;
                ExistingWE.ToYear = we.ToYear;
                ExistingWE.Description = we.Description;
                ExistingWE.IDPers = we.IDPers;


                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }



        }


        #endregion
        #region Delete Work Experience from Database
        public bool Delete(int IDEmp)
        {
            if (IDEmp != 0)
            {
                WorkExperience emp = dbcontext.WorkExperiences.Find(IDEmp);
                dbcontext.WorkExperiences.Remove(emp);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Select Work Experience from Database
        public WorkExperience Select(int Id)
        {
            if (Id != 0)
            {
                WorkExperience we = dbcontext.WorkExperiences.Where(temp => temp.IDExp == Id).FirstOrDefault();
                return we;
            }
            else
            {
                return null;
            }

        }
        #endregion
        #region List of Work Experiences in database
        public List<WorkExperience> GetAllWorkExperiences()
        {
            var welist = dbcontext.WorkExperiences.ToList();
            return welist;
        }
        #endregion
    }
}

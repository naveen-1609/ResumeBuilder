using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class EducationDAL
    {
        ResumeDbEntities dbcontext = new ResumeDbEntities();
        #region Add data to database
        public bool SaveEducation(Education edu)
        {
            if (edu != null)
            {
                dbcontext.Educations.Add(edu);
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
        public bool update(Education edu)
        {
            if (edu != null)
            {
                Education ExistingEducation = dbcontext.Educations.Where(temp => temp.IDEdu == edu.IDEdu).FirstOrDefault();

                ExistingEducation.IDEdu = edu.IDEdu;
                ExistingEducation.InstituteUniversity = edu.InstituteUniversity;
                ExistingEducation.InstituteUniversity = edu.InstituteUniversity;
                ExistingEducation.TitleOfDiploma = edu.TitleOfDiploma;
                ExistingEducation.Degree = edu.Degree;
                ExistingEducation.FromYear = edu.FromYear;
                ExistingEducation.ToYear = edu.ToYear;
                ExistingEducation.City = edu.City;
                ExistingEducation.Country = edu.Country;
                ExistingEducation.IdPers = edu.IdPers;

                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }



        }


        #endregion
        #region Delete Education from Database
        public bool Delete(int IDEdu)
        {
            if (IDEdu != 0)
            {
                Education education = dbcontext.Educations.Find(IDEdu);
                dbcontext.Educations.Remove(education);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Select Education from Database
        public Education Select(int Id)
        {
            if (Id != 0)
            {
                Education edu = dbcontext.Educations.Where(temp => temp.IDEdu == Id).FirstOrDefault();
                return edu;
            }
            else
            {
                return null;
            }

        }
        #endregion
        #region List of Education in database
        public List<Education> GetAllEducation()
        {
            var edulist = dbcontext.Educations.ToList();
            return edulist;
        }
        #endregion
    }
}

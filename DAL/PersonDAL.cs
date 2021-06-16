using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class PersonDAL
    {
        ResumeDbEntities dbcontext = new ResumeDbEntities();
        #region Add data to database
        public bool SavePrson(Person ppl)
        {
            if (ppl != null)
            {
                dbcontext.People.Add(ppl);
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
        public bool update(Person ppl)
        {
            if (ppl != null)
            {
                Person ExistingPerson = dbcontext.People.Where(temp => temp.IDPers == ppl.IDPers).FirstOrDefault();

                ExistingPerson.IDPers = ppl.IDPers;
                ExistingPerson.FirstName = ppl.FirstName;
                ExistingPerson.LastName = ppl.LastName;
                ExistingPerson.DateOfBirth = ppl.DateOfBirth;
                ExistingPerson.Nationality = ppl.Nationality;
                ExistingPerson.EducationalLevel = ppl.EducationalLevel;
                ExistingPerson.Address = ppl.Address;
                ExistingPerson.Tel = ppl.Tel;
                ExistingPerson.Email = ppl.Email;
                ExistingPerson.Summary = ppl.Summary;
                ExistingPerson.LinkedInProdil = ppl.LinkedInProdil;
                ExistingPerson.FaceBookProfil = ppl.FaceBookProfil;
                ExistingPerson.C_CornerProfil = ppl.C_CornerProfil;
                ExistingPerson.TwitterProfil = ppl.TwitterProfil;
                ExistingPerson.User_Name = ppl.User_Name;
                ExistingPerson.Profil = ppl.Profil;

                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }



        }


        #endregion
        #region Delete person from Database
        public bool Delete(int IdPers)
        {
            if (IdPers != 0)
            {
                Person ppl = dbcontext.People.Find(IdPers);
                dbcontext.People.Remove(ppl);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Select Person from Database
        public Person Select(int Id)
        {
            if (Id != 0)
            {
                Person ppl = dbcontext.People.Where(temp => temp.IDPers == Id).FirstOrDefault();
                return ppl;
            }
            else
            {
                return null;
            }

        }
        #endregion
        #region List of People in database
        public List<Person> GetAllPeople()
        {
            var ppllist = dbcontext.People.ToList();
            return ppllist;
        }
        #endregion
    }
}

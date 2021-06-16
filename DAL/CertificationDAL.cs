using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CertificationDAL
    {
        ResumeDbEntities dbcontext = new ResumeDbEntities();
        #region Add data to database
        public bool SaveCertification(Certification cer)
        {
            if (cer != null)
            {
                dbcontext.Certifications.Add(cer);
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
        public bool update(Certification cer)
        {
            if (cer != null)
            {
                Certification ExistingCertification = dbcontext.Certifications.Where(temp => temp.IdCer == cer.IdCer).FirstOrDefault();

                ExistingCertification.IdCer = cer.IdCer;
                ExistingCertification.CertificationName = cer.CertificationName;
                ExistingCertification.CertificationAuthority = cer.CertificationAuthority;
                ExistingCertification.LevelCertification = cer.LevelCertification;
                ExistingCertification.FromYear = cer.FromYear;
                ExistingCertification.IdPers = cer.IdPers;

                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }



        }


        #endregion
        #region Delete Certification from Database
        public bool Delete(int IdCer)
        {
            if (IdCer != 0)
            {
                Certification cer = dbcontext.Certifications.Find(IdCer);
                dbcontext.Certifications.Remove(cer);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Select Certification from Database
        public Certification Select(int Id)
        {
            if (Id != 0)
            {
                Certification admin = dbcontext.Certifications.Where(temp => temp.IdCer == Id).FirstOrDefault();
                return admin;
            }
            else
            {
                return null;
            }

        }
        #endregion
        #region List of Cerrtifications in database
        public List<Certification> GetAllCertification()
        {
            var admlist = dbcontext.Certifications.ToList();
            return admlist;
        }
        #endregion
    }
}

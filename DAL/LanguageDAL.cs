using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class LanguageDAL
    {
        ResumeDbEntities dbcontext = new ResumeDbEntities();
        #region Add data to database
        public bool SaveLanguage(Language lang)
        {
            if (lang != null)
            {
                dbcontext.Languages.Add(lang);
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
        public bool update(Language lang)
        {
            if (lang != null)
            {
                Language ExistingLang = dbcontext.Languages.Where(temp => temp.IDLang == lang.IDLang).FirstOrDefault();

                ExistingLang.IDLang = lang.IDLang;
                ExistingLang.LanguageName = lang.LanguageName;
                ExistingLang.Proficiency = lang.Proficiency;

                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }



        }


        #endregion
        #region Delete Language from Database
        public bool Delete(int IDLang)
        {
            if (IDLang != 0)
            {
                Language lang = dbcontext.Languages.Find(IDLang);
                dbcontext.Languages.Remove(lang);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Select Language from Database
        public Language Select(int Id)
        {
            if (Id != 0)
            {
                Language lang = dbcontext.Languages.Where(temp => temp.IDLang == Id).FirstOrDefault();
                return lang;
            }
            else
            {
                return null;
            }

        }
        #endregion
        #region List of Languages in database
        public List<Language> GetAllLanguages()
        {
            var langlist = dbcontext.Languages.ToList();
            return langlist;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class SkillDAL
    {
        ResumeDbEntities dbcontext = new ResumeDbEntities();
        #region Add data to database
        public bool SaveSkill(Skill ski)
        {
            if (ski != null)
            {
                dbcontext.Skills.Add(ski);
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
        public bool update(Skill ski)
        {
            if (ski != null)
            {
                Skill ExistingSkill = dbcontext.Skills.Where(temp => temp.IDSki == ski.IDSki).FirstOrDefault();

                ExistingSkill.IDSki = ski.IDSki;
                ExistingSkill.SkillName = ski.SkillName;
                ExistingSkill.IdPers = ski.IdPers;

                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }



        }


        #endregion
        #region Delete Skill from Database
        public bool Delete(string IDSki)
        {
            if (IDSki != null)
            {
                Skill ski = dbcontext.Skills.Find(IDSki);
                dbcontext.Skills.Remove(ski);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Select Skill from Database
        public Skill Select(int Id)
        {
            if (Id != 0)
            {
                Skill ski = dbcontext.Skills.Where(temp => temp.IDSki == Id).FirstOrDefault();
                return ski;
            }
            else
            {
                return null;
            }

        }
        #endregion
        #region List of Skills in database
        public List<Skill> GetAllSkills()
        {
            var skilist = dbcontext.Skills.ToList();
            return skilist;
        }
        #endregion
    }
}

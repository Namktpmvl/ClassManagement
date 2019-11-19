using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManagement
{
    public class ClassManagement
    {
        public Class[] GetClass()
        {
            var db = new OOPCSharfEntities();
            var classes =  db.Classes.ToArray();

            return classes;
        }

        public void AddClass(string name , string description)
        {
            var newClass = new Class();
            newClass.Name = name;
            newClass.Description = description;

            var db = new OOPCSharfEntities();
            db.Classes.Add(newClass);
            db.SaveChanges();
        }

        public void EditClass(int id, string name, string description)
        {
            var db = new OOPCSharfEntities();
            var oldClass = db.Classes.Find(id);

            oldClass.Name = name;
            oldClass.Description = description;

            db.Entry(oldClass).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteClass(int id)
        {
            var db = new OOPCSharfEntities();
            var @class = db.Classes.Find(id);
            db.Classes.Remove(@class);
            db.SaveChanges();
        }

        public Class GetClass(int id)
        {
            var db = new OOPCSharfEntities();
            var @class = db.Classes.Find(id);
            return @class;
        }
    }
}

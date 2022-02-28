using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magazin
{
    class Zakaz
    {

        public int id_zakaz { get => _id; }
        private int _id = -1;
        public int id_polzovatel { get; set; }






        public Zakaz()
        {

        }
        public Zakaz(Dictionary<string, object> data)
        {

            this._id = (int)data["id_zakaz"];

            this.id_polzovatel = (int)data["id_polzovatel"];
        }

        public static Zakaz getById(int id)
        {
            var data = App.db.execute("select * from \"zakaz\" where \"zakaz\"=@zakaz;",
                new Dictionary<string, object>()
                {
                    { "zakaz", id }

                });
            if (data.Count == 0)
            {
                return new Zakaz();
            }

            return new Zakaz(data[0]);
        }
        public static List<Zakaz> getAll()
        {
            List<Zakaz> roles = new List<Zakaz>();
            foreach (var data in App.db.execute("select * from \"zakaz\" where true;"))
            {
                roles.Add(new Zakaz(data));
            }

            return roles;
        }

        public static List<Zakaz> getByPosition(int familia)
        {
            List<Zakaz> roles = new List<Zakaz>();
            foreach (var data in App.db.execute("select * from \"Zakaz\" where id_familia=@id_familia;", new Dictionary<string, object>() { { "@id_familia", familia } }))
            {

                roles.Add(new Zakaz(data));

            }
            return roles;
        }
        public static List<Zakaz> getByPositionUser(int familia)
        {
            List<Zakaz> roles = new List<Zakaz>();
            foreach (var data in App.db.execute("select * from \"zakaz\" where id_familia=@id_familia;", new Dictionary<string, object>() { { "@id_familia", familia } }))
            {

                roles.Add(new Zakaz(data));

            }
            return roles;
        }

        public bool exists()
        {
            return _id != -1;
        }
        public void delete()
        {
            App.db.execute("delete from \"zakaz\" where \"id_zakaz\"=@id_zakaz;",
                new Dictionary<string, object>
                {
                    { "id_zakaz", id_zakaz }
                });
            _id = -1;
        }

        public void save()
        {
            if (this.exists())
            {
                App.db.execute(

                    "UPDATE \"zakaz\" SET   id_polzovatel=@id_polzovatel  WHERE id_zakaz=@id_zakaz;",
                    new Dictionary<string, object>()
                    {
                        { "id_zakaz", _id },
                        { "id_polzovatel", id_polzovatel }
                    });
                return;
            }
            var data = App.db.execute(

               "INSERT INTO \"zakaz\"( id_polzovatel) VALUES (@id_polzovatel) RETURNING id_zakaz;",
               new Dictionary<string, object>()
               {
                        { "id_polzovatel", id_polzovatel }
               });
            if (data.Count > 0)
            {
                this._id = (int)data[0]["id_zakaz"];



            }
        }
    }
}

        
        
    
   



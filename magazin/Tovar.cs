using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magazin
{
    class Tovar
    {
        public int tovar { get => _id; }
        private int _id = -1;
        public string nazvania { get; set; }
        public string opisanie { get; set; }

        public string on { get=>nazvania+" "+opisanie; }

        public Tovar()
        {

        }
        public Tovar(Dictionary<string, object> data)
        {

            this._id = (int)data["tovars"];

            this.nazvania = data["nazvania"].ToString();
            this.opisanie = data["opisanie"].ToString();
            
        }
        public static Tovar getById(int id)
        {

           
            var data = App.db.execute("select * from \"tovar\" where \"tovar\"=@tovar;",
                new Dictionary<string, object>()
                {
                    { "tovar", id }

                });
            if (data.Count == 0)
            {
                return new Tovar();
            }

            return new Tovar(data[0]);
        }
        public static List<Tovar> getAll()
        {
            List<Tovar> roles = new List<Tovar>();
            foreach (var data in App.db.execute("select * from \"tovar\" where true;"))
            {
                roles.Add(new Tovar(data));
            }

            return roles;
        }

        public bool exists()
        {
            return _id != -1;
        }

        public void delete()
        {
            App.db.execute("delete from \"tovar\" where \"tovars\"=@tovars;",
                new Dictionary<string, object>()
                {
                    { "tovars", tovar }

                });
            _id = -1;
        }
        public void save()
        {
            if (this.exists())
            {
                App.db.execute(

                    "UPDATE \"tovar\" SET nazvania=@nazvania, opisanie=@opisanie  WHERE tovars=@tovars;",

                    

                    new Dictionary<string, object>()
                    {
                        { "nazvania", nazvania },
                        { "opisanie", opisanie },

                        {"tovars", _id },

                       

                    });
                return;
            }

            var data = App.db.execute(

               "INSERT INTO \"tovar\"(nazvania, opisanie) VALUES (@nazvania, @opisanie) RETURNING tovars;",

              

               new Dictionary<string, object>()
               {
                     { "nazvania", nazvania },
                        { "opisanie", opisanie }
               });
            if (data.Count > 0)
            {

                this._id = (int)data[0]["tovars"];

               

            }


        }
        //public static Tovar getByLoginPassword(string login, string password)
        //{
        //    var data = App.db.execute("select * from \"tovar\" where login=@login and pass=@pass;",
        //        new Dictionary<string, object>()
        //        {
        //            { "login", login },
        //            { "pass", password },
        //        });
        //    if (data.Count == 0)
        //    {
        //        return new Tovar();
        //    }

        //    return new Tovar(data[0]);
        //}


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magazin
{
    public class User
    {
        public int polzovatel { get => _id; }
        private int _id = -1;
        public string surname { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public User()
        {

        }
        public User(Dictionary<string, object> data)
        {
            this._id = (int)data["polzovateli"];
            this.surname = data["familia"].ToString();
            this.name = data["ima"].ToString();
            this.login = data["login"].ToString();
            this.password = data["pass"].ToString();
        }
        public static User getById(int id)
        {
            var data = App.db.execute("select * from \"polzovatel\" where \"polzovateli\"=@polzovateli;",
                new Dictionary<string, object>()
                {
                    { "polzovateli", id }
                });
            if (data.Count == 0)
            {
                return new User();
            }

            return new User(data[0]);
        }
        public static List<User> getAll()
        {
            List<User> roles = new List<User>();
            foreach (var data in App.db.execute("select * from \"polzovateli\" where true;"))
            {
                roles.Add(new User(data));
            }

            return roles;
        }

        public bool exists()
        {
            return _id != -1;
        }

        public void delete()
        {
            App.db.execute("delete from \"polzovatel\" where \"polzovateli\"=@polzovateli;",
                new Dictionary<string, object>()
                {
                    { "polzovateli", polzovatel }
                });
            _id = -1;
        }
        public void save()
        {
            if (this.exists())
            {
                App.db.execute(
                    "UPDATE \"polzovatel\" SET familia=@familia, ima=@ima, login=@login,pass=@pass  WHERE polzovateli=@polzovateli;",
                    new Dictionary<string, object>()
                    {
                        { "familia", surname },
                        { "ima", name },
                        { "login", login },
                        { "pass", password },
                        {"polzovateli", _id }
                    });
                return;
            }

            var data = App.db.execute(
               "INSERT INTO \"polzovatel\"(familia, ima, login, pass) VALUES (@familia, @ima, @login, @pass) RETURNING polzovateli;",
               new Dictionary<string, object>()
               {
                     { "familia", surname },
                        { "ima", name },
                        { "login", login },
                        { "pass", password }                   
               });
            if (data.Count > 0)
            {
                this._id = (int)data[0]["polzovateli"];
            }

            
        }
        public static User getByLoginPassword(string login, string password)
        {
            var data = App.db.execute("select * from \"polzovatel\" where login=@login and pass=@pass;",
                new Dictionary<string, object>()
                {
                    { "login", login },
                    { "pass", password },
                });
            if (data.Count == 0)
            {
                return new User();
            }

            return new User(data[0]);
        }

    }
}

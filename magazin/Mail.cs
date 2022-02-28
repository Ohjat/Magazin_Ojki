using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magazin
{
    internal class Mail
    {
        public int id_email { get => _id; }
        private int _id = -1;
        public string napisanie { get; set; }

        public Mail()
        {

        }
        public Mail(Dictionary<string, object> data)
        {
            this._id = (int)data["id_email"];
            this.napisanie = data["napisanie"].ToString();
            
        }
        public bool exists()
        {
            return _id != -1;
        }

        public void save()
        {
            if (this.exists())
            {
                App.db.execute(
                    "UPDATE \"email\" SET napisanie=@napisanie  WHERE id_email=@id_email;",
                    new Dictionary<string, object>()
                    {
                        { "napisanie", napisanie },
                        {"id_email", _id }
                    });
                return;
            }
            var data = App.db.execute(
               "INSERT INTO \"email\"(napisanie) VALUES (@napisanie) RETURNING id_email;",
               new Dictionary<string, object>()
               {
                     { "napisanie", napisanie }
                        
               });
            if (data.Count > 0)
            {
                this._id = (int)data[0]["id_email"];
            }



        }
        



}
}

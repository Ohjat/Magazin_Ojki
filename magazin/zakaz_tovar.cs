using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magazin
{
    class zakaz_tovar
    {
        public int id_zakaz { get; set; }
        public int id_tovar { get; set; }

        
        public string nazvania { get; set; }
        public string opisanie { get; set; }



        public void delete()
        {
            App.db.execute("delete from \"zakaz_tovar\" where \"id_zakaz\"=@id_zakaz AND \"id_tovar\"=@id_tovar;",
                new Dictionary<string, object>()
                {
                    { "id_zakaz", id_zakaz },
                    { "id_tovar", id_tovar }
                });
            id_zakaz = -1;
            id_tovar = -1;
        }
        public void save()
        {

            var data = App.db.execute(
               "INSERT INTO \"zakaz_tovar\"( id_zakaz,id_tovar) VALUES (@id_zakaz, @id_tovar);",
               new Dictionary<string, object>()
               {
                        { "id_zakaz", id_zakaz },
                    { "id_tovar", id_tovar }

               });

            //var data1 = App.db.execute(
            //"INSERT INTO \"tovar\"(nazvania, opisanie) VALUES (@nazvania, @opisanie) RETURNING tovars;",
            //new Dictionary<string, object>()
            //{
            //         { "nazvania", nazvania },
            //            { "opisanie", opisanie }
            //});




        }
    }
}

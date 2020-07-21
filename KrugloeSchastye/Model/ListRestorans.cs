using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrugloeSchastye.Model
{
    public class ListRestorans : ObservableCollection<Restaurants>
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public ListRestorans()
        {
            var q =
                from rest in db.Restaurants
                select rest;

            foreach (Restaurants item in q)
            {
                this.Add(item);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrugloeSchastye.Model
{
    public class ListRazdelMenu : ObservableCollection<Razdeli>
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public ListRazdelMenu()
        {
            var q =
                from rMenu in db.Razdeli
                select rMenu;
            foreach (Razdeli item in q)
            {
                this.Add(item);
            }
        }
    }
}

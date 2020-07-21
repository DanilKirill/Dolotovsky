using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrugloeSchastye.Model
{
    public class ListBluda : ObservableCollection<Menu>
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public ListBluda()
        {
            var q =
                from lmenu in db.Menu
                select lmenu;
            foreach (Menu item in q)
            {
                this.Add(item);
            }
        }
    }
}

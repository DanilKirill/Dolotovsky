using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrugloeSchastye.Model
{
    public class ListStol : ObservableCollection<Stoli>
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public ListStol()
        {
            var q =
                from stol in db.Stoli
                select stol;

            foreach (Stoli item in q)
            {
                this.Add(item);
            }
        }
    }
}

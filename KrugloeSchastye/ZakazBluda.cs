//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KrugloeSchastye
{
    using System;
    using System.Collections.Generic;
    
    public partial class ZakazBluda
    {
        public int idZakazBludo { get; set; }
        public int idZakaza { get; set; }
        public int NameBludo { get; set; }
        public int Kolvo { get; set; }
        public int Cena { get; set; }
        public int Summa { get; set; }
    
        public virtual Menu Menu { get; set; }
        public virtual Zakazi Zakazi { get; set; }
    }
}

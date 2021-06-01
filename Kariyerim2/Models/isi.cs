namespace Kariyerim2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("isi")]
    public partial class isi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public isi()
        {
            isiscis = new HashSet<isisci>();
        }

        [Key]
        public int is_id { get; set; }

        public int pozisyon_id { get; set; }

        public int departman_id { get; set; }

        public int egitim_id { get; set; }

        public int is_yeri_id { get; set; }

        public virtual departman departman { get; set; }

        public virtual egitim egitim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<isisci> isiscis { get; set; }

        public virtual isyeri isyeri { get; set; }

        public virtual pozisyon pozisyon { get; set; }
    }
}

namespace Kariyerim2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ilce")]
    public partial class ilce
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ilce()
        {
            isyeris = new HashSet<isyeri>();
        }

        [Key]
        public int ilce_kodu { get; set; }

        [StringLength(50)]
        public string ilce_adi { get; set; }

        public int il_kodu { get; set; }

        public virtual il il { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<isyeri> isyeris { get; set; }
    }
}

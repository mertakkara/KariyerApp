namespace Kariyerim2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sektor")]
    public partial class sektor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sektor()
        {
            isyeris = new HashSet<isyeri>();
        }

        [Key]
        public int sektor_id { get; set; }

        [Required]
        [StringLength(50)]
        public string sektor_adi { get; set; }

        [Required]
        [StringLength(50)]
        public string sektor_tanimi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<isyeri> isyeris { get; set; }
    }
}

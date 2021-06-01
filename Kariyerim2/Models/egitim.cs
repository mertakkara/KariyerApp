namespace Kariyerim2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("egitim")]
    public partial class egitim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public egitim()
        {
            isis = new HashSet<isi>();
        }

        [Key]
        public int egitim_id { get; set; }

        [StringLength(50)]
        public string egitim_adi { get; set; }

        [Required]
        [StringLength(50)]
        public string egitim_tanimi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<isi> isis { get; set; }
    }
}

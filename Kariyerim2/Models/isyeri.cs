namespace Kariyerim2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("isyeri")]
    public partial class isyeri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public isyeri()
        {
            isis = new HashSet<isi>();
        }

        [Key]
        public int is_yeri_id { get; set; }

        public int ilce_id { get; set; }

        [Required]
        [StringLength(50)]
        public string is_yeri_adi { get; set; }

        public int sektor_id { get; set; }

        public virtual ilce ilce { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<isi> isis { get; set; }

        public virtual sektor sektor { get; set; }
    }
}

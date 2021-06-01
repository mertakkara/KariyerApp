namespace Kariyerim2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            isiscis = new HashSet<isisci>();
        }

        [Key]
        public int kid { get; set; }

        [StringLength(50)]
        public string kadi { get; set; }

        [StringLength(50)]
        public string parola { get; set; }

        [StringLength(50)]
        public string rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<isisci> isiscis { get; set; }
    }
}

namespace Kariyerim2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("isisci")]
    public partial class isisci
    {
        [Key]
        public int is_isci_id { get; set; }

        public int is_id { get; set; }

        public int kid { get; set; }

        public virtual isi isi { get; set; }

        public virtual user user { get; set; }
    }
}

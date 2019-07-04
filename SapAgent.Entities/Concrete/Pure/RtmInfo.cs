using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("RtmInfo", Schema = "Pure")]
    public partial class RtmInfo : IEntity
    {
        public RtmInfo()
        {
        }

        public int ID { get; set; }

        public int? BASEID { get; set; }

        [StringLength(10)]
        public string BUFFER { get; set; }

        [StringLength(100)]
        public string NAME { get; set; }

        public decimal HITRATIO { get; set; }

        public decimal ALLOCSIZE { get; set; }

        public decimal FREESIZE { get; set; }

        public decimal FREESIZEP { get; set; }

        public decimal MAXOBJCTS { get; set; }

        public decimal FREEDIR { get; set; }

        public decimal FREEDIRP { get; set; }

        public decimal MAXSWAPPED { get; set; }

        public decimal DBACCESS { get; set; }
    }
}

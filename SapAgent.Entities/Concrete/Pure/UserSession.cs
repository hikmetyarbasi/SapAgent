using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("UserSession", Schema = "Pure")]
    public partial class UserSession: IUserSession
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string SESSION_TYPE { get; set; }

        [StringLength(100)]
        public string EXTSTYPE { get; set; }

        public DateTime? EXTTIME { get; set; }

        [StringLength(50)]
        public string EXTTRACE { get; set; }

        public int? TOTALMEMKB { get; set; }

        public int? TOTALMEMBRUTTOKB { get; set; }

        public int? TOTALMEMHEAPKB { get; set; }

        public int? TOTALMEMHYPERKB { get; set; }

        public int? TOTALMEMABAPKB { get; set; }

        [StringLength(200)]
        public string APPLINFO { get; set; }

        [StringLength(200)]
        public string ACTPROGRAM { get; set; }

        [StringLength(50)]
        public string SECURITYCONTEXT { get; set; }

        public int? LOGONHDL { get; set; }

        public int? LOGONID { get; set; }

        public int? SESSIONHDL { get; set; }

        [StringLength(50)]
        public string SESSIONKEY { get; set; }

        [StringLength(50)]
        public string TENANT { get; set; }

        [StringLength(100)]
        public string USERNAME { get; set; }

        [StringLength(50)]
        public string APPLICATION { get; set; }

        [StringLength(200)]
        public string LOCATIONINFO { get; set; }

        public int? SESSIONS { get; set; }

        [StringLength(50)]
        public string RFCHDL { get; set; }

        [StringLength(50)]
        public string RFCTYPELONG { get; set; }

        [StringLength(100)]
        public string SERVERNAME { get; set; }

        [StringLength(50)]
        public string PRIORITY { get; set; }

        public int? OPENTASKS { get; set; }

        [StringLength(50)]
        public string WEBSOCKETHANDLE { get; set; }

        public int? SAPGUIVERSION { get; set; }

        public int? REQUESTTIME { get; set; }

        [StringLength(200)]
        public string STATE { get; set; }

        [StringLength(50)]
        public string CLIENTIPADDR { get; set; }
    }
}

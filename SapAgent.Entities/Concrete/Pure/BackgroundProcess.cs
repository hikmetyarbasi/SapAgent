using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("BackgroundProcess",Schema ="Pure")]
    public partial class BackgroundProcess: IBackgroundProcess
    {
        public int Id { get; set; }

        public string JOBNAME { get; set; }

        public DateTime? SDLSTRTDT { get; set; }

        public TimeSpan? SDLSTRTTM { get; set; }

        public DateTime? SDLDATE { get; set; }

        public TimeSpan? SDLTIME { get; set; }

        [StringLength(100)]
        public string SDLUNAME { get; set; }

        public DateTime? LASTCHDATE { get; set; }

        public TimeSpan? LASTCHTIME { get; set; }

        [StringLength(100)]
        public string LASTCHNAME { get; set; }

        public DateTime? RELDATE { get; set; }

        public TimeSpan? RELTIME { get; set; }

        [StringLength(50)]
        public string RELUNAME { get; set; }

        public DateTime? STRTDATE { get; set; }

        public TimeSpan? STRTTIME { get; set; }

        public DateTime? ENDDATE { get; set; }

        public TimeSpan? ENDTIME { get; set; }

        public int? PRDMINS { get; set; }

        public int? PRDHOURS { get; set; }

        public int? PRDDAYS { get; set; }

        public int? PRDWEEKS { get; set; }

        public int? PRDMONTHS { get; set; }

        [StringLength(1)]
        public string PERIODIC { get; set; }

        [StringLength(50)]
        public string DELANFREP { get; set; }

        [StringLength(50)]
        public string EMERGMODE { get; set; }

        [StringLength(10)]
        public string STATUS { get; set; }

        [StringLength(10)]
        public string NEWFLAG { get; set; }

        [StringLength(50)]
        public string AUTHCKNAM { get; set; }

        [StringLength(50)]
        public string AUTHCKMAN { get; set; }

        public int? SUCCNUM { get; set; }

        [StringLength(100)]
        public string JOBLOG { get; set; }

        public DateTime? LASTSTRTDT { get; set; }

        public TimeSpan? LASTSTRTTM { get; set; }

        public int? WPNUMBER { get; set; }

        public int? WPPROCID { get; set; }

        [StringLength(50)]
        public string EVENTID { get; set; }

        [StringLength(50)]
        public string EVENTPARM { get; set; }

        [StringLength(100)]
        public string BTCSYSREAX { get; set; }

        [StringLength(1)]
        public string JOBCLASS { get; set; }

        public int? PRIORITY { get; set; }

        [StringLength(100)]
        public string EXECSERVER { get; set; }

        [StringLength(100)]
        public string REAXSERVER { get; set; }

        [StringLength(200)]
        public string TGTSRVGRP { get; set; }

        [StringLength(200)]
        public string PROGNAME { get; set; }

        public int? DURATION { get; set; }

        public int? LATENCY { get; set; }
        public Guid SREQINDEX { get; set; }
    }


}

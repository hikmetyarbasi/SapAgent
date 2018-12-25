using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Config
{
    [Table("FuncFlag", Schema = "Config")]
    public class FuncFlag : IEntity
    {
        private int _functionId;

        public FuncFlag(int functionId)
        {
            this._functionId = functionId;
        }

        public FuncFlag()
        {
        }

        public int Id { get; set; }
        [Key]
        public int Func { get; set; }
        public int Flag { get; set; }
        public Guid SReqIndex { get; set; }

    }
}

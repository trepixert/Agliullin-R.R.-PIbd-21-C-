using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfectioneryProject {
    public class ConnectionBetweenDetailAndOutput{
        public int ID { get; set; }
        public int OutputID { get; set; }
        public int DetailID { get; set; }
        public int Count { get; set; }
        public virtual Detail Details { get; set; }
        public virtual Output Outputs { get; set; }
    }
}

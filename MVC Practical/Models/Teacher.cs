using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Practical.Models {
    public class Teacher {
        [Key] 
        public int ID {
            get;
            set;
        }

        [Required] 
        public string Name {
            get;
            set;
        }

        public DateTime Joindate {
            get;
            set;
        }

        public DateTime Birthdate {
            get;
            set;
        }
    }
}
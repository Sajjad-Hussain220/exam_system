using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace examsys.Models
{
    public partial class tbl_SEMESTER_DETAILS
    {
        public tbl_SEMESTER_DETAILS()
        {
            this.tbl_RESULT = new HashSet<tbl_RESULT>();
            this.tbl_STUDENT_SEMESTER = new HashSet<tbl_STUDENT_SEMESTER>();
        }

        public int Sem_ID { get; set; }
        [Required]

        [StringLength(10)] // Maximum length of 10 characters
        public string Course_Code { get; set; }
        [Required]

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid Teacher ID")]
        public Nullable<int> T_ID { get; set; }
        

        [Display(Name = "Is Active")]
        public Nullable<bool> IsActive { get; set; }

        [StringLength(100)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }

        [StringLength(100)]
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Modified Date")]
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public virtual tbl_COURSE tbl_COURSE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_RESULT> tbl_RESULT { get; set; }

        public virtual tbl_TEACHER tbl_TEACHER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_STUDENT_SEMESTER> tbl_STUDENT_SEMESTER { get; set; }
    }
}

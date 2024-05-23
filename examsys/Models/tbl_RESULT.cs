using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace examsys.Models
{
    public partial class tbl_RESULT
    {
        [Key]
        [Column(Order = 0)]
        public int Sem_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)] // Adjust the length as needed
        public string Course_Code { get; set; }

        [Key]
        [Column(Order = 2)]
        public int St_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        public int Exam_ID { get; set; }
        [Required]

        [Display(Name = "Marks")] // Display name for UI
        public decimal? Marks { get; set; }
        [Required]

        [StringLength(2)] // Adjust the length as needed
        public string Grade { get; set; }
        [Required]

        [Display(Name = "Result Date")] // Display name for UI
        [DataType(DataType.Date)] // Specify data type for UI
        public DateTime? Result_Date { get; set; }

        [Display(Name = "Is Active")] // Display name for UI
        public bool? IsActive { get; set; }

        [Display(Name = "Created By")] // Display name for UI
        [StringLength(100)] // Adjust the length as needed
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")] // Display name for UI
        [DataType(DataType.DateTime)] // Specify data type for UI
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Modified By")] // Display name for UI
        [StringLength(100)] // Adjust the length as needed
        public string ModifiedBy { get; set; }

        [Display(Name = "Modified Date")] // Display name for UI
        [DataType(DataType.DateTime)] // Specify data type for UI
        public DateTime? ModifiedDate { get; set; }

        // Navigation properties
        public virtual tbl_COURSE tbl_COURSE { get; set; }
        public virtual tbl_EXAM tbl_EXAM { get; set; }
        public virtual tbl_SEMESTER_DETAILS tbl_SEMESTER_DETAILS { get; set; }
        public virtual tbl_STUDENT tbl_STUDENT { get; set; }
    }
}

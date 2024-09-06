using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DB.Models
{
    public partial class Task
    {
        public Task()
        {
            Class = new HashSet<Class>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Status { get; set; }
        //0 => Waiting
        //1 => Running
        //3 => Finished 
        //4 => Cancelled
        //5 => Waiting for AI Training

        public int AiTraining { get; set; }

        public string TaskManeger { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of annotators must be greater than zero.")]
        public int NumberOfAnnotators { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Random value must be greater than or equal to zero.")]
        public int Random { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [CustomValidation(typeof(Task), "ValidateDateNotInPast")]
        public DateTime Deadline { get; set; }
        public string DatasetId { get; set; }
        [Required]
        public int AnnotationClassMappingId { get; set; }
        [Required]
        public int DistributionPolicyId { get; set; }
        [Required]
        public int InputTypeId { get; set; }
        [Required]
        public int TaskTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual AnnotationClassMapping AnnotationClassMapping { get; set; }
        public virtual DistributionPolicy DistributionPolicy { get; set; }
        public virtual InputType InputType { get; set; }
        public virtual TaskType TaskType { get; set; }
        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<UsersTask> UsersTasks { get; set; }
        public static ValidationResult ValidateDateNotInPast(DateTime date, ValidationContext context)
        {
            if (date.Date < DateTime.Today)
            {
                return new ValidationResult("Date cannot be in the past.");
            }

            return ValidationResult.Success;
        }
    }
}

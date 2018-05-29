using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    public class TaskDetails

    {
        
        [Display(Name = "Task_ID")]
        [Key]
        public int Task_ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Priority")]
        public string Priority { get; set; }
        [Display(Name = "EstimatedCost")]
        public decimal EstimatedCost { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "CreatedDate")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

    }

}
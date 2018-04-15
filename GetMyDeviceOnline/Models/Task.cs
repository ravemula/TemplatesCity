using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetMyDeviceOnline.Models
{
    public class Task
    {
        //Every Task entry has a Task, a Status, and a TaskID
        public int TaskID { get; set; }
        [Required]
        public string TaskText { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Creator { get; set; }
        [Required]
        public string CreatorName { get; set; }
        [Required]
        public virtual ICollection<AadObject> SharedWith { get; set; }
    }
}
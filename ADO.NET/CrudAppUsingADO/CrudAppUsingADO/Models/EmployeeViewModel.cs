using System.ComponentModel.DataAnnotations;

namespace CrudAppUsingADO.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        [Range(10000, 200000)]
        public int salary { get; set; }
        public string city { get; set; }
    }
}

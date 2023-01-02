using System;
using System.Collections.Generic;

namespace DZ_12_17_TSK03.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<SupportSpecialist> SupportSpecialists { get; set; }
 
        
    }
}
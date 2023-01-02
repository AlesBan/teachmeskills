using System;
using System.Collections.Generic;

namespace DZ_12_17_TSK03.Models
{
    public class SupportSpecialist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<SupportRequest> SupportRequests { get; set; }
    }
}
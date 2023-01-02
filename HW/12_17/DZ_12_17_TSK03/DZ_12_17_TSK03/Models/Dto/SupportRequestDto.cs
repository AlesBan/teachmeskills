using System;

namespace DZ_12_17_TSK03.Models
{
    public class SupportRequestDto
    {
        public SupportRequestDto()
        {
            
        }

        public string RequestTheme { get; set; }
        public string RequestDescription { get; set; }
        public string Department { get; set; }
    }
}
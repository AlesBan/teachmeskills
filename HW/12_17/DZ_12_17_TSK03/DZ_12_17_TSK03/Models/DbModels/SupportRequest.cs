using System;

namespace DZ_12_17_TSK03.Models
{
    public class SupportRequest
    {
        public SupportRequest(SupportRequestDto supportRequestDto)
        {
            Id = Guid.NewGuid();
            RequestTheme = supportRequestDto.RequestTheme;
            RequestDescription = supportRequestDto.RequestDescription;
            Status = "Active";
        }
        public Guid Id { get; set; }
        public string RequestTheme { get; set; }
        public string RequestDescription { get; set; }
        public string Status { get; set; }
        public Guid SpecialistId { get; set; }
        public SupportSpecialist Specialist { get; set; }
    }
}
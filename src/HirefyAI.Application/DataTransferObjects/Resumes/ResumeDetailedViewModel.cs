using DataTransferObjects.Educations;
using DataTransferObjects.Experiences;
using DataTransferObjects.Skills;
using HirefyAI.Domain.Entities;

namespace HirefyAI.Application.DataTransferObjects.Resumes
{
    public class ResumeDetailedViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Summary { get; set; }

        public Template Template { get; set; }
        public int TemplateId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public List<SkillViewModel> Skills { get; set; } = new List<SkillViewModel>();
        public List<EducationViewModel> Educations { get; set; } = new List<EducationViewModel>();
        public List<ExperienceViewModel> Experiences { get; set; } = new List<ExperienceViewModel>();

        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}

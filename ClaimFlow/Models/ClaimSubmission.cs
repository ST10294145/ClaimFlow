using System;
using System.ComponentModel.DataAnnotations;

namespace ClaimFlow.Models
{
    public class ClaimSubmission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Claim Title")]
        [StringLength(100, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Claim Description")]
        [StringLength(1000, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Claimant Name")]
        [StringLength(50)]
        public string ClaimantName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Claimant Email")]
        public string ClaimantEmail { get; set; }

        [Required]
        [Display(Name = "Claim Date")]
        [DataType(DataType.Date)]
        public DateTime ClaimDate { get; set; } = DateTime.Now;

        [Display(Name = "Claim Status")]
        public string Status { get; set; } = "Pending";

        // Optional: Attachments or supporting documents
        [Display(Name = "Attachment File Path")]
        public string? AttachmentPath { get; set; }
    }
}

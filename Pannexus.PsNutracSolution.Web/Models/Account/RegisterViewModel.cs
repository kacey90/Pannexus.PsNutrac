using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Pannexus.PsNutrac.Users;

namespace Pannexus.PsNutrac.Web.Models.Account
{
    public class RegisterViewModel : IValidatableObject
    {
        /// <summary>
        /// Not required for single-tenant applications.
        /// </summary>
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(User.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(User.MaxSurnameLength)]
        public string Surname { get; set; }

        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(User.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        [MaxLength(255), DisableAuditing]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }


        [MaxLength(7), Required]
        public string Gender { get; set; }

        [MaxLength(150)]
        public string Occupation { get; set; }

        [MaxLength(100)]
        public string Designation { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string State { get; set; }

        [MaxLength(100), Required]
        public string Bank { get; set; }

        [MaxLength(20)]
        public string SortCode { get; set; }

        [MaxLength(100), Required]
        public string AccountNumber { get; set; }

        public bool IsExternalLogin { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var emailRegex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            if (!UserName.Equals(EmailAddress) && emailRegex.IsMatch(UserName))
            {
                yield return new ValidationResult("Username cannot be an email address unless it's same with your email address !");
            }
        }
    }
}
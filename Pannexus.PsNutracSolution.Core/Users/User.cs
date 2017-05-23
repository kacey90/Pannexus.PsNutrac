using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace Pannexus.PsNutrac.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            return new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password)
            };
        }

        //[MaxLength(100)]
        //public string FamilyName { get; set; }

        [MaxLength(7)]
        public string Gender { get; set; }

        [MaxLength(150)]
        public string Occupation { get; set; }

        [MaxLength(100)]
        public string Designation { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string State { get; set; }

        [MaxLength(100)]
        public string Bank { get; set; }

        [MaxLength(20)]
        public string SortCode { get; set; }

        [MaxLength(100)]
        public string AccountNumber { get; set; }
    }
}
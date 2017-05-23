namespace Pannexus.PsNutrac.Web.Models.Account
{
    public class RegisterResultViewModel
    {
        public string TenancyName { get; set; }
        
        public string UserName { get; set; }

        public string EmailAddress { get; set; }
        
        public string NameAndSurname { get; set; }

        public bool IsActive { get; set; }
        
        public string Gender { get; set; }
        
        public string Occupation { get; set; }
        
        public string Designation { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Bank { get; set; }
        
        public string SortCode { get; set; }
        
        public string AccountNumber { get; set; }
    }
}
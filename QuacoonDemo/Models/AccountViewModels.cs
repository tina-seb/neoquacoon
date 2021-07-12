using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CardBoss.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class FileModel
    {
        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public HttpPostedFileBase PostedFile { get; set; }
    }

    public class ExcelModel
    {
        [Required(ErrorMessage = "Please select file.")]
        public HttpPostedFileBase PostedFile { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [Phone]
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Are you a company account admin?")]
        public bool CompanyAdmin { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Are you a non-admin employee?")]
        public bool CompanyEmployee { get; set; }

       /* [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Are you a vendor?")]
        public bool Vendor { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Are you an expert?")] */
        public bool Expert { get; set; }
    }

    public class ContactFormModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [DataType(DataType.Text)]
        public int VendorId { get; set; }
    }
    public class RegisterCompanyViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "AddressLine1")]
        public string AddressLine1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "AddressLine2")]
        public string AddressLine2 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "State")]
        public State State { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Location Phone")]
        public string LocationPhone { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Add another company location")]
        public bool AnotherLocation { get; set; }
    }

    public class RegisterLocationViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "AddressLine1")]
        public string AddressLine1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "AddressLine2")]
        public string AddressLine2 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "State")]
        public State State { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        public Country Country { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Location Phone")]
        public string LocationPhone { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Add another company location")]
        public bool AnotherLocation { get; set; }
    }

    public class RegisterSupplierViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
         
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Supplier Email")]
        public string SupplierEmail { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Invite Another Supplier")]
        public bool AnotherSupplier { get; set; }

    }
    public class RegisterProductViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Product Category")]
        public string ProductCategory { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "SKU")]
        public string SKU { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Other Product Identifier")]
        public string OtherProductId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Add another product")]
        public bool AnotherProduct { get; set; }
    }

    public class RegisterExpertViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Bio")]
        public string Bio { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Expertise Type")]
        public string ExpertType { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Free/Rate (if any)")]
        public string Rate { get; set; }

    }

    public class RegisterVendorViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Service Description")]
        public string ServiceDescription { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Service Type")]
        public Service ServiceType { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Rate")]
        public string Rate { get; set; }

    }

    public class RegisterMaterialViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Material Name")]
        public string MaterialName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Material Category")]
        public string MaterialCategory { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "SKU")]
        public string SKU { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Other Material Identifier")]
        public string OtherMaterialId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Order Of Use")]
        public string Order { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity Per Product")]
        public string Quantity { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Supplier For This Material For This Product")]
        public string SupplierName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Supplier Email")]
        public string SupplierEmail { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Add Another Supplier For This Material For This Product")]
        public bool AnotherSupplier { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Add Another Raw Material For This Product")]
        public bool AnotherProduct { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class SearchKeywordModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Keyword")]
        public string Keyword { get; set; }
    }


    public enum Country
    {
        US,
    }


    public enum State
    {
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Delaware,
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        [Display(Name = "New Hampshire")]
        NewHampshire,
        [Display(Name = "New Jersey")]
        NewJersey,
        [Display(Name = "New Mexico")]
        NewMexico,
        [Display(Name = "New York")]
        NewYork,
        [Display(Name = "North Carolina")]
        NorthCarolina,
        [Display(Name = "North Dakota")]
        NorthDakota,
        Ohio,
        Oklahoma,
        Oregon,
        Pennsylvania,
        [Display(Name = "Rhode Island")]
        Rhode_Island,
        [Display(Name = "South Carolina")]
        South_Carolina,
        [Display(Name = "South Dakota")]
        South_Dakota,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Virginia,
        Washington,
        [Display(Name = "West Virginia")]
        West_Virginia,
        Wisconsin,
        Wyoming,
    }

    public enum Service
    {
        [Display(Name = "Select Service/Expertise Type")]
        Select,
        [Display(Name = "3PL")]
        ThreePL,
        Academic,
        [Display(Name = "Air Transportation Providers")]
        Air_Transportation_Providers,
        Certifications,
        Cleaning,
        Containers,
        [Display(Name = "Equiment Leasing")]
        Equipment_Leasing,
        [Display(Name = "Environmental Services")]
        Environmental_Services,
        Financial,
        Government,
        [Display(Name = "Intermodal marketing companies (IMC)")]
        Intermodal_marketing_companies,
        [Display(Name = "Logistic Service Provider (LSP)")]
        Logistic_Service_Provider,
        [Display(Name = "Logistics Consultants")]
        Logistics_Consultants,
        [Display(Name = "Logistics Equipment")]
        Logistics_Equipment,
        Media,
        [Display(Name = "NVOCC (Non-vessel operating common carrier) (Freight forwarder)")]
        NVOCC,
        [Display(Name = "Ocean Transportation Providers")]
        Ocean_Transportation_Providers,
        [Display(Name = "Other Road Transportation Providers")]
        Other_Road_Transportation_Providers,
        Others,
        Packers,
        Ports,
        [Display(Name = "Product Suppliers")]
        Product_Suppliers,
        [Display(Name = "Repairs/Handymen")]
        Repairs_Handymen,
        [Display(Name = "Shippers/Beneficial Cargo Owners (BCO)")]
        Shippers,
        [Display(Name = "Technology Vendors")]
        Technology_Vendors,
        [Display(Name = "Temp Staff")]
        Temp_Staff,
        Trucks,
        Warehouses,
    }

    /* Afghanistan,
     Albania,
     Algeria,
     Andorra,
     Angola,
     Antigua_and_Barbuda,
     Argentina,
     Armenia,
     Australia,
     Austria,
     Azerbaijan,
     Bahamas,
     Bahrain,
     Bangladesh,
     Barbados,
     Belarus,
     Belgium,
     Belize,
     Benin,
     Bhutan,
     Bolivia,
     Bosnia_and_Herzegovina,
     Botswana,
     Brazil,
     Brunei,
     Bulgaria,
     Burkina_Faso,
     Burundi,
     Cabo_Verde,
     Cambodia,
     Cameroon,
     Canada,
     Central_African_Republic, 
     Chad,
     Chile,
     China,
     Colombia,
     Comoros,
     Congo,
     Costa_Rica
     Cote d'Ivoire
     Croatia
     Cuba
     Cyprus
     Czechia
     Denmark
     Djibouti
     Dominica
     Dominican Republic
     Ecuador
     Egypt
     El Salvador
     Equatorial Guinea
     Eritrea
     Estonia
     Eswatini (formerly Swaziland)
     Ethiopia
     Fiji
     Finland
     France
     Gabon
     Gambia
     Georgia
     Germany
     Ghana
     Greece
     Grenada
     Guatemala
     Guinea
     Guinea-Bissau
     Guyana
     Haiti
     Honduras
     Hungary
     Iceland
     India
     Indonesia
     Iran
     Iraq
     Ireland
     Israel
     Italy
     Jamaica
     Japan
     Jordan
     Kazakhstan
     Kenya
     Kiribati
     Kosovo
     Kuwait
     Kyrgyzstan
     Laos
     Latvia
     Lebanon
     Lesotho
     Liberia
     Libya
     Liechtenstein
     Lithuania
     Luxembourg
     Madagascar
     Malawi
     Malaysia
     Maldives
     Mali
     Malta
     Marshall Islands
     Mauritania
     Mauritius
     Mexico
     Micronesia
     Moldova
     Monaco
     Mongolia
     Montenegro
     Morocco
     Mozambique
     Myanmar
     Namibia
     Nauru
     Nepal
     Netherlands
     New Zealand
     Nicaragua
     Niger
     Nigeria
     North Korea
     North Macedonia
     Norway
     Oman
     Pakistan
     Palau
     Palestine
     Panama
     Papua New Guinea
     Paraguay
     Peru
     Philippines
     Poland
     Portugal
     Qatar
     Romania
     Russia
     Rwanda
     Saint Kitts and Nevis
     Saint Lucia
     Saint Vincent and the Grenadines
     Samoa
     San Marino
     Sao Tome and Principe
     Saudi Arabia
     Senegal
     Serbia
     Seychelles
     Sierra Leone
     Singapore
     Slovakia
     Slovenia
     Solomon Islands
     Somalia
     South Africa
     South Korea
     South Sudan
     Spain
     Sri Lanka
     Sudan
     Suriname
     Sweden
     Switzerland
     Syria
     Taiwan
     Tajikistan
     Tanzania
     Thailand
     Timor-Leste
     Togo
     Tonga
     Trinidad and Tobago
     Tunisia
     Turkey
     Turkmenistan
     Tuvalu
     Uganda
     Ukraine
     United Arab Emirates 
     United Kingdom 
     United States of America 
     Uruguay
     Uzbekistan
     Vanuatu
     Vatican City 
     Venezuela
     Vietnam
     Yemen
     Zambia
     Zimbabwe 
 }*/
}

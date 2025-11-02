namespace hostellers
{
    

    public class ValidUser
    {
        public int UserID { get; set; }                      // int, primary key
        public string Username { get; set; }                 // varchar(50), unique
        public string PasswordHash { get; set; }             // varchar(255), hashed password
        public string HostelID { get; set; }                 // char(4), unique, 4-digit format
        public string HostelName { get; set; }               // varchar(100)
        public string MobileNumber { get; set; }             // varchar(15), nullable
        public string Email { get; set; }                     // varchar(100), nullable
        public DateTime? CreatedAt { get; set; }              // datetime, default getdate()
        public bool? IsActive { get; set; }                    // bit, default true (1)
    }

}

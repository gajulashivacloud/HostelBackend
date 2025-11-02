namespace hostellers
{
    public class Hosteler
    {
        public int HostelerID { get; set; }                     // Identity, Primary Key
        public string FullName { get; set; }                     // varchar(100), Not null
        public DateTime? DateOfBirth { get; set; }               // date, nullable
        public string Gender { get; set; }                        // varchar(10), nullable
        public string ContactNumber { get; set; }                // varchar(15), nullable
        public string Email { get; set; }                         // varchar(100), nullable
        public string Address { get; set; }                       // varchar(255), nullable
        public string HostelID { get; set; }                      // char(4), not null, foreign key
        public string RoomNumber { get; set; }                    // varchar(10), nullable
        public string BedNumber { get; set; }                     // varchar(10), nullable
        public DateTime? CheckInDate { get; set; }                // date, nullable
        public DateTime? CheckOutDate { get; set; }               // date, nullable
        public string EmergencyContactName { get; set; }          // varchar(100), nullable
        public string EmergencyContactPhone { get; set; }         // varchar(15), nullable
     
    }

}

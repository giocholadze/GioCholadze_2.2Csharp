namespace Task_6.Models
{
    public class Order
    {
        public string xelshekrulebaID { get; set; }
        public string shemkvetiID { get; set; }
        public string gadasaxdeli_l { get; set; }
        public string gadasaxdeli_d { get; set; }
        public string gadaxdili_l { get; set; }
        public string gadaxdili_d { get; set; }
        public string vali_l { get; set; }
        public string vali_d { get; set; }
        public string kursi { get; set; }
        public DateTime tarigi_dawyebis { get; set; }
        public DateTime tarigi_shesrulebis { get; set; }
        public DateTime tarigi_damtavrebis { get; set; }
        public string shesruleba { get; set; }
        public string visi_mizezit { get; set; }
        public int DaysLeft { get; set; }
    }
}

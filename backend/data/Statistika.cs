namespace backend.data
{
    public class Statistika
    {
        public int id { get; set; }
        public DateTime sudaryta { get; set; }
        public DateTime data_nuo { get; set; }
        public DateTime data_iki { get; set; }
        public Statistika() { }
        public Statistika(int Id, DateTime sudaryta, DateTime data_nuo, DateTime data_ik)
        {
            this.id = Id;
            this.sudaryta = sudaryta;
            this.data_nuo = data_nuo;
            this.data_iki = data_iki;
        }
    }
}

namespace backend.data
{
    public class Rezervacija
    {
        public int id { get; set; }
        public DateTime pradzia { get; set; }
        public DateTime pabaiga { get; set; }
        public int fk_pirkejas { get; set; }
        public int fk_pardavejas { get; set; }
        public Rezervacija() { }
        public Rezervacija(int id, DateTime pradzia, DateTime pabaiga, int fk_pirkejas, int fk_pardavejas)
        {
            this.id = id;
            this.pradzia = pradzia;
            this.pabaiga = pabaiga;
            this.fk_pirkejas = fk_pirkejas;
            this.fk_pardavejas = fk_pardavejas;
        }
    }
}

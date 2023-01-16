namespace backend.data
{
    public class Vadovelis
    {
        public int id { get; set; }
        public string pavadinimas { get; set; }
        public int puslapiu_skaicius { get; set; }
        public string isbn { get; set; }
        public int fk_populiarumas { get; set; }
        public string aprasymas { get; set; }
        public string leidejas { get; set; }
        public int metai { get; set; }
        public string kalba { get; set; }

        public Vadovelis() { }
        public Vadovelis(int id, string pavadinimas, int puslapis, string isbn, int fk_populiarumas, string aprasymas, string leidejas, int metai, string kalba)
        {
            this.id = id;
            this.pavadinimas = pavadinimas;
            this.puslapiu_skaicius = puslapis;
            this.isbn = isbn;
            this.fk_populiarumas = fk_populiarumas;
            this.aprasymas = aprasymas;
            this.leidejas = leidejas;
            this.metai = metai;
            this.kalba = kalba;
        }
    }
}

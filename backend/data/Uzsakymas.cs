namespace backend.data
{
    public class Uzsakymas
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public int fk_pirkejas { get; set; }
        public Uzsakymas() { }
        public Uzsakymas(int id,DateTime data, int fk_pirkejas) { 
            this.id = id;
            this.data = data;
            this.fk_pirkejas = fk_pirkejas;
        }
    }
}

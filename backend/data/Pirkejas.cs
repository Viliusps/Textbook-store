namespace backend.data
{
    public class Pirkejas
    {
        public int id { get; set; }
        public string mokejimo_metodas { get; set; }
        public int fk_vartotojas { get; set; }
        public Pirkejas() { }
        public Pirkejas(int id, string mokejimas, int fk_vartotojas)
        {
            this.id = id;
            this.mokejimo_metodas = mokejimas;
            this.fk_vartotojas = fk_vartotojas;
        }
    }
}

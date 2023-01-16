namespace backend.data
{
    public class Pardavejas
    {
        public int id { get; set; }
        public int banko_saskaitos_numeris { get; set; }
        public int fk_vartotojas { get; set; }

        public Pardavejas() { }
        public Pardavejas(int id, int Saskaita, int fk_vartotojas)
        {
            this.id = id;
            banko_saskaitos_numeris = Saskaita;
            this.fk_vartotojas = fk_vartotojas;
        }
    }
}

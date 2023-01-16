namespace backend.data
{
    public class vartotojo_parduodami_vadoveliai
    {
        public int id { get; set; }
        public decimal kaina { get; set; }
        public string bukle { get; set; }
        public int fk_pardavejas { get; set; }
        public int fk_vadovelis { get; set; }
        public int fk_uzsakymas { get; set; }

        public vartotojo_parduodami_vadoveliai() { }
        public vartotojo_parduodami_vadoveliai(int id, decimal kaina, string bukle, int fk_pardavejas, int fk_vadovelis, int fk_uzsakymas)
        {
            this.id = id;
            this.kaina = kaina;
            this.bukle = bukle;
            this.fk_pardavejas = fk_pardavejas;
            this.fk_vadovelis = fk_vadovelis;
            this.fk_uzsakymas = fk_uzsakymas;
        }
    }
}

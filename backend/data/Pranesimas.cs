namespace backend.data
{
    public class Pranesimas
    {
        public int id { get; set; }
        public string pranesimo_turinys { get; set; }
        public DateTime issiuntimo_data { get; set; }
        public string tipas { get; set; }
        public int fk_vartotojas { get; set; }

        public Pranesimas() { }
        public Pranesimas(int id, string turinys, DateTime siuntimas, string tipas, int fk_vartotojas)
        {
            this.id = id;
            this.pranesimo_turinys = turinys;
            this.issiuntimo_data = siuntimas;
            this.tipas = tipas;
            this.fk_vartotojas = fk_vartotojas;
        }
    }
}

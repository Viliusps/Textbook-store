namespace backend.data
{
    public class Marsrutas
    {
        public int id { get; set; }
        public int numatoma_trukme  { get; set; }
        public int numatomas_atstumas { get; set; }
        public int siuntiniu_skaicius { get; set; }
        public int transporto_priemones_id { get; set; }
        public int fk_kurjeris { get; set; }

        public Marsrutas() { }
        public Marsrutas(int id, int trukme, int atstumas, int skaicius, int transportoId, int fk_kurjeris)
        {
            this.id = id;
            this.numatoma_trukme = trukme;
            this.numatomas_atstumas=atstumas;
            this.siuntiniu_skaicius = skaicius;
            this.transporto_priemones_id = transportoId;
            this.fk_kurjeris = fk_kurjeris;
            
        }
    }
}

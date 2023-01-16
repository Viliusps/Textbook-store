namespace backend.data
{
    public class Kurjeris
    {
        public int id { get; set; }
        public DateTime vairuotojo_pazymejimo_galiojimo_data { get; set; }
        public int menesio_darbo_valandos { get; set; }
        public int maksimalios_menesio_darbo_valandos { get; set; }
        public string aptarnaujama_apskritis { get; set; }
        public int fk_vartotojas { get; set; }


        public Kurjeris() { }
        public Kurjeris(int Id, DateTime galioja, int valandos, int maxValandos, string apskritis, int fk_vartotojas)
        {
            id = Id;
            vairuotojo_pazymejimo_galiojimo_data = galioja;
            menesio_darbo_valandos = valandos;
            maksimalios_menesio_darbo_valandos = maxValandos;
            aptarnaujama_apskritis = apskritis;
            this.fk_vartotojas = fk_vartotojas;

        }
    }
}

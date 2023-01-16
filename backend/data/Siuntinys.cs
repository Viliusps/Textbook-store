namespace backend.data
{
    public class Siuntinys
    {
        public int id { get; set; }
        public string kliento_vardas_pavarde { get; set; }
        public string kliento_el_pastas { get; set; }
        public string kliento_telefono_nr { get; set; }
        public string buvimo_vieta { get; set; }
        public string busena { get; set; }
        public int fk_marsruto_taskas { get; set; }
        public int fk_uzsakymas { get; set; }

        public Siuntinys() { }
        public Siuntinys(int id, string klientas, string ePastas, string telefNr, string vieta, string busena, int fk_marsruto_taskas, int fk_uzsakymas)
        {
            this.id = id;
            this.kliento_vardas_pavarde = klientas;
            this.kliento_el_pastas = ePastas;
            this.kliento_telefono_nr = telefNr;
            this.buvimo_vieta = vieta;
            this.busena = busena;
            this.fk_marsruto_taskas = fk_marsruto_taskas;
            this.fk_uzsakymas = fk_uzsakymas;
        }

    }
}

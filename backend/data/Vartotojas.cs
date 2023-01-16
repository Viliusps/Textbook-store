namespace backend.data
{
    public class Vartotojas
    {
        public int id { get; set; }
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public string miestas { get; set; }
        public string adresas { get; set; }
        public string el_pastas { get; set; }
        public int pasto_kodas { get; set; }
        public string slapyvardis { get; set; }
        public string slaptazodis { get; set; }
        public string vartotojo_ivertinimas { get; set; }
        public Vartotojas() { }

        public Vartotojas(int id, string Vardas, string Pavarde, string Miestas, string Adresas, string EPastas, int PKodas, string Slapyvardis, string Slaptazodis, string Vertinimas)
        {
            this.id = id;
            this.vardas = Vardas;
            this.pavarde = Pavarde;
            this.miestas = Miestas;
            this.adresas = Adresas;
            this.el_pastas = EPastas;
            this.pasto_kodas = PKodas;
            this.slapyvardis = Slapyvardis;
            this.slaptazodis = Slaptazodis;
            this.vartotojo_ivertinimas = Vertinimas;
        }
    }

    
}

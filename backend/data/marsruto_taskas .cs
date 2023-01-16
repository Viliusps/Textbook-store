namespace backend.data
{
    public class marsruto_taskas
    {
        public int id { get; set; }
        public string koordinates { get; set; }
        public string adresas { get; set; }
        public bool ar_ivykdyta { get; set; }
        public int fk_marsrutas { get; set; }

        public marsruto_taskas() { }
        public marsruto_taskas(int Id,string koordinate, string adresas, bool vykdyta, int fk_marsrutas)
        {
            this.id = Id;
            this.koordinates = koordinate;
            this.adresas = adresas;
            this.ar_ivykdyta = vykdyta;
            this.fk_marsrutas = fk_marsrutas;
        }
    }
}

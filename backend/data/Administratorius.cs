namespace backend.data
{
    public class Administratorius
    {
        public int id { get; set; }
        public DateTime administratorius_nuo { get; set; }
        public int vartotojo_id { get; set; }
        public Administratorius() { }
        public Administratorius(int id, DateTime Nuo, int vartotojo_id)
        {
            this.id = id;
            administratorius_nuo = Nuo;
            this.vartotojo_id = vartotojo_id;
        }
    }
}

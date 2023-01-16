namespace backend.data
{
    public class Populiarumas
    {
        public int id { get; set; }
        public int pop_skaicius { get; set; }
        public string isbn { get; set; }

        public Populiarumas() { }
        public Populiarumas(int id, int pop_skaicius, string isbn)
        {
            this.id = id;
            this.pop_skaicius = pop_skaicius;
            this.isbn = isbn;
        }
    }
}

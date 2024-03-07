namespace Ncfe.CodeTest.Model
{
    public class Learner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}

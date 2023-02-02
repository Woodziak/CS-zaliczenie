namespace Library
{
    public class Catalogue
    {
        private string name="";
        public List<Category> Category= new List<Category>();
        public string Name
        {
            get { return name; }
            set { name=value;}
        }

    }

}
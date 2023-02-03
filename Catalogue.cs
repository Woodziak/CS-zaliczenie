namespace Library
{
    public class Catalogue
    {
        private string name="";
        public Catalogue(string name)
        {
            this.name=name;

        }

        public void ViewCatalogue()
        {


        }
        public string Name
        {
            get { return name; }
            set { name=value;}
        }

    }

}

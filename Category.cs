namespace Library
{
    public class Category
    {
        //vars
        private string name="";
        private string description="";
        public Category( string name)
        {
            this.name=name;

        }
        public Category( string name, string description)
        {
            this.name=name;
            this.description=description;
        }
        //get/set methods
        public string Name
        {
            get { return name; }
            set { name=value;}
        }

    }

}
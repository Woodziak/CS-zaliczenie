namespace Library
{
    public class Category
    {
        //vars
        private string name="";
        public List<Book> Books= new List<Book>();

        

        //get/set methods
        public string Name
        {
            get { return name; }
            set { name=value;}
        }

    }

}
namespace Library
{
    public class Book
    {

        //vars
        protected string title="";
        protected string author="";
        protected int isbn=0;
        protected string category="";
        protected int serialnumber=0;
        protected string status="available";

        //constructors
        public Book(string title, string author, int ISBN, string category)
        {
            this.title=title;
            this.author=author;
            this.isbn=ISBN;
            this.category=category;
            Random rnd = new Random();
            this.serialnumber=rnd.Next();
        }
        public Book(){}

        //get/set methods
        public string Title
        {
            get { return title;}
            set { title=value;}
        }
        public string Author
        {
            get { return author;}
            set { author=value; }
        }
        public int Isbn
        {
            get { return isbn;  }
            set { isbn=value;   }
        }
        public string Category
        {
            get { return category;  }
            set { category=value;   }
        }
        public int SerialNumber
        {
            get { return serialnumber; }
            set { serialnumber=value; }
        }
        public string Status
        {
            get { return status; }
            set { status=value; }
        }
    }
    public class Dictionary : Book
    {
        private string type="";
        public Dictionary(string title, string author, int ISBN, string category, string type)
        {
            this.title=title;
            this.author=author;
            this.isbn=ISBN;
            this.category=category;
            this.type=type;
            
        }
        public string Type
        {
            get { return type;  }
            set { type=value;   }
        }
    }
    public class Encyclopedia : Book
    {
        private string topic="";
        public Encyclopedia(string title, string author, int ISBN, string category, string topic)
        {
            this.title=title;
            this.author=author;
            this.isbn=ISBN;
            this.category=category;
            this.topic=topic;
            
        }
        public string Topic
        {
            get { return topic;  }
            set { topic=value;   }
        }        
    }
    public class Manual : Book
    {
        private string device="";
        public Manual(string title, string author, int ISBN, string category, string device)
        {
            this.title=title;
            this.author=author;
            this.isbn=ISBN;
            this.category=category;
            this.device=device;
            
        }
        
        public string Device
        {
            get { return device;  }
            set { device=value;   }
        }        
    }
    public class Textbook : Book
    {
        private string classes="";
        public Textbook(string title, string author, int ISBN, string category, string classes)
        {
            this.title=title;
            this.author=author;
            this.isbn=ISBN;
            this.category=category;
            this.classes=classes;
            
        }
        public string Classes
        {
            get { return classes;  }
            set { classes=value;   }
        }        
    }


}
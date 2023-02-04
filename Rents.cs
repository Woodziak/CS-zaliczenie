namespace Library
{
    public class Rents
    {
        protected string firstname="";
        protected string lastname="";
        protected int rentedbook;
        protected int rentid;
        protected int invoiceid;

        public Rents(string firstname, string lastname, int rentedbook, int rentid)
        {
            this.firstname=firstname;
            this.lastname=lastname;
            this.rentedbook=rentedbook;
            this.rentid=rentid;
            
        }
        public string FirstName
        {
            get { return firstname; }
            set { firstname=value; }

        }
        public string LastName
        {
            get { return lastname;}
            set { lastname=value; }

        }
        public int RentedBook
        {
            get {return rentedbook;}
            set {rentedbook=value;}

        }
        public int RentID
        {
            get {return rentid;}
            set {rentid=value;}

        }
    }




}
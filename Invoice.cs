namespace Library
{
    public class Invoice
    {
        protected string invoicetype="";
        protected int invoiceid;
        protected int fee=10;
        public Invoice(int invoiceid)
        {
            this.invoiceid=invoiceid;
            invoicetype="receipt";
        }
        public int InvoiceID
        {
            get {return invoiceid; }
            set {invoiceid=value;}
        }
        public int Fee
        {
            get { return fee; }
            set { invoiceid=value;}
        }
        public string InvoiceType
        {
            get {return invoicetype;}
            set {invoicetype=value;}
        }
    }




}
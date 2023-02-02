using System;
//Library service system created for 'Object programming' classes by Lukasz Jasinski, sophomore's year student.
namespace Library
{
    class Program
    {
        static bool run=true;
        public static List<Book> BooksList = new List<Book>();
        public static List<Dictionary> DictionariesList = new List<Dictionary>();
        public static List<Encyclopedia> EncyclopediasList = new List<Encyclopedia>();
        public static List<Manual> ManualsList = new List<Manual>();
        public static List<Textbook> TextbooksList = new List<Textbook>();
        private static void Main(string[] args)
        {
            App myApp = new App();
            while(Program.run==true)
            {
                switch(myApp.DisplayMenu())
                {
                    case 1:
                        switch(myApp.DisplayBooksTab())
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("No     Title     Author     ISBN     Category");                               
                                if (BooksList.Count!=0)
                                {
                                    int number=1;
                                    foreach(var Book in BooksList)
                                    {
                                        Console.WriteLine("{0}. {1}, {2}, {3}, {4}", number, Book.Title, Book.Author, Book.Isbn, Book.Category);
                                        number++;
                                    }
                                }
                                else
                                    Console.WriteLine("No Books in your Library store");
                                Console.WriteLine("No     Title     Author     ISBN     Category       Dictionary Type");   
                                if (DictionariesList.Count!=0)
                                {
                                    int number=1;
                                    foreach(var Dictionary in DictionariesList)
                                    {
                                        Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}", number, Dictionary.Title, Dictionary.Author, Dictionary.Isbn, Dictionary.Category, Dictionary.Type);
                                        number++;
                                    }
                                }
                                else
                                    Console.WriteLine("No Dictionaries in your Library store");
                                Console.WriteLine("No     Title     Author     ISBN     Category       Encyclopedia topic");   
                                if (EncyclopediasList.Count!=0)
                                {
                                    int number=1;
                                    foreach(var Encyclopedia in EncyclopediasList)
                                    {
                                        Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}", number, Encyclopedia.Title, Encyclopedia.Author, Encyclopedia.Isbn, Encyclopedia.Category, Encyclopedia.Topic);
                                        number++;
                                    }
                                }
                                else
                                    Console.WriteLine("No Encyclopedias in your Library store");
                            
                                Console.WriteLine("Press Enter to return to menu");
                                Console.ReadLine();
                                break;
                            case 2:
                                string? temptitle; 
                                string? tempauthor;
                                int tempisbn=0;
                                string? tempcategory;                
                                string? temptype;
                                Console.WriteLine("What is the Title of new book");
                                temptitle=Console.ReadLine();
                                if (string.IsNullOrEmpty(temptitle)) 
                                {
                                    temptitle="Placeholder";
                                    Console.WriteLine("Setting placeholder Title");
                                }                                
                                Console.WriteLine("Who is the Author of new book");
                                tempauthor=Console.ReadLine();
                                if (string.IsNullOrEmpty(tempauthor)) 
                                {
                                    tempauthor="Placeholder";
                                    Console.WriteLine("Setting placeholder Author");
                                }                                
                                Console.WriteLine("What is the ISBN number of new book");
                                try
                                {
                                    tempisbn=Convert.ToInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("Exception caught, prompted value is not valid string, setting random number (you can edit it later)");
                                    Random rnd = new Random();
                                    tempisbn=rnd.Next();
                                    Thread.Sleep(2000);  
                                }
            
                                Console.WriteLine("What is the category of new book");
                                tempcategory=Console.ReadLine();
                                if (string.IsNullOrEmpty(tempcategory)) 
                                {
                                    tempcategory="None";
                                    Console.WriteLine("Setting Category to None");
                                }                        
                                Console.WriteLine("Is your book any of type: Dictionary, Encyclopedia, Manual or Textbook?");
                                Console.WriteLine("If so, please type it right now, otherwise leave blank");
                                temptype=Console.ReadLine();
                                if (string.IsNullOrEmpty(temptype)) 
                                {
                                    temptype="";
                                    Console.WriteLine("Setting Type to Blank");
                                    BooksList.Add(new Book(temptitle, tempauthor, tempisbn, tempcategory));
                                }
                                else
                                {
                                    temptype=temptype.ToLower();
                                    switch(temptype)
                                    {
                                        case "dictionary":
                                            string? tempdicttype;
                                            do
                                            {
                                                Console.WriteLine("Please provide topic of this Dictionary or type 0 to set it to Blank");
                                                tempdicttype=Console.ReadLine();
                                                
                                            }while(string.IsNullOrEmpty(tempdicttype));
                                            if(tempdicttype=="0")
                                            {
                                                tempdicttype="";
                                                Console.WriteLine("Setting Dictionary tyope to blank");
                                            }
                                            DictionariesList.Add(new Dictionary(temptitle, tempauthor, tempisbn, tempcategory,tempdicttype));
                                            break;
                                        case "encyclopedia":
                                            string? temptopic;
                                            do
                                            {
                                                Console.WriteLine("Please provide topic of this Encyclopedia or type 0 to set it to Blank");
                                                temptopic=Console.ReadLine();
                                                
                                            }while(string.IsNullOrEmpty(temptopic));
                                            if(temptopic=="0")
                                            {
                                                temptopic="";
                                            }
                                            EncyclopediasList.Add(new Encyclopedia(temptitle, tempauthor, tempisbn, tempcategory, temptopic));
                                            break;
                                        case "manual":
                                            ManualsList.Add(new Manual(temptitle, tempauthor, tempisbn, tempcategory,temptype));
                                            break;
                                        case "textbook":
                                            TextbooksList.Add(new Textbook(temptitle, tempauthor, tempisbn, tempcategory,temptype));
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                Console.WriteLine("New book Added");
                                Thread.Sleep(1000);
                                break;
                            case 3:
                                Console.WriteLine("That should delete books");
                                break;
                            case 4:
                                Console.WriteLine("That should go back");
                                break;
                            default:
                                break;
                        }
                    break;
                case 2:
                    myApp.DisplayCategoriesTab();
                    break;
                case 3:
                    myApp.DisplayCatalogueTab();
                    break;
                case 4:
                    myApp.DisplayRentalTab();
                    break;
                case 5:
                    Console.WriteLine("Invoices are going to be implemented soon...");
                    break;
                case 6:
                    Console.WriteLine("Help is going to be implemented soon...");
                    break;
                case 0:
                    run=myApp.Exit();
                    string result = ( run==false)? "Closing..." : "Continuing";
                    Console.WriteLine(result);
                    Thread.Sleep(1000);
                    break;
                default:
                    break;
             
        }


            }
        }


                        
    }
}

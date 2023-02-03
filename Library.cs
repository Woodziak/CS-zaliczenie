using System;
//Library service system created for 'Object programming' classes by Lukasz Jasinski, sophomore's year student.
namespace Library
{
    class Program
    {    
            public static Catalogue myCatalogue = new Catalogue("default");
            public static List<Category> CategoriesList = new List<Category>();
            public static List<Book> BooksList = new List<Book>();
            public static List<Dictionary> DictionariesList = new List<Dictionary>();
            public static List<Encyclopedia> EncyclopediasList = new List<Encyclopedia>();
            public static List<Manual> ManualsList = new List<Manual>();
            public static List<Textbook> TextbooksList = new List<Textbook>();        
        private static void Main(string[] args)
        {
            bool run=true;

            App myApp = new App();
            //book for debugging purposes
            BooksList.Add(new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 0330258648, "default"));
            DictionariesList.Add(new Dictionary("Urban Dictionary","Aaron Peckham", 43543452, "default", "Street slang's dictionary"));
            
            CategoriesList.Add(new Category("default"));
            while(run==true)
            {   
                switch(myApp.DisplayMenu())
                {
                    case 1:
                        switch(myApp.DisplayBooksTab())
                        {
                            case 1:
                                myApp.ViewAllBooks();
                                break;
                            case 2:
                                myApp.AddNewBook();
                                break;
                            case 3:
                                myApp.DeleteBook();
                                break;
                            default:
                                break;
                        }
                    break;
                case 2:
                    switch(myApp.DisplayCategoriesTab())
                    {
                        case 1: 
                            Console.Clear();
                            Console.WriteLine("Please put THE NAME of Category you would like to see");
                            int number=1;
                            foreach(var Category in CategoriesList)
                            {
                                Console.WriteLine("{0}. {1}", number,Category.Name);
                                number++;
                            }
                            string? category;
                            category=Console.ReadLine();
                            if(string.IsNullOrEmpty(category))
                                category="";
                            else
                                myApp.ViewCategory(category);
                            Console.WriteLine("Press Enter to return to main menu");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Please put the name of Category you would like to add");
                            string? newcategory=Console.ReadLine();
                            if(string.IsNullOrEmpty(newcategory))
                            {
                                category="";
                                Console.WriteLine("Empty string dettected, no categories will be added");
                            }
                            else
                            {
                                CategoriesList.Add(new Category(newcategory));
                                Console.WriteLine("Category {0} added, please press enter to return to main menu",newcategory);
                            }
                            Console.ReadLine();
                            break;
                        case 3:
                        default:
                            break;
                    }
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

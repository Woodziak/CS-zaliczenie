namespace Library
{
    public class App
    {
        
        public int InputVerification()
        {   int option;
            try
            {
                option=Convert.ToUInt16(Console.ReadLine());
            }
            catch
            {
                
                Console.WriteLine("Returning to Main Menu");
                option=10;
            }
            return option;
        }
        public int DisplayMenu()
        {
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine(
                "Choose your option:\n"+
                "1. Books\n"+
                "2. Categories\n"+
                "3. Catalogue\n"+
                "4. Rental service\n"+
                "5. Invoices\n"+
                "0. Exit"+
                "\n\n\n\n\n"+
                "Prompt: "          
            );
            
        return InputVerification();
        }
        public int DisplayBooksTab()
        {
            
            Console.Clear();
            Console.WriteLine(
                "Choose your option:\n"+
                "1. View Books\n"+
                "2. Add new Book\n"+
                "3. Delete Book\n"+
                "\n\n\n\n\n"+
                "Prompt: "          
            );
            
            return InputVerification();
        }
        public int DisplayCategoriesTab()
        {
            
            Console.Clear();
            Console.WriteLine(
                "Choose your option:\n"+
                "1. View Categories\n"+
                "2. Add new Category\n"+
                "3. Delete Category\n"+
                "\n\n\n\n\n"+
                "Prompt: "          
            );
            
            return InputVerification();
        
        }
        public int DisplayCatalogueTab()
        {
            
            Console.Clear();
            Console.WriteLine(
                "Choose your option:\n"+
                "1. View Catalogue\n"+
                "2. Delete all Books and Categories\n"+
                "\n\n\n\n\n"+
                "Prompt: "          
            );
            
            return InputVerification();
        
        }
        public int DisplayRentalTab()
        {
            
            Console.Clear();
            Console.WriteLine(
                "Choose your option:\n"+
                "1. View Rented books\n"+
                "2. Add new Rent\n"+
                "3. Return Book\n"+
                "\n\n\n\n\n"+
                "Prompt: "          
            );
            
            return InputVerification();
        
        }
        public void AddNewBook()
        {
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
                tempcategory="default";
                Console.WriteLine("Setting Category to default");
            }                        
            Console.WriteLine("Is your book any of type: Dictionary, Encyclopedia, Manual or Textbook?");
            Console.WriteLine("If so, please type it right now, otherwise leave blank");
            temptype=Console.ReadLine();
            if (string.IsNullOrEmpty(temptype)) 
            {
                temptype="";
                Console.WriteLine("Setting Type to Blank");
                Program.BooksList.Add(new Book(temptitle, tempauthor, tempisbn, tempcategory));
                Console.WriteLine("Your book has been added");
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
                        Program.DictionariesList.Add(new Dictionary(temptitle, tempauthor, tempisbn, tempcategory,tempdicttype));
                        Console.WriteLine("Your book has been added");
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
                        Program.EncyclopediasList.Add(new Encyclopedia(temptitle, tempauthor, tempisbn, tempcategory, temptopic));
                        Console.WriteLine("Your book has been added");
                        break;
                    case "manual":
                        string? tempdevice;
                        do
                        {
                            Console.WriteLine("Please provide Device to which this Manual refers or type 0 to set it to Blank");
                            tempdevice=Console.ReadLine();
                            
                        }while(string.IsNullOrEmpty(tempdevice));
                        if(tempdevice=="0")
                        {
                            tempdevice="";
                        }
                        Program.ManualsList.Add(new Manual(temptitle, tempauthor, tempisbn, tempcategory,tempdevice));
                        Console.WriteLine("Your book has been added");
                        break;
                    case "textbook":
                        string? tempclasses;
                        do
                        {
                            Console.WriteLine("Please provide Classes to which this Textbook refers or type 0 to set it to Blank");
                            tempclasses=Console.ReadLine();
                            
                        }while(string.IsNullOrEmpty(tempclasses));
                        if(tempclasses=="0")
                        {
                            tempclasses="";
                        }                                        
                        Program.TextbooksList.Add(new Textbook(temptitle, tempauthor, tempisbn, tempcategory,tempclasses));
                        Console.WriteLine("Your book has been added");
                        break;
                    default:
                        Console.WriteLine("You did specify special type but it was not recognized - book has not been added");
                        break;
                }
            }
            Thread.Sleep(1000);
        }
        public int ViewBooks(bool rented)
        {
            Console.Clear();
            Console.WriteLine("No           Title           Author          ISBN            Category       Serial Number       Status");                               
            if (Program.BooksList.Count!=0)
            {
                int number=1;
                if (!rented)
                {
                    foreach(var Book in Program.BooksList)
                    {
                        Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}", 
                        number, 
                        Book.Title, 
                        Book.Author, 
                        Book.Isbn, 
                        Book.Category, 
                        Book.SerialNumber,
                        Book.Status);
                        number++;
                    }
                }
                else
                {
                    foreach(var Book in Program.BooksList)
                    {
                        if(Book.Status=="RENTED")
                        {
                            Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5},", 
                            number, 
                            Book.Title, 
                            Book.Author, 
                            Book.Isbn, 
                            Book.Category, 
                            Book.SerialNumber,
                            Book.Status);
                            number++;
                        }
                    }

                }

            }
            else
                Console.WriteLine("No Books in your Library store");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            return Program.BooksList.Count;

        }
        public int ViewDictionaries(bool rented)
        {
            Console.Clear();
            Console.WriteLine("No           Title           Author          ISBN            Type       Serial Number       Status");   
            if (Program.DictionariesList.Count!=0)
            {
                int number=1;
                foreach(var Dictionary in Program.DictionariesList)
                {
                    if(!rented)
                    {
                        Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}, {7}", 
                        number, 
                        Dictionary.Title, 
                        Dictionary.Author, 
                        Dictionary.Isbn, 
                        Dictionary.Category, 
                        Dictionary.Type, 
                        Dictionary.SerialNumber, 
                        Dictionary.Status);
                        number++;
                    }
                    else
                    {
                        if(Dictionary.Status=="RENTED")
                        {   Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}, {7}", 
                            number, 
                            Dictionary.Title, 
                            Dictionary.Author, 
                            Dictionary.Isbn, 
                            Dictionary.Category, 
                            Dictionary.Type, 
                            Dictionary.SerialNumber, 
                            Dictionary.Status);
                            number++;                       
                        }
                    }
                }
            }
            else
                Console.WriteLine("No Dictionaries in your Library store");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            return Program.BooksList.Count;
        }
        public int ViewEncyclopedias(bool rented)
        {
            Console.Clear();
            Console.WriteLine("No           Title           Author          ISBN            Topic      Serial Number       Status");   
            if (Program.EncyclopediasList.Count!=0)
            {
                int number=1;
                foreach(var Encyclopedia in Program.EncyclopediasList)
                {
                    if(!rented)
                    {
                        Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}, {7}", 
                        number, 
                        Encyclopedia.Title, 
                        Encyclopedia.Author, 
                        Encyclopedia.Isbn, 
                        Encyclopedia.Category, 
                        Encyclopedia.Topic, 
                        Encyclopedia.SerialNumber,
                        Encyclopedia.Status);
                        number++;
                    }
                    else
                    {
                        if(Encyclopedia.Status=="RENTED")
                        {
                            Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}, {7}", 
                            number, 
                            Encyclopedia.Title, 
                            Encyclopedia.Author, 
                            Encyclopedia.Isbn, 
                            Encyclopedia.Category, 
                            Encyclopedia.Topic, 
                            Encyclopedia.SerialNumber,
                            Encyclopedia.Status);
                            number++;        
                        }                
                    }
                }
            }
            else
                Console.WriteLine("No Encyclopedias in your Library store");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            return Program.BooksList.Count;
        }
        public int ViewManuals(bool rented)
        {
            Console.Clear();
            Console.WriteLine("No           Title           Author          ISBN            Device      Serial Number       Status");   
            if (Program.ManualsList.Count!=0)
            {
                int number=1;
                foreach(var Manual in Program.ManualsList)
                {
                    if(!rented)
                    {
                        Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}, {7}", 
                        number, 
                        Manual.Title, 
                        Manual.Author, 
                        Manual.Isbn, 
                        Manual.Category, 
                        Manual.Device, 
                        Manual.SerialNumber,
                        Manual.Status);
                        number++;
                    }
                    else
                    {
                        if(Manual.Status=="RENTED")
                        {
                            Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}, {7}", 
                            number, 
                            Manual.Title, 
                            Manual.Author, 
                            Manual.Isbn, 
                            Manual.Category, 
                            Manual.Device, 
                            Manual.SerialNumber,
                            Manual.Status);
                            number++;   
                        }                     
                    }
                }
            }
            else
                Console.WriteLine("No Manuals in your Library store");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            return Program.BooksList.Count;
        }
        public int ViewTextbooks(bool rented)
        {
            Console.Clear();
            Console.WriteLine("No           Title           Author          ISBN            Classes        Serial Number        Status");   
            if (Program.TextbooksList.Count!=0)
            {
                int number=1;
                foreach(var Textbook in Program.TextbooksList)
                {
                    if(!rented)
                    {
                        Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}, {7}", 
                        number, 
                        Textbook.Title, 
                        Textbook.Author, 
                        Textbook.Isbn, 
                        Textbook.Category, 
                        Textbook.Classes, 
                        Textbook.SerialNumber,
                        Textbook.Status);
                        number++;
                    }
                    else
                    {
                        if(Textbook.Status=="RENTED")
                        {
                            Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}, {7}", 
                            number, 
                            Textbook.Title, 
                            Textbook.Author, 
                            Textbook.Isbn, 
                            Textbook.Category, 
                            Textbook.Classes, 
                            Textbook.SerialNumber,
                            Textbook.Status);
                            number++;                            
                        }
                    }
                }
            }
            else
                Console.WriteLine("No Textbooks in your Library store");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            return Program.BooksList.Count;
        }
        public int ViewAllBooks(bool rented)
        {   
            if (rented)
                return ViewBooks(true)+ViewDictionaries(true)+ViewEncyclopedias(true)+ViewManuals(true)+ViewTextbooks(true);
            else
                return ViewBooks(false)+ViewDictionaries(false)+ViewEncyclopedias(false)+ViewManuals(false)+ViewTextbooks(false);
        }
        public void DeleteIndexFromList(List<Book> BL)
        {
            Console.WriteLine("Please choose index you would like to delete or press enter to exit");
            int index=InputVerification();
            index--;
            if (index<0)
                Console.WriteLine("Cannot modify this index - index does not exist or out of range");
            else    
            {
                BL.RemoveAt(index);
                Console.WriteLine("Book removed");
            }
            Console.WriteLine("Press Enter to move to Main Menu");
            Console.ReadLine();
        }
        public void DeleteIndexFromList(List<Dictionary> DL)
        {
            Console.WriteLine("Please choose index you would like to delete or press enter to exit");
            int index=InputVerification();
            index--;
            if (index<0)
                Console.WriteLine("Cannot modify this index - index does not exist or out of range");
            else    
            {
                DL.RemoveAt(index);
                Console.WriteLine("Book removed");
            }
            Console.WriteLine("Press Enter to move to Main Menu");
            Console.ReadLine();
        }
        public void DeleteIndexFromList(List<Encyclopedia> EL)
        {
            Console.WriteLine("Please choose index you would like to delete or press enter to exit");
            int index=InputVerification();
            index--;
            if (index<0)
                Console.WriteLine("Cannot modify this index - index does not exist or out of range");
            else    
            {
                EL.RemoveAt(index);
                Console.WriteLine("Book removed");
            }
            Console.WriteLine("Press Enter to move to Main Menu");
            Console.ReadLine();
        }
        public void DeleteIndexFromList(List<Manual> ML)
        {
            Console.WriteLine("Please choose index you would like to delete or press enter to exit");
            int index=InputVerification();
            index--;
            if (index<0)
                Console.WriteLine("Cannot modify this index - index does not exist or out of range");
            else
            {    
                ML.RemoveAt(index);
                Console.WriteLine("Book removed");
            }
            Console.WriteLine("Press Enter to move to Main Menu");
            Console.ReadLine();
        }
        public void DeleteIndexFromList(List<Textbook> TL)
        {
            Console.WriteLine("Please choose index you would like to delete or press enter to exit");
            int index=InputVerification();
            index--;
            if (index<0)
                Console.WriteLine("Cannot modify this index - index does not exist or out of range");
            else    
            {
                TL.RemoveAt(index);
                Console.WriteLine("Book removed");
            }
            Console.WriteLine("Press Enter to move to Main Menu");
            Console.ReadLine();
        }
        public void DeleteBook()
        {
            Console.Clear();
            Console.WriteLine("WARNING\nYOU ARE GOING TO DELETE BOOK\nPLEASE PICK POSITION YOU WOULD LIKE TO DELETE\n\n\n");
            Console.WriteLine(
                "Choose collection you would like to alter or press Enter to return to menu\n"+
                "1. Books\n"+
                "2. Dictionaries\n"+
                "3. Encyclopedias\n"+
                "4. Manuals\n"+
                "5. Textbooks\n");
            switch(InputVerification())
            {
                case 1:
                    if (ViewBooks(false)>0)
                        DeleteIndexFromList(Program.BooksList);
                    else
                        Console.WriteLine("Cannot delete, this collection has no books! Press Enter to return to main menu");
                    Console.ReadLine();
                    break;
                case 2:
                    ViewDictionaries(false);
                    DeleteIndexFromList(Program.DictionariesList);
                    break;
                case 3:
                    ViewEncyclopedias(false);
                    DeleteIndexFromList(Program.EncyclopediasList);
                    break;
                case 4:
                    ViewManuals(false);
                    DeleteIndexFromList(Program.ManualsList);
                    break;
                case 5:
                    ViewTextbooks(false);
                    DeleteIndexFromList(Program.TextbooksList);
                    break;
                default: 
                    break;
            }
            

        }
        public void ViewCategory(string name)
        {
            int number=1;
            
            foreach(var Book in Program.BooksList)
            {
                if (Book.Category==name)
                {
                    Console.WriteLine("{0}. {1}, {2}, {3}, {4}. {5}", number, Book.Title, Book.Author, Book.Isbn, Book.Category, Book.SerialNumber);
                    number++;

                }
            }
            foreach(var Dictionary in Program.DictionariesList)
            {
                if (Dictionary.Category==name)
                {
                    Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}", number, Dictionary.Title, Dictionary.Author, Dictionary.Isbn, Dictionary.Category, Dictionary.Type, Dictionary.SerialNumber);
                    number++;

                }
            }
            foreach(var Encyclopedia in Program.EncyclopediasList)
            {
                if (Encyclopedia.Category==name)
                {
                    Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}", number, Encyclopedia.Title, Encyclopedia.Author, Encyclopedia.Isbn, Encyclopedia.Category, Encyclopedia.Topic, Encyclopedia.SerialNumber);
                    number++;

                }
            }
            foreach(var Manual in Program.ManualsList)
            {
                if (Manual.Category==name)
                {
                    Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}", number, Manual.Title, Manual.Author, Manual.Isbn, Manual.Category, Manual.Device, Manual.SerialNumber);
                    number++;

                }
            }
            foreach(var Textbook in Program.TextbooksList)
            {
                if (Textbook.Category==name)
                {
                    Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}", number, Textbook.Title, Textbook.Author, Textbook.Isbn, Textbook.Category, Textbook.Classes, Textbook.SerialNumber);
                    number++;

                }
            }        
            if(number==1)
                Console.WriteLine("The is no book in specified category");
        }
        public void DeleteCategory(string name)
        {
            Console.WriteLine("The category {0} and those books are going to be deleted",name);
            ViewCategory(name);
            Console.WriteLine("Are you sure you want to delete ALL of those entries? [y/n]");
            bool check=(Console.ReadLine()=="y")? true : false;
            if(check)
            {
                Program.BooksList.RemoveAll(BooksList=>BooksList.Category==name);
                Program.DictionariesList.RemoveAll(DictionariesList=>DictionariesList.Category==name);
                Program.EncyclopediasList.RemoveAll(EncyclopediasList=>EncyclopediasList.Category==name);
                Program.ManualsList.RemoveAll(ManualsList=>ManualsList.Category==name);
                Program.TextbooksList.RemoveAll(TexbooksList=>TexbooksList.Category==name);
                Program.CategoriesList.RemoveAll(CategoriesList=>CategoriesList.Name==name);
                Console.WriteLine("Books and category deleted.\nReturning to main menu");
            }     
            else
                Console.WriteLine("Aborting");
    

        }
        public void DisplayCatalogue()
        {
            ViewAllBooks(false);
        }
        public void DeleteCatalogue()
        {
            Console.Clear();
            Console.WriteLine("WARNING\nWARNING\nWARNING\nYou are going to delete whole catalogue, are you sure? [y/n]");
            bool check=(Console.ReadLine()=="y")? true : false;
            if (check)
            {
                Program.BooksList.Clear();
                Program.DictionariesList.Clear();
                Program.EncyclopediasList.Clear();
                Program.ManualsList.Clear();
                Program.TextbooksList.Clear();
                Program.CategoriesList.Clear();
            }
            else
                Console.WriteLine("Aborting");

        }
        public void DisplayRents()
        {
            //Console.Clear();
            Console.WriteLine("For now, these books are rented");
            ViewAllBooks(true);
            Console.WriteLine("Who rented:");
            Console.WriteLine("First Name   Last Name   Book S/N    Rent ID");
            foreach(var Rent in Program.RentsList)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", 
                Rent.FirstName, 
                Rent.LastName, 
                Rent.RentedBook, 
                Rent.RentID);
                
            }

            Console.WriteLine("Press enter to return to Main Menu");
            Console.ReadLine();

        }
        public (int,int) RentBook()
        {   int id=0;
            int sn=0;
            Random rnd=new Random();
            Console.Clear();
            Console.WriteLine("Please specify from which type you would like to rent a book: Book, Dictionary, Encyclopedia, Manual, Textbook");
            string? name=Console.ReadLine();
            if(string.IsNullOrEmpty(name))
            {
                name="";
                Console.WriteLine("No input detected, returning to main menu");
            }
            else
            {   name=name.ToLower();
                
                switch(name)
                {
                    case "book":
                        if (ViewBooks(false)>0)
                        {
                            Console.WriteLine("Please pick the serial number of the Book you would like to rent");
                            sn=InputVerification();
                            foreach( var Book in Program.BooksList)
                            {
                                if ((Book.SerialNumber==sn) && (Book.Status=="AVAILABLE"))
                                {
                                    Book.Status="RENTED";
                                    Console.WriteLine("Book {0} has been rented",Book.Title);
                                    if (Program.RentsList.Count==0)
                                        id=1;
                                    else
                                    {
                                        var Rent= Program.RentsList.Last();
                                        id=Rent.RentID+1;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ERROR - Cannot rent that book");
                                }
                            }
                        }
                        break;
                    case "dictionary":
                        if (ViewDictionaries(false)>0)
                        {                        
                            Console.WriteLine("Please pick the serial number of the Dictionary you would like to rent");
                            sn=InputVerification();
                            foreach( var Dictionary in Program.DictionariesList)
                            {
                                if (Dictionary.SerialNumber==sn && Dictionary.Status=="AVAILABLE")
                                {
                                    Dictionary.Status="RENTED";
                                    Console.WriteLine("Book {0} has been rented",Dictionary.Title);
                                    if (Program.RentsList.Count==0)
                                        id=1;
                                    else
                                    {                                    
                                        var Rent= Program.RentsList.Last();
                                        id=Rent.RentID+1;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ERROR - Cannot rent that book");
                                }
                            }
                        }
                        break;
                    case "encyclopedia":
                        if(ViewEncyclopedias(false)>0)
                        {
                            Console.WriteLine("Please pick the serial number of the Encyclopedia you would like to rent");
                            sn=InputVerification();
                            foreach( var Encyclopedia in Program.EncyclopediasList)
                            {
                                if (Encyclopedia.SerialNumber==sn && Encyclopedia.Status=="AVAILABLE")
                                {
                                    Encyclopedia.Status="RENTED";
                                    Console.WriteLine("Book {0} has been rented",Encyclopedia.Title);
                                    if (Program.RentsList.Count==0)
                                        id=1;
                                    else
                                    {                            
                                        var Rent= Program.RentsList.Last();
                                        id=Rent.RentID+1;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ERROR - Cannot rent that book");
                                }
                            }
                        }
                        break;
                    case "manual":
                        if(ViewManuals(false)>0)
                        {
                            Console.WriteLine("Please pick the serial number of the Manual you would like to rent");
                            sn=InputVerification();
                            foreach( var Manual in Program.ManualsList)
                            {
                                if (Manual.SerialNumber==sn && Manual.Status=="AVAILABLE")
                                {
                                    Manual.Status="RENTED";
                                    Console.WriteLine("Book {0} has been rented",Manual.Title);
                                    if (Program.RentsList.Count==0)
                                        id=1;
                                    else
                                    {                                
                                        var Rent= Program.RentsList.Last();
                                        id=Rent.RentID+1;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ERROR - Cannot rent that book");
                                }
                            }                        
                        }
                        break;
                    case "textbook":
                        if(ViewTextbooks(false)>0)
                        {
                            Console.WriteLine("Please pick the serial number of the Textbook you would like to rent");
                            sn=InputVerification();
                            foreach( var Textbook in Program.TextbooksList)
                            {
                                if (Textbook.SerialNumber==sn && Textbook.Status=="AVAILABLE")
                                {
                                    Textbook.Status="RENTED";
                                    Console.WriteLine("Book {0} has been rented",Textbook.Title);
                                    if (Program.RentsList.Count==0)
                                        id=1;
                                    else
                                    {                                    
                                        var Rent= Program.RentsList.Last();
                                        id=Rent.RentID+1;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ERROR - Cannot rent that book");
                                }
                            }                        
                        }
                        break;
                    default:
                        break;
                }
            }
            return (id, sn);
        }
        public bool Exit()
        {
            Console.WriteLine("Are you sure you want to close this program? [y/n]");
            bool run= (Console.ReadLine()=="y")? false : true;
            return run;
        }
    }   

}

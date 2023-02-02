namespace Library
{
    public class App
    {
        int option;
        public void InputVerification()
        {
            try
            {
                option=Convert.ToUInt16(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Exception caught, prompted value is not string, too long int or not unsigned int\nWaiting for recovery");
                option=10;
                Thread.Sleep(2000);  
            }
            
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
                "6. Help\n"+
                "0. Exit"+
                "\n\n\n\n\n"+
                "Prompt: "          
            );
            InputVerification();

        return option;
        }
        public int DisplayBooksTab()
        {
            
            Console.Clear();
            Console.WriteLine(
                "Choose your option:\n"+
                "1. View Books\n"+
                "2. Add new Book\n"+
                "3. Delete Book\n"+
                "0. Back"+
                "\n\n\n\n\n"+
                "Prompt: "          
            );
            InputVerification();
            return option;
        }

        public int DisplayCategoriesTab()
        {
            
            Console.Clear();
            Console.WriteLine(
                "Choose your option:\n"+
                "1. View Categories\n"+
                "2. Add new Category\n"+
                "3. Delete Category\n"+
                "0. Back"+
                "\n\n\n\n\n"+
                "Prompt: "          
            );
            InputVerification();
            return option;
        
        }
        public int DisplayCatalogueTab()
        {
            
            Console.Clear();
            Console.WriteLine(
                "Choose your option:\n"+
                "1. View Catalogue\n"+
                "2. Delete all Books and Categories\n"+
                "0. Back"+
                "\n\n\n\n\n"+
                "Prompt: "          
            );
            InputVerification();
            return option;
        
        }
        public int DisplayRentalTab()
        {
            
            Console.Clear();
            Console.WriteLine(
                "Choose your option:\n"+
                "1. View Rented books\n"+
                "2. Add new Rent\n"+
                "3. Return Book\n"+
                "0. Back"+
                "\n\n\n\n\n"+
                "Prompt: "          
            );
            InputVerification();
            return option;
        
        }





        public bool Exit()
        {
            Console.WriteLine("Are you sure you want to close this program? [y/n]");
            bool run= (Console.ReadLine()=="y")? false : true;
            return run;
        }
    }   

}
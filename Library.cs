﻿using System;
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
            public static List<Rents> RentsList = new List<Rents>();
            public static List<Invoice> InvoicesList = new List<Invoice>();
        private static void Main(string[] args)
        {
            bool run=true;

            App myApp = new App();
            //books for debugging purposes
            BooksList.Add(new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 0330258648, "default", 1));
            DictionariesList.Add(new Dictionary("Urban Dictionary","Aaron Peckham", 43543452, "default", "Street slang's dictionary", 2));
            EncyclopediasList.Add(new Encyclopedia("Encyclopedia of Natural Science","Edward Norton", 234983468, "default", "Natural science", 3));
            ManualsList.Add(new Manual("Instruction for Oster Blender","Bartosz Menel",57346345,"default","Oster Blender", 4));
            TextbooksList.Add(new Textbook("Hungarian Grammar","Nagy Pista",543534,"default","Hungarian",5));
            CategoriesList.Add(new Category("default"));
            while(run==true)
            {   
                switch(myApp.DisplayMenu())
                {
                case 1:
                    switch(myApp.DisplayBooksTab())
                        {
                            case 1:
                                myApp.ViewAllBooks(false);
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
                    int number=1;
                    string? category;
                    switch(myApp.DisplayCategoriesTab())
                    {
                        
                        case 1: 
                            Console.Clear();
                            Console.WriteLine("Please put THE NAME of Category you would like to see");
                            if(CategoriesList.Count!=0) 
                            {    foreach(var Category in CategoriesList)
                                {
                                    Console.WriteLine("{0}. {1}", number,Category.Name);
                                    number++;
                                }
                                
                                category=Console.ReadLine();
                                if(string.IsNullOrEmpty(category))
                                    category="";
                                else
                                    myApp.ViewCategory(category);
                                Console.WriteLine("Press Enter to return to main menu");
                                Console.ReadLine();
                            }
                            else
                                Console.WriteLine("No categories has been specified in this system");
                            break;
                        case 2:
                            Console.WriteLine("Please put name of the category you would like to add");
                            string? newcategory=Console.ReadLine();
                            if(string.IsNullOrEmpty(newcategory))
                            {
                                category="";
                                Console.WriteLine("Empty string dettected, no categories will be added. Press Enter to return to Menu");
                            }
                            else
                            {
                                CategoriesList.Add(new Category(newcategory));
                                Console.WriteLine("Category {0} added, please press enter to return to main menu",newcategory);
                            }
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Please put the name of Category you would like to delete\nWARNING\nIT WILL ALSO DELETE ALL BOOKS ASSOCIATED WITH THIS CATEGORY");
                            number=1;
                            foreach(var Category in CategoriesList)
                            {
                                Console.WriteLine("{0}. {1}", number,Category.Name);
                                number++;
                            }
                            string? deletecategory=Console.ReadLine();
                            if(string.IsNullOrEmpty(deletecategory))
                            {
                                deletecategory="";
                                Console.WriteLine("Empty string dettected, no categories will be deleted. Press Enter to return to Menu");
                            }
                            else
                                myApp.DeleteCategory(deletecategory);
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch(myApp.DisplayCatalogueTab())
                    {
                        case 1:
                            myApp.DisplayCatalogue();
                            break;
                        case 2:
                            myApp.DeleteCatalogue();
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    switch(myApp.DisplayRentalTab())
                    {
                        case 1:
                            myApp.DisplayRents();
                            break;
                        case 2:
                            string? fn;
                            string? ln;
                            (int, int, int) id=(0,0,0);
                            Console.Write("Please input your first name: ");
                            fn=Console.ReadLine();
                            if(string.IsNullOrEmpty(fn))
                                fn="John";
                            Console.Write("Please input last name: ");
                            ln=Console.ReadLine();
                            if(string.IsNullOrEmpty(ln))
                                ln="Doe";
                            id=myApp.RentBook();
                            if(id.Item1!=0)
                            {
                                RentsList.Add(new Rents(fn, ln, id.Item2 ,id.Item1));
                                InvoicesList.Add(new Invoice(id.Item3));
                            }
                            break;
                        case 3:
                            myApp.MakeBookReturned(myApp.ReturnBook());
                            break;
                        default:
                            break;
                    }
                    break;
                case 5:
                    myApp.DisplayInvoice();
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

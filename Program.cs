using System;
using TaskManagement;



namespace TaskManagment 
{   

    
    internal class Program
    {

       
        static void Main(string[] args)
        {
            /*
             * main dispatch loop
             * parses user input and calls appropriate TaskManager method
             */

            TaskManager toDoList = new TaskManager();
            var input = -1;
            
            while (input!=7) 
            {
                TaskManager.ShowMenu();
                input=TaskManager.GetValidInt(Console.ReadLine(),1,7);
                
                if (input == 1)
                {
                    toDoList.CreateToDo(); 
                }
                else if (input==2)
                {
                    toDoList.DeleteToDo();
                }

                else if (input == 3)
                {
                    toDoList.EditToDo();
                }

                else if(input==4)
                {
                    toDoList.CompleteToDo();
                }
                
                else if (input==5)
                {
                    toDoList.ShowList(true);
                }
                else if (input == 6)
                {
                    toDoList.ShowList(false);
                }
                else if (input == 7)
                {
                     Console.WriteLine("Goodbye");
                }
             
                else
                {
                    Console.WriteLine("error, please enter a # 1-7");
                }
              
            } 
           
        }
    }
}
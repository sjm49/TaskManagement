using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.models;


namespace TaskManagement
{
    public class TaskManager
    {
        public List<ToDo> ToDoList;

        public TaskManager()
        {
            Console.WriteLine("Welcome to the task management app");
            this.ToDoList=new List<ToDo>();
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\nEnter a number:");
            Console.WriteLine("1. Create a New Task");
            Console.WriteLine("2. Delete a task");
            Console.WriteLine("3. Edit a task");
            Console.WriteLine("4. Complete a task");
            Console.WriteLine("5. List all outstanding tasks");
            Console.WriteLine("6. List all tasks");
            Console.WriteLine("7. Exit");
        }

        public static int GetValidInt(string strInt, int floor, int ceiling)
        {  //given initial user input string (strInt), get an in bounds integer
           //floor and ceiling are min max values, inclusive

            int num = floor - 1;
            bool isInt = int.TryParse(strInt, out num);
            
            while (!isInt || (num < floor || num > ceiling))
            {
                Console.WriteLine("Please enter a valid number");
                isInt = int.TryParse(Console.ReadLine(), out num);
            }
            return num;
        }

        public void CreateToDo()
        {
            ToDo new_Task = new ToDo();
            Console.WriteLine("\nEnter task name");
            new_Task.Name = Console.ReadLine();
            Console.WriteLine("\nEnter task description");
            new_Task.Description = Console.ReadLine();
           
            new_Task.Deadline = GetValidDeadline();
            this.ToDoList.Add(new_Task);
        }

        public void DeleteToDo()
        {   
            if (this.isEmpty()){ return; }
            Console.WriteLine("\nWhich task # should i delete?");
            ShowList();
            var strIndex = Console.ReadLine();
            int index = GetValidInt(strIndex, 1, this.ToDoList.Count);
            this.ToDoList.RemoveAt(index - 1);
        }

        public ToDo GetToDo(int index)
        {   
            return this.ToDoList[index];
        }

        
        public bool isEmpty()
        {
            if (this.ToDoList.Count == 0)
            {
                Console.WriteLine("\nTo Do List is Empty");
                return true;
            }
            return false;
        }
        public void ShowList(bool incompleteOnly=false) //when flag true print only outstanding tasks
        {  
  
            if (this.isEmpty()){ return;}

            int index = 0;
            foreach (var item in this.ToDoList)
            {
                index++;
                if (incompleteOnly && item.IsCompleted)
                {
                    continue;
                }
                
                Console.WriteLine(String.Format("{0,-20} {1,-40} {2, -30} {3,-20}",
                    $"{index}. {item.Name}", $"{ item.Description}",
                    $"Due: {item.Deadline}", $"Completed: {item.IsCompleted}"));

            }
        }

        public void CompleteToDo()
        {   

            if(this.isEmpty()){ return; }
            Console.WriteLine("\nWhich task # is complete");
            ShowList();
            int index = GetValidInt(Console.ReadLine(), 1, this.ToDoList.Count)-1;
            if (!this.ToDoList[index].IsCompleted)
            {
                this.ToDoList[index].IsCompleted = true;
                Console.WriteLine("\nTask is now complete");
            }
            else
            {
                Console.WriteLine("\nTask is already complete");
            }
        }

       
        public DateTime GetValidDeadline()
        {
            DateTime newDeadline;
            Console.WriteLine("\nEnter Deadline");

            while (!DateTime.TryParse(Console.ReadLine(), out newDeadline))
            {
                Console.WriteLine("\nPlease enter valid Date");

            }
            return newDeadline;
        }
        

    public void EditToDo()
        {
            if (this.isEmpty()) { return; }
            Console.WriteLine("Which task # should I edit");
            ShowList();
            string strInd = Console.ReadLine();
            int index = GetValidInt(strInd, 1, this.ToDoList.Count) - 1;
            ToDo taskToEdit = GetToDo(index);
           
            int selection = -1;

            while (selection != 0)
            {
                Console.WriteLine("Which field do you want to edit:");
                Console.WriteLine("1. Name 2. Description 3. Deadline");
                Console.WriteLine("Press 0 to stop editing");
                string selectionStr = Console.ReadLine();
                selection = GetValidInt(selectionStr, 0, 3);

                if (selection == 1)
                {
                    Console.WriteLine("Enter new Name");
                    taskToEdit.Name = Console.ReadLine();
                }
                if (selection == 2)
                {
                    Console.WriteLine("Enter new Description");
                    taskToEdit.Description = Console.ReadLine();
                }
                if (selection == 3)
                {
                    taskToEdit.Deadline = GetValidDeadline();
                }

            }

        }

    }
}

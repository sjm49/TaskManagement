using System;

namespace TaskManagement.models
{
	public class ToDo
	{/*
	  * an individual task or "ToDo" item
	  */
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }


    }
}


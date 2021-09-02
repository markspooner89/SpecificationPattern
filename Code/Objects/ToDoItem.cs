
using System;

namespace Code.Objects
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DueDate { get; set; }

        public ToDoItem(int id, string description, bool isComplete, DateTime dueDate)
        {
            Id = id;
            Description = description;
            IsComplete = isComplete;
            DueDate = dueDate;
        }
    }
}

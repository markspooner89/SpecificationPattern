using Code.Objects;
using System.Collections.Generic;

namespace Code.Data
{
    public interface IToDoItemRepository
    {
        public List<ToDoItem> GetToDoItems();
    }
}

using Code.Data;
using Code.Filters;
using Code.Objects;
using Code.Specifications;
using System.Collections.Generic;

namespace Code.Services
{
    public class ToDoItemService
    {
        private readonly IToDoItemRepository _repository;

        public ToDoItemService(IToDoItemRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ToDoItem> GetToDoItems(IEnumerable<ISpecification<ToDoItem>> specs)
        {
            var items = _repository.GetToDoItems();

            var toDoItemFilter = new ToDoItemFilter();
            var result = toDoItemFilter.Filter(items, specs);

            return result;
        }
    }
}

using Code.Objects;
using Code.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace Code.Filters
{
    public class ToDoItemFilter : IFilter<ToDoItem>
    {
        public IEnumerable<ToDoItem> Filter(IEnumerable<ToDoItem> items, IEnumerable<ISpecification<ToDoItem>> specs)
        {
            foreach (var i in items)
                if (specs.All(s => s.IsSatisfied(i)))
                    yield return i;
        }
    }
}

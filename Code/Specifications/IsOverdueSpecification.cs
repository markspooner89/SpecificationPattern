using Code.Objects;
using System;

namespace Code.Specifications
{
    public class IsOverdueSpecification : ISpecification<ToDoItem>
    {
        private readonly DateTime _currentDateTime;

        public IsOverdueSpecification(DateTime currentDateTime)
        {
            _currentDateTime = currentDateTime;
        }

        public bool IsSatisfied(ToDoItem t)
        {
            return t.DueDate < _currentDateTime;
        }
    }
}

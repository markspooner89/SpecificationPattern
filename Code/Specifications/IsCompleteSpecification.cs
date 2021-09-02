using Code.Objects;

namespace Code.Specifications
{
    public class IsCompleteSpecification : ISpecification<ToDoItem>
    {
        private bool _isComplete;

        public IsCompleteSpecification(bool isComplete)
        {
            _isComplete = isComplete;
        }

        public bool IsSatisfied(ToDoItem t)
        {
            return t.IsComplete == _isComplete;
        }
    }
}

using Code.Specifications;
using System.Collections.Generic;

namespace Code.Filters
{
    public interface IFilter<T>
    {
        public IEnumerable<T> Filter(IEnumerable<T> items, IEnumerable<ISpecification<T>> specs);
    }
}

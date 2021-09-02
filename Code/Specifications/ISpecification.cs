
namespace Code.Specifications
{
    public interface ISpecification<T>
    {
        public bool IsSatisfied(T t);
    }
}

namespace IAmHungry.Application.Abstractions
{
    public interface IMealsFilter
    {
        public bool IsSoup();
        public bool IsVegetarian();

        public bool IsEmpty();
    }
}

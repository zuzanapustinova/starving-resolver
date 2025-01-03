using IAmHungry.Application.Abstractions;
using IAmHungry.Domain;

namespace IAmHungry.Application
{
    public class MealsFilter : IMealsFilter
    {
        private Meal _meal;
        public Meal Meal
        {
            get { return _meal; }
            set { _meal = value; }
        }
        public MealsFilter(Meal meal) 
        {
            _meal = meal;
        }

        private bool IsContainedInDescription(string substring)
        {
            return Meal.Description.ToLower().Contains(substring.ToLower());
        }

        public bool IsSoup()
        {
            return IsContainedInDescription(MealKind.Soup());
        }

        public bool IsVegetarian()
        {
            if (MealKind.Vege().Any(vege => IsContainedInDescription(vege)))
            {
                return true;
            }
            var meatList = MealKind.Meat().Concat(MealKind.Fish());
            return meatList.All(meat => !IsContainedInDescription(meat));
        }

        public bool IsEmpty()
        {
            return MealKind.NoDataAvailable().Any(line => IsContainedInDescription(line));
        }
    }
}

namespace IAmHungry.Domain
{

    public class Restaurant
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
        private Menu? _dailyMenu;
        public Menu DailyMenu {
            get 
            {
                { return _dailyMenu ?? (_dailyMenu = new Menu()); }
            }
            set 
            { 
                _dailyMenu = value; 
            }
        }

        public Restaurant(string url, string name, string address)
        {
            Url = url;
            Name = name;
            Address = address;
        }      
    }
}

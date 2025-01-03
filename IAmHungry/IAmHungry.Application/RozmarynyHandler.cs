using HtmlAgilityPack;
using IAmHungry.Application.Abstractions;
using IAmHungry.Domain;

namespace IAmHungry.Application
{
    public class RozmarynyHandler : IRestaurantMenu
    {
        public IWebPageParser webPageParser { get; }

        private string _rozmarynyUrl;
        private string _rozmarynyKontakt;
        private string _rozmarynyMenu;
        private HtmlAgilityPack.HtmlDocument MenuPageContent { get; set; }

        public RozmarynyHandler(IWebPageParser parser, string url) 
        {
            //pozor na to, že adresa restaurace je rozmaryny.cz, ale tady se to dělí ještě na /kontakt a /menu pro získání infa
            webPageParser = parser;
            _rozmarynyUrl = url;
            _rozmarynyKontakt = $"{url}/kontakt";
            _rozmarynyMenu = $"{url}/menu";
            MenuPageContent = webPageParser.LoadPage(_rozmarynyMenu);
        }

        public Menu GetMenu(DateTime date)
        {
            var dailyMenu = new Menu();
            var dailyMenuNode = new List<HtmlNodeCollection>();
            var today = DateTime.Today;
            var day = (date == today) ? ConvertTodayToCzechDate() : ConvertToCzechDate(date);
            
            foreach (var node in webPageParser.FindNodes(MenuPageContent, $".//div[@class='dailyMenuMainGroup']"))
            {
                dailyMenuNode.AddRange(from node2 in node.ChildNodes where node2.InnerText.Contains(day) select node.ChildNodes);
            }

            foreach (var node in dailyMenuNode)
            {
                dailyMenu.Items.AddRange(node.Select(line => new MenuItem(new Meal(line.InnerText))));
            }

            return dailyMenu;
        }

        private static string ConvertTodayToCzechDate()
        {
            return DateTime.Today.Day + "." + DateTime.Today.Month + ".";
        }

        private static string ConvertToCzechDate(DateTime date)
        {
            return date.Day + "." + date.Month + ".";
        }

        public Restaurant GetRestaurant()
        {
            var webPage = webPageParser.LoadPage(_rozmarynyKontakt);
            var info = webPageParser.GetSingleNodeInnerText(webPage, "//div[@class='contactItem']//div[@class='headerTxt']").Split(", ");
            var restaurant = new Restaurant(_rozmarynyUrl, info[0], info[1])
            {
                //zatím nastaveno jen pro aktuální dnešní datum
                DailyMenu = GetMenu(DateTime.Today)
            };
            if (restaurant.DailyMenu.Items.Count == 0)
            {
                restaurant.DailyMenu.Items.Add(new MenuItem(new Meal("Restaurace nedodala aktuální údaje.")));
            }
            return restaurant;
        }
    }
}

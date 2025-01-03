
namespace IAmHungry.Domain
{
    public static class MealKind
    {
        public static List<string> Meat()
        {
            return new List<string>
            {
                "anglick",
                "boloň",
                "bologn",
                "dančí",
                "dršťk",
                "frankfurtsk",
                "gulášová",
                "hovězí",
                "játr",
                "jehně",
                "jelení",
                "jelítk",
                "jitrnic",
                "kačen",
                "kachní",
                "kančí",
                "klobás",
                "klokaní",
                "krkovi",
                "krůtí",
                "kuře",
                "masem",
                "masov",
                "pancett",
                "panenk",
                "párk",
                "pečeně",
                "prosciutto",
                "řízek",
                "roštěn",
                "salám",
                "segedín",
                "sekaná",
                "škvark",
                "slanin",
                "špekáč",
                "šunk",
                "svíčková",
                "telecí",
                "utopenec",
                "uzené maso",
                "uzenin",
                "uzeným masem",
                "vepř",
                "vrabec",
                "zabíjačk",
                "žebra",
                "zvěřin"
            };
        }

        public static List<string> Fish()
        {
            return new List<string>
            {
                "candát",
                "fish",
                "losos",
                "mořsk",
                "pstruh",
                "ryb",
                "tresk",
                "tuňák",
                "vlk",
            };
        }

        public static List<string> Vege()
        {
            return new List<string>
            {
                "vege",
                "tempeh",
                "sójov",
                "gulášová z hlívy"
            };
        }

        public static string Soup()
        {
            return "polévk";
        }

        public static List<string> NoDataAvailable()
        {
            return new List<string>
            {
                "Restaurace nedodala aktuální údaje.",
                "mimo provoz",
                "nepodáváme",
                "zavřeno",
            };
        }
    }
}

using PieShop.InventoryMgmt.Domain.ProductMgmt;
using PieShop.InventoryMgmt.Domain.General;
using PieShop.InventoryMgmt;

Product.ChangeStockThreshold(10);
Product.StockThreshold = 10;

//Price samplePrice = new Price(10, Currency.Euro);
Price samplePrice = new Price() { ItemPrice = 10, Currency = Currency.Euro };

//three different ways to instantiate object in C#

//Product p1 = new Product(1, "Sugar", "lorem", samplePrice, UnitType.PerKg, 100);
Product p1 = new Product(1) { Name = "Sugar", Description = "Lorem ipsum", Price = samplePrice, UnitType = UnitType.PerKg }; // can do this way if you want to avoid using a specfic constructor.
var p2 = new Product(2, "Cake decorations", "lorem ipsum", samplePrice, UnitType.PerBox, 20);
Product p3 = new(3, "Strawberry", "lorem ipsum", samplePrice, UnitType.PerBox, 10);


PrintWelcome();

#region Layout
static void PrintWelcome()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
    ()()()()()()   ____       _   _                       _       _____ _         _____ _                                        
    |\         |  |  _ \     | | | |                     ( )     |  __ (_)       / ____| |                                         ()()()()()()
    |.\. . . . |  | |_) | ___| |_| |__   __ _ _ __  _   _|/ ___  | |__) |  ___  | (___ | |__   ___  _ __                           |\         |
    \'.\       |  |  _ < / _ \ __| '_ \ / _` | '_ \| | | | / __| |  ___/ |/ _ \  \___ \| '_ \ / _ \| '_ \                          |.\. . . . |
     \.:\ . . .|  | |_) |  __/ |_| | | | (_| | | | | |_| | \__ \ | |   | |  __/  ____) | | | | (_) | |_) |                         \'.\       |
      \'o\     |  |____/ \___|\__|_| |_|\__,_|_| |_|\__, | |___/ |_|__ |_|\___| |_____/|_| |_|\___/| .__/                    _      \.:\ . . .|
       \.'\. . |  |_   _|                    | |     __/ |         |  \/  |                        | |                      | |      \'o\     |
        \'.\   |    | |  _ ____   _____ _ __ | |_ __|___/__ _   _  | \  / | __ _ _ __   __ _  __ _ |_|_ _ __ ___   ___ _ __ | |_      \.'\. . |
         \'`\ .|    | | | '_ \ \ / / _ \ '_ \| __/ _ \| '__| | | | | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '_ ` _ \ / _ \ '_ \| __|      \'.\   |
          \.'\ |   _| |_| | | \ V /  __/ | | | || (_) | |  | |_| | | |  | | (_| | | | | (_| | (_| |  __/ | | | | |  __/ | | | |_        \'`\ .|
           \__\|  |_____|_| |_|\_/ \___|_| |_|\__\___/|_|   \__, | |_|  |_|\__,_|_| |_|\__,_|\__, |\___|_| |_| |_|\___|_| |_|\__|        \.'\ |
                                                             __/ |                            __/ |                                       \__\|
                                                            |___/                            |___/                               
    ");

    Console.ResetColor();

    Console.WriteLine("Press enter key to start logging in!");

    //accepting enter here
    Console.ReadLine();

    Console.Clear();
}
#endregion
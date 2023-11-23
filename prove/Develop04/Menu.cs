public class Menu
{
    private string _menuOptions;
    private string _optionOne;
    private string _optionTwo;
    private string _optionThree;
    private string _optionFour;
    
    public Menu(string menuOptions, string optionOne, string optionTwo, string optionThree, string optionFour)
    {
        _menuOptions = menuOptions;
        _optionOne = optionOne;
        _optionTwo = optionTwo;
        _optionThree = optionThree;
        _optionFour = optionFour;
    }

    public int GetDisplayMenu()
    {
        while (true)
        {
            string menuSelection;
            int menuNumber;
            Console.WriteLine(_menuOptions);
            Console.WriteLine($"  {_optionOne}");
            Console.WriteLine($"  {_optionTwo}");
            Console.WriteLine($"  {_optionThree}");
            Console.WriteLine($"  {_optionFour}");
            Console.Write("Select a choice from the menu: ");
            menuSelection = Console.ReadLine();
            bool isInt = menuSelection.All(char.IsDigit);
            if (isInt == true)
            {
                menuNumber = int.Parse(menuSelection);
                if (menuNumber > 0 && menuNumber < 5)
                {
                    return menuNumber;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
public class GoalManager
{
    private string _menuOptions;
    private string _optionOne;
    private string _optionTwo;
    private string _optionThree;
    private string _optionFour;
    private string _optionFive;
    private string _optionSix;
    private int _score;
    private List<Goal> _goals = new List<Goal>();

    private ChecklistGoal _checkListGoal = new ChecklistGoal("", "", "", 0, 0);

    private SimpleGoal _simpleGoal = new SimpleGoal("", "", "");
    private EternalGoal _eternalGoal = new EternalGoal("", "", "");

    private bool simpleGoalIsComplete;
    private bool eternalGoalIsComplete;
    private bool checklistisComplete;
    
    public GoalManager(int score, string menuOptions, string optionOne, string optionTwo, string optionThree,
        string optionFour, string optionFive, string optionSix)
    {
        _menuOptions = menuOptions;
        _optionOne = optionOne;
        _optionTwo = optionTwo;
        _optionThree = optionThree;
        _optionFour = optionFour;
        _optionFive = optionFive;
        _optionSix = optionSix;
        _score = 0;
    }

    // Gets the _goals
    public void SetGoals(List<Goal> goals)
    {
        _goals = goals;
    }

    // Gets the _score.
    public int GetScore()
    {
        return _score;
    }

    // Sets the _score
    public void SetScore(int score)
    {
        _score += score;
    }

    // Show the start menu. Return 0 if user entered value is invalid.
    public int Start(int score)
    {
        while (true)
        {
            string menuSelection;
            int menuNumber;
            Console.WriteLine();
            Console.WriteLine($"You have {score} points.");
            Console.WriteLine();
            Console.WriteLine(_menuOptions);
            Console.WriteLine($"  {_optionOne}");
            Console.WriteLine($"  {_optionTwo}");
            Console.WriteLine($"  {_optionThree}");
            Console.WriteLine($"  {_optionFour}");
            Console.WriteLine($"  {_optionFive}");
            Console.WriteLine($"  {_optionSix}");
            Console.Write("Select a choice from the menu: ");
            menuSelection = Console.ReadLine();
            bool isInt = menuSelection.All(char.IsDigit);
            if (isInt == true)
            {
                menuNumber = int.Parse(menuSelection);
                if (menuNumber > 0 && menuNumber < 7)
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

    // Asks the user for the information about a new goal. Then, creates the goal and adds it to the list.
    public List<Goal> CreateNewGoal(int menuLength)
    {
        bool exitLoop = false;
        string menuSelection;
        int menuNumber = 0;
        while (exitLoop != true)
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            menuSelection = Console.ReadLine();
            bool isInt = menuSelection.All(char.IsDigit);
            if (isInt == true)
            {
                menuNumber = int.Parse(menuSelection);
                if (menuNumber > 0 && menuNumber < (menuLength + 1))
                {
                    exitLoop = true;
                }
                else
                {
                    Console.Clear(); // Clear console if loop is rerun and menu displays again.
                    Console.WriteLine($"Please enter a value between 1 and {menuLength + 1}.");
                }
            }
        }
        // Simple Goal or Eternal goal. They require they same inputs. Just differ in the way they are written.
        if (menuNumber == 1 || menuNumber == 2)
        {
            Console.Write("What is the name of your goal? ");
            string shortName = Console.ReadLine();
            Console.Write("What is the short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            // For Simple Goal.
            if(menuNumber == 1)
            {
                _simpleGoal = new SimpleGoal(shortName, description, points);
                _goals.Add(_simpleGoal);
            }
            // For Eternal Goal.
            else if(menuNumber == 2)
            {
                _eternalGoal = new EternalGoal(shortName, description, points);
                _goals.Add(_eternalGoal);
            }
        }
        // For Checklist Goal.
        else if(menuNumber == 3)
        {
            Console.Write("What is the name of your goal? ");
            string shortName = Console.ReadLine();
            Console.Write("What is the short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            string target = Console.ReadLine();
            Console.Write("What is the bonus for accomplishing it that many times? ");
            string bonus = Console.ReadLine();
            _checkListGoal = new ChecklistGoal(shortName, description, points, int.Parse(target), int.Parse(bonus));
            _goals.Add(_checkListGoal);
        }
        return _goals;
    }

    // Displays the players current score.
    public void DisplayPlayerInfo(int addedScore)
    {
        _score = _score + addedScore;
    }

    // Lists the names of each of the goals.
    public void DisplayGoalNames()
    {
        Console.WriteLine("The goals are:");
        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. " + goal.GetName());
            i++;
        }
    }

    // List the goal details (including the checkbox of whether it is complete).
    public void ListGoalDetails(int score)
    {
        Console.WriteLine("The goals are:");
        int i = 1;
        foreach (Goal goal in _goals)
        {
            if (goal.GetType() == typeof(ChecklistGoal))
            {
                Console.WriteLine($"{i}. [ ] " + goal.GetName() + " " + "(" + goal.GetDescription() + ")" + $" -- Currently completed: " + _checkListGoal.GetAmountCompleted() + "/" + _checkListGoal.GetTarget());
            }
            else
            {
                Console.WriteLine($"{i}. [ ] " + goal.GetName() + " " + "(" + goal.GetDescription() + ")");
            }
            i++;
        }
    }

    public void RecordEvent(List<Goal> goals)
    {
        ListGoalDetails(_score);
        Console.Write("Which goal did you accomplish (enter a number)? ");
        string goalAccomplished = Console.ReadLine();
        int goalAccomplishedIndex = int.Parse(goalAccomplished) - 1;
        string points = _goals[goalAccomplishedIndex].GetPoints();
        int score = int.Parse(points);
        Console.WriteLine($"Congratulations! You have earned " + _goals[goalAccomplishedIndex].GetPoints() + " points!");
        _score = score + _score;
        Goal goalType = _goals[goalAccomplishedIndex];
        if (goalType.GetType() == typeof(SimpleGoal))
        {
            simpleGoalIsComplete = _simpleGoal.IsComplete();
            _simpleGoal.SetIsComplete(simpleGoalIsComplete);
        }
        else if (goalType.GetType() == typeof(EternalGoal))
        {
            eternalGoalIsComplete = _eternalGoal.IsComplete();
            _simpleGoal.SetIsComplete(simpleGoalIsComplete);
        }
        else if (goalType.GetType() == typeof(ChecklistGoal))
        {
            _checkListGoal.RecordEvent(goalType);
            checklistisComplete = _checkListGoal.IsComplete();
            if (checklistisComplete == true)
            {
                 _score += _checkListGoal.GetBonus();
                 Console.WriteLine($"Congratulations! You earned a " + _checkListGoal.GetBonus() + " point bonus for completing your goal!");
            }
        }

    }

    public void SaveGoals(List<Goal> goals)
    {
        Console.Write("What would you like to name your text file (exclude the file extension)? ");
        string filename = Console.ReadLine();
        Console.WriteLine($"Saving to {filename}.txt file...");

        using (StreamWriter outputFile = new StreamWriter($"{filename}.txt"))
        {
            outputFile.WriteLine(_score);
            // Add to text file with the WriteLine method
            foreach (Goal goal in goals)
            {
                if (goal.GetType() == typeof(SimpleGoal))
                {
                    outputFile.WriteLine("Simple Goal:", goal.GetName(), goal.GetDescription(), goal.GetPoints(), simpleGoalIsComplete);
                }
                else if (goal.GetType() == typeof(EternalGoal))
                {
                    outputFile.WriteLine("Eternal Goal:", goal.GetName(), goal.GetDescription(), goal.GetPoints(), eternalGoalIsComplete);
                }
                // else if (goal.GetType() == typeof(ChecklistGoal))
                // {
                //     outputFile.WriteLine("Checklist Goal:", goal.GetName(), goal.GetDescription(), goal.GetPoints(), goal.GetBonus(), goal.GetAmountCompleted(), _checkListGoal.GetTarget());
                //     Console.WriteLine();
                // }
            }
        }
    }
}
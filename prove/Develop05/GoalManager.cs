public class GoalManager
{
    private string _menuOptions;
    private string _optionOne;
    private string _optionTwo;
    private string _optionThree;
    private string _optionFour;
    private string _optionFive;
    private string _optionSix;

    private string _optionSeven;
    private int _score;
    private string _menuSelection;
    private List<Goal> _goals = new List<Goal>();
    private List<string> _stringRepresentation = new List<string>();

    private ChecklistGoal _checkListGoal = new ChecklistGoal("", "", "", 0, 0);

    private SimpleGoal _simpleGoal = new SimpleGoal("", "", "");
    private EternalGoal _eternalGoal = new EternalGoal("", "", "");
    private bool _recordingEvent = false;
    
    public GoalManager(string menuOptions, string optionOne, string optionTwo, string optionThree,
        string optionFour, string optionFive, string optionSix, string optionSeven)
    {
        _menuOptions = menuOptions;
        _optionOne = optionOne;
        _optionTwo = optionTwo;
        _optionThree = optionThree;
        _optionFour = optionFour;
        _optionFive = optionFive;
        _optionSix = optionSix;
        _optionSeven = optionSeven;
        _score = 0;
    }

    // Sets the _goals
    public void SetGoals(List<Goal> goals)
    {
        _goals = goals;
    }

    // Gets the _score.
    public int GetScore()
    {
        return _score;
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
            Console.WriteLine($"  {_optionSeven}");
            Console.Write("Select a choice from the menu: ");
            menuSelection = Console.ReadLine();
            bool isInt = menuSelection.All(char.IsDigit);
            if (isInt == true)
            {
                menuNumber = int.Parse(menuSelection);
                if (menuNumber > 0 && menuNumber < 8)
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
        int menuNumber = 0;
        while (exitLoop != true)
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            _menuSelection = Console.ReadLine();
            bool isInt = _menuSelection.All(char.IsDigit);
            if (isInt == true)
            {
                menuNumber = int.Parse(_menuSelection);
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
                _stringRepresentation.Add("Simple Goal" + "," + shortName + "," + description + "," + points + "," + _simpleGoal.IsComplete());
            }
            // For Eternal Goal.
            else if(menuNumber == 2)
            {
                _eternalGoal = new EternalGoal(shortName, description, points);
                _goals.Add(_eternalGoal);
                _stringRepresentation.Add("Eternal Goal" + "," + shortName + "," + description + "," + points + "," + _simpleGoal.IsComplete());
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
            // Will need the _stringRepresentation loaded prior to Recording an event to compute details related to the checklist event.
            _stringRepresentation.Add("Checklist Goal" + "," + shortName + "," + description + "," + points + "," + bonus + "," + _checkListGoal.GetAmountCompleted() + "," + target + "," + _checkListGoal.IsComplete());
        }
        return _goals;
    }

    // List the goal details (including the checkbox of whether it is complete).
    public List<Goal> ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        int i = 1;
        int goalIndex;
        foreach (Goal goal in _goals)
        {
            if (goal.GetType() == typeof(SimpleGoal))
            {
                if (goal.IsComplete() == true)
                {
                    Console.WriteLine($"{i}. [ X ] " + goal.GetName() + " " + "(" + goal.GetDescription() + ")");
                }
                else
                {
                    Console.WriteLine($"{i}. [ ] " + goal.GetName() + " " + "(" + goal.GetDescription() + ")");
                }
                
            }
            else if (goal.GetType() == typeof(EternalGoal))
            {
                if (goal.IsComplete() == true)
                {
                    Console.WriteLine($"{i}. [ X ] " + goal.GetName() + " " + "(" + goal.GetDescription() + ")");
                }
                else
                {
                    Console.WriteLine($"{i}. [ ] " + goal.GetName() + " " + "(" + goal.GetDescription() + ")");
                }
            }
            else if (goal.GetType() == typeof(ChecklistGoal))
            {
                goalIndex = i - 1;
                ChecklistGoal tempChecklistGoal = new ChecklistGoal(goal.GetName(), goal.GetDescription(), goal.GetPoints(), 0, 0);
                string stringRepresentation = _stringRepresentation[goalIndex];
                // For comma seprated values.
                string[] parts = stringRepresentation.Split(",");
                int amountCompleted = int.Parse(parts[5]);
                tempChecklistGoal.SetAmountCompleted(amountCompleted);
                int target = int.Parse(parts[6]);
                tempChecklistGoal.SetTarget(target);
                if (goal.IsComplete() == true)
                {
                    if (_recordingEvent == true)
                    {
                         _goals[goalIndex] = tempChecklistGoal;
                        Console.WriteLine($"{i}. [ X ] " + goal.GetName() + " " + "(" + goal.GetDescription() + ")" + $" -- Currently completed: " + (tempChecklistGoal.GetAmountCompleted() + 1) + "/" + tempChecklistGoal.GetTarget());
                        _goals[goalIndex].RecordEvent();
                        _recordingEvent = false;
                    }
                    else
                    {
                        Console.WriteLine($"{i}. [ X ] " + goal.GetName() + " " + "(" + goal.GetDescription() + ")" + $" -- Currently completed: " + tempChecklistGoal.GetAmountCompleted() + "/" + tempChecklistGoal.GetTarget());
                    }
                }
                else
                {
                    if (_recordingEvent == true)
                    {
                        _goals[goalIndex] = tempChecklistGoal;
                        Console.WriteLine($"{i}. [ ] " + goal.GetName() + " " + "(" + goal.GetDescription() + ")" + $" -- Currently completed: " + (tempChecklistGoal.GetAmountCompleted() + 1) + "/" + tempChecklistGoal.GetTarget());
                        _recordingEvent = false;
                    }
                    else
                    {
                        Console.WriteLine($"{i}. [ ] " + goal.GetName() + " " + "(" + goal.GetDescription() + ")" + $" -- Currently completed: " + tempChecklistGoal.GetAmountCompleted() + "/" + tempChecklistGoal.GetTarget());
                    } 
                }
            }
            i++;
        }
        return _goals;
    }

    // Records an event if a goal is completed. Will mark as complete if a simple goal or eternal goal. For a checklist goal it
    // won't be complete until the target is reached.
    public List<Goal> RecordEvent()
    {
        ListGoalDetails();
        _recordingEvent = true;
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
            SimpleGoal tempSimpleGoal = new SimpleGoal(goalType.GetName(), goalType.GetDescription(), goalType.GetPoints());
            tempSimpleGoal.SetIsComplete(true);
            _goals[goalAccomplishedIndex] = tempSimpleGoal;
        }
        else if (goalType.GetType() == typeof(EternalGoal))
        {
            EternalGoal tempEternalGoal = new EternalGoal(goalType.GetName(), goalType.GetDescription(), goalType.GetPoints());
            tempEternalGoal.SetIsComplete(true);
            _goals[goalAccomplishedIndex] = tempEternalGoal;
        }
        else if (goalType.GetType() == typeof(ChecklistGoal))
        {
            ChecklistGoal tempChecklistGoal = new ChecklistGoal(goalType.GetName(), goalType.GetDescription(), goalType.GetPoints(), 0, 0);
            string stringRepresentation = _stringRepresentation[goalAccomplishedIndex];
            // For comma seprated values.
            string[] parts = stringRepresentation.Split(",");
            int bonus = int.Parse(parts[4]);
            tempChecklistGoal.SetBonus(bonus);
            tempChecklistGoal.SetAmountCompleted(int.Parse(parts[5]) + 1);
            int target = int.Parse(parts[6]);
            tempChecklistGoal.SetTarget(target);
            tempChecklistGoal.IsComplete();
            _goals[goalAccomplishedIndex] = tempChecklistGoal;
            // _checkListGoal = tempChecklistGoal;
        }
        return _goals;
    }

    // Saves created goals to a .txt file of the user's choice. This file can later be reloaded.
    public void SaveGoals(List<Goal> goals)
    {
        Console.Write("What would you like to name your text file (exclude the file extension)? ");
        string filename = Console.ReadLine();
        Console.WriteLine($"Saving to {filename}.txt file...");

        using (StreamWriter outputFile = new StreamWriter($"{filename}.txt"))
        {
            outputFile.WriteLine(_score);
            // Add to text file with the WriteLine method
            foreach (string stringRepresentation in _stringRepresentation)
            {
                outputFile.WriteLine(stringRepresentation);
            }
            Console.WriteLine($"Your {filename}.txt file has been saved!");
        }
    }

    // Loads goals for further manipulation by the user in the program.
    public List<Goal> LoadGoals()
    {
       _goals.Clear();
        Console.Write("What text file would you like to load (exclude the file extension)? ");
        string filename = Console.ReadLine();
        // Ensure a file exists before loading it.
        if (File.Exists($"{filename}.txt"))
        {
            Console.WriteLine($"Loading {filename}.txt...");

            // Read all lines from the text file.
            string[] lines = File.ReadAllLines($"{filename}.txt");

            // parts[0] = Goal Type
            // parts[1] = Short Name
            // parts[2] = Description
            // parts[3] = Points
            // parts[4] = Is Completed
            // If Checklist Type
            // parts[4] = Bonus
            // parts[5] = Amount Completed
            // parts[6] = Target
            // parts[7] = Is Completed
            int i = 0;
            foreach(string line in lines)
            {
                if (i == 0)
                {
                    _score = int.Parse(line);
                    i++;
                }
                // For comma seprated values.
                string[] parts = line.Split(",");
                if (line.Contains("Simple Goal") && lines.Length > 1)
                {
                     _simpleGoal = new SimpleGoal(parts[1], parts[2], parts[3]);
                     _simpleGoal.SetIsComplete(bool.Parse(parts[4]));
                     _goals.Add(_simpleGoal);
                     _stringRepresentation.Add("Simple Goal" + "," + parts[1] + "," + parts[2] + "," + parts[3] + "," + parts[4]);
                }
                else if (line.Contains("Eternal Goal") && lines.Length > 1)
                {
                    _eternalGoal = new EternalGoal(parts[1], parts[2], parts[3]);
                    _eternalGoal.SetIsComplete(bool.Parse(parts[4]));
                    _goals.Add(_eternalGoal);
                    _stringRepresentation.Add("Eternal Goal" + "," + parts[1] + "," + parts[2] + "," + parts[3] + "," + parts[4]);
                }
                else if (line.Contains("Checklist Goal") && lines.Length > 1)
                {
                    _checkListGoal = new ChecklistGoal(parts[1], parts[2], parts[3], int.Parse(parts[6]), int.Parse(parts[4]));
                    _checkListGoal.SetAmountCompleted(int.Parse(parts[5]));
                    _checkListGoal.SetTarget(int.Parse(parts[6]));
                    _checkListGoal.SetIsComplete(bool.Parse(parts[7]));
                    _goals.Add(_checkListGoal);
                    _stringRepresentation.Add("Checklist Goal" + "," + parts[1] + "," + parts[2] + "," + parts[3] + "," + parts[4] + "," + parts[5] + "," + parts[6] + "," + parts[7]);
                }  
            }  
        }
        return _goals;
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
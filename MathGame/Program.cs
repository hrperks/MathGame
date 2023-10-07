// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text.RegularExpressions;

string[] validInput = { "A", "S", "M", "D", "Q", "V" };
int score = 0;
string input = "";
string name = "";
string gameType = string.Empty;
List<String> scores = new List<String>();
DateTime date = DateTime.Now;
Console.WriteLine("What is your name: ");
name = Console.ReadLine();

Boolean playable = true;
while (playable)
{
    Console.Clear();
    while (!validInput.Contains(input.ToUpper())) {
        Console.WriteLine($"Welcome to the Math Game {name}");
        Console.WriteLine("Pres A for Addition");
        Console.WriteLine("Press S for Subtraction");
        Console.WriteLine("Press M for Multiplication");
        Console.WriteLine("Press D for Division");
        Console.WriteLine("Press V to view scores!");
        Console.WriteLine("Press Q to Quit");
        input = Console.ReadLine();
        Console.Clear();
    }

    switch (input.ToUpper())
    {
        case "A":
            gameType = "Addition";
            break;
        case "S":
            gameType = "Subtraction";
            break;
        case "M":
            gameType = "Multiplication";
            break;
        case "D":
            gameType = "Division";
            break;
        case "V":
            foreach (string past_scores in scores)
            {
                Console.WriteLine(past_scores);
            }
            Console.WriteLine("press any button to continue: ");
            Console.ReadKey();
            break;
        case "Q":
            playable = false;
            break;
    }
    if (gameType != string.Empty)
    {
        score = Game(gameType);
        scores.Add($"{name} Scored {score} points in the {gameType} Game!");
    }
    gameType = string.Empty;
    input = string.Empty;
}




Console.WriteLine($"{name} got {score}");

int Game(string Type)
{
   
    int score = 0;
    Boolean isValid = false;
    int result = 0;
   for (int i = 0; i < 10; i++)
    {
        Console.Clear();
        calculateRound(Type, out result);
        isValid = false;
        while (!isValid)
        {
            var answer = Console.ReadLine();
            score += SubmitAnswer(result, answer, out isValid);
        }
    }
    return score;
}

void calculateRound(string Type, out int result)
{
    Random random = new Random();
    int numberOne = 0;
    int numberTwo = 0;
    result = 0;

    switch (Type)
    {
        case "Subtraction":
            numberOne = random.Next(10);
            numberTwo = random.Next(10);
            if (numberOne >= numberTwo)
            {
                result = numberOne - numberTwo;
                Console.WriteLine($"{numberOne} - {numberTwo} = ?");
            }
            else
            {
                result = numberTwo - numberOne;
                Console.WriteLine($"{numberTwo} - {numberOne} = ?");
            }
            break;
        case "Multiplication":
            numberOne = random.Next(10);
            numberTwo = random.Next(10);
            result = numberOne * numberTwo;
            Console.WriteLine($"{numberOne} x {numberTwo} :");
            break;
        case "Division":
            do
            {
                numberOne = random.Next(100);
                numberTwo = random.Next(1, 100);
                result = numberOne / numberTwo;
            } while (numberOne % numberTwo != 0);
            Console.WriteLine($"{numberOne} / {numberTwo} = ?");
            break;
        case "Addition":
            numberOne = random.Next(10);
            numberTwo = random.Next(10);
            result = numberOne + numberTwo;
            Console.WriteLine($"{numberOne} + {numberTwo} :");
            break;
    }
}

int SubmitAnswer(int result, string answer, out Boolean isValid)
{
    int int_answer;
    int score = 0;
    isValid = false;
    if (int.TryParse(answer, out int_answer))
    {
        isValid = true;
        if (result == int_answer)
        {
            score++;
        }
    }
    else
    {
        Console.WriteLine("Your answer Must be an integer");
    }
    return score;
}
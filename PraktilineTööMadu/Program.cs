using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Xml.Linq;

namespace PraktilineTööMadu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set window size and player name
            int x = 80;
            int y = 30;
            string writeName = "Write your name: ";

            Console.SetCursorPosition(x / 2 - writeName.Length / 2, y / 2);
            Console.Write(writeName);
            Console.SetCursorPosition(x / 2, y / 2 + 1);
            string playerName = Console.ReadLine();
            Console.Clear();

            // Game over setup
            int foodCounter = 0;
            string gameOver = "GAME OVER";
            Console.SetWindowSize(x, y);

            // Walls
            Walls walls = new Walls(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            walls.Draw();

            // Snake
            Point p = new Point(4, 5, '@');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            Console.ForegroundColor = ConsoleColor.Green;
            snake.Draw();

            // Food creators for good and bad food
            FoodCreator goodFoodCreator = new FoodCreator(x, y, '$'); // Good food
            FoodCreator badFoodCreator = new FoodCreator(x, y, 'X');  // Bad food

            Point goodFood = goodFoodCreator.CreateFood();
            Point badFood = badFoodCreator.CreateFood();

            Console.ForegroundColor = ConsoleColor.Yellow;
            goodFood.Draw(goodFood.x, goodFood.y, goodFood.sym); // Drawing good food
            Console.ForegroundColor = ConsoleColor.Red;
            badFood.Draw(badFood.x, badFood.y, badFood.sym); // Drawing bad food

            bool gameOverFlag = false;

            // Timer
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (!gameOverFlag)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    gameOverFlag = true;
                    Console.Clear();
                    int xNEW = Console.WindowWidth;
                    int yNEW = Console.WindowHeight;
                    Console.SetCursorPosition((xNEW - gameOver.Length) / 2, yNEW / 2);
                    Console.WriteLine(gameOver);
                }
                else
                {
                    // Checking if snake eats good food
                    if (snake.Eat(goodFood) || snake.Eat(badFood))
                    {
                        // Clear both food positions
                        Console.SetCursorPosition(goodFood.x, goodFood.y);
                        Console.Write(' ');
                        Console.SetCursorPosition(badFood.x, badFood.y);
                        Console.Write(' ');

                        // Generate new positions for both foods
                        goodFood = goodFoodCreator.CreateFood();
                        badFood = badFoodCreator.CreateFood();

                        // Adjust score based on which food was eaten
                        if (snake.Eat(goodFood))
                        {
                            foodCounter += 1;
                        }
                        else if (snake.Eat(badFood))
                        {
                            foodCounter -= 1;
                        }

                        // Draw new food positions
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goodFood.Draw(goodFood.x, goodFood.y, goodFood.sym);
                        Console.ForegroundColor = ConsoleColor.Red;
                        badFood.Draw(badFood.x, badFood.y, badFood.sym);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        snake.Move();
                    }
                }

                // Showing elapsed time
                TimeSpan elapsedTime = stopwatch.Elapsed;
                Console.SetCursorPosition(Console.WindowWidth - 15, 0);

                // Update food counter and timer
                Console.SetCursorPosition(0, 0);
                Console.Write($"Food eaten: {foodCounter} Time: {elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}");

                Thread.Sleep(75);

                // Handle keyboard input
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            // Stop timer and display game over
            stopwatch.Stop();

            // Save the score
            Leaderboard.SaveScore(playerName, foodCounter, stopwatch.Elapsed);

            // Wait for key press before closing
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace PraktilineTööMadu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Настраиваем размеры окна консоли
            Console.SetupWindow(80, 30);

            // Отображаем стартовое сообщение
            Console.ShowStartMessage();

            // Ожидание нажатия клавиши пробела для продолжения
            Console.WaitForKeyPress(ConsoleKey.Spacebar);

            // Получение имени игрока
            string playerName = Console.GetPlayerName();

            // Отображаем правила игры
            Console.ShowGameRules();

            // Ожидание нажатия пробела для старта игры
            Console.WaitForKeyPress(ConsoleKey.Spacebar);

            // Запуск игры с полученным именем игрока

            // Счетчик съеденной еды
            int foodCounter = 0;
            // Флаг для проверки состояния игры (закончена или нет)
            bool gameOver = false;

            // Создание объекта стен для игры
            Walls walls = new Walls(System.Console.WindowWidth, System.Console.WindowHeight);
            // Инициализация змейки
            Snake snake = Snake.InitializeSnake();

            // Создание объектов для хорошей и плохой еды
            FoodCreator goodFoodCreator = new FoodCreator(System.Console.WindowWidth, System.Console.WindowHeight, '$');
            FoodCreator badFoodCreator = new FoodCreator(System.Console.WindowWidth, System.Console.WindowHeight, 'X');
            
            // Создание первой позиции хорошей и плохой еды
            Point goodFood = goodFoodCreator.CreateFood();
            Point badFood = badFoodCreator.CreateFood();
            
            // Отрисовка стен, змейки и еды на экране
            Food.DrawInitialGameObjects(walls, snake, goodFood, badFood);
            
            // Инициализация таймера для отслеживания времени игры
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            // Основной игровой цикл
            while (true)
            {
                // Проверяем, не завершилась ли игра (столкновение со стеной или хвостом змеи)
                gameOver = Console.CheckGameOver(snake, walls);


                if (!gameOver)
                {
                    // Обрабатываем поедание еды змейкой
                    foodCounter = Food.HandleFoodConsumption(snake, goodFoodCreator, badFoodCreator, ref goodFood, ref badFood, foodCounter);
                    // Движение змейки
                    snake.Move();

                    // Отображаем текущие результаты игры (счет и время)
                    Console.DisplayGameStats(foodCounter, stopwatch.Elapsed);

                    // Приостанавливаем выполнение на 75 миллисекунд для анимации змейки
                    // нужен для того чтобы змейка не обновлялась каждую секунду
                    Thread.Sleep(75);

                    // Обрабатываем нажатие клавиш для управления змейкой
                    Console.HandleKeyPress(snake);
                }
                else 
                { 
                    break;
                }
            }
            // Завершаем игру: сохраняем результат, отображаем сообщение
            Console.EndGame(playerName, foodCounter, stopwatch);
        }
    }
}
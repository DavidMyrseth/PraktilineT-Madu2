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
            SystemOptions.SetupWindow(80, 30);

            // Отображаем стартовое сообщение
            SystemOptions.ShowStartMessage();

            // Ожидание нажатия клавиши пробела для продолжения
            SystemOptions.WaitForKeyPress(ConsoleKey.Spacebar);

            // Получение имени игрока
            string playerName = SystemOptions.GetPlayerName();

            // Отображаем правила игры
            SystemOptions.ShowGameRules();

            // Ожидание нажатия пробела для старта игры
            SystemOptions.WaitForKeyPress(ConsoleKey.Spacebar);

            // Запуск игры с полученным именем игрока

            // Счетчик съеденной еды
            int foodCounter = 0;
            // Флаг для проверки состояния игры (закончена или нет)
            bool gameOver = false;
            
            // Создание объекта стен для игры
            Walls walls = new Walls(Console.WindowWidth, Console.WindowHeight);
            // Инициализация змейки
            Snake snake = SystemOptions.InitializeSnake();
            
            // Создание объектов для хорошей и плохой еды
            FoodCreator goodFoodCreator = new FoodCreator(Console.WindowWidth, Console.WindowHeight, '$');
            FoodCreator badFoodCreator = new FoodCreator(Console.WindowWidth, Console.WindowHeight, 'X');
            
            // Создание первой позиции хорошей и плохой еды
            Point goodFood = goodFoodCreator.CreateFood();
            Point badFood = badFoodCreator.CreateFood();
            
            // Отрисовка стен, змейки и еды на экране
            SystemOptions.DrawInitialGameObjects(walls, snake, goodFood, badFood);
            
            // Инициализация таймера для отслеживания времени игры
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            // Основной игровой цикл
            while (true)
            {
                // Проверяем, не завершилась ли игра (столкновение со стеной или хвостом змеи)
                gameOver = SystemOptions.CheckGameOver(snake, walls);


                if (!gameOver)
                {
                    // Обрабатываем поедание еды змейкой
                    foodCounter = SystemOptions.HandleFoodConsumption(snake, goodFoodCreator, badFoodCreator, ref goodFood, ref badFood, foodCounter);
                    // Движение змейки
                    snake.Move();

                    // Отображаем текущие результаты игры (счет и время)
                    SystemOptions.DisplayGameStats(foodCounter, stopwatch.Elapsed);

                    // Приостанавливаем выполнение на 75 миллисекунд для анимации змейки
                    // нужен для того чтобы змейка не обновлялась каждую секунду
                    Thread.Sleep(75);

                    // Обрабатываем нажатие клавиш для управления змейкой
                    SystemOptions.HandleKeyPress(snake);
                }
                else 
                { 
                    break;
                }
            }
            // Завершаем игру: сохраняем результат, отображаем сообщение
            SystemOptions.EndGame(playerName, foodCounter, stopwatch);
        }
    }
}
using System.Diagnostics;

namespace PraktilineTööMadu
{
    class Console
    {
        public static void SetupWindow(int width, int height)
        {
            // Устанавливаем размеры окна консоли
            System.Console.SetWindowSize(width, height);
            // Очищаем экран
            System.Console.Clear();
        }

        public static void ShowStartMessage()
        {
            // Стартовое сообщение
            string message = "You play as Hungry At sign -> @";
            // Сообщение для продолжения
            string prompt = "Press SPACE to continue...";
            // Отображаем сообщение в центре экрана
            DisplayCenteredMessage(message, -2);
            // Отображаем инструкцию о продолжении игры
            DisplayCenteredMessage(prompt, 2);
        }

        public static void DisplayCenteredMessage(string message, int yOffset)
        {
            // Вычисляем координаты для центрирования сообщения
            int x = System.Console.WindowWidth / 2 - message.Length / 2;
            int y = System.Console.WindowHeight / 2 + yOffset;
            // Устанавливаем позицию курсора
            System.Console.SetCursorPosition(x, y);
            // Печатаем сообщение
            System.Console.WriteLine(message);
        }

        public static string GetPlayerName()
        {
            // Очищаем экран
            System.Console.Clear();
            // Сообщение о вводе имени
            string prompt = "Write your name: ";
            // Отображаем сообщение по центру
            int x = System.Console.WindowWidth / 2 - prompt.Length / 2;
            int y = System.Console.WindowHeight / 2 - 2;
            System.Console.SetCursorPosition(x, y);
            // Печатаем сообщение "Write your name:" и оставляем курсор для ввода рядом
            System.Console.Write(prompt);

            // Ввод имени игрока на той же строке
            string playerName = System.Console.ReadLine();
            return playerName;
        }
            public static void WaitForKeyPress(ConsoleKey key)
        {
            // Ожидаем, пока пользователь не нажмет нужную клавишу
            while (System.Console.ReadKey(true).Key != key) { }
        }

        public static void ShowGameRules()
        {
            // Очищаем экран перед показом правил
            System.Console.Clear();
            // Правила игры
            string rules = "You play as @. Eat $ to gain 1 point. Eat X to lose 1 point.";
            // Сообщение о начале игры
            string prompt = "Press SPACE to start the game...";
            // Отображаем правила в центре экрана
            DisplayCenteredMessage(rules, 0);
            // Отображаем инструкцию о продолжении
            DisplayCenteredMessage(prompt, 2);
        }

        public static bool CheckGameOver(Snake snake, Walls walls)
        {
            // Проверяем столкновение змейки со стеной или с собственным хвостом
            if (walls.IsHit(snake) || snake.IsHitTail())
            {
                // Очищаем экран и выводим сообщение о конце игры
                System.Console.Clear();
                string gameOverMessage = "GAME OVER";
                DisplayCenteredMessage(gameOverMessage, 0);
                return true; // Игра окончена
            }
            return false; // Игра продолжается
        }

        public static void DisplayGameStats(int foodCounter, TimeSpan elapsedTime)
        {
            // Отображаем счетчик еды и прошедшее время в левом верхнем углу экрана
            System.Console.SetCursorPosition(0, 0);
            System.Console.Write($"Food eaten: {foodCounter} Time: {elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}");
        }

        public static void HandleKeyPress(Snake snake)
        {
            // Проверяем, была ли нажата клавиша
            if (System.Console.KeyAvailable)
            {
                // Считываем нажатую клавишу и передаем ее змейке для обработки
                ConsoleKey key = System.Console.ReadKey(true).Key;
                snake.HandleKey(key);
            }
        }

        public static void EndGame(string playerName, int foodCounter, Stopwatch stopwatch)
        {
            // Останавливаем таймер
            stopwatch.Stop();
            // Сохраняем результат игрока в таблицу лидеров
            Leaderboard.SaveScore(playerName, foodCounter, stopwatch.Elapsed);
            // Сообщение об окончании игры и ожидание нажатия клавиши для выхода
            System.Console.SetCursorPosition(0, System.Console.WindowHeight - 1);
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }
    }
}
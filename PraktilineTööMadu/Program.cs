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
            SystemOptions.StartGame(playerName);
        }
    }
}
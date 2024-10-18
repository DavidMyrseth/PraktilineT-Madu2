namespace PraktilineTööMadu
{
    class Food
    {
        public static void DrawFood(Point goodFood, Point badFood)
        {
            // Рисуем хорошую еду
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            goodFood.Draw(goodFood.x, goodFood.y, goodFood.sym);

            // Рисуем плохую еду
            System.Console.ForegroundColor = ConsoleColor.Red;
            badFood.Draw(badFood.x, badFood.y, badFood.sym);
        }
        public static int HandleFoodConsumption(Snake snake, FoodCreator goodFoodCreator, FoodCreator badFoodCreator, ref Point goodFood, ref Point badFood, int foodCounter)
        {
            // Проверяем, съела ли змея хорошую еду
            if (snake.Eat(goodFood))
            {
                foodCounter += 1; // Увеличиваем счет за хорошую еду
                ClearFoodPosition(goodFood);
                goodFood = goodFoodCreator.CreateFood(); // Создаем новую позицию для хорошей еды
                System.Console.ForegroundColor = ConsoleColor.Yellow;
                DrawFood(goodFood, badFood); // Отрисовываем новую хорошую еду
            }
            // Проверяем, съела ли змея плохую еду
            else if (snake.Eat(badFood))
            {
                foodCounter -= 1; // Уменьшаем счет за плохую еду
                ClearFoodPosition(badFood);
                badFood = badFoodCreator.CreateFood(); // Создаем новую позицию для плохой еды
                System.Console.ForegroundColor = ConsoleColor.Red;
                DrawFood(goodFood, badFood); // Отрисовываем новую плохую еду
            }

            return foodCounter; // Возвращаем обновленный счетчик еды
        }
        public static void ClearFoodPosition(Point food)
        {
            // Очищаем позицию еды, заменяя символ на пробел
            System.Console.SetCursorPosition(food.x, food.y);
            System.Console.Write(' ');
        }
        public static void DrawInitialGameObjects(Walls walls, Snake snake, Point goodFood, Point badFood)
        {
            // Рисуем стены
            System.Console.ForegroundColor = ConsoleColor.Red;
            walls.Draw();

            // Рисуем хорошую еду
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            goodFood.Draw(goodFood.x, goodFood.y, goodFood.sym);

            // Рисуем плохую еду
            System.Console.ForegroundColor = ConsoleColor.Red;
            badFood.Draw(badFood.x, badFood.y, badFood.sym);
        }
    }
}
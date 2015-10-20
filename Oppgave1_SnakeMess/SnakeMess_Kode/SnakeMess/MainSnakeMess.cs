namespace SnakeMess
{
    static class MainSnakeMess
	{
        private static GameManager g = new GameManager();

        // Main method for game
        public static void Main(string[] arguments)
        {
            g.CreateGame();
            g.SnakeDirection = GameManager.Direction.Down;
            g.PlayGame();
        }
	}
}
 
 
namespace SnakeMess
{
    class GameState
    {
        // Create variables for states
        public bool Pause { get; set; }

        // Construct GameState and instantiate initial states
        public GameState ()
        {
            Pause = false;
        }
    }
}

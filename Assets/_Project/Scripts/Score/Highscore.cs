namespace Game
{
    public class Highscore
    {
        private readonly Score _score;

        public Highscore(Score score)
        {
            _score = score;
        }

        public int Value { get; set; }

        public void Update()
        {
            if (_score.Value > Value)
            {
                Value = _score.Value;
            }
        }
    }
}
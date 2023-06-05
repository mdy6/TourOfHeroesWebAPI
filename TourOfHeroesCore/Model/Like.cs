namespace TourOfHeroesCore.Model
{
    public struct Like
    {
        public int Value { get; set; }

        public Like(int value)
        {
            Value = value;
        }

        public void PlusOne()
        {
            Value++;
        }
        public void MinusOne()
        {
            Value--;
        }
    }
    public struct DontLike
    {
        public int Value { get; set; }

        public DontLike(int value)
        {
            Value = value;
        }

        public void PlusOne()
        {
            Value++;
        }
        public void MinusOne()
        {
            Value--;
        }
    }



    public struct Popularity
    {
        public int Value { get; set; }
    }

}

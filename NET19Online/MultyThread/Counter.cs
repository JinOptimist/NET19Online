namespace MultyThread
{
    public class Counter
    {
        public int counter = 1;
        // public static object obj = new object();

        public void CountInif(string name)
        {
            while (true) // Ivan sleep
            {
                counter++;
                Console.WriteLine($"{name}: {counter}");
            }
        }
    }
}

// Ivan count to 2
// Ivan print 2

// Lera count to 3
// Lera print 3

// Ivan count to 4

// Lera count to 5
// Lera print 5
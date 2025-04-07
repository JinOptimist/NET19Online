using MultyThread;

//var thread = new Thread(() =>
//{
//    Console.Write('1');
//});
//thread.Start();

//var taskIvan = new Task(() =>
//{
//    while (true)
//    {
//        Console.WriteLine("I'm Ivan");
//    }
//});

//var taskLera = new Task(() =>
//{
//    while (true)
//    {
//        Console.WriteLine(" ******* I'm Lera");
//    }
//});

//taskLera.Start();
//taskIvan.Start();


//var counter = new Counter();
//var counterIvan = new Counter();

//var task1 = new Task(() => { counterIvan.CountInif("Ivan"); });
//task1.Start();

//var task2 = new Task(() => { counter.CountInif("Lera"); });
//task2.Start();

var joker = new Joker();
var joke = await joker.GetJokeAsync();



Console.ReadKey();

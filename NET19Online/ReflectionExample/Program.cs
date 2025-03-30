using ReflectionExample;
using System.Reflection;

var reflectionHelper = new ReflectionHelper();

//var manga = new Manga();
//reflectionHelper.WriteBaseInfo(manga);
//reflectionHelper.WriteBaseInfo(reflectionHelper);
// var ranobe = new Ranobe();
// reflectionHelper.WriteBaseInfo(ranobe);
//reflectionHelper.WriteBaseInfo<Ranobe>();

//reflectionHelper.WriteSecrurityInfo<Ranobe>();
//reflectionHelper.WriteSecrurityInfo<Manga>();

var manga = new Manga("Overlord", yearOfRelease: 2001);

var type = manga.GetType();
var fieldMagicNumber = type.GetField("magicNumber", BindingFlags.Instance | BindingFlags.NonPublic);
fieldMagicNumber.SetValue(manga, 100);

Console.WriteLine(manga.HowOldAreYou()); // 25
using AnExampleApp.Interfaces;
using AnExampleApp.Services;


IDidYouMean didYouMean = new DidYouMean();

/*
 * GetByDistance Assignment
 * */
didYouMean.SetDataSource(new DataSource(new List<string> { }));
var result1Empty = didYouMean.GetByDistance("123", 2);
Console.WriteLine("123 max distance 2 EMPTY check");
foreach (var entry in result1Empty)
{
    Console.WriteLine($"  Distance {entry.Key}: {string.Join(", ", entry.Value)}");
}

didYouMean.SetDataSource(new DataSource(new List<string> { "123", "234", "345", "456", "567", "678", "789", "1234", "2345", "3456", "4567", "5678", "6789" }));
didYouMean.SetDataSource(new DataSource(new List<string> { "123", "234", "345", "456", "567", "678", "789", "1234", "2345", "3456", "4567", "5678", "6789" }));

var result1 = didYouMean.GetByDistance("123", 2);
Console.WriteLine("123 max distance 2:");
foreach (var entry in result1)
{
    Console.WriteLine($"  Distance {entry.Key}: {string.Join(", ", entry.Value)}");
}

var result2 = didYouMean.GetByDistance("321", 2);
Console.WriteLine("321 max distance 2:");
foreach (var entry in result2)
{
    Console.WriteLine($"  Distance {entry.Key}: {string.Join(", ", entry.Value)}");
}

var result3 = didYouMean.GetByDistance("12", 1);
Console.WriteLine("12 max distance 1:");
foreach (var entry in result3)
{
    Console.WriteLine($"  Distance {entry.Key}: {string.Join(", ", entry.Value)}");
}

var result4 = didYouMean.GetByDistance("1234", 2);
Console.WriteLine("1234 max distance 2:");
foreach (var entry in result4)
{
    Console.WriteLine($"  Distance {entry.Key}: {string.Join(", ", entry.Value)}");
}


/*
 * last assignment
 */
Console.WriteLine($"peter vs peder = {didYouMean.Distance("peter", "peder")}");
Console.WriteLine($"peter vs pete = {didYouMean.Distance("peter", "pete")}");
Console.WriteLine($"peter vs eter = {didYouMean.Distance("peter", "eter")}");
Console.WriteLine($"peter vs peetr = {didYouMean.Distance("peter", "peetr")}");
Console.WriteLine($"peter vs peter = {didYouMean.Distance("peter", "peter")}");
Console.WriteLine($"peter vs pedro = {didYouMean.Distance("peter", "pedro")}");




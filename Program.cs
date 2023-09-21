using space1;

var acc = new BA($"<script>alert('hej')</script>", 1000);
acc.Md(500, DateTime.Now, "MD made");
Console.WriteLine(acc.bal);
acc.Md(100, DateTime.Now, "Test message");
Console.WriteLine(acc.bal);
Console.WriteLine(acc.Gac());
try
{
    acc.Mw(750, DateTime.Now, "Attempt to od");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to od");
    Console.WriteLine(e.ToString());
}
BA ia;
try
{
    ia = new BA("test", 55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating with negative value");
    Console.WriteLine(e.ToString());
    return;
}
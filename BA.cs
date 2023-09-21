namespace space1;

public class BA
{
    private static int ACN = 1;

    public string NUM { get; }
    public string Owner { get; set; }

    private List<Tr> _at = new List<Tr>();

    public decimal bal
    {
        get
            {
                decimal bal = 0;
                foreach (var item in _at)
                {
                    bal += item.Am;
                }
                return bal;
            }
    }
    public BA(string nm, decimal ib)
    {
        NUM = ACN.ToString();
        ACN++;

        this.Owner = nm;
        Md(ib, DateTime.Now, "Initial");

        
    }
    public void Md(decimal am, DateTime d, string n)
    {
        if (am <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(am), "Amount must be positive");
        }
        var dep = new Tr(am, d, n);
        _at.Add(dep);
    }

    public void Mw(decimal a, DateTime d, string n)
    {
        if (a <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(a), "Amount must be positive");
        }
        if (bal - a < 0)
        {
            throw new InvalidOperationException("ba is insufficient");
        }
        var wd = new Tr(-a, d, n);
        _at.Add(wd);
    }
    public string Gac()
    {
        var report = new System.Text.StringBuilder();

        decimal bal2 = 0;
        report.AppendLine("D\t\tA\tB\tN");
        foreach (var i in _at)
        {
            bal2 += i.Am;
            report.AppendLine($"{i.D.ToShortDateString()}\t{i.Am}\t{bal2}\t{i.N}");
        }

        return report.ToString();
    }
}
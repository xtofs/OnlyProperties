static class ComparableExtension
{
    public static bool IfNotEqual<T>(this T a, T b, out int val)
        where T : IComparable<T>
    {
        val = a.CompareTo(b);
        return val == 0;
    }

    public static bool IfNotEqual<T>(this IComparer<T> comparer, T a, T b, out int val)
    {
        val = comparer.Compare(a, b);
        return val == 0;
    }
}



// var a = Accessor.From((Foo foo) => foo.Bar.Baz.Name);

// Console.WriteLine(a);

// var f = new Foo(new Bar(new Baz("abc")));

// Console.WriteLine(a.Get(f));



// record Foo(Bar Bar);
// record Bar(Baz Baz);
// record Baz(string Name);


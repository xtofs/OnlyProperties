using Microsoft.VisualBasic;

var a = Enumerable.Range(1, 10).Select(i => new Widget(i * 2, "2i"));
var b = Enumerable.Range(1, 10).Select(i => new Widget(i * 3, "3i"));

var c = a.Merge(b, Widget.Comparer);

System.Console.WriteLine(string.Join("\n", c));


record Widget(int Value1, string Value2)
{
    public static IComparer<Widget> Comparer = new WidgetComparer();

    private class WidgetComparer : IComparer<Widget>
    {
        public int Compare(Widget? x, Widget? y)
        {
            return x is null ? -1 : y is null ? 1 : x.Value1.CompareTo(y.Value1);
        }
    }
}


record Book(string Title, int Edition, string Language) : IComparable<Book>
{
    public int CompareTo(Book? other)
    {
        if (object.ReferenceEquals(this, other)) return 0;
        if (this is null) return -1; // null is smaller than everything
        if (other is null) return 1; // everything is larger than null

        // return Title.IfNotEqual(other.Title, out var cmp) ? cmp :
        //     Edition.IfNotEqual(other.Edition, out cmp) ? cmp :
        //     Language.IfNotEqual(other.Language, out cmp) ? cmp :
        //     0;

        return StringComparer.InvariantCultureIgnoreCase.IfNotEqual(Title, other.Title, out var cmp) ? cmp :
            Edition.IfNotEqual(other.Edition, out cmp) ? cmp :
            Language.IfNotEqual(other.Language, out cmp) ? cmp :
            0;
    }
}



// var a = Accessor.From((Foo foo) => foo.Bar.Baz.Name);

// Console.WriteLine(a);

// var f = new Foo(new Bar(new Baz("abc")));

// Console.WriteLine(a.Get(f));



// record Foo(Bar Bar);
// record Bar(Baz Baz);
// record Baz(string Name);


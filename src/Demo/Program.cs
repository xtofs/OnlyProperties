

var a = Accessor.From((Foo foo) => foo.Bar.Baz.Name);

Console.WriteLine(a);

var f = new Foo(new Bar(new Baz("abc")));

Console.WriteLine(a.Get(f));



record Foo(Bar Bar);
record Bar(Baz Baz);
record Baz(string Name);


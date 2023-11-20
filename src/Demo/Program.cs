

var a = Accessor.From((Foo foo) => foo.Bar.Baz.Name);


var f = new Foo(new Bar(new Baz("abc")));

System.Console.WriteLine(a.Get(f));



record Foo(Bar Bar);
record Bar(Baz Baz);
record Baz(string Name);


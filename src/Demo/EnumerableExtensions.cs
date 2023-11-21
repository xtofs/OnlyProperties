

static class EnumerableExtensions
{
    public static IEnumerable<T> Merge<T>(this IEnumerable<T> left, IEnumerable<T> right, IComparer<T> comparer)
    {
        T value;
        var leftEnum = left.GetEnumerator();
        var rightEnum = right.GetEnumerator();

        var leftHasMoved = leftEnum.MoveNext();
        var rightHasMoved = rightEnum.MoveNext();

        while (leftHasMoved && rightHasMoved)
        {
            switch (comparer.Compare(leftEnum.Current, rightEnum.Current))
            {
                case -1:
                case 0:
                    yield return value = leftEnum.Current;
                    leftHasMoved = leftEnum.MoveNext();
                    if (leftHasMoved && comparer.Compare(value, leftEnum.Current) > 0)
                    {
                        throw new ArgumentException($"left is not sorted !({value} >= {leftEnum.Current})");
                    }
                    break;

                case 1:
                    yield return value = rightEnum.Current;
                    rightHasMoved = rightEnum.MoveNext();
                    if (rightHasMoved && comparer.Compare(value, rightEnum.Current) > 0)
                    {
                        throw new ArgumentException($"right is not sorted !({value} >= {leftEnum.Current})");
                    }
                    break;
            }
        }
        // only one of the Enumerabors has ended at this point
        Debug.Assert(leftHasMoved != rightHasMoved);
        if (leftHasMoved)
        {
            do
            {
                yield return leftEnum.Current;
            } while (leftEnum.MoveNext());
        }
        else if (rightHasMoved)
        {
            do
            {
                yield return rightEnum.Current;
            }
            while (rightEnum.MoveNext());
        }
    }
}




// var a = Accessor.From((Foo foo) => foo.Bar.Baz.Name);

// Console.WriteLine(a);

// var f = new Foo(new Bar(new Baz("abc")));

// Console.WriteLine(a.Get(f));



// record Foo(Bar Bar);
// record Bar(Baz Baz);
// record Baz(string Name);


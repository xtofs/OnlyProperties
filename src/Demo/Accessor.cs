







static class Accessor
{
    public static Accessor<TSource, TResult> From<TSource, TResult>(Expression<Func<TSource, TResult>> func)
    {
        var expr = func.Body;
        var properties = new List<PropertyInfo>();

        while (true)
        {
            if (expr is ParameterExpression pe)
            {
                return new Accessor<TSource, TResult>(properties, pe, func);
            }
            else if (expr is MemberExpression me && me.Member is PropertyInfo pi)
            {
                properties.Insert(0, pi);
                expr = me.Expression;
            }
            else
            {
                throw new ArgumentException("TODO");
            }
        }
    }
}


class Accessor<TSource, TResult>
{
    private readonly List<PropertyInfo> properties;
    private readonly ParameterExpression parameterExpression;
    private readonly Expression<Func<TSource, TResult>> func;

    public Accessor(List<PropertyInfo> properties, ParameterExpression pe, Expression<Func<TSource, TResult>> func)
    {
        this.properties = properties;
        this.parameterExpression = pe;
        this.func = func;
    }

    public TResult Get(TSource f)
    {
        return func.Compile()(f);
    }

    public override string ToString()
    {
        return $"{parameterExpression.Name}.{string.Join(".", from p in properties select p.Name)}";
    }
}
using System.Linq.Expressions;

namespace AirportWarehouse.Utils.Mapper;

internal class ExpressionTranslator<TSource, TTarget> : ExpressionVisitor
{
    private readonly ParameterExpression _targetParam
        = Expression.Parameter(typeof(TTarget), "e");

    private readonly Dictionary<string, string> _propertyMap;
    private ParameterExpression? _sourceParam;

    public ExpressionTranslator(Dictionary<string, string> propertyMap)
    {
        _propertyMap = propertyMap;
    }

    public Expression<Func<TTarget, TResult>> Translate<TResult>(
        Expression<Func<TSource, TResult>> expr)
    {
        _sourceParam = expr.Parameters[0];
        var body = Visit(expr.Body);
        return Expression.Lambda<Func<TTarget, TResult>>(body!, _targetParam);
    }

    protected override Expression VisitParameter(ParameterExpression node)
        => node == _sourceParam ? _targetParam : base.VisitParameter(node);

    protected override Expression VisitMember(MemberExpression node)
    {
        if (node.Expression == _sourceParam)
        {
            var sourceProp = node.Member.Name;

            if (!_propertyMap.TryGetValue(sourceProp, out var targetProp))
                throw new InvalidOperationException(
                    $"No hay mapeo definido para '{sourceProp}' en '{typeof(TSource).Name}'. " +
                    $"Decláralo con Map() en el perfil correspondiente.");

            var targetMember = typeof(TTarget).GetProperty(targetProp)
                ?? throw new InvalidOperationException(
                    $"La propiedad '{targetProp}' no existe en '{typeof(TTarget).Name}'.");

            return Expression.MakeMemberAccess(_targetParam, targetMember);
        }

        return base.VisitMember(node);
    }
}

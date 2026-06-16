
using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Utils.Mapper;
using System.Linq.Expressions;
using System.Reflection;

namespace AirportWarehouseAdminApi.Utils.Mapper
{
    public class MappingProfile<TEntity, TDto> : IGenericMapper<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
    {
        private readonly Dictionary<string, Func<TEntity, object?>> _toDtoRules = new();
        private readonly Dictionary<string, Func<TDto, object?>> _toEntityRules = new();
        private readonly List<(PropertyInfo Entity, PropertyInfo Dto)> _mirrorProps;
        private Action<TEntity, TDto>? _updateRules;

        private readonly HashSet<string> _ignoredToDto = new();
        private readonly HashSet<string> _ignoredToEntity = new();

        public MappingProfile()
        {
            _mirrorProps = ResolveMirrorProperties();
        }
        public TDto ToDto(TEntity entity)
        {
            var dto = Activator.CreateInstance<TDto>();

            foreach (var (eProp, dProp) in _mirrorProps)
            {
                if(_ignoredToDto.Contains(eProp.Name)) continue;
                dProp.SetValue(dto, eProp.GetValue(entity));
            }

            foreach (var (propName, rule) in _toDtoRules)
            {
                var prop = typeof(TDto).GetProperty(propName);
                var value = rule(entity);

                if (value is DBNull) value = null;

                prop?.SetValue(dto, value);
            }

            return dto;
        }


        public IEnumerable<TDto> ToDtoList(IEnumerable<TEntity> entities)
             => entities.Select(ToDto);

        public TEntity ToEntity(TDto dto)
        {
            var entity = Activator.CreateInstance<TEntity>();

            foreach (var (eProp, dProp) in _mirrorProps)
            {
                if (_ignoredToEntity.Contains(eProp.Name)) continue;
                eProp.SetValue(entity, dProp.GetValue(dto));
            }

            foreach (var (propName, rule) in _toEntityRules)
            {
                if (_ignoredToEntity.Contains(propName)) continue;
                typeof(TEntity).GetProperty(propName)?.SetValue(entity, rule(dto));

            }

            return entity;
        }

        public void ApplyUpdate(TEntity entity, TDto dto)
        {
            if (_updateRules is not null)
            {
                _updateRules(entity, dto);
                return;
            }

            foreach (var (eProp, dProp) in _mirrorProps)
            {
                if (_ignoredToEntity.Contains(eProp.Name)) continue;
                eProp.SetValue(entity, dProp.GetValue(dto));
            }

            foreach (var (propName, rule) in _toEntityRules)
            {
                if (_ignoredToEntity.Contains(propName)) continue;
                typeof(TEntity).GetProperty(propName)?.SetValue(entity, rule(dto));
            }

        }

        public Expression<Func<TEntity, bool>> ToEntityExpression(Expression<Func<TDto, bool>> expr)
            => new ExpressionTranslator<TDto, TEntity>(BuildPropertyNameMap()).Translate(expr);

        #region Protected Mapping Methods

        protected MappingProfile<TEntity, TDto> Map<TProp>(Expression<Func<TDto, TProp>> dtoProperty, Expression<Func<TEntity, TProp>> fromEntity)
        {
            var compiled = CompileNullSafe(fromEntity);
            _toDtoRules[GetMemberName(dtoProperty)] = e => compiled(e);
            return this;
        }

        protected MappingProfile<TEntity, TDto> MapToEntity<TProp>(Expression<Func<TEntity, TProp>> entityProperty, Expression<Func<TDto, TProp>> fromDto)
        {
            var compiled = CompileNullSafe(fromDto);
            _toEntityRules[GetMemberName(entityProperty)] = d => compiled(d);
            return this;
        }

        protected MappingProfile<TEntity, TDto> MapUpdate(Action<TEntity, TDto> updateRule)
        {
            _updateRules = updateRule;
            return this;
        }

        protected MappingProfile<TEntity, TDto> MapInclude<TProp>(Expression<Func<TDto, TProp>> dtoField, Expression<Func<TEntity, object>> navigationProperty)
        {
            var dtoProp = GetMemberName(dtoField);
            var entityProp = GetMemberName(navigationProperty);
            return this;
        }

        protected MappingProfile<TEntity, TDto> IgnoreOnToDto(params Expression<Func<TEntity, object>>[] entityProperties)
        {
            foreach (var prop in entityProperties)
                _ignoredToDto.Add(GetMemberName(prop));

            _mirrorProps.Clear();
            _mirrorProps.AddRange(ResolveMirrorProperties());
            return this;
        }

        protected MappingProfile<TEntity, TDto> IgnoreOnToEntity(params Expression<Func<TEntity, object>>[] entityProperties)
        {
            foreach(var prop in entityProperties)
                _ignoredToEntity.Add(GetMemberName(prop));
            _mirrorProps.Clear();
            _mirrorProps.AddRange(ResolveMirrorProperties());
            return this;
        }

        #endregion


        #region Private Methods
        private List<(PropertyInfo Entity, PropertyInfo Dto)> ResolveMirrorProperties()
        {
            var entityProps = typeof(TEntity)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite)
                .ToDictionary(p => p.Name);

            var mirrors = new List<(PropertyInfo, PropertyInfo)>();

            foreach (var dProp in typeof(TDto)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite))
            {
                if (!entityProps.TryGetValue(dProp.Name, out var eProp)) continue;

                if (_ignoredToDto.Contains(eProp.Name) || _ignoredToEntity.Contains(eProp.Name)) continue;

                if (eProp.PropertyType == dProp.PropertyType
                    || dProp.PropertyType.IsAssignableFrom(eProp.PropertyType))
                    mirrors.Add((eProp, dProp));
            }

            return mirrors;
        }

        private static string GetMemberName<T, TProp>(Expression<Func<T, TProp>> expr)
            => expr.Body is MemberExpression m
            ? m.Member.Name
            : throw new ArgumentException("La expresión debe ser un acceso a propiedad: x => x.Propiedad");


        private Dictionary<string, string> BuildPropertyNameMap()
        {
            var map = new Dictionary<string, string>();

            foreach (var (eProp, dProp) in _mirrorProps)
                map[dProp.Name] = eProp.Name;

            foreach (var propName in _toDtoRules.Keys)
                if (!map.ContainsKey(propName) && typeof(TEntity).GetProperty(propName) is not null)
                    map[propName] = propName;

            return map;
        }

        private static Func<TSource, object?> CompileNullSafe<TSource, TProp>(Expression<Func<TSource, TProp>> expr)
        {
            var safeBody = MakeNullSafe(expr.Body);
            var converted = Expression.Convert(safeBody, typeof(object));
            var lambda = Expression.Lambda<Func<TSource, object?>>(converted, expr.Parameters);
            return lambda.Compile();
        }

        private static Expression MakeNullSafe(Expression expr)
        {
            switch (expr)
            {
                case MemberExpression m:
                    var innerSafe = MakeNullSafe(m.Expression!);
                    var access = Expression.MakeMemberAccess(innerSafe, m.Member);
                    return Expression.Condition(
                        Expression.Equal(innerSafe, Expression.Constant(null, innerSafe.Type)),
                        Expression.Default(m.Type),
                        access);

                case MethodCallExpression mc:
                    Expression? instance = mc.Object is not null ? MakeNullSafe(mc.Object) : null;
                    var args = mc.Arguments.Select(MakeNullSafe).ToArray();
                    var call = instance is null ? Expression.Call(mc.Method, args) : Expression.Call(instance, mc.Method, args);
                    if (instance is null) return call;
                    return Expression.Condition(
                        Expression.Equal(instance, Expression.Constant(null, instance.Type)),
                        Expression.Default(mc.Type),
                        call);

                case UnaryExpression u when u.NodeType == ExpressionType.Convert || u.NodeType == ExpressionType.ConvertChecked:
                    var operandSafe = MakeNullSafe(u.Operand);
                    return Expression.Convert(operandSafe, u.Type);

                case ParameterExpression p:
                case ConstantExpression c:
                    return expr;

                default:
                    return expr;
            }
        }

        #endregion
    }
}

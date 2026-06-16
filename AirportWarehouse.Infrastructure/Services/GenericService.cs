using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.ParamerEntities;
using AirportWarehouse.Infrastructure.Interfaces.DataInterfaces;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;
using AirportWarehouse.Utils.Mapper;
using AirportWarehouseAdminApi.Core.CustomEntities;
using System.Linq.Expressions;

namespace AirportWarehouse.Infrastructure.Services;

public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
{
    public GenericService(IUnitOfWork unitOfWork, IGenericMapper<TEntity, TDto> mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;   
    }
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericMapper<TEntity, TDto> _mapper;

    public async virtual Task<TDto> CreateAsync(TDto dto)
    {
        var entity = _mapper.ToEntity(dto);
        var createdEntity = await _unitOfWork.Repository<TEntity>().CreateAsync(entity).ConfigureAwait(false);

        await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        return _mapper.ToDto(createdEntity);
    }

    public async Task<bool> DeleteAsync(Guid Id)
    {
        var result = await _unitOfWork.Repository<TEntity>().DeleteAsync(Id).ConfigureAwait(false);
        if (result) 
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

        return result;

    }

    public async Task<IEnumerable<TDto>> GetAllAsync(IEnumerable<Expression<Func<TEntity, object>>>? includes = null)
    {
        var entities = await _unitOfWork.Repository<TEntity>().GetAllAsync(includes).ConfigureAwait(false);
        return _mapper.ToDtoList(entities);
    }

    public async Task<TDto?> GetByIdAsync(Guid Id)
    {
        var entity = await _unitOfWork.Repository<TEntity>().GetByIdAsync(Id).ConfigureAwait(false);
        return entity is null ? null : _mapper.ToDto(entity);
    }

    public virtual async Task<TDto?> UpdateAsync(TDto dto)
    {

        var existing = await _unitOfWork.Repository<TEntity>().GetByIdAsync(dto.Id);
        if (existing is null) return null;

        _mapper.ApplyUpdate(existing, dto);

        var updated = await _unitOfWork.Repository<TEntity>().UpdateAsync(existing);

        if (updated is null) return null;

        await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        return _mapper.ToDto(updated);
    }

    public async Task<PagedResult<TDto>> GetPagedAsync(PaginationsParams paginations, Expression<Func<TDto, bool>>? filter = null, IEnumerable<Expression<Func<TEntity, object>>>? includes = null)
    {
        var entityFilter = filter is not null ? _mapper.ToEntityExpression(filter) : null;

        var (entities, totalCount) = await _unitOfWork
            .Repository<TEntity>()
            .GetPagedAsync(paginations.Page, paginations.PageSize, entityFilter, includes)
            .ConfigureAwait(false);

        return new PagedResult<TDto>
        {
            Data = _mapper.ToDtoList(entities),
            Page = paginations.Page,
            PageSize = paginations.PageSize,
            TotalCount = totalCount
        };
    }

    public async virtual Task<IEnumerable<TDto>> CreateListAsync(IEnumerable<TDto> dtos)
    {
        var entities = dtos.Select(dto => _mapper.ToEntity(dto)).ToList();

        foreach (var entity in entities)
        {
            await _unitOfWork.Repository<TEntity>().CreateAsync(entity).ConfigureAwait(false);
        }
        await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

        return _mapper.ToDtoList(entities);
    }
}

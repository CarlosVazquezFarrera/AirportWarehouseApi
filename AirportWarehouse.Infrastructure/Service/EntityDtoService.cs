﻿using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Service
{
    public class EntityDtoService<TEntity, TDto> : IEntityDtoService<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDTO
    {
        public EntityDtoService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<TDto> GetAll()
        {
            var entities = _unitOfWork.Repository<TEntity>().GetAll();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto> GetByIdAsync(Guid Id)
        {
            var entity = await _unitOfWork.Repository<TEntity>().GetById(Id) ?? throw new NotFoundException();
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> AddAsync(TDto DtoEntity)
        {
            var entity = _mapper.Map<TEntity>(DtoEntity);
            await _unitOfWork.Repository<TEntity>().Add(entity);
            await _unitOfWork.SaveChanguesAsync();
            return _mapper.Map<TDto>(entity) ;
        }

        public async Task<TDto> UpdateAsync(TDto DtoEntity)
        {
            var existingEntity = await _unitOfWork.Repository<TEntity>().GetById(DtoEntity.Id) ?? throw new NotFoundException();
            _mapper.Map(DtoEntity, existingEntity);
            _unitOfWork.Repository<TEntity>().Update(existingEntity);
            await _unitOfWork.SaveChanguesAsync();
            return DtoEntity;
        }
    }
}

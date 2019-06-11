using System;
using System.Linq;
using System.Linq.Expressions;
using Weather.DAL.Base;
using Weather.Domain.Enum;
using Weather.Domain.Interfaces;
using Weather.Domain.NotMapped;

namespace Weather.BLL.Base
{
    public class BaseManager<TEntity> : IManager<TEntity> where TEntity : class
    {
        #region Atributos

        private IRepository<TEntity> _repository;
        protected DomainResult<TEntity> _domainResult;
        private UnitOfWorkDAL _unitOfWorkDAL;

        #endregion

        #region Propriedades

        protected UnitOfWorkDAL UnitOfWork
        {
            get
            {
                if (_unitOfWorkDAL == null)
                    _unitOfWorkDAL = new UnitOfWorkDAL();

                return _unitOfWorkDAL;
            }
        }

        #endregion

        #region Construtor

        public BaseManager(UnitOfWorkDAL pUnitOfWorkDal)
        {
            _unitOfWorkDAL = pUnitOfWorkDal;
            _domainResult = new DomainResult<TEntity>();
            _repository = _unitOfWorkDAL.GetRepository<TEntity>();
        }

        #endregion

        #region Métodos Públicos

        public virtual IQueryable<TEntity> GetBy(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            return _repository.GetBy(filter, orderBy, includeProperties);
        }

        public virtual TEntity FindBy(object id)
        {
            return _repository.FindBy(id);
        }

        public virtual TEntity FindBy(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
        {
            return _repository.FindBy(filter, includeProperties);
        }

        public DomainResult<TEntity> Insert(TEntity entity)
        {
            _domainResult = new DomainResult<TEntity>();

            if (!IsValid(entity, ERepositoryOperacao.Insert))
                return _domainResult;

            _domainResult.Entidade = _repository.Insert(entity);
            _domainResult.Mensagem = "Operação realizada com sucesso!";

            return _domainResult;
        }

        public virtual DomainResult<TEntity> Add(TEntity entityToInsert)
        {
            try
            {
                if (!IsValid(entityToInsert, ERepositoryOperacao.Insert))
                    return _domainResult;

                _repository.Add(entityToInsert);
                _domainResult.Sucesso = true;
                _domainResult.Mensagem = "Inserido com sucesso!";

            }
            catch (Exception ex)
            {
                _domainResult.Erros.Add("Erro ao inserir.");
                _domainResult.ExceptionGerada = ex;
            }

            return _domainResult;

        }

        public virtual DomainResult<TEntity> Delete(object id)
        {
            try
            {
                var entity = FindBy(id);
                return Delete(entity);
            }
            catch (Exception ex)
            {
                _domainResult.Erros.Add("Erro ao deletar.");
                _domainResult.ExceptionGerada = ex;
            }
            return _domainResult;
        }

        public virtual DomainResult<TEntity> Delete(TEntity entityToDelete)
        {
            try
            {

                if (!IsValid(entityToDelete, ERepositoryOperacao.Delete))
                    return _domainResult;

                _repository.Delete(entityToDelete);
                _domainResult.Sucesso = true;
                _domainResult.Mensagem = "Removido com sucesso!";


            }
            catch (Exception ex)
            {
                _domainResult.Erros.Add("Erro ao deletar.");
                _domainResult.ExceptionGerada = ex;
            }
            return _domainResult;

        }

        public virtual DomainResult<TEntity> Update(TEntity entityToUpdate)
        {
            try
            {

                if (!IsValid(entityToUpdate, ERepositoryOperacao.Update))
                    return _domainResult;

                _repository.Update(entityToUpdate);
                _domainResult.Sucesso = true;
                _domainResult.Mensagem = "Atualizado com sucesso!";


            }
            catch (Exception ex)
            {
                _domainResult.Erros.Add("Erro ao atualizar.");
                _domainResult.ExceptionGerada = ex;
            }
            return _domainResult;

        }

        public bool IsValid(TEntity entity, ERepositoryOperacao operacao)
        {
            var retorno = true;
            switch (operacao)
            {
                case ERepositoryOperacao.Insert:
                    retorno = InsertIsValid(entity);
                    break;
                case ERepositoryOperacao.Delete:
                    retorno = DeleteIsValid(entity);
                    break;
                case ERepositoryOperacao.Update:
                    retorno = UpdateIsValid(entity);
                    break;
                default:
                    throw new ApplicationException("Operação inválida!");

            }
            return retorno;
        }

        public virtual bool InsertIsValid(TEntity entity)
        {
            return true;
        }

        public virtual bool UpdateIsValid(TEntity entity)
        {
            return true;
        }

        public virtual bool DeleteIsValid(TEntity entity)
        {
            return true;
        }

        public DomainResult<TEntity> GetDomainResult()
        {
            return _domainResult;
        }

        #endregion

        #region Métodos Privados

        #endregion
    }
}

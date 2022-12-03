using Dapper.Contrib.Extensions;

namespace DapperGRP.Domain.Entities
{
    public abstract class Entity
    {
        [ExplicitKey]
        protected Guid Id { get; set; }
        public Entity() => Id = Guid.NewGuid();
        public Entity(Guid id) => Id = id;
    }
}

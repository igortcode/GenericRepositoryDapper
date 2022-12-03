using Dapper.Contrib.Extensions;

namespace DapperGRP.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public string Id { get; protected set; }
        public Entity() => Id = Guid.NewGuid().ToString();
        public Entity(string id) => Id = id;
    }
}

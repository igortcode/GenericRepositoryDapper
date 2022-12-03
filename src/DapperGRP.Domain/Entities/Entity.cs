namespace DapperGRP.Domain.Entities
{
    public abstract class Entity
    {
        protected Guid Id { get; set; }
        public Entity() => Id = Guid.NewGuid();
        public Entity(Guid id) => Id = id;
    }
}

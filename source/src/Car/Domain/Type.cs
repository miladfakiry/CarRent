using CarRent.Common.Domain;

namespace CarRent.Car.Domain
{
    public class Type : Entity
    {
        public Type(Guid id) : base(id)
        {
        }
        public string Name { get; }
    }
}

using System;

namespace LojaCamisas.Domain
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        protected Entity() { }

        protected Entity(int id)
        {
            Id = id;
        }
    }
}

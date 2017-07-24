using System;

namespace Common.Database.Entities.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
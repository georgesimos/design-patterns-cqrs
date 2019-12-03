using System;
namespace DesignPatterns.Infrastructure
{
    public interface IAggregateEntity
    {
        int Version { get; set; }
    }
}

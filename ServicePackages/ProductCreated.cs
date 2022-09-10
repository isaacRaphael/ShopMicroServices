using System;

namespace ServicePackages {
    public record ProductCreated(Guid Id, string? Name, decimal Price, decimal Cost, string? ImageUrl);
}
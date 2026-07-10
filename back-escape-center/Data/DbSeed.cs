using back_escape_center.Models;
using Microsoft.EntityFrameworkCore;

namespace back_escape_center.Data;

public static class DbSeed
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (await db.Users.AnyAsync())
            return;

        var user1 = new RegisterModel
        {
            Id = Guid.NewGuid(),
            Name = "Admin",
            Email = "admin@escape.com",
            Phone = "(11) 99999-0001",
            Password = "123456",
            CreatedAt = DateTime.UtcNow
        };

        var user2 = new RegisterModel
        {
            Id = Guid.NewGuid(),
            Name = "João Silva",
            Email = "joao@escape.com",
            Phone = "(11) 99999-0002",
            Password = "123456",
            CreatedAt = DateTime.UtcNow
        };

        db.Users.AddRange(user1, user2);

        var client1 = new ClientModel
        {
            Id = Guid.NewGuid(),
            Name = "Maria Oliveira",
            Email = "maria@email.com",
            Phone = "(21) 98888-1111",
            DateBorn = new DateTime(1990, 5, 15),
            CreatedAt = DateTime.UtcNow
        };

        var client2 = new ClientModel
        {
            Id = Guid.NewGuid(),
            Name = "Carlos Santos",
            Email = "carlos@email.com",
            Phone = "(31) 97777-2222",
            DateBorn = new DateTime(1985, 8, 22),
            CreatedAt = DateTime.UtcNow
        };

        var client3 = new ClientModel
        {
            Id = Guid.NewGuid(),
            Name = "Ana Costa",
            Email = "ana@email.com",
            Phone = "(41) 96666-3333",
            DateBorn = new DateTime(1995, 12, 3),
            CreatedAt = DateTime.UtcNow
        };

        db.Clients.AddRange(client1, client2, client3);

        db.Services.AddRange(
            new ServiceModel
            {
                Id = Guid.NewGuid(),
                ClientId = client1.Id,
                TypeService = "Troca de óleo",
                Budget = "150.00",
                Status = "Concluído",
                CreatedAt = DateTime.UtcNow,
                GetCar = DateTime.UtcNow.AddDays(1)
            },
            new ServiceModel
            {
                Id = Guid.NewGuid(),
                ClientId = client2.Id,
                TypeService = "Alinhamento e balanceamento",
                Budget = "200.00",
                Status = "Em andamento",
                CreatedAt = DateTime.UtcNow,
                GetCar = DateTime.UtcNow.AddDays(2)
            },
            new ServiceModel
            {
                Id = Guid.NewGuid(),
                ClientId = client3.Id,
                TypeService = "Revisão completa",
                Budget = "800.00",
                Status = "Aguardando",
                CreatedAt = DateTime.UtcNow,
                GetCar = null
            }
        );

        await db.SaveChangesAsync();
    }
}

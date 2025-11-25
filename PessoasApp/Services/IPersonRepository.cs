using PessoasApp.Models;

namespace PessoasApp.Services;

public interface IPersonRepository
{
    Task<IReadOnlyList<Person>> GetAsync(string? search = null, CancellationToken cancellationToken = default);
    Task<Person?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Person> AddAsync(Person person, CancellationToken cancellationToken = default);
    Task<Person> UpdateAsync(Person person, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}


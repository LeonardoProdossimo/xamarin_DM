using PessoasApp.Models;

namespace PessoasApp.Services;

public class PersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<Person>> GetAsync(string? search = null, CancellationToken cancellationToken = default) =>
        _repository.GetAsync(search, cancellationToken);

    public async Task<Person> SaveAsync(Person person, CancellationToken cancellationToken = default)
    {
        return person.Id == 0
            ? await _repository.AddAsync(person, cancellationToken).ConfigureAwait(false)
            : await _repository.UpdateAsync(person, cancellationToken).ConfigureAwait(false);
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default) =>
        _repository.DeleteAsync(id, cancellationToken);
}


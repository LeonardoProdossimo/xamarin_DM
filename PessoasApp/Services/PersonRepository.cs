using Microsoft.Maui.Storage;
using PessoasApp.Models;
using SQLite;

namespace PessoasApp.Services;

public class PersonRepository : IPersonRepository
{
    private const SQLiteOpenFlags DatabaseFlags =
        SQLiteOpenFlags.ReadWrite |
        SQLiteOpenFlags.Create |
        SQLiteOpenFlags.SharedCache;

    private readonly Lazy<Task<SQLiteAsyncConnection>> _database;

    public PersonRepository()
    {
        _database = new Lazy<Task<SQLiteAsyncConnection>>(InitializeAsync);
    }

    public async Task<IReadOnlyList<Person>> GetAsync(string? search = null, CancellationToken cancellationToken = default)
    {
        var db = await GetConnectionAsync();
        var results = await db.Table<Person>().OrderBy(p => p.FullName).ToListAsync().ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(search))
        {
            return results;
        }

        var term = search.Trim().ToLowerInvariant();
        return results
            .Where(p =>
                p.FullName.ToLower().Contains(term) ||
                p.Email.ToLower().Contains(term) ||
                (!string.IsNullOrWhiteSpace(p.Document) && p.Document!.ToLower().Contains(term)))
            .ToList();
    }

    public async Task<Person?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var db = await GetConnectionAsync();
        return await db.Table<Person>().FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);
    }

    public async Task<Person> AddAsync(Person person, CancellationToken cancellationToken = default)
    {
        var db = await GetConnectionAsync();
        person.CreatedAt = DateTime.UtcNow;
        await db.InsertAsync(person).ConfigureAwait(false);
        return person;
    }

    public async Task<Person> UpdateAsync(Person person, CancellationToken cancellationToken = default)
    {
        var db = await GetConnectionAsync();
        await db.UpdateAsync(person).ConfigureAwait(false);
        return person;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var db = await GetConnectionAsync();
        await db.DeleteAsync<Person>(id).ConfigureAwait(false);
    }

    private async Task<SQLiteAsyncConnection> InitializeAsync()
    {
        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "people.db3");
        var connection = new SQLiteAsyncConnection(databasePath, DatabaseFlags);
        await connection.CreateTableAsync<Person>().ConfigureAwait(false);
        return connection;
    }

    private Task<SQLiteAsyncConnection> GetConnectionAsync() => _database.Value;
}


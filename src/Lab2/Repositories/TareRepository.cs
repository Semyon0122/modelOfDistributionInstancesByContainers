using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class TareRepository : ITareRepository
{
    private readonly Dictionary<TareIdentifier, Tare> _storage;

    public TareRepository()
    {
        _storage = new Dictionary<TareIdentifier, Tare>();
    }

    public Tare? GetById(TareIdentifier id)
    {
        return _storage.GetValueOrDefault(id);
    }

    public void Save(Tare tare)
    {
        _storage.Add(tare.Id, tare);
    }
}
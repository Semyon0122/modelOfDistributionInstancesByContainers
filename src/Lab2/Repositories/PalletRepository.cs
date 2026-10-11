using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class PalletRepository : IPalletRepository
{
    private readonly Dictionary<PalletIdentifier, Pallet> _storage;

    public PalletRepository()
    {
        _storage = new Dictionary<PalletIdentifier, Pallet>();
    }

    public Pallet? GetById(PalletIdentifier id)
    {
        return _storage.GetValueOrDefault(id);
    }

    public void Save(Pallet pallet)
    {
        _storage.Add(pallet.Id, pallet);
    }
}
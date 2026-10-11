using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IPalletRepository
{
    Pallet? GetById(PalletIdentifier id);

    void Save(Pallet pallet);
}
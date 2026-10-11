using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Identifiers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface ITareRepository
{
    Tare? GetById(TareIdentifier id);

    void Save(Tare tare);
}
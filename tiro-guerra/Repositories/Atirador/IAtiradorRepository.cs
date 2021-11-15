using System;
using System.Collections.Generic;
using TiroGuerra.Models;

namespace TiroGuerra.Repositories
{
    public interface IAtiradorRepository
    {
        void Create(Atirador model);
        List<Atirador> ReadAll();
        Atirador Read(int id);
        Atirador Read(string CPF, string RA);

        void Update(int id, Atirador model);
        void Delete(int id);

    }
}
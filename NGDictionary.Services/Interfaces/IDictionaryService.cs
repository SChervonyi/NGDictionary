using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NGDictionary.Services.Interfaces
{
    public interface IDictionaryService
    {
        Task AddDictionary();

        Task DeleteDictionary(Guid dictionaryId);
    }
}

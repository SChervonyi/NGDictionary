using NGDictionary.Database.Interfaces.Helpers;
using NGDictionary.Dto;
using System;

namespace NGDictionary.Database.Helpers
{
    public class DictionaryUpdateHelper : IUpdateEntityHelper<Dictionary>
    {
        // It could be an extension method for Word, but it's better to avoid adding a logic to a model.
        public void Update(Dictionary source, Dictionary target)
        {
            target.Description = source.Description;
            target.ImageUrl = source.ImageUrl;
            target.IsFavorite = source.IsFavorite;
            target.Name = source.Name;
        }
    }
}

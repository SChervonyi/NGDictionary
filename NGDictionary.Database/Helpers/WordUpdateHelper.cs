using NGDictionary.Database.Interfaces.Helpers;
using NGDictionary.Dto;

namespace NGDictionary.Database.Helpers
{
    class WordUpdateHelper : IUpdateEntityHelper<Word>
    {
        
        // It could be an extension method for Word, but it's better to avoid adding a logic to a model.
        public void Update(Word source, Word target)
        {
            target.AudioUrl = source.AudioUrl;
            target.Details = source.Details;
            target.DictionaryId = source.DictionaryId;
            target.ImageUrl = source.ImageUrl;
            target.Text = source.Text;
            target.Translation = source.Translation;
        }
    }
}

using EFCoreBoardgameData.Models;

namespace BoardgameLibrary.BoardgameManagement
{
    public interface IBoardgameRepository
    {
        public Boardgame Add(Boardgame bg);//Name is decieving - it is actually upsert AHAHAHAHAHAH
        public IEnumerable<Boardgame> AddMany(IEnumerable<Boardgame> bgs);

        public Boardgame Remove(Boardgame bg);
        public IEnumerable<Boardgame> RemoveMany(IEnumerable<Boardgame> bgs);

        public Boardgame GetByName(string bgName);
        public IEnumerable<Boardgame> GetAll(); //For anything advanced, we use getall, and then LINQ it (inneficient as it may be)
    }
}

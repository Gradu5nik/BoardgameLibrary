using EFCoreBoardgameData;
using EFCoreBoardgameData.Models;

namespace BoardgameLibrary.BoardgameManagement
{
    public class BoardgameRepository:IBoardgameRepository
    {
        private readonly EFCoreBoardgameDbContext _context;

        public BoardgameRepository(EFCoreBoardgameDbContext context)
        {
            _context = context;
        }

        public Boardgame Add(Boardgame bg)
        {
            _context.Boardgames.Add(bg);
            _context.SaveChanges();
            return bg;
        }

        public IEnumerable<Boardgame> AddMany(IEnumerable<Boardgame> bgs)
        {
            _context.Boardgames.AddRange(bgs);
            _context.SaveChanges();
            return bgs;
        }

        public IEnumerable<Boardgame> GetAll()
        {
            return _context.Boardgames;
        }

        public Boardgame? GetByName(string bgName)
        {
            return _context.Boardgames.Where(x => x.Name==bgName).FirstOrDefault();
        }

        public Boardgame Remove(Boardgame bg)
        {
            _context.Boardgames.Remove(bg);
            _context.SaveChanges();
            return bg;
        }

        public IEnumerable<Boardgame> RemoveMany(IEnumerable<Boardgame> bgs)
        {
            _context.RemoveRange(bgs);
            _context.SaveChanges();
            return bgs;
        }
    }
}

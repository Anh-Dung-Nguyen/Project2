using Project2.Models;
using Project2.Repository;

namespace Project2.Service
{
    public interface IServices
    {
        List3 GetDetails(string soHsgd);
        IQueryable<Table1> GetDetailss(string soHsgd);
        IQueryable<Table2> GetDetailsss(string soHsgd);
    }
    
    public class Services : IServices
    {
        private readonly Repo _repo;
        private readonly Repos _repos;
        private readonly Reposi _reposi;
        public Services(Repo repo, Repos repos, Reposi reposi)
        {
            _repo = repo;
            _repos = repos;
            _reposi = reposi;
        }
        public List3 GetDetails(string soHsgd)
        {
            return _repo.GetDetails(soHsgd);
        }

        public IQueryable<Table1> GetDetailss(string soHsgd)
        {
            return _repos.GetDetailss(soHsgd);
        }
        public IQueryable<Table2> GetDetailsss(string soHsgd)
        {
            return _reposi.GetDetailsss(soHsgd);
        }
    }
}

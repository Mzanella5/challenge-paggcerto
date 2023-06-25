
using Microsoft.EntityFrameworkCore;

namespace challengePaggcerto.src.api.Models.EntityModel
{
    public static class AnticipationQuery
    {
        public static IQueryable<Anticipation> WhereAnticipationId(this IQueryable<Anticipation> queryAnticipation, long id)
        {
            return queryAnticipation.Where(x => x.Id == id);
        }

        public static IQueryable<Anticipation> WhereAnticipationIds(this IQueryable<Anticipation> queryAnticipations, List<Anticipation> anticipations){
            var ids = new List<long>();
            anticipations.ForEach(a => ids.Add(a.Id));
            var query = queryAnticipations.Where(a => ids.Contains(a.Id));
            return query;
        }

        public static IQueryable<Anticipation> IncludeTransactions(this IQueryable<Anticipation> queryAnticipations){
            return queryAnticipations.Include(a => a.Transactions);
        } 

    }
}

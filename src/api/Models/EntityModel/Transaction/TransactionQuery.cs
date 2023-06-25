
using Microsoft.EntityFrameworkCore;

namespace challengePaggcerto.src.api.Models.EntityModel
{
    public static class TransactionQuery
    {
        public static IQueryable<Transaction> WhereTransactionId(this IQueryable<Transaction> queryTransactions, long id)
        {
            return queryTransactions.Where(x => x.Id == id);
        }

        public static IQueryable<Transaction> IncludeParcels(this IQueryable<Transaction> queryTransactions){
            return queryTransactions.Include(x => x.Parcels);
        }

        public static IQueryable<Transaction> WhereTransactionAllowed(this IQueryable<Transaction> queryTransactions){
            return queryTransactions.Where(t => !t.Anticipated);
        }

        public static IQueryable<Transaction> WhereTransactionIds(this IQueryable<Transaction> queryTransactions, List<Transaction> transactions){            
            var ids = new List<long>();
            transactions.ForEach(t => ids.Add(t.Id));
            return queryTransactions.Where(t => ids.Contains(t.Id));
        }

        public static IQueryable<Transaction> IncludeAnticipations(this IQueryable<Transaction> queryTransactions){
            return queryTransactions.Include(t => t.Anticipation);
        }

    }
}

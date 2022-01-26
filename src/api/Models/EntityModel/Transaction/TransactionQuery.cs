
using Microsoft.EntityFrameworkCore;

namespace challengePaggcerto.src.api.Models.EntityModel
{
    public static class TransactionQuery
    {
        public static IQueryable<Transaction> WhereTransactionId(this IQueryable<Transaction> transactions, long id)
        {
            return transactions.Where(x => x.Id == id);
        }

        public static IQueryable<Transaction> IncludeParcels(this IQueryable<Transaction> transactions){
            return transactions.Include(x => x.Parcels);
        }

        public static IQueryable<Transaction> WhereTransactionAllowed(this IQueryable<Transaction> transactions){
            return transactions.Where(t => !t.Anticipated);
        }
    }
}

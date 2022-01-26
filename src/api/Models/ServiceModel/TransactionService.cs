
using challengePaggcerto.src.api.Models.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace challengePaggcerto.src.api.Models.ServiceModel
{
    public class TransactionService
    {
        private async Task<bool> AddParcelsAsync(DataContext context, List<Parcel> parcels)
        {

            context.Parcels?.AddRange(parcels);
            var changes = await context.SaveChangesAsync();

            if (changes == parcels.Count())
            {
                return true;
            }
            return false;
        }
        public async Task<bool> AddTransactionAsync(DataContext context, Transaction transaction)
        {
            List<Parcel> parcels = new List<Parcel>();
            int changes = 0;

            transaction.NetValue = transaction.GrossValue - transaction.FixRate;

            //Call a class for Validations

            context.Transactions?.Add(transaction);
            changes = await context.SaveChangesAsync();

            if (changes <= 0)            
                return false;           

            if(transaction.AcquirerConfirm){
                for (int i = 1; i <= transaction.ParcelAmount; i++)
                {
                    parcels.Add(
                        new Parcel{
                            Transaction = transaction,
                            GrossValue = transaction.GrossValue / transaction.ParcelAmount,
                            NetValue = transaction.NetValue / transaction.ParcelAmount,
                            ParcelNumber = i,

                            DateReceived = transaction.DateExecuted.AddDays(30*i)
                        }
                    );
                }

                if(!await AddParcelsAsync(context, parcels))
                    return false;
            }

            return true;
        }
        public async Task<Transaction?> GetTransactionByIdAsync(DataContext context, long id)
        {
            try
            {
                var tResult = await context.Transactions!.IncludeParcels().WhereTransactionId(id).FirstOrDefaultAsync();
                return tResult;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public async Task<ICollection<Transaction>?> GetAllowedTransactionsAsync(DataContext context){
            try
            {
                ICollection<Transaction> transactions;
                transactions = await context.Transactions!.WhereTransactionAllowed().ToListAsync();
                return transactions;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            return null;
        }

        public async Task<bool> RequestAnticipation(DataContext context, ICollection<Transaction> transactions) 
        {
            int changes = 0;
            try{
                
                Anticipation anticipation = new Anticipation{
                    RequestDate = DateTime.Now,
                    AnticipatedRequiredValue = 0.0,
                    AnticipatedValue = 0.0
                };

                foreach (Transaction t in transactions){
                    if(!t.Anticipated)
                        anticipation.AnticipatedRequiredValue += t.NetValue;                                                                
                    else                  
                        transactions.Remove(t);
                                                      
                }

                foreach(Transaction t in transactions){
                    t.Anticipated = true;
                    t.Anticipation = anticipation;
                }
                context.UpdateRange(transactions);

                context.Anticipations?.Add(anticipation);
                changes = await context.SaveChangesAsync();

                if(changes > transactions.Count)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
    }
}
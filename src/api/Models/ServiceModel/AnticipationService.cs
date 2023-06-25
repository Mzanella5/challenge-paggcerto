using challengePaggcerto.src.api.Models.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace challengePaggcerto.src.api.Models.ServiceModel
{
    public class AnticipationService
    {   
        public async Task<List<Transaction>?> RequestAnticipation(DataContext context, List<Transaction> transactions) 
        {
            int changes = 0;
            try{
                
                Anticipation anticipation = new Anticipation{
                    RequestDate = DateTime.Now,
                    AnticipatedRequiredValue = 0.0,
                    AnticipatedValue = 0.0
                };       

                transactions.RemoveAll(t => t.Anticipated);
                transactions.ForEach(t => {
                    anticipation.AnticipatedRequiredValue += t.NetValue;
                });

                foreach(Transaction t in transactions){
                    t.Anticipated = true;
                    t.Anticipation = anticipation;
                }
                context.Transactions?.UpdateRange(transactions);

                context.Anticipations?.Add(anticipation);
                changes = await context.SaveChangesAsync();

                if(changes > transactions.Count)
                    return transactions;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
        public async Task<List<Anticipation>> AnalyzingAnticipations(DataContext context, List<Anticipation> anticipations)
        {          
            var listAntecipation = await context.Anticipations!.WhereAnticipationIds(anticipations).ToListAsync();

            Console.WriteLine(anticipations.Count);
            var a = listAntecipation.RemoveAll(a => (int)a.AnalysisState != 0);
            listAntecipation.ForEach(a =>{
                a.StartAnalysisDate = DateTime.Now;
                a.AnalysisState = EAnticipationStatus.InAnalysis;
            });
            return listAntecipation;
        }

        public async Task<int> ConcludeAnalyzingTransactions(DataContext context, List<Transaction> transactions, long idAntecipation, bool acceptedThese)
        {
            int accepted = 0, rejected = 0, changes = 0, count = 0;

            var anticipation = await context.Anticipations!.WhereAnticipationId(idAntecipation).IncludeTransactions().FirstOrDefaultAsync();
            transactions = await context.Transactions!.WhereTransactionIds(transactions).ToListAsync();

            if(acceptedThese)
            {
                foreach(Transaction t in transactions){
                    foreach(Parcel p in t.Parcels!){
                        p.DatePassedOn = DateTime.Now;
                        p.ValueAnticipated = p.NetValue * 0.038;                       
                    }
                    t.DateAccepted = DateTime.Now;
                }
            }
            else
            {
                foreach(Transaction t in transactions){
                    t.DateRejected = DateTime.Now;
                    t.Anticipated = false;
                }
            }

            foreach(Transaction t in anticipation!.Transactions!){
                if(t.DateAccepted != null)
                    accepted++;
                if(t.DateRejected != null)
                    rejected++;
            }

            count = transactions.Count();
            if(accepted + rejected == count){
                if(rejected == count)
                    anticipation.AnalysisState = EAnticipationStatus.Rejected;
                else
                    if(accepted == count)
                        anticipation.AnalysisState = EAnticipationStatus.Accepted;
                    else
                        anticipation.AnalysisState = EAnticipationStatus.PartialAccepted;
            }

            context.Transactions!.UpdateRange(transactions);
            context.Anticipations!.Update(anticipation);
            changes = await context.SaveChangesAsync();

            return changes;
        }

    }
}
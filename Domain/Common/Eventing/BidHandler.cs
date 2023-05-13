using Domain.Core;

namespace Domain.Common.Eventing
{
    public class BidHandler
    {
        private static int bidId = 0;
        private readonly int _bidId;

        public BidHandler()
        {
            if(bidId >= int.MaxValue) bidId = 0;
            bidId++;
            _bidId = bidId;
        }

        public void Handle(Vehicle sender, BidEvent e)
        {
            try
            {
                Console.WriteLine($"Oferta {_bidId} w wysokości {e.Amount} została złożona. Aktualnie cena pojazdu {sender.Id} wynosi {sender.Price}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}

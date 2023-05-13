namespace Domain.Common.Eventing
{
    public class BidEvent : EventArgs
    {
        public int Amount { get; }

        public BidEvent(int amount)
        {
            Amount = amount;
        }
    }
}

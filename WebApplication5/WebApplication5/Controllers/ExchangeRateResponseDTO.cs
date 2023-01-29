namespace WebApplication5.Controllers
{
    public class ExchangeRateResponseDTO
    {
        public double CurrentChange;
        public double CurrentExchangeRate;
        public string Key;
        public string LastUpdate;
        public int Unit;
        public ExchangeRateResponseDTO(double CurrentChange,double CurrentExchangeRate,string Key, string LastUpdate, int Unit)
        {
            this.CurrentChange = CurrentChange; 
            this.CurrentExchangeRate = CurrentExchangeRate;
            this.Key = Key;
            this.LastUpdate = LastUpdate;
            this.Unit = Unit;
        }
    }
}

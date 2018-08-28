namespace dotnet_code_challenge.Requests
{
    public class GetHorsesWithPriceRequest
    {
        public string FeedId { get; set; }

        public int RaceNumber { get; set; } = 1;
    }
}

namespace TechStore.API.APIModels
{
    public class APIResponse<TDados> where TDados : class
    {
        public TDados Data { get; set; }

        public APIResponse(TDados data)
            => Data = data; 
    }
}

namespace WKTechnology.Application.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        public BaseHttpService(IClient client)
        {
            _client = client;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Inputs inválidos", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "O registro não foi encontrado.", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Algo deu errado, tente novamente mais tarde.", Success = false };
            }
        }
    }
}

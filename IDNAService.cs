using DNA.Requests;
using DNA.Responses;

public interface IDNAService
{
    Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
    Task<LoginUserResponse> LoginUserAsync(LoginUserRequest request);
    Task<GetJobResponse> GetJobAsync(GetJobRequest request);
    Task ProcessJobAsync(LoginUserResponse loginUserResponse, GetJobResponse getJobResponse);
    Task<StrandResponse> StrandAsync(StrandRequest request);
    Task<StrandEncodedResponse> StrandEncodedAsync(StrandEncodedRequest request);
    Task<GeneResponse> CheckGeneAsync(GeneRequest request);
}

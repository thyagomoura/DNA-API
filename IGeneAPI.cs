using DNA.Requests;
using DNA.Responses;
using Refit;

public interface IGeneAPI
{
    [Post("/api/users/create")]
    Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);

    [Post("/api/users/login")]
    Task<LoginUserResponse> LoginUserAsync(LoginUserRequest request);

    [Get("/api/dna/jobs")]
    Task<GetJobResponse> GetJobAsync([Authorize("Bearer")] string token);

    [Post("/api/dna/jobs/{id}/decode")]
    Task<StrandResponse> StrandAsync(string id, [Authorize("Bearer")] string token);

    [Post("/api/dna/jobs/{id}/encode")]
    Task<StrandEncodedResponse> StrandEncodedAsync(string id, [Authorize("Bearer")] string token);

    [Post("/api/dna/jobs/{id}/gene")]
    Task<GeneResponse> CheckGeneAsync(string id, [Authorize("Bearer")] string token);
}

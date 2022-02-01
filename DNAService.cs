using DNA.Requests;
using DNA.Responses;
using Refit;

public class DNAService : IDNAService
{
    private readonly IGeneAPI _geneAPI;

    public DNAService(string apiUrl)
    {
        _geneAPI = RestService.For<IGeneAPI>(apiUrl);
    }

    public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
    {
        var createUserResponse = await _geneAPI.CreateUserAsync(request);

        Console.WriteLine("Username: " + request.Username);

        Console.WriteLine("Password: " + request.Password);

        return createUserResponse;
    }
    public async Task<LoginUserResponse> LoginUserAsync(LoginUserRequest request)

    {
        var loginUserResponse = await _geneAPI.LoginUserAsync(request);

        Console.WriteLine("AccesToken: " + loginUserResponse.AccessToken);

        return loginUserResponse;
    }
    public async Task<GetJobResponse> GetJobAsync(GetJobRequest request)
    {
        var getJobResponse = await _geneAPI.GetJobAsync(request.Token);

        return getJobResponse;
    }

    public async Task ProcessJobAsync(LoginUserResponse loginUserResponse, GetJobResponse getJobResponse)
    {
        switch (getJobResponse.Job.Type)
        {
            case "DecodeStrand":
                var strandRequest = new StrandRequest()
                {
                    Token = loginUserResponse.AccessToken,
                    IdJob = getJobResponse.Job.Id,
                    Strand = getJobResponse.Job.Strand,
                };

                var strandResponse = await StrandAsync(strandRequest);

                break;

            case "EncodeStrand":
                var strandEncodedRequest = new StrandEncodedRequest()
                {
                    Token = loginUserResponse.AccessToken,
                    IdJob = getJobResponse.Job.Id,
                    StrandEncoded = getJobResponse.Job.StrandEncoded
                };

                var strandEncodedResponse = await StrandEncodedAsync(strandEncodedRequest);

                break;

            case "CheckGene":
                var geneRequest = new GeneRequest()
                {
                    Token = loginUserResponse.AccessToken,
                    IdJob = getJobResponse.Job.Id,
                    IsActivated = getJobResponse.Job.GeneEncoded
                };

                var geneResponse = await CheckGeneAsync(geneRequest);

                break;
        }

    }

    public async Task<StrandResponse> StrandAsync(StrandRequest request)
    {
        Console.WriteLine("Processing Strand Job...");

        // var strandResponse = await _geneAPI.StrandAsync(request.IdJob, request.Token);

        // return strandResponse;

        return await Task.FromResult<StrandResponse>(null);
    }
    public async Task<StrandEncodedResponse> StrandEncodedAsync(StrandEncodedRequest request)
    {
        Console.WriteLine("Processing Strand Encoded Job...");

        // var strandEncodedResponse = await _geneAPI.StrandEncodedAsync(request.IdJob, request.Token);

        // return strandEncodedResponse;

        return await Task.FromResult<StrandEncodedResponse>(null);
    }
    public async Task<GeneResponse> CheckGeneAsync(GeneRequest request)
    {
        Console.WriteLine("Processing Check Gene Job...");

        // var geneResponse = await _geneAPI.GeneAsync(request.IdJob, request.Token);

        // return geneResponse;

        return await Task.FromResult<GeneResponse>(null);
    }
}
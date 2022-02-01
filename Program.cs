using DNA.Requests;

IDNAService dnaService = new DNAService("https://gene.lacuna.cc");

var createUserRequest = new CreateUserRequest()
{
    Username = Guid.NewGuid().ToString()[..8],
    Email = $"{Guid.NewGuid()}@test.com",
    Password = Guid.NewGuid().ToString()[..8]
};

var createUserResponse = await dnaService.CreateUserAsync(createUserRequest);

// TODO CHECK IS USER WAS CREATED SUCCESSFULLY 

var loginUserRequest = new LoginUserRequest()
{
    Username = createUserRequest.Username,
    Password = createUserRequest.Password,
};

var loginUserResponse = await dnaService.LoginUserAsync(loginUserRequest);

// TODO CHECK IS USER WAS LOGGED SUCCESSFULLY 

var getJobRequest = new GetJobRequest()
{
    Token = loginUserResponse.AccessToken
};

var getJobResponse = await dnaService.GetJobAsync(getJobRequest);

// TODO CHECK WORK RECEIVED SUCCESSFULLY
await dnaService.ProcessJobAsync(loginUserResponse, getJobResponse);

Console.WriteLine("Process Finished!");

Console.ReadKey();
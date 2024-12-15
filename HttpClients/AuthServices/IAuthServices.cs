using System.Security.Claims;
using Domain.Models;
using Task = Domain.Models.Task;

namespace HttpClients.AuthServices;

public interface IAuthService
{
    public System.Threading.Tasks.Task LoginAsync(string username, string password);
    public System.Threading.Tasks.Task LogoutAsync();
    public System.Threading.Tasks.Task RegisterAsync(AuthenticationUser user);
    public Task<ClaimsPrincipal> GetAuthAsync();
    
   public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}
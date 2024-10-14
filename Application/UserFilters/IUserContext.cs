
using Domain.Abstractions;

namespace Application.UserFilters;

public interface IUserContext 
{
    public int UserId { get; set; }
    public string UserName { get; set; }
}
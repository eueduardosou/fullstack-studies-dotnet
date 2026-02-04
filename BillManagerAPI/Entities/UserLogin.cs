namespace BillManagerAPI.Entities;

public sealed class UserLogin
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
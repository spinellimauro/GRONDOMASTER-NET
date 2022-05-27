using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    public bool FirstLogin { get; set; }
    public DateTime? FirstLoginDate { get; set; }
    public DateTime? LastPasswordChangedDate { get; set; }
    public DateTime? LastLoginTime { get; set; }
    public DT Usuario { get; set; }
}
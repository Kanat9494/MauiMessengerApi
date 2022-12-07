﻿namespace MauiMessengerApi.Functions.User;

public class UserDTO
{
    public int UserId { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string AvatarSourceName { get; set; } = null!;
    public bool IsOnline { get; set; }
    public DateTime LastLogonTime { get; set; }
    public string Token { get; set; } = null!;
}

namespace MauiMessengerApi.Models;

public class ChatUserContext : DbContext
{
    public ChatUserContext(DbContextOptions<ChatUserContext> options) : base(options)
    { }

    public virtual DbSet<ChatUser> ChatUsers { get; set; }
}

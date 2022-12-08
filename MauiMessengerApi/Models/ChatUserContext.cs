namespace MauiMessengerApi.Models;

public class ChatUserContext : DbContext
{
    public ChatUserContext(DbContextOptions<ChatUserContext> options) : base(options)
    { }

    public virtual DbSet<ChatUser> ChatUsers { get; set; }
    public virtual DbSet<ChatUserFriend> ChatUserFriends { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
}

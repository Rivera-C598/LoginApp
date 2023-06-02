using SQLite;

namespace LoginApp
{
    internal class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
    }
}

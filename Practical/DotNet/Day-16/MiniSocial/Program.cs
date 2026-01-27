using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    // TASK 1: Custom Exception
    public class SocialException : Exception
    {
        public SocialException(string message) : base(message) { }
        public SocialException(string message, Exception inner) : base(message, inner) { }
    }

    // TASK 2: Posting Interface
    public interface IPostable
    {
        void AddPost(string content);
        IReadOnlyList<Post> GetPosts();
    }

    // TASK 3: Post Class
    public class Post
    {
        public User Author { get; }
        public string Content { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;

        public Post(User author, string content)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            Author = author;
            Content = content;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine(Content);

            var hashtags = Regex.Matches(Content, @"#([A-Za-z]+)");
            if (hashtags.Count > 0)
            {
                sb.Append("Tags: ");
                sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
            }

            return sb.ToString().TrimEnd();
        }
    }

    // TASK 4: User Class (Partial – Core)
    public partial class User : IPostable, IComparable<User>
    {
        public string Username { get; init; }
        public string Email { get; init; }

        private readonly List<Post> _posts = new();
        private readonly HashSet<string> _following = new(StringComparer.OrdinalIgnoreCase);

        public event Action<Post>? OnNewPost;

        public User(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("username");

            if (!Regex.IsMatch(email ?? "", @"^[^@]+@[^@]+\.[^@]+$"))
                throw new SocialException("Invalid email format");

            Username = username.Trim();
            Email = email.Trim().ToLowerInvariant();
        }

        public void Follow(string username)
        {
            if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Cannot follow yourself");

            _following.Add(username);
        }

        public bool IsFollowing(string username)
            => _following.Contains(username);

        public void AddPost(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Post content cannot be empty");

            if (content.Length > 280)
                throw new SocialException("Post too long (max 280 characters)");

            var post = new Post(this, content.Trim());
            _posts.Add(post);
            OnNewPost?.Invoke(post);
        }

        public IReadOnlyList<Post> GetPosts()
            => _posts.AsReadOnly();

        public int CompareTo(User? other)
        {
            if (other == null) return 1;
            return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
            => $"@{Username}";
    }

    // TASK 5: User Partial Extension
   
    public partial class User
    {
        public string GetDisplayName()
            => $"User: {Username} <{Email}>";
    }

    // TASK 6: Generic Repository
    public class Repository<T> where T : class
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);

        public IReadOnlyList<T> GetAll() => _items.AsReadOnly();

        public T? Find(Predicate<T> match)
            => _items.Find(match);
    }

    // TASK 7: Time Utility (Extension Method)
    public static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime date)
        {
            var diff = DateTime.UtcNow - date;

            if (diff.TotalSeconds < 60)
                return "just now";
            if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes} min ago";
            if (diff.TotalHours < 24)
                return $"{(int)diff.TotalHours} h ago";

            return date.ToString("MMM dd");
        }
    }

    // TASK 8: Helper Extensions
    public static class UserExtensions
    {
        public static IEnumerable<string> GetFollowingNames(this User user)
            => user == null ? Enumerable.Empty<string>() : new List<string>();
    }

    // TASK 9: Program (Console App Controller)
    public class Program
    {
        private static readonly Repository<User> _users = new();
        private static User? _currentUser;
        private const string _dataFile = "minisocial.json";

        static void Main()
        {
            Console.Title = "MiniSocial";
            LoadData();

            while (true)

            
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("=== MiniSocial ===\n");

                    if (_currentUser == null)
                        ShowLoginMenu();
                    else
                        ShowMainMenu();
                }
                catch (SocialException ex)
                {
                    ConsoleColorWrite(ex.Message, ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    ConsoleColorWrite("Unexpected error occurred", ConsoleColor.Red);
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }

        static void ShowLoginMenu()
        {
            Console.WriteLine("1. Register\n2. Login\n3. Exit");
            switch (Console.ReadLine())
            {
                case "1": Register(); break;
                case "2": Login(); break;
                case "3": SaveData(); Environment.Exit(0); break;
                default: throw new SocialException("Invalid menu choice");
            }
        }

        static void Register()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();

            if (_users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)) != null)
                throw new SocialException("Username already exists");

            var user = new User(username!, email!);
            _users.Add(user);
            ConsoleColorWrite("Registration successful", ConsoleColor.Green);
        }

        static void Login()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            var user = _users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                throw new SocialException("User not found");

            _currentUser = user;
            _currentUser.OnNewPost += p =>
            {
                if (_currentUser!.IsFollowing(p.Author.Username))
                    ConsoleColorWrite($"New post from {p.Author}", ConsoleColor.Cyan);
            };

            ConsoleColorWrite("Login successful", ConsoleColor.Green);
        }

        static void ShowMainMenu()
        {
            Console.WriteLine($"Logged in as {_currentUser}\n");
            Console.WriteLine("1. Post\n2. My Posts\n3. Timeline\n4. Follow\n5. Users\n6. Logout\n7. Exit");

            switch (Console.ReadLine())
            {
                case "1": PostMessage(); break;
                case "2": ShowPosts(_currentUser!.GetPosts()); break;
                case "3": ShowTimeline(); break;
                case "4": FollowUser(); break;
                case "5": ListUsers(); break;
                case "6": _currentUser = null; break;
                case "7": SaveData(); Environment.Exit(0); break;
                default: throw new SocialException("Invalid menu choice");
            }
        }

        static void PostMessage()
        {
            Console.Write("Post: ");
            var content = Console.ReadLine();
            if (string.IsNullOrEmpty(content)) return;
            _currentUser!.AddPost(content);
            ConsoleColorWrite("Post created", ConsoleColor.Green);
        }

        static void ShowTimeline()
        {
            var posts = _users.GetAll()
                .Where(u => u == _currentUser || _currentUser!.IsFollowing(u.Username))
                .SelectMany(u => u.GetPosts())
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            ShowPosts(posts);
        }

        static void ShowPosts(IEnumerable<Post> posts)
        {
            if (!posts.Any())
            {
                Console.WriteLine("No posts available");
                return;
            }

            foreach (var post in posts.Take(10))
            {
                Console.WriteLine(post);
                Console.WriteLine($"({post.CreatedAt.FormatTimeAgo()})");
                Console.WriteLine(new string('-', 30));
            }
        }

        static void FollowUser()
        {
            Console.Write("Follow username: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name)) return;

            if (_users.Find(u => u.Username.Equals(name, StringComparison.OrdinalIgnoreCase)) == null)
                throw new SocialException("User not found");

            _currentUser!.Follow(name);
            ConsoleColorWrite($"Now following {name}", ConsoleColor.Green);
        }

        static void ListUsers()
        {
            foreach (var user in _users.GetAll().OrderBy(u => u))
                Console.WriteLine(user.GetDisplayName());
        }

        static void SaveData()
        {
            try
            {
                var json = JsonSerializer.Serialize(_users.GetAll());
                File.WriteAllText(_dataFile, json);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        static void LoadData()
        {
            if (!File.Exists(_dataFile)) return;

            try
            {
                var json = File.ReadAllText(_dataFile);
                var users = JsonSerializer.Deserialize<List<User>>(json);
                if (users != null)
                    users.ForEach(u => _users.Add(u));
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        static void LogError(Exception ex)
        {
            try
            {
                File.AppendAllText("error.log",
                    $"{DateTime.Now}\n{ex.Message}\n{ex.StackTrace}\n\n");
            }
            catch { }
        }

        static void ConsoleColorWrite(string message, ConsoleColor color)
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = prev;
        }
    
}

}
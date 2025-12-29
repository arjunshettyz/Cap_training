using System;
enum UserRole { Admin, Librarian, Member }
enum ItemStatus { Available, Borrowed, Reserved, Lost }

namespace LibrarySystem
{
    namespace Items
    {
        class Book
        {
            public void Show()
            {
                Console.WriteLine("This is a Book");
            }
        }
        class Magazine
        {
            public void Show()
            {
                Console.WriteLine("This is a Magazine");
            }
        }
    }
    namespace Users
    {
        class Member
        {
            public string Name { get; set; }
            public UserRole Role { get; set; }

            public void ShowRole()
            {
                Console.WriteLine($"{Name} has role: {Role}");
            }
        }
    }
    
}
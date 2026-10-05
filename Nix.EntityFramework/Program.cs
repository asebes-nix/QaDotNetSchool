using Microsoft.EntityFrameworkCore;
using Nix.EntityFramework;

using (var db = new BloggingContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    var blog = new Blog
    {
        Url = "https://nix-qa-automation-school.blog",
        Posts =
        [
            new Post { Title = "RestSharp API testing", Content = "Sending requests and validating JSON responses." },
            new Post { Title = "NUnit Constraint model", Content = "Why Assert.That() beats the Classic model." },
            new Post { Title = "Entity Framework for test data", Content = "Seeding and cleaning test data without raw SQL." }
        ]
    };

    db.Blogs.Add(blog);
    db.SaveChanges();
}

PrintBlog("Data after adding:");

using (var db = new BloggingContext())
{
    var post = db.Posts.Find(1);

    if (post is not null)
    {
        Console.WriteLine($"\nPost found by id: {post.PostId}. {post.Title}");
    }
}

using (var db = new BloggingContext())
{
    var postToEdit = db.Posts.Find(1);

    if (postToEdit is not null)
    {
        postToEdit.Title = "RestSharp API testing with NUnit";
        postToEdit.Content = "API requests asserted with the Constraint model.";
    }

    var postToDelete = db.Posts.Find(2);

    if (postToDelete is not null)
    {
        db.Posts.Remove(postToDelete);
    }

    db.SaveChanges();
}

PrintBlog("\nData after editing and deleting:");

static void PrintBlog(string header)
{
    using var db = new BloggingContext();

    var blog = db.Blogs
        .Include(b => b.Posts)
        .First();

    Console.WriteLine(header);
    Console.WriteLine($"Blog: {blog.Url}");

    foreach (var post in blog.Posts.OrderBy(p => p.PostId))
    {
        Console.WriteLine($"{post.PostId}. {post.Title} - {post.Content}");
    }
}
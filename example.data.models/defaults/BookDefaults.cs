using example.data.models.contexts;

namespace example.data.models.defaults;

public static class BookDefaults
{
    public static void PopulateDatabase(ref ILibraryContext context)
    {
        var mariner = new Publisher
        {
            Name = "Mariner Books",
            Id = "MB1"
        };

        if (context.Contains(mariner)) return;

        var jollyRoger = new Publisher
        {
            Name = "Jolly Roger Publications",
            Id = "JRP"
        };

        context.AddToDbSet(new Book
        {
            ISBN = "978-0543003415",
            Title = "The Lord of the Rings",
            Author = "J.R.R. Tolkien",
            Language = "English",
            Publisher = mariner
        });
        context.AddToDbSet(new Book
        {
            ISBN = "978-0543010219",
            Title = "Fly Fishing",
            Author = "J.R Hartley",
            Language = "Polish",
            Publisher = jollyRoger
        });
        context.AddToDbSet(new Book
        {
            ISBN = "978-0547247762",
            Title = "The Sealed Letter",
            Author = "Emma Donoghue",
            Language = "English",
            Publisher = mariner
        });

        context.SaveChanges();
    }

}

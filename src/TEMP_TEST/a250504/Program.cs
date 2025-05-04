// See https://aka.ms/new-console-template for more information
using a250504;
using Microsoft.EntityFrameworkCore.Query.Internal;

Console.WriteLine("Hello, World!");

using var db = new AppDbContext();
db.Add(new Note { Name = "Note-11", NoteType = NoteTypes.Active });
db.Add(new Record { Name = "Record-22", RecordType = Record.RecordTypes.Active });
await db.SaveChangesAsync();

Console.WriteLine("All done.");

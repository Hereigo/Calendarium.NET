namespace a250504;

public class Note
{
    public int NoteId { get; set; }

    public required string Name { get; set; }

    public NoteTypes NoteType { get; set; }
}

public enum NoteTypes
{
    Active,
    Inactive,
    Deleted
}
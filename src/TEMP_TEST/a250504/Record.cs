namespace a250504;

public class Record
{
    public int RecordId { get; set; }

    public required string Name { get; set; }

    public RecordTypes RecordType { get; set; }

    public enum RecordTypes
    {
        Active,
        Inactive,
        Deleted
    }

}
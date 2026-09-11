public class Transaction
{
    public int TransactionId { get; set; }

    public string SoldierName { get; set; } = "";

    public string SoldierRank { get; set; } = "";

    public string EquipmentName { get; set; } = "";

    public string SerialNumber { get; set; } = "";

    public string Action { get; set; } = "";

    public DateTime DateTime { get; set; }

    public bool Verified { get; set; }
}
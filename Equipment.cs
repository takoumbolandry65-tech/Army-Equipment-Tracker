public class Equipment
{
    public int EquipmentId { get; set; }

    public string Name { get; set; } = "";

    public string SerialNumber { get; set; } = "";

    public string Category { get; set; } = "";

    public string Location { get; set; } = "";

    public string Status { get; set; } = "IN";

    public string AssignedSoldier { get; set; } = "";
}
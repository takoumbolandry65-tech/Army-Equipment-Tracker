public class InventoryManager
{
    private List<Equipment> equipmentList = new List<Equipment>();
    private List<Transaction> transactionHistory = new List<Transaction>();

    public void AddEquipment(Equipment equipment)
    {
        equipmentList.Add(equipment);
        Console.WriteLine("Equipment added successfully.");
    }

    public void DisplayAllEquipment()
    {
        Console.WriteLine();
        Console.WriteLine("===== ALL EQUIPMENT =====");

        if (equipmentList.Count == 0)
        {
            Console.WriteLine("No equipment found.");
            return;
        }

        foreach (Equipment equipment in equipmentList)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"ID: {equipment.EquipmentId}");
            Console.WriteLine($"Name: {equipment.Name}");
            Console.WriteLine($"Serial Number: {equipment.SerialNumber}");
            Console.WriteLine($"Category: {equipment.Category}");
            Console.WriteLine($"Location: {equipment.Location}");
            Console.WriteLine($"Status: {equipment.Status}");
        }
    }
 
    public Equipment? SearchBySerialNumber(string serialNumber)
    {
        foreach (Equipment equipment in equipmentList)
        {
            if (equipment.SerialNumber.Equals(
                serialNumber,
                StringComparison.OrdinalIgnoreCase))
            {
                return equipment;
            }
        }

        return null;
}
public void IssueEquipment(
    string serialNumber,
    Soldier soldier)
{
    Equipment? equipment = SearchBySerialNumber(serialNumber);

    if (equipment == null)
    {
        Console.WriteLine("Equipment not found.");
        return;
    }

    if (equipment.Status == "OUT")
    {
        Console.WriteLine();
        Console.WriteLine("ERROR: This equipment is already issued.");
        Console.WriteLine($"Currently assigned to: {equipment.AssignedSoldier}");
        return;
    }

    equipment.Status = "OUT";
    equipment.AssignedSoldier = $"{soldier.Rank} {soldier.Name}";

    Transaction transaction = new Transaction();

    transaction.TransactionId = transactionHistory.Count + 1;
    transaction.SoldierName = soldier.Name;
    transaction.SoldierRank = soldier.Rank;
    transaction.EquipmentName = equipment.Name;
    transaction.SerialNumber = equipment.SerialNumber;
    transaction.Action = "OUT";
    transaction.DateTime = DateTime.Now;
    transaction.Verified = true;

    transactionHistory.Add(transaction);

    Console.WriteLine();
    Console.WriteLine("Equipment issued successfully!");
    Console.WriteLine($"Equipment: {equipment.Name}");
    Console.WriteLine($"Serial Number: {equipment.SerialNumber}");
    Console.WriteLine($"Issued To: {soldier.Rank} {soldier.Name}");
    Console.WriteLine($"Date/Time: {transaction.DateTime}");
}
public void ReturnEquipment(string serialNumber)
{
    Equipment? equipment = SearchBySerialNumber(serialNumber);

    if (equipment == null)
    {
        Console.WriteLine("Equipment not found.");
        return;
    }

    if (equipment.Status == "IN")
    {
        Console.WriteLine();
        Console.WriteLine("ERROR: This equipment is already IN.");
        return;
    }

    string soldierName = equipment.AssignedSoldier;

    Transaction transaction = new Transaction();

    transaction.TransactionId = transactionHistory.Count + 1;
    transaction.SoldierName = soldierName;
    transaction.SoldierRank = "";
    transaction.EquipmentName = equipment.Name;
    transaction.SerialNumber = equipment.SerialNumber;
    transaction.Action = "IN";
    transaction.DateTime = DateTime.Now;
    transaction.Verified = true;

    transactionHistory.Add(transaction);

    equipment.Status = "IN";
    equipment.AssignedSoldier = "";

    Console.WriteLine();
    Console.WriteLine("Equipment returned successfully!");
    Console.WriteLine($"Equipment: {equipment.Name}");
    Console.WriteLine($"Serial Number: {equipment.SerialNumber}");
    Console.WriteLine($"Returned By: {soldierName}");
    Console.WriteLine($"Status: {equipment.Status}");
    Console.WriteLine($"Date/Time: {transaction.DateTime}");
}
public void DisplayTransactionHistory()
{
    Console.WriteLine();
    Console.WriteLine("===== TRANSACTION HISTORY =====");

    if (transactionHistory.Count == 0)
    {
        Console.WriteLine("No transactions found.");
        return;
    }

    foreach (Transaction transaction in transactionHistory)
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine($"Transaction ID: {transaction.TransactionId}");
        Console.WriteLine($"Soldier: {transaction.SoldierRank} {transaction.SoldierName}");
        Console.WriteLine($"Equipment: {transaction.EquipmentName}");
        Console.WriteLine($"Serial Number: {transaction.SerialNumber}");
        Console.WriteLine($"Action: {transaction.Action}");
        Console.WriteLine($"Date/Time: {transaction.DateTime}");
        Console.WriteLine($"Verified: {transaction.Verified}");
    }
}
}
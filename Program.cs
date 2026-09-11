Console.WriteLine("========================================");
Console.WriteLine("       ARMS ROOM EQUIPMENT TRACKER");
Console.WriteLine("========================================");

InventoryManager manager = new InventoryManager();

// Temporary equipment for testing
Equipment equipment1 = new Equipment();

equipment1.EquipmentId = 1;
equipment1.Name = "Dell Laptop";
equipment1.SerialNumber = "DL-10001";
equipment1.Category = "Computer";
equipment1.Location = "S4 Office";
equipment1.Status = "IN";

manager.AddEquipment(equipment1);

Equipment equipment2 = new Equipment();

equipment2.EquipmentId = 2;
equipment2.Name = "Motorola Radio";
equipment2.SerialNumber = "MR-20001";
equipment2.Category = "Communication";
equipment2.Location = "Supply Room";
equipment2.Status = "IN";

manager.AddEquipment(equipment2);

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("========================================");
    Console.WriteLine("              MAIN MENU");
    Console.WriteLine("========================================");
    Console.WriteLine("1. View All Equipment");
    Console.WriteLine("2. Search Equipment");
    Console.WriteLine("3. Issue Equipment");
    Console.WriteLine("4. Return Equipment");
    Console.WriteLine("5. View Transaction History");
    Console.WriteLine("6. Exit");
    Console.WriteLine("========================================");

    Console.Write("Select an option: ");

    string choice = (Console.ReadLine() ?? "").Trim();

    switch (choice)
    {
        case "1":
            manager.DisplayAllEquipment();
            break;

        case "2":
            Console.Write("Enter serial number: ");
            string searchSerial = Console.ReadLine() ?? "";

            Equipment? foundEquipment =
                manager.SearchBySerialNumber(searchSerial);

            if (foundEquipment != null)
            {
                Console.WriteLine();
                Console.WriteLine("Equipment Found!");
                Console.WriteLine($"Name: {foundEquipment.Name}");
                Console.WriteLine($"Serial Number: {foundEquipment.SerialNumber}");
                Console.WriteLine($"Category: {foundEquipment.Category}");
                Console.WriteLine($"Location: {foundEquipment.Location}");
                Console.WriteLine($"Status: {foundEquipment.Status}");

                if (foundEquipment.Status == "OUT")
                {
                    Console.WriteLine(
                        $"Assigned To: {foundEquipment.AssignedSoldier}");
                }
            }
            else
            {
                Console.WriteLine("Equipment not found.");
            }

            break;

        case "3":
            Soldier soldier = new Soldier();

            Console.Write("Enter Soldier name: ");
            soldier.Name = Console.ReadLine() ?? "";

            Console.Write("Enter Soldier rank: ");
            soldier.Rank = Console.ReadLine() ?? "";

            Console.Write("Enter Soldier unit: ");
            soldier.Unit = Console.ReadLine() ?? "";

            Console.Write("Enter equipment serial number: ");
            string issueSerial = Console.ReadLine() ?? "";

            manager.IssueEquipment(issueSerial, soldier);
            break;

        case "4":
            Console.Write("Enter equipment serial number to return: ");
            string returnSerial = Console.ReadLine() ?? "";

            manager.ReturnEquipment(returnSerial);
            break;

        case "5":
            manager.DisplayTransactionHistory();
            break;

        case "6":
            Console.WriteLine();
            Console.WriteLine("Exiting Arms Room Equipment Tracker...");
            running = false;
            break;

        default:
            Console.WriteLine();
            Console.WriteLine(
                "Invalid selection. Please choose 1 through 6.");
            break;
    }
    if (running)
{
    Console.WriteLine();
    Console.WriteLine("Press ENTER to return to the main menu...");
    Console.ReadLine();
}
}
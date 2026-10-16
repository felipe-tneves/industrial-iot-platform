using IndustrialIoT.Domain;

namespace IndustrialIoT.Application;

public class EquipmentService
{
    private readonly List<Equipment> _equipments = new();

    public Equipment RegisterEquipments(string name, string code, string location)
    {
        var normalizedCode = code.Trim().ToUpperInvariant();

        bool codeAlreadyExists = _equipments.Any(
            equipment => equipment.Code == normalizedCode
        );

        if (codeAlreadyExists)
        {
            throw new InvalidOperationException(
                $"Já existe um equipamento registrado com o código '{normalizedCode}'."
            );
        }

        var equipment = new Equipment(name, normalizedCode, location);

        _equipments.Add(equipment);

        return equipment;
    }

    public List<Equipment> GetAllEquipments()
    {
        return _equipments.ToList();
    }
}

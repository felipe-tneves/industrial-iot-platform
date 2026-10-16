using IndustrialIoT.Domain;
using IndustrialIoT.Application;

namespace IndustrialIoT.Domain.Tests;

public class EquipmentTests
{
    // Testa a criação de um equipamento com dados válidos
    [Fact]
    public void Constructor_WithValidData_CreatesEquipment()
    {
        var equipment = new Equipment(
            name: "Motor Princiapal",
            code: "EQ001",
            location: "Setor de Produção"
        );

        // Verifica se o equipamento foi criado corretamente
        Assert.NotEqual(Guid.Empty, equipment.Id);
        Assert.Equal("Motor Princiapal", equipment.Name);
        Assert.Equal("EQ001", equipment.Code);
        Assert.Equal("Setor de Produção", equipment.Location);
        Assert.True(equipment.IsActive);

        // Verifica se a data de criação está próxima do momento atual
        Assert.True((DateTime.UtcNow - equipment.CreatedAtUtc).TotalSeconds < 1);
    }

    // Testa a criação de um equipamento com nome vazio ou nulo
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_WithEmptyName_ThrowsException(string name)
    {
        Assert.Throws<ArgumentException>(() => new Equipment(name, "EQ001", "Setor de Produção"));
    }

    // Testa a criação de um equipamento com código vazio ou nulo
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_WithEmptyCode_ThrowsException(string code)
    {
        Assert.Throws<ArgumentException>(() => new Equipment("Motor Principal", code, "Setor de Produção"));
    }

    // Testa a criação de um equipamento com localização vazio ou nulo
    [Fact]
    public void Constructor_WithEmptyLocation_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Equipment("Motor Principal", "EQ001", ""));
    }

    // Testa a desativação de um equipamento
    [Fact]
    public void Deactivate_ChangesEquipmentStatus()
    {
        var equipment = new Equipment("Motor Principal", "EQ001", "Setor de Produção");
        equipment.Deactivate();

        Assert.False(equipment.IsActive);
    }

    // Testa a ativação de um equipamento
    [Fact]
    public void Activate_ChangesEquipmentStatus()
    {
        var equipment = new Equipment("Motor Principal", "EQ001", "Setor de Produção");
        equipment.Deactivate();
        equipment.Activate();

        Assert.True(equipment.IsActive);
    }

    [Fact]
    public void RegisterEquipments_WithValidData_ReturnsEquipment()
    {
        var service = new EquipmentService();
        var equipment = service.RegisterEquipments(
            "Motor Principal",
            "EQ001",
            "Setor de Produção");

        Assert.Equal("Motor Principal", equipment.Name);
        Assert.Equal("EQ001", equipment.Code);
        Assert.Single(service.GetAllEquipments());
    }

    [Fact]
    public void RegisterEquipments_WithDuplicateCode_ThrowsException()
    {
        var service = new EquipmentService();

        service.RegisterEquipments(
            "Motor Principal",
            "EQ001",
            "Setor de Produção"
        );

        Assert.Throws<InvalidOperationException>(() => service.RegisterEquipments("Outro Motor", "EQ001", "Setor de Manutenção"));

        Assert.Single(service.GetAllEquipments());
        
    }

    [Fact]
    public void GetAllEquipments_ReturnsAllRegisteredEquipments()
    {
        var service = new EquipmentService();

        service.RegisterEquipments("Motor Principal", "EQ001", "Setor de Produção");
        service.RegisterEquipments("Bomba Secundária", "EQ002", "Setor de Manutenção");

        var equipments = service.GetAllEquipments();

        Assert.Equal(2, equipments.Count);
        Assert.Contains(equipments, e => e.Code == "EQ001");
        Assert.Contains(equipments, e => e.Code == "EQ002");
    }
}

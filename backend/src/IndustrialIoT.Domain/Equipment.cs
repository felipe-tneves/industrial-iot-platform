namespace IndustrialIoT.Domain;

public class Equipment
{
    //Identificador único do equipamento
    public Guid Id { get; private set; }
    //Nome do equipamento
    public string Name { get; private set; }
    //Código do equipamento
    public string Code { get; private set; }
    //Localização do equipamento
    public string Location { get; private set; }
    //Indica se o equipamento está ativo
    public bool IsActive { get; private set; }
    //Data de criação do equipamento
    public DateTime CreatedAtUtc { get; private set; }

    // Construtor da classe Equipment
    public Equipment(string name, string code, string location)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do equipamento é obrigatório.", nameof(name));

        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("O código do equipamento é obrigatório.", nameof(code));

        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("A localização do equipamento é obrigatória.", nameof(location));

        Id = Guid.NewGuid();
        Name = name;
        Code = code;
        Location = location;
        IsActive = true;
        CreatedAtUtc = DateTime.UtcNow;

    }

    // Método para desativar o equipamento
    public void Deactivate()
    {
        IsActive = false;
    }

    // Método para ativar o equipamento
    public void Activate()
    {
        IsActive = true;
    }


}

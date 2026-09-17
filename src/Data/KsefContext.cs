namespace KsefGateway.Data;

public class KsefContext
{
	public Guid Id { get; set; }
	public string Nip { get; set; } = "";
	public string Environment { get; set; } = "";
}
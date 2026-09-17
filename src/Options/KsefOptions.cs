using System.ComponentModel.DataAnnotations;

namespace KsefGateway.Options;

public class KsefOptions
{
	[Required]
	public required string KsefToken { get; set; }

	[Required]
	public required string Environment { get; set; }
}
using Application.Enums;

namespace Application.DTO;

public record RegisterRequest(
    string? Email,
    string? Password,
    string? PersonName,
    string? Gender
    );

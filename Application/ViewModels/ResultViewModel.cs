using FluentValidation.Results;

namespace Application.ViewModels;

public class ResultViewModel
{
    public CustomerViewModel SucceedResult { get; set; }
    public bool IsLastStatusChange { get; set; }
    public ValidationResult FailedResults { get; set; }
}
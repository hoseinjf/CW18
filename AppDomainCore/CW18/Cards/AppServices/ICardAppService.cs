using App.Domain.Core.Golestan.Student.DTOs;

namespace App.Domain.Core.Golestan.Student.AppServices
{
    public interface ICardAppService
    {
        List<CardDto> GetCards();
    }
}

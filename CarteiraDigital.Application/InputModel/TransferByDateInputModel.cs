using CarteiraDigital.Domain.Entities;

namespace CarteiraDigital.Application.InputModel
{
    public class TransferByDateInputModel
    {
        public int Id { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        
    }
}

using System;
namespace FoodApp.Models.DataTransferObjects.Responses
{
    public class SuccessfulLoginResponseDTO
    {
        public string AccessToken { get; set; }

        public SuccessfulLoginResponseDTO()
        {
        }

        public SuccessfulLoginResponseDTO(string token)
        {
            AccessToken = token;
        }
    }
}

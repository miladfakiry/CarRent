using System.Text.Json.Serialization;

namespace CarRent.Car.Api.v1;

public class CarResponseDto
{
    public CarResponseDto(Domain.Car car)
    {
        Id = car.Id;
        CarNumber = car.CarNumber;
        Brand = car.Brand.Id.ToString();
        Type = car.Type.Id.ToString();
        CarClass = car.CarClass.Id.ToString();
    }
    public CarResponseDto(){}

    public Guid Id { get; set; }

    public string CarNumber { get; set; }

    public string Brand { get; set; }

    public string CarClass { get; set; }

    public string Type { get; set; }
}
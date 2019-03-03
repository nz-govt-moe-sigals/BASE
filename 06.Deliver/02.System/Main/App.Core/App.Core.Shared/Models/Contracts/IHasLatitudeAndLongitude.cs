namespace App.Core.Shared.Models
{
    public interface IHasLatitudeAndLongitude
    {
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
    }
}
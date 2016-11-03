namespace Arkitektum.NorgesAPI.KommuneData
{
    public interface IKommuneTjeneste
    {
        Kommune FinnKommuneMedNummer(string kommuneNummer);
    }
}
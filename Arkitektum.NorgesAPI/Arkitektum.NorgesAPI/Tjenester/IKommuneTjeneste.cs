namespace Arkitektum.NorgesAPI.Tjenester
{
    public interface IKommuneTjeneste
    {
        Kommune FinnKommuneMedNummer(string kommuneNummer);
    }
}
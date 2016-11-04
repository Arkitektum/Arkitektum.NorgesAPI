namespace Arkitektum.NorgesAPI.Tjenester
{
    public interface IFylkeTjeneste
    {
        Fylke FinnFylkeMedNummer(string kommuneNummer);
    }
}
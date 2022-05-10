namespace ApplicationCore.Interfaces
{
    public interface IQueryService<Tin, Tout>
    {
        IEnumerable<Tout> Run(Tin query);
    }
}

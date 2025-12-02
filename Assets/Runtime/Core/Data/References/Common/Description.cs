namespace Data.References.Common
{
    public abstract class Description : IIdentified
    {
        public string Id { get; }

        protected Description(string id)
        {
            Id = id;
        }
    }
}

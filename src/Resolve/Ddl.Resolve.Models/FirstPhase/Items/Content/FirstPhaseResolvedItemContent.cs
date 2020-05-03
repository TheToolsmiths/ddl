namespace Ddl.Resolve.Models.FirstPhase.Items.Content
{
    public abstract class FirstPhaseResolvedItemContent
    {
        protected FirstPhaseResolvedItemContent(FirstPhaseResolvedItemType contentType)
        {
            this.ContentType = contentType;
        }

        public FirstPhaseResolvedItemType ContentType { get; }
    }
}

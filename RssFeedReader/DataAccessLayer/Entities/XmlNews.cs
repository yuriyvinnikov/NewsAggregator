namespace RssFeedReader.DataAccessLayer.Entities
{
    public class XmlNews : BaseEntity
    {
        public int NewsStorageMetaDataId { get; set; }

        public string Xml { get; set; }
    }
}

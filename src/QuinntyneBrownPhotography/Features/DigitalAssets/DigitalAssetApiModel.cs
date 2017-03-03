using QuinntyneBrownPhotography.Data.Models;
using System;

namespace QuinntyneBrownPhotography.Features.DigitalAssets
{
    public class DigitalAssetApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? FileModified { get; set; }
        public long? Size { get; set; }
        public string ContentType { get; set; }
        public string RelativePath { get; set; }
        public Byte[] Bytes { get; set; } = new byte[0];
        public Guid? UniqueId { get; set; } = Guid.NewGuid();

        public static TModel FromDigitalAsset<TModel>(DigitalAsset digitalAsset) where
            TModel : DigitalAssetApiModel, new()
        {
            var model = new TModel();
            model.Id = digitalAsset.Id;
            model.Name = digitalAsset.Name;
            model.Description = digitalAsset.Description;
            return model;
        }

        public static DigitalAssetApiModel FromDigitalAsset(DigitalAsset digitalAsset)
            => FromDigitalAsset<DigitalAssetApiModel>(digitalAsset);
    }
}

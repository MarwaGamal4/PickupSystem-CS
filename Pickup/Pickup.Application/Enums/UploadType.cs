using System.ComponentModel;

namespace Pickup.Application.Enums
{
    public enum UploadType
    {
        [Description(@"Images\Products")]
        Product,

        [Description(@"Images\ProfilePictures")]
        ProfilePicture,

        [Description(@"Documents")]
        Document,

        [Description(@"Images\Invoices")]
        Invoice,

        [Description(@"Images\Invoices\InternalInv")]
        internal_Inv
    }
}
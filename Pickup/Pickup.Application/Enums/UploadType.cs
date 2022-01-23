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

        [Description(@"Documents\Invoices")]
        Invoice,

        [Description(@"Documents\Invoices\TransactionInvoices")]
        internal_Inv
    }
}
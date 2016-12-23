using System;
namespace GHQ.Logic.Models.Response
{

    public class PhtotGalleryRespose
    {
        public PhtotGalleryD d { get; set; }
    }

    public class PhtotGalleryD
    {
        public PhtotGalleryResposeResult[] results { get; set; }
    }

    public class PhtotGalleryResposeResult
    {
        public __Metadata __metadata { get; set; }
        public Author Author { get; set; }
        public Checkedoutbyuser CheckedOutByUser { get; set; }
        public Listitemallfields ListItemAllFields { get; set; }
        public Lockedbyuser LockedByUser { get; set; }
        public Modifiedby ModifiedBy { get; set; }
        public Versions Versions { get; set; }
        public string CheckInComment { get; set; }
        public int CheckOutType { get; set; }
        public string ContentTag { get; set; }
        public int CustomizedPageStatus { get; set; }
        public string ETag { get; set; }
        public bool Exists { get; set; }
        public string Length { get; set; }
        public int Level { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public string Name { get; set; }
        public string ServerRelativeUrl { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public object Title { get; set; }
        public int UIVersion { get; set; }
        public string UIVersionLabel { get; set; }
    }



    public class Author
    {
        public __Deferred __deferred { get; set; }
    }


    public class Checkedoutbyuser
    {
        public __Deferred1 __deferred { get; set; }
    }

    public class Listitemallfields
    {
        public __Deferred2 __deferred { get; set; }
    }


    public class Lockedbyuser
    {
        public __Deferred3 __deferred { get; set; }
    }


    public class Modifiedby
    {
        public __Deferred4 __deferred { get; set; }
    }


    public class Versions
    {
        public __Deferred5 __deferred { get; set; }
    }


}

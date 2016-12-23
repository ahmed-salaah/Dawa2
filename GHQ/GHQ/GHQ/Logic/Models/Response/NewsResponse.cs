using System;
namespace GHQ.Logic.Models.Response
{
    public class NewsResponse
    {
        public D d { get; set; }
    }

    public class D
    {
        public Result[] results { get; set; }
    }

    public class Result
    {
        public __Metadata __metadata { get; set; }
        public Firstuniqueancestorsecurableobject FirstUniqueAncestorSecurableObject { get; set; }
        public Roleassignments RoleAssignments { get; set; }
        public Attachmentfiles AttachmentFiles { get; set; }
        public Contenttype ContentType { get; set; }
        public Fieldvaluesashtml FieldValuesAsHtml { get; set; }
        public Fieldvaluesastext FieldValuesAsText { get; set; }
        public Fieldvaluesforedit FieldValuesForEdit { get; set; }
        public File File { get; set; }
        public Folder Folder { get; set; }
        public Parentlist ParentList { get; set; }
        public int FileSystemObjectType { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string EventDescription { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ContentTypeId { get; set; }
        public int ID { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public int AuthorId { get; set; }
        public int EditorId { get; set; }
        public string OData__UIVersionString { get; set; }
        public bool Attachments { get; set; }
        public string GUID { get; set; }
    }

    public class __Metadata
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string etag { get; set; }
        public string type { get; set; }
    }

    public class Firstuniqueancestorsecurableobject
    {
        public __Deferred __deferred { get; set; }
    }

    public class __Deferred
    {
        public string uri { get; set; }
    }

    public class Roleassignments
    {
        public __Deferred1 __deferred { get; set; }
    }

    public class __Deferred1
    {
        public string uri { get; set; }
    }

    public class Attachmentfiles
    {
        public __Deferred2 __deferred { get; set; }
    }

    public class __Deferred2
    {
        public string uri { get; set; }
    }

    public class Contenttype
    {
        public __Deferred3 __deferred { get; set; }
    }

    public class __Deferred3
    {
        public string uri { get; set; }
    }

    public class Fieldvaluesashtml
    {
        public __Deferred4 __deferred { get; set; }
    }

    public class __Deferred4
    {
        public string uri { get; set; }
    }

    public class Fieldvaluesastext
    {
        public __Deferred5 __deferred { get; set; }
    }

    public class __Deferred5
    {
        public string uri { get; set; }
    }

    public class Fieldvaluesforedit
    {
        public __Deferred6 __deferred { get; set; }
    }

    public class __Deferred6
    {
        public string uri { get; set; }
    }

    public class File
    {
        public __Deferred7 __deferred { get; set; }
    }

    public class __Deferred7
    {
        public string uri { get; set; }
    }

    public class Folder
    {
        public __Deferred8 __deferred { get; set; }
    }

    public class __Deferred8
    {
        public string uri { get; set; }
    }

    public class Parentlist
    {
        public __Deferred9 __deferred { get; set; }
    }

    public class __Deferred9
    {
        public string uri { get; set; }
    }
}

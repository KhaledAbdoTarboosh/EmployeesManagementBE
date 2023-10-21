namespace FastDeliveryBE.Const
{
    public static class Routing
    {
        //-------------------------------Attachments----------------------------------------
        public const string Attachment_apiController = "api/attachments";
        public const string Attachment_AddAttachment = "add-attachment";
        public const string Attachment_AttachmentURL = "add-attachment-return-url";
        public const string Attachment_AddAttachments = "add-attachments";
        public const string Attachment_GetAttachmentsForRequest = "get-request-attachments";
        public const string Attachment_UpdateAttachmentsRequest = "update-attachments-request";
        public const string Attachment_DeleteAttachments = "delete-attachments";
        public const string Attachment_DeleteAttachment = "delete-attachment";
        public const string Attachment_GetAttachmentsForRequestByHeaderID = "get-attachment-by-id";
        public const string Attachment_GetMainAttachmentForRequest = "get-main-attachment-for-request";
        public const string Attachment_GetFile = "get-file";
        public const string Attachment_RMAttachmentURL = "RMAttatchment";
        public const string Attachment_GetFileWithoutToken = "getFile";
        //---------------------------------------------------------------------------------

        //-------------------------------Services----------------------------------------
        public const string Services_apiController = "api/Services";
        public const string Services_GetAllServices = "get-all-services";
        public const string Services_GetServiceByID = "get-service-by-id";
        public const string Services_GetServiceByFolderName = "get-service-by-foldername";
        public const string Services_AddService = "add-service";

        //---------------------------------------------------------------------------------
    }
}

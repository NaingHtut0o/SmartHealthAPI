using System.Net.Mail;
using Microsoft.AspNetCore.Http;

namespace SmartHealthAPI.Utilities
{
    public static class Message
    {
        // Errors
        public const string ErrMsgEmailFormat = "Isn't In Correct Email Format. ";
        public const string ErrMsgPswdNotMatch = "Passwords Do Not Match. ";
        public const string ErrMsgAdd = "Error While Inserting. ";
        public const string ErrMsgUpt = "Error While Updating. ";
        public const string ErrMsgRead = "Error While Retriving Data. ";
        public const string ErrMsgReq = "Request Data Cannot Be Null. ";
        public const string ErrMsgAuth = "Incorrect Password. ";
        public const string ErrMsgDel = "Error While Deleting. ";
        public const string ErrMsgDup = "Already Exist. ";

        // Not Found
        public const string NotFoundMsg = "Not Found. ";
        public const string NotFoundData = "Do Not Have Data With Provided ID. ";
        public const string NotFoundUser = "Do Not Have User With Provided Email. ";

        // Successes
        public const string SucMsgAdd = "Successfully Inserted New ";
        public const string SucMsgUpt = "Successfully Updated ";
        public const string SucMsgRead = "Successfully Read. ";
        public const string SucMsgLgIn = "Logged In Successfully. ";
        public const string SucMsgLgOut = "Logged Out Successfully. ";
        public const string SucMsgDel = "Successfully Deleted ";

        // Infomations
        public const string InfMsgRead = "Reading Data ...";
        public const string InfMsgAdd = "Adding Data ...";
        public const string InfMsgEdt = "Editing Data ...";
        public const string InfMsgLgIn = "Logging In ...";
        public const string InfMsgLgOut = "Logging Out ...";
        public const string InfMsgUser = "Retriving Login User ...";
        public const string InfMsgDel = "Deleting Data ...";

        // Authorization
        public const string AccDenMsg = "Unauthorized Access. ";
    }
}

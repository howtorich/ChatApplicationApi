namespace SocialCommunicationModels.CommonModels
{
    /// <summary>
    /// Excution Status Enums Class.
    /// </summary>
    public class ExecutionStatusEnums
    {
        /// <summary>
        /// Chat Excution Status Enum.
        /// </summary>
        public enum ExecutionStatus
        {
            /// <summary>
            /// No Content type.
            /// </summary>
            NoContent = 1001,

            /// <summary>
            /// Api Excution Error.
            /// </summary>
            ExecutionError = 1002,

            /// <summary>
            /// Success Status.
            /// </summary>
            Success = 1003,

            /// <summary>
            /// Failed Sttus.
            /// </summary>
            Failed = 1004,

            /// <summary>
            /// Validation Success.
            /// </summary>
            ValidationSuccess = 1005,

            /// <summary>
            /// Validation Failed.
            /// </summary>
            ValidationFailed = 1006,

            /// <summary>
            /// No Such Api Action Type Status.
            /// </summary>
            NoSuchAction = 1007,

            /// <summary>
            /// Api Action type Required.
            /// </summary>
            ActionTypeRequired = 1008,

            /// <summary>
            /// Un Authorized Access Denied Status Type.
            /// </summary>
            UnAuthorized = 1009,


            // **************  Register Status  *********************
            /// <summary>
            /// User Does not Exist.
            /// </summary>
            UserDoesnotExist = 101,

            /// <summary>
            /// User Name Does Not Allowed Spaces status Type.
            /// </summary>
            UserNameDoesnotAllowSpaces = 102,

            /// <summary>
            /// User Name Does Not Allow Special Symbols status Type.
            /// </summary>
            UserNameDoesnotAllowSpecialSymbols = 103,


            // **************   Adding Frined Status    **************************
            /// <summary>
            /// Provide user Id Status Type.
            /// </summary>
            ProvideUserId = 121,

            /// <summary>
            /// Provide Friend id Status Type.
            /// </summary>
            ProvideFriendUserId = 122,

            /// <summary>
            /// User Cannot Add Themselves Status Type.
            /// </summary>
            UserCannotAddThemSelves = 123,

            /// <summary>
            /// Adding Exists User Sttus Type.
            /// </summary>
            AddingExistsUser = 124,


            /// <summary>
            /// Conversation Does not exist status type.
            /// </summary>
            ConversationDoesnotExist = 141

        }

        /// <summary>
        /// Api Functional Excution Status
        /// </summary>
        /// <seealso cref="ExecutionStatus"/>
        public ExecutionStatus ExecutionalStatus { get; set; }

        /// <summary>
        /// Excutional Status Message. Based on Excutional Status.
        /// </summary>
        /// <seealso cref="ExecutionalStatus"/>
        public string ExecutionalStatusMessage
        {
            get
            {
                return ExecutionStatusMessage(ExecutionalStatus);
            }
        }

        /// <summary>
        /// Api Error Message.
        /// </summary>
        public string ErrorMessage;

        /// <summary>
        /// Api Inner Execption.
        /// </summary>
        public string InnerException;

        /// <summary>
        /// Api Exception StackTrace.
        /// </summary>
        public string StackTrace;

        private string ExecutionStatusMessage(ExecutionStatus ExecutionEnum)
        {
            string ExecutionalMessage;
            switch (ExecutionEnum)
            {
                case ExecutionStatus.NoContent:
                    ExecutionalMessage = "No Content";
                    break;
                case ExecutionStatus.ExecutionError:
                    ExecutionalMessage = "Executional Error";
                    break;
                case ExecutionStatus.Success:
                    ExecutionalMessage = "Success";
                    break;
                case ExecutionStatus.Failed:
                    ExecutionalMessage = "Failed";
                    break;
                case ExecutionStatus.ValidationSuccess:
                    ExecutionalMessage = "Validation Success";
                    break;
                case ExecutionStatus.ValidationFailed:
                    ExecutionalMessage = "Validation Failed";
                    break;
                case ExecutionStatus.NoSuchAction:
                    ExecutionalMessage = "No Such Action type!...";
                    break;
                case ExecutionStatus.ActionTypeRequired:
                    ExecutionalMessage = "Action type Required...";
                    break;
                case ExecutionStatus.UnAuthorized:
                    ExecutionalMessage = "UnAuthorized! Access denied...";
                    break;

                // Register Status.
                case ExecutionStatus.UserDoesnotExist:
                    ExecutionalMessage = "User does not exist.";
                    break;
                case ExecutionStatus.UserNameDoesnotAllowSpaces:
                    ExecutionalMessage = "Username does not allow Spaces.";
                    break;
                case ExecutionStatus.UserNameDoesnotAllowSpecialSymbols:
                    ExecutionalMessage = "Username does not allow Special Symbols.";
                    break;

                // Adding Friends Status
                case ExecutionStatus.ProvideUserId:
                    ExecutionalMessage = "Provide UserId.";
                    break;
                case ExecutionStatus.ProvideFriendUserId:
                    ExecutionalMessage = "Provide Friend UserId.";
                    break;
                case ExecutionStatus.UserCannotAddThemSelves:
                    ExecutionalMessage = "User Cannot add themselves.";
                    break;
                case ExecutionStatus.AddingExistsUser:
                    ExecutionalMessage = "Already User Exists.";
                    break;

                // Conversation Execution Status.
                case ExecutionStatus.ConversationDoesnotExist:
                    ExecutionalMessage = "No Such Type of Conversation.";
                    break;
                default:
                    ExecutionalMessage = "--- Somting went worng! ---";
                    break;
            }

            return ExecutionalMessage;
        }
    }
}

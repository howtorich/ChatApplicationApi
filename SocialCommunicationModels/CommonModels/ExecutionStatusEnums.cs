namespace SocialCommunicationModels.CommonModels
{
    public class ExecutionStatusEnums
    {
        public enum ExecutionStatus
        {
            NoContent = 1001,

            ExecutionError = 1002,

            Success = 1003,

            Failed = 1004,

            ValidationSuccess = 1005,

            ValidationFailed = 1006,

            NoSuchAction = 1007,

            ActionTypeRequired = 1008,

            UnAuthorized = 1009,


            // Register Status
            UserDoesnotExist = 101,

            UserNameDoesnotAllowSpaces = 102,

            UserNameDoesnotAllowSpecialSymbols = 103,


            // Adding Frined Status
            ProvideUserId = 121,

            ProvideFriendUserId = 122,

            UserCannotAddThemSelves = 123,

            AddingExistsUser = 124,







        }

        public ExecutionStatus ExecutionalStatus { get; set; }

        public string ExecutionalStatusMessage
        {
            get
            {
                return ExecutionStatusMessage(ExecutionalStatus);
            }
        }

        public string ErrorMessage;

        public string InnerException;

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
                default:
                    ExecutionalMessage = "--- Somting went worng! ---";
                    break;
            }

            return ExecutionalMessage;
        }
    }
}

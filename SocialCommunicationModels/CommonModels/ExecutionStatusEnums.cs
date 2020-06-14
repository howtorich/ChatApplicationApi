namespace SocialCommunicationModels.CommonModels
{
    public class ExecutionStatusEnums
    {
        public enum ExecutionStatus
        {
            NoContent = 1001,

            ExecutionError = 1002,

            Success = 1003,

            Failed = 1004
        }

        public ExecutionStatus ExecutionalStatus { private get; set; }

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
                default:
                    ExecutionalMessage = "--- Somting went worng! ---";
                    break;
            }

            return ExecutionalMessage;
        }
    }
}

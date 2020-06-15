using SocialCommunicationDA.SqlServerLogic.ChatLogic;
using SocialCommunicationModels.ChatInputAndOutputModels;
using SocialCommunicationModels.CommonModels;

namespace SocialCommunicationsBL.BusinessLogic.ChatLogic
{
    public class GetChatRegisteredUsers
    {
        public OutputModel ChatRegisteredUsersGet(InputModel inputModel)
        {
            OutputModel outputModel;

            GetChatRegisteredUsersDL getChatRegisteredUsersDL = new GetChatRegisteredUsersDL();

            outputModel = getChatRegisteredUsersDL.ChatRegisteredUsersGet(inputModel);

            if (outputModel?.ChatRegisteredUsers.Count > 0 || outputModel?.responseModel?.ExecutionStatus == 1)
            {
                outputModel.ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Success;
            }
            else
            {
                outputModel.ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Failed;
            }

            return outputModel;
        }
    }
}

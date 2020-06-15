namespace SocialCommunicationsBL.BusinessLogic.ChatLogic
{
    using SocialCommunicationDA.SqlServerLogic.ChatLogic;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.CommonModels;

    public class GetChatRegisteredUserFriends
    {
        public OutputModel ChatRegisteredUserFriends(InputModel inputModel)
        {
            OutputModel outputModel;

            GetChatRegisteredUserFriendsDL getChatRegisteredUserFriendsDL = new GetChatRegisteredUserFriendsDL();

            outputModel = getChatRegisteredUserFriendsDL.ChatRegisteredUserFriends(inputModel);

            if (outputModel?.ChatRegisteredUserFriends.Count > 0 || outputModel?.responseModel?.ExecutionStatus == 1)
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

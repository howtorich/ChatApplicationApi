using SocialCommunicationDA.SqlServerLogic.ChatLogic;
using SocialCommunicationModels.ChatInputAndOutputModels;
using SocialCommunicationModels.CommonModels;

namespace SocialCommunicationsBL.BusinessLogic.ChatLogic
{
    /// <summary>
    /// Get Chat Registered Users List (Global Chat users list).
    /// </summary>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers"/>
    internal class GetChatRegisteredUsers
    {
        /// <summary>
        /// Get Chat Registered User List Golbal Chat Users List.
        /// </summary>
        /// <param name="inputModel" cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel">Chat Common Input Model.</param>
        /// <returns cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers">Chat Common output Model.</returns>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers"/>
        internal OutputModel ChatRegisteredUsersGet(InputModel inputModel)
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

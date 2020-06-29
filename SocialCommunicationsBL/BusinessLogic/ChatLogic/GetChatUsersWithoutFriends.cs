namespace SocialCommunicationsBL.BusinessLogic.ChatLogic
{
    using SocialCommunicationDA.SqlServerLogic.ChatLogic;
    using SocialCommunicationModels.ChatInputAndOutputModels;

    /// <summary>
    /// Get Chat Users Without Frineds of Particular User.
    /// </summary>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers"/>
    internal class GetChatUsersWithoutFriends
    {
        /// <summary>
        /// Chat User Without Friends of Particular User.
        /// </summary>
        /// <param name="inputModel" cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel">Chat Common Input Model.</param>
        /// <returns cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers">Chat Common Output Model.</returns>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers"/>
        internal OutputModel ChatUsersWithoutFriendsGet(InputModel inputModel)
        {
            OutputModel outputModel;

            GetChatUsersWithoutFriendsDL getChatUsersWithoutFriendsDL = new GetChatUsersWithoutFriendsDL();

            outputModel = getChatUsersWithoutFriendsDL.ChatUsersWithoutFriendsGet(inputModel);

            if (outputModel?.Friends?.Count > 0 || outputModel.responseModel.ExecutionStatus == 1)
            {
                outputModel.ExecutionalStatus = SocialCommunicationModels.CommonModels.ExecutionStatusEnums.ExecutionStatus.Success;
            }
            else
            {
                outputModel.ExecutionalStatus = SocialCommunicationModels.CommonModels.ExecutionStatusEnums.ExecutionStatus.Failed;
            }

            return outputModel;
        }


    }
}

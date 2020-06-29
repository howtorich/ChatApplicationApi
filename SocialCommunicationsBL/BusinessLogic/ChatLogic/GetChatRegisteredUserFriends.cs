namespace SocialCommunicationsBL.BusinessLogic.ChatLogic
{
    using SocialCommunicationDA.SqlServerLogic.ChatLogic;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.CommonModels;

    /// <summary>
    /// Get Char Registered User Friends List.
    /// </summary>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.Friends"/>
    internal class GetChatRegisteredUserFriends
    {
        /// <summary>
        /// Chat Registratered User Friends List Get.
        /// </summary>
        /// <param name="inputModel" cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel">Chat Common Input Model.</param>
        /// <returns cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.Friends">Chat Common Output Model.</returns>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.Friends"/>
        /// <remarks>End Point Sample Json: </remarks>
        internal OutputModel ChatRegisteredUserFriends(InputModel inputModel)
        {
            OutputModel outputModel;

            GetChatRegisteredUserFriendsDL getChatRegisteredUserFriendsDL = new GetChatRegisteredUserFriendsDL();

            outputModel = getChatRegisteredUserFriendsDL.ChatRegisteredUserFriends(inputModel);

            if (outputModel?.Friends.Count > 0 || outputModel?.responseModel?.ExecutionStatus == 1)
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

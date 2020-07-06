namespace SocialCommunicationsBL.BusinessLogic.ChatLogic
{
    using SocialCommunicationDA.SqlServerLogic.ChatLogic;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.CommonModels;

    /// <summary>
    /// Get Conversation Info BLL Class.
    /// </summary>
    /// <seealso cref="InputModel.chatConversationModel"/>
    /// <seealso cref="OutputModel.chatConversationModel"/>
    internal class GetChatConversationInfo
    {
        /// <summary>
        /// Get Conversation Details Method.
        /// </summary>
        /// <param name="inputModel">Chat Common Input Model.</param>
        /// <returns>Chat Common Output Model.</returns>
        /// <seealso cref="InputModel.chatConversationModel"/>
        /// <seealso cref="OutputModel.chatConversationModel"/>
        internal OutputModel GetChatConversationDetails(InputModel inputModel)
        {
            OutputModel outputModel;

            var getChatConversationInfoDL = new GetChatConversationInfoDL();

            outputModel = getChatConversationInfoDL.GetChatConversationInfo(inputModel);

            if (outputModel?.responseModel?.ExecutionStatus == 1)
            {
                if (outputModel?.chatConversationModel != null)
                {
                    outputModel.ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Success;
                }
                else
                {
                    outputModel.ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.ConversationDoesnotExist;
                }
            }
            else
            {
                outputModel.ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Failed;
            }

            return outputModel;
        }
    }
}

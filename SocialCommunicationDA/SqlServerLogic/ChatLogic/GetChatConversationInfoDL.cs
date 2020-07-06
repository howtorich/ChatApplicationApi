namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.ChatModels.ConversationModels;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Get Conversation Info DLL Class.
    /// </summary>
    /// <seealso cref="InputModel.chatConversationModel"/>
    /// <seealso cref="OutputModel.chatConversationModel"/>
    public class GetChatConversationInfoDL
    {
        /// <summary>
        /// Get Conversation Details Method.
        /// </summary>
        /// <param name="inputModel">Chat Common Input Model.</param>
        /// <returns>Chat Common Output Model.</returns>
        /// <seealso cref="InputModel.chatConversationModel"/>
        /// <seealso cref="OutputModel.chatConversationModel"/>
        public OutputModel GetChatConversationInfo(InputModel inputModel)
        {
            OutputModel outputModel;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_GetChatConversationInfo");

            command.AddParameter("@Chat_bwt", SqlDbType.VarChar, inputModel.chatConversationModel.Chat_bwt);

            command.AddCommonInputParams();

            using (IDataReader reader = command.ExecuteReader())
            {
                outputModel = new OutputModel();
                if (reader.Read())
                {
                    outputModel.chatConversationModel = new ChatConversationModel()
                    {
                        Chat_bwt = reader.GetDbValue("chat_bwt", string.Empty),
                        ConversationId = reader.GetDbValue<long>("coversation_id", 0),
                        ConversationMesgCount = reader.GetDbValue<long>("message_count", 0),
                    };
                }
            }

            outputModel.responseModel = new ResponseModel();
            command.GetCommonOutputParams(outputModel.responseModel);

            command.ConnectionDispose();

            return outputModel;
        }
    }
}

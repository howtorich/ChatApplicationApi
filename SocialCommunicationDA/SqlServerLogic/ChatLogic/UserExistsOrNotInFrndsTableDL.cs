namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// User Existe or not in Chat table in Db. DLL Class.
    /// </summary>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.addFriend"/>
    /// <seealso cref="CommonLibary.CommonModels.ResponseModel"/>
    public class UserExistsOrNotInFrndsTableDL
    {
        /// <summary>
        /// User Exists in Chat Table or no. DLL Member.
        /// </summary>
        /// <param name="inputModel" cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.addFriend">Chat Common Input Model.</param>
        /// <returns cref="CommonLibary.CommonModels.ResponseModel">Common Response Model.</returns>
        public ResponseModel UserExistsOrNotInFrndsTable(InputModel inputModel)
        {
            ResponseModel responseModel;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_UserExistsOrNotInFrndsTable");

            command.AddParameter("@UserID", SqlDbType.Int, inputModel.addFriend.UserId.ToString());

            command.AddParameter("@AddingUserId", SqlDbType.Int, inputModel.addFriend.AddingFriendUserId.ToString());

            command.AddParameter("@Exists", SqlDbType.Bit, false.ToString(), ParameterDirection.Output);

            command.AddCommonInputParams();

            command.ExecuteNonQuery();

            responseModel = new ResponseModel();
            responseModel.ResponseData = command.GetOutputParam("@Exists", false);

            command.GetCommonOutputParams(responseModel);

            command.Connection.Close();

            return responseModel;
        }
    }
}

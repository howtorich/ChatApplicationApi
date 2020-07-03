namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Get User Friends Column Data. DLL
    /// </summary>
    /// <seealso cref="InputModel"/>
    /// <seealso cref="ResponseModel"/>
    public class GetUserFriendsColunmDataDL
    {
        /// <summary>
        /// Get users Friends Colunm Data. DLL Memnber.
        /// </summary>
        /// <param name="inputModel" cref="InputModel">Chat Common input Model.</param>
        /// <returns cref="ResponseModel">Common Response Model.</returns>
        public ResponseModel GetUserFriendsColunmData(InputModel inputModel)
        {
            ResponseModel response;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_GetUserFriendsColunmData");

            command.AddParameter("@UserID", SqlDbType.Int, inputModel.addFriend.UserId.ToString());

            command.AddParameter("@UserFrinedsColData", SqlDbType.VarChar, null,2048, ParameterDirection.Output);

            command.AddCommonInputParams();

            command.ExecuteNonQuery();

            response = new ResponseModel();
            response.ResponseData = command.GetOutputParam("@UserFrinedsColData", string.Empty);

            command.GetCommonOutputParams(response);

            command.Connection.Close();

            return response;
        }
    }
}

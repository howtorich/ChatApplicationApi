namespace SocialCommunicationsBL.BusinessLogic
{
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.CommonModels;
    using SocialCommunicationsBL.BusinessLogic.ChatLogic;
    using System.Threading.Tasks;

    /// <summary>
    /// Can Handle the Action Flow from the request input model ApiAction.
    /// </summary>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.ApiAction"/>
    public class ChatActionFlowBl
    {
        /// <summary>
        /// Handle the Action Based on the input Model Api Action type.
        /// Conrtoll Flow can divert based on respective Api Action.
        /// </summary>
        /// <param name="inputModel">Chat Common Input Model.</param>
        /// <returns>Chat Common Ouput Model.</returns>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.ApiAction"/>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel"/>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel"/>
        public async Task<OutputModel> ChatApiActionFlow(InputModel inputModel)
        {
            OutputModel outputModel;

            if (inputModel?.ApiAction == null)
            {
                return new OutputModel()
                {
                    ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.ActionTypeRequired,
                };
            }

            switch (inputModel.ApiAction)
            {
                case ChatApiActionEnums.ChatApiActions.Registration:
                    // Test Input Json  : {"ApiAction":100,"chatRegisterUserModel":{"UserName":"pavan@somineni99"}}
                    // Test Output Json : {"chatRegisterUserOutput":{"userName":"pavan@somineni99","userId":23},"chatRegisteredUsers":null,"chatRegisteredUserFriends":null,"responseModel":{"executionStatus":1,"errorStatus":0,"errorMessage":""},"errorMessage":null,"innerException":null,"stackTrace":null,"executionalStatus":1003,"executionalStatusMessage":"Success"}

                    ChatUserRegistration chatUserRegistration = new ChatUserRegistration();
                    outputModel = chatUserRegistration.UserRegistration(inputModel);

                    break;
                case ChatApiActionEnums.ChatApiActions.GetGolbalChatUsersList:
                    // Test Input Json  : {"ApiAction":101,"chatRegisterUserModel":{}}
                    // Test Output Json : {"chatRegisterUserOutput":null,"chatRegisteredUsers":[{"userName":"pavanSomineni","userId":1},{"userName":"Satya","userId":3},{"userName":"Vijay","userId":4},{"userName":"PDV Sai Krish","userId":5},{"userName":"Pdvs","userId":6},{"userName":"Pdvs Krishna","userId":7},{"userName":"pavan Krishna","userId":8},{"userName":"sassss","userId":9},{"userName":"pavanKrishna","userId":10},{"userName":"pavanKrishna2","userId":11},{"userName":"pavanKrishna3","userId":12},{"userName":"pavanKrishna4","userId":16},{"userName":"pavansomineni9","userId":17},{"userName":"pavanKrishna11","userId":20},{"userName":"pavansomineni19","userId":21},{"userName":"pavansomineni99","userId":22},{"userName":"pavan@somineni99","userId":23}],"chatRegisteredUserFriends":null,"responseModel":null,"errorMessage":null,"innerException":null,"stackTrace":null,"executionalStatus":1003,"executionalStatusMessage":"Success"}

                    GetChatRegisteredUsers getChatRegisteredUsers = new GetChatRegisteredUsers();

                    outputModel = getChatRegisteredUsers.ChatRegisteredUsersGet(inputModel);

                    break;
                case ChatApiActionEnums.ChatApiActions.GetUserFriendsList:
                    // Test Input Json  : {"ApiAction":102,"chatRegisterUserModel":{"UserId":1}}
                    // Test Output Json : {"chatRegisterUserOutput":null,"chatRegisteredUsers":null,"chatRegisteredUserFriends":[{"userName":"Satya","userId":3},{"userName":"Vijay","userId":4}],"responseModel":null,"errorMessage":null,"innerException":null,"stackTrace":null,"executionalStatus":1003,"executionalStatusMessage":"Success"}

                    GetChatRegisteredUserFriends getChatRegisteredUserFriends = new GetChatRegisteredUserFriends();

                    outputModel = getChatRegisteredUserFriends.ChatRegisteredUserFriends(inputModel);

                    break;

                case ChatApiActionEnums.ChatApiActions.GetUsersWithoutFriends:
                    // Test Input Json  : {"ApiAction":102,"chatRegisterUserModel":{"UserId":1}}
                    // Test Output Json : {"chatRegisterUserOutput":null,"chatRegisteredUsers":null,"chatRegisteredUserFriends":[{"userName":"Satya","userId":3},{"userName":"Vijay","userId":4}],"responseModel":null,"errorMessage":null,"innerException":null,"stackTrace":null,"executionalStatus":1003,"executionalStatusMessage":"Success"}

                    GetChatUsersWithoutFriends getChatUsersWithoutFriends = new GetChatUsersWithoutFriends();

                    outputModel = getChatUsersWithoutFriends.ChatUsersWithoutFriendsGet(inputModel);

                    break;

                case ChatApiActionEnums.ChatApiActions.AddFriend:
                    // Test Input Json  : {"ApiAction":104,"addFriend":{"UserId":70,"AddingFriendUserId":23}}
                    // Test Output Json : {"responseModel":{"executionStatus":1,"errorStatus":0,"errorMessage":""},"errorMessage":null,"innerException":null,"stackTrace":null,"executionalStatus":1003,"executionalStatusMessage":"Success"}

                    AddFriend addFriend = new AddFriend();

                    outputModel = addFriend.FriendAdding(inputModel);

                    break;

                default:
                    outputModel = new OutputModel()
                    {
                        ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.NoSuchAction,
                    };
                    break;
            }

            return await Task.FromResult(outputModel);
        }
    }
}

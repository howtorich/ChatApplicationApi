using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System.Threading.Tasks;

namespace SocialCommunicationModels.CommonUsage
{
    public class AwsDynamoDbCommon
    {
        public enum AwsDynamoDbTables
        {
            tbl_ChatRegistration_Users = 100,
            
        }


        public AmazonDynamoDBClient AwsConnection()
        {
            AmazonDynamoDBClient awsDynamoDbInstance = null;

            try
            {
                AwsDynamoDbKeys awsDynamoDbKeys = new AwsDynamoDbKeys();
                //  RegionEndpoint..GetBySystemName("ap-south-1")
                awsDynamoDbInstance = new AmazonDynamoDBClient(awsDynamoDbKeys.AwsDynamoDbAccessKey, awsDynamoDbKeys.AwsDynamoDbScrectKey, RegionEndpoint.APSouth1);
            }
            catch
            {

            }
            return awsDynamoDbInstance;
        }

        public async Task<Document> GetItemOnPrimaryKeyString(string primaryKey, string TableName)
        {
            AmazonDynamoDBClient awsDynamoDbInstance = AwsConnection();

            Table UserRegistrationTable = Table.LoadTable(awsDynamoDbInstance, TableName);

            return await UserRegistrationTable.GetItemAsync(primaryKey);
        }
    }
}

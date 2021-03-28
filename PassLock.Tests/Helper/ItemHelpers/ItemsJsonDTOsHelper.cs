namespace PassLock.Tests.Helper.ItemHelpers
{
    public class ItemsJsonDTOsHelper
    {
        const string LOGIN_ITEM_JSON = "{\"object\":\"item\",\"id\":\"e35b521d-57a7-400a-b242-acf800da5ef8\"," +
            "\"organizationId\":null,\"folderId\":null,\"type\":1,\"name\":\"Example Login\"," +
            "\"notes\":\"Example note\",\"favorite\":true,\"fields\":[{\"name\":\"example user defined\"," +
            "\"value\":\"example value\",\"type\":0}],\"login\":{\"uris\":[{\"match\":null," +
            "\"uri\":\"https:\\/\\/www.google.at\\/\"}],\"username\":\"exampleUser\"," +
            "\"password\":\"examplePassword\",\"totp\":null,\"passwordRevisionDate\":null}," +
            "\"collectionIds\":[],\"revisionDate\":\"2021-03-27T13:15:03.803Z\"}";

        public static string CreateItemsDTOJsonList(int count)
        {
            string json = "[";

            for (int i = 0; i < count; i++)
            {
                json += LOGIN_ITEM_JSON;

                if (i + 1 != count)
                    json += ",";
            }

            json += "]";
            return json;
        }
    }
}

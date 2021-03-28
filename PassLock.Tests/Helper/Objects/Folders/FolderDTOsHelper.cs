using PassLock.Bitwarden.Data.DTOs.Objects.Folders;

namespace PassLock.Tests.Helper.Objects.Folders
{
    public class FolderDTOsHelper
    {
        public const string ID = "e55b521d-57a7-440a-b242-acf865da5ef8";
        public const string NAME = "Example folder";

        public static BitwardenFolderDTO CreateFolderDTO()
        {
            return new BitwardenFolderDTO
            {
                Object = "folder",
                Id = ID,
                Name = NAME,
            };
        }

        public static string CreateFolderDTOJsonList(int count)
        {
            string json = "[";
            for (int i = 0; i < count; i++)
            {
                json += CreateFolderObj();
                if (i + 1 != count)
                    json += ",";
            }

            json += "]";
            return json;
        }

        private static string CreateFolderObj(string name = NAME)
        {
            return $"{{\"object\":\"folder\",\"id\":\"5f2c03e2-fe7c-438d-b9bc-accd014f732d\",\"name\":\"{name}\"}}";
        }
    }
}

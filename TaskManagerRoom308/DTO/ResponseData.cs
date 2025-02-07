using TaskManagerRoom308.DTO.GetAllUser;

namespace TaskManagerRoom308.DTO
{
    public class ResponseData<T>
    {
        public T Data { get; set; }
        public MetaDataDTO MetaData { get; set; } = new();

        public void SetValueMetaData(int totalCount, int PageSize, int pageNumber)
        {
            MetaData.PageSize = PageSize;
            MetaData.PageNumber = pageNumber;
            MetaData.TotalRow = totalCount;
            MetaData.TotalPage = (int)Math.Ceiling((double)totalCount / PageSize);
        }
    }
}
